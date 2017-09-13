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
            Parallel.For(0, int.MaxValue, x =>
            {
                var tmp = Path.GetTempFileName();
                try
                {
                    var psi = new ProcessStartInfo("cmd.exe", $"/q/c cl /nologo /c bzip2.c /Fo\"{tmp}\" || exit /b")
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
