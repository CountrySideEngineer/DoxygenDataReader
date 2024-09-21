using System.Diagnostics;
using System.Reflection;

namespace Doxygen
{
    public class Runner
    {
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
