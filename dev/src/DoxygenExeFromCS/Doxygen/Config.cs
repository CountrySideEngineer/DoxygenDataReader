using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Doxygen
{
    [Serializable]
    [XmlRoot("DoxyConfig")]
    public class Config
    {
        /// <summary>
        /// Input file name of Doxygen.
        /// </summary>
        [XmlElement]
        public string Doxyfile { get; set; } = string.Empty;

        /// <summary>
        /// Doxygen exe file path.
        /// </summary>
        [XmlElement]
        public string ExePath { get; set; } = string.Empty;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// Set accessibility as protected to prohibit user to create, new, the object.   
        /// </remarks>
        protected Config() { }

        /// <summary>
        /// Returns doxygen configuration data.
        /// </summary>
        /// <returns></returns>
        internal static Config GetConfig()
        {
            string curDir = Directory.GetCurrentDirectory();
            string path = curDir + @"\DoxyConfig.xml";
            try
            {
                Config config = ReadConfig(path);

                return config;
            }
            catch (Exception)
            {
                var config = new Config()
                {
                    ExePath = @"C:\Program Files\doxygen\bin\doxygen.exe",
                    Doxyfile = "Doxyfile"
                };
                GenerateDefaultConfig(path, config);

                return config;
            }
        }

        /// <summary>
        /// Read doxygen configuration.
        /// </summary>
        /// <param name="configPath">Configuration file path.</param>
        /// <returns>Config object read from <paramref name="configPath"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        protected static Config ReadConfig(string configPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using Stream reader = new FileStream(configPath, FileMode.Open);
            var config = serializer.Deserialize(reader) ?? throw new ArgumentException();

            return (Config)config;
        }

        /// <summary>
        /// Generate configuration file includes doxygen execution with default value.
        /// </summary>
        /// <param name="configPath">File output path.</param>
        /// <param name="defaultConfig">Default configuration.</param>
        protected static void GenerateDefaultConfig(string configPath, Config defaultConfig)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using Stream writer = new FileStream(configPath, FileMode.CreateNew);
            serializer.Serialize(writer, defaultConfig);
        }
    }
}
