namespace chapter2_02
{
    //thực hiện các công việc bất đồng bộ, đồng thời in thông tin liên quan đến từng tác vụ và xử lý các ngoại lệ (nếu có)
    internal class Program
    {
        static void Main()
        {
            Task[] tasks = new Task[5];
            String taskData = "hello";
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine($"Task={Task.CurrentId}, obj={taskData}," + $"threadID={Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                });
            }
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("one of more exceptions occurred :");
                foreach (var ex in ae.Flatten().InnerExceptions)
                    Console.WriteLine("{0}", ex.Message);
            }
            Console.WriteLine("status of completed tasks");
            foreach (var t in tasks)
            {
                Console.WriteLine("Task #{0}:{1}", t.Id, t.Status);
            }
        }
    }
}
