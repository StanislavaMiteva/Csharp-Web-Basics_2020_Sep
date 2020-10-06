using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MVCFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName]string viewPath = null)
        {
            string layout = System.IO.File.ReadAllText("Views/Shared/_Layout.html");

            string viewContent = System.IO.File.ReadAllText(
                "Views/" + 
                this.GetType().Name.Replace("Controller", string.Empty) + 
                "/" + viewPath + ".html");

            string responseHtml = layout.Replace("@RenderBody()", viewContent);

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            HttpResponse response = new HttpResponse(contentType, fileBytes);
            return response;
        }
    }
}
