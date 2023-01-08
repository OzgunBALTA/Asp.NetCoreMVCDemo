using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.ViewComponents.Writer
{
    public class WriterFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
