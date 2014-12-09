using Linx.Operacional.Compra.BV.WebAPI.DS.Config;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Model;

namespace WebApp.Controller
{
    public class UploadController : ApiController
    {
        [HttpPost]
        [Route("excel/upload")]
        public async Task<IEnumerable<Product>> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            List<Product> result = new List<Product>();
            var provider = new MultipartFormDataMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync<MultipartFormDataMemoryStreamProvider>(provider);

            provider.Files.ForEach(async file => 
            {
                Stream stream = await file.ReadAsStreamAsync();
                List<Product> products = Excel.Generic.Reader.Read<Product>(stream);
                result.AddRange(products);
            });

            return result;
        }

        [HttpGet]
        [Route("hello")]
        public string Hello()
        {
            return "hello";
        }
    }
}
