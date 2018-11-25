namespace StorageMaster
{
    using Exam_Storage_Master.Core;
    using Exam_Storage_Master.Models;
    using Exam_Storage_Master.Models.Products;
    using Exam_Storage_Master.Models.Storages;
    using Exam_Storage_Master.Models.Vehicles;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
