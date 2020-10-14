using SUS.HTTP;
using SUS.MVCFramework.ViewEngine;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MVCFramework
{
    public abstract class Controller
    {
        private SusViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }

        public HttpRequest Request { get; set; }
        public HttpResponse View(
            object viewModel=null,
            [CallerMemberName]string viewPath = null)
        {
            string viewContent = System.IO.File.ReadAllText(
                "Views/" + 
                this.GetType().Name.Replace("Controller", string.Empty) + 
                "/" + viewPath + ".cshtml");
            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);
            
            string responseHtml = this.PutViewInLayout(viewContent, viewModel);

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

        public HttpResponse Redirect(string url)
        {
            HttpResponse response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }

        public HttpResponse Error(string errorText)
        {
            var viewContent= $"<div class=\"alert alert-danger\" role=\"alert\">{errorText}</div>";
            string responseHtml = this.PutViewInLayout(viewContent);

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            HttpResponse response = new HttpResponse("text/html", responseBodyBytes, HttpStatusCode.ServerError);
            return response;
        }
        private string PutViewInLayout(string viewContent, object viewModel = null)
        {
            string layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layout = this.viewEngine.GetHtml(layout, viewModel);
            string responseHtml = layout.Replace("____VIEW_GOES_HERE____", viewContent);
            return responseHtml;
        }
    }
}
