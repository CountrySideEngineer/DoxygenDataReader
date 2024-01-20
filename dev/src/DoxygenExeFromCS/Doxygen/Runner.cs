using System.Diagnostics;
using System.Reflection;

namespace Doxygen
{
    public class Runner
    {
        /// <summary>
        /// Path to doxygen executable file.
        /// </summary>
        public string Path { get; set; } = @"C:\Program Files\doxygen\bin\doxygen.exe";

        /// <summary>
        /// Path to doxygen configuration file, Doxyfile.
        /// </summary>
        public string Config { get; set; } = @"Doxyfile";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Runner() { }
        
        /// <summary>
        /// Execute
        /// </summary>
        public void Run()
        {
            var config = Doxygen.Config.GetConfig();

            var procStartInfo = new ProcessStartInfo(config.ExePath)
            {
                ArgumentList =
                {
                    config.Doxyfile
                }
            };
            Process? proc = Process.Start(procStartInfo);
            proc?.WaitForExit();
            int? code = proc?.ExitCode;
        }

    }
}
