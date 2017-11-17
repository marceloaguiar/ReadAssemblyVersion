using System;
using System.Reflection;

namespace ReadAssemblyVersion
{
    class Program
    {
        private enum ExitCode
        {
            Success = 0,
            InvalidUsage = -1
        }

        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Write("Invalid Arguments");
                return (int)ExitCode.InvalidUsage;
            }

            try
            {
                if (System.IO.File.Exists(args[0]))
                {
                    var filePath = args[0];
                    Assembly assembly = Assembly.LoadFrom(filePath);
                    Version version = assembly.GetName().Version;
                    Console.Write(version.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Error : {ex.Message}");
                return (int)ExitCode.InvalidUsage;
            }
            return (int)ExitCode.Success;
        }

    }
}