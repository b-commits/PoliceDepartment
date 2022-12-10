var wtf = await DoSomeLongAction();





Task<string> DoSomeLongAction()
{
    return new Task<string>(() =>
    {
        Task.Delay(1500);
        Console.WriteLine("FROM LONG ACTION");
        return "abc";
    });
} 