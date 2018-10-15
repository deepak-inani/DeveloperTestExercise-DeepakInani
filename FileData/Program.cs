using System;

namespace FileData
{
    /// <summary>
    /// Program Class -  File Data.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main Method for entry or start of Program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                ////Pass the parameter to class for execution.
                var bootstrap = new BootStrapper(args);
                //// Write the result on console... To Simplify I have added verbose.
                Console.WriteLine(bootstrap.ProcessFile());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                // Handle and Log Error to log file and console.
                Console.WriteLine("Error:" + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
