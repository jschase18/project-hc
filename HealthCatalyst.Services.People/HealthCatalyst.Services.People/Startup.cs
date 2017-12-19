using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(HealthCatalyst.Services.People.Startup))]

namespace HealthCatalyst.Services.People
{
    /// <summary>
    /// Startup - Defines the API pipeline
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Builds API pipeline
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // Configure Service
            var config = new HttpConfiguration();

            // Format class properties to headless camel case for the front end
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>()
                                      .First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Configure Attribute Routing
            config.MapHttpAttributeRoutes();

            // Configure CORS
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Configure Web API
            app.UseWebApi(config);
        }
    }
}
