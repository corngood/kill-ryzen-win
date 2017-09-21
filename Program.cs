using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace kill_ryzen_win
{
    class Program
    {
        static void Main(string[] args)
        {
            var compiler = "cl";
            int? jobs = null;
            for (var i = 0; i < args.Length; ++i)
            {
                switch (args[i])
                {
                    case "-c": compiler = args[++i]; break;
                    case "-j": jobs = int.Parse(args[++i]); break;
                }
            }
            if (jobs.HasValue)
            {
                int a, b;
                System.Threading.ThreadPool.GetMinThreads(out a, out b);
                System.Threading.ThreadPool.SetMinThreads(jobs.Value, b);
            }
            Parallel.For(0, int.MaxValue, x =>
            {
                var tmp = Path.GetTempFileName();
                try
                {
                    // extra quotes due to weird cmd.exe /c quoting rules, see cmd.exe /?
                    var psi = new ProcessStartInfo("cmd.exe", $"/q/c \"\"{compiler}\" /nologo /c bzip2.c /Fo\"{tmp}\" || exit /b\"")
                    {
                        UseShellExecute = false,
                    };
                    using (var p = Process.Start(psi))
                    {
                        p.WaitForExit();
                        if (p.ExitCode != 0)
                            throw new Exception("FAIL");
                    }
                }
                finally
                {
                    File.Delete(tmp);
                }
            });
        }
    }
}
