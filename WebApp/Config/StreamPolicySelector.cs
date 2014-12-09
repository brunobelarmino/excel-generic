using Microsoft.Owin;
using System.Web.Http.WebHost;

namespace WebApp.Config
{
    public class StreamPolicySelector : WebHostBufferPolicySelector
    {
        public override bool UseBufferedInputStream(object hostContext)
        {
            var context = hostContext as OwinContext;

            if (context.Request.ContentType != null && context.Request.ContentType.Contains("multipart/form-data"))
                return false;

            return true;
        }
    }
}