namespace chapter2_task_demonstration_01
{
    internal class Program
    {
        static void PrintNumber(string message)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{message}:{i}");
                Thread.Sleep(1000);
            }
        }
        static void Main()
        {
            Thread.CurrentThread.Name = "main";

            Task task01 = new Task(() => PrintNumber("task 01"));
            task01.Start();

            Task task02 = Task.Run(delegate
            {
                PrintNumber("task 02");
            });

            Task task03 = new Task(new Action(() =>
            {
                PrintNumber("task 03");
            }));

            task03.Start();
            Console.WriteLine($"thread '{Thread.CurrentThread.Name}'");
            Console.ReadKey();
        }
    }
}
