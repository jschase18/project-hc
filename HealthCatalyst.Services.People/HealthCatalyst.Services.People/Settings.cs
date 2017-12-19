using System.Configuration;

namespace HealthCatalyst.Services.People
{
    /// <summary>
    /// Service Configuration Settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static Settings _settings;

        /// <summary>
        /// Default Constructor
        /// </summary>
        private Settings()
        {
        }

        /// <summary>
        /// Singleton Instance access
        /// </summary>
        public static Settings Instance
        {
            get
            {
                if(_settings == null)
                {
                    _settings = new Settings
                    {
                        ConnectionString = ConfigurationManager.ConnectionStrings["PeopleContext"].ConnectionString,
                        EnableLatencySimulation = bool.Parse(ConfigurationManager.AppSettings["EnableLatencySimulation"])

                    };
                }

                return _settings;
            }
        }
        
        /// <summary>
        /// Connection string for People database
        /// </summary>
        public string ConnectionString { get; set; }
        
        /// <summary>
        /// Enable Latency Simulation
        /// </summary>
        public bool EnableLatencySimulation { get; set; }
    }
}
