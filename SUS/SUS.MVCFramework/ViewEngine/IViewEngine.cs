namespace SUS.MVCFramework.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml(string temlateCode, object viewModel);
    }
}
