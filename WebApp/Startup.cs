using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Hosting;
using WebApp.Config;

[assembly: OwinStartup(typeof(WebApp.Startup))]
namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IHostBufferPolicySelector), new StreamPolicySelector());

            builder.UseWebApi(config);
        }
    }
}
