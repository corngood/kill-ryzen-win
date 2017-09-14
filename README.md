- you can download a zip of this project [here](https://github.com/corngood/kill-ryzen-win/archive/master.zip)
- install some version of visual studio with C and C# compilers
- VS 2017 community edition works when installed with [these options](https://i.imgur.com/DQgtMqE.png)
- start VS command prompt, e.g. "x64 Native Tools Command Prompt for VS 2017"
  - you don't need to actually start the VS gui, or do any sort of login/activation

```
kill-ryzen-win>build.cmd
...
kill-ryzen-win>run.cmd
bzip2.c
bzip2.c
bzip2.c
...
[CTRL-C]
```

- multiple 'bzip2.c' prints on a single line are fine
- the whole process will stop when there's any sort of error, with output like:

```
bzip2.c

Unhandled Exception: System.AggregateException: One or more errors occurred. ---> System.Exception: FAIL
   at kill_ryzen_win.Program.<>c.<Main>b__0_0(Int32 x) in [...]\Program.cs:line 26
   at System.Threading.Tasks.Parallel.<>c__DisplayClass17_0`1.<ForWorker>b__1()
   at System.Threading.Tasks.Task.InnerInvokeWithArg(Task childTask)
   at System.Threading.Tasks.Task.<>c__DisplayClass176_0.<ExecuteSelfReplicating>b__0(Object )
   --- End of inner exception stack trace ---
   at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
   at System.Threading.Tasks.Task.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
   at System.Threading.Tasks.Parallel.ForWorker[TLocal](Int32 fromInclusive, Int32 toExclusive, ParallelOptions parallelOptions, Action`1 body, Action`2 bodyWithState, Func`4 bodyWithLocal, Func`1 localInit, Action`1 localFinally)
   at System.Threading.Tasks.Parallel.For(Int32 fromInclusive, Int32 toExclusive, Action`1 body)
   at kill_ryzen_win.Program.Main(String[] args) in C:\Users\davidm\Downloads\kill-ryzen-win-master\Program.cs:line 34

kill-ryzen-win>
```

- when cmd.exe crashes you may see JIT debugger popups [like this](https://i.imgur.com/EBT7GhF.png)
  - this is probably the crash described in https://github.com/corngood/kill-ryzen-win/issues/1, and indicates a hardware problem
  - you'll need to close all the JIT popups before kill-ryzen-win will print an error and exit
- you may see internal compiler error prints in the output before a failure
  - this indicates a hardware problem
  - TODO: get an example snippet
- you may see internal compiler errors when pressing ctrl-c
  - this is normal
  

