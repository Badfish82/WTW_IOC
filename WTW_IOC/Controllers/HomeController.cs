using System;
using System.Text;
using System.Web.Mvc;
using WTW_IOC.Logic.Logic;

namespace WTW_IOC.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISampleLogic _sampleLogic;

        public HomeController(ISampleLogic sampleLogic)
        {
            _sampleLogic = sampleLogic;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_sampleLogic.AddMessage(1, 2));
            sb.AppendLine(_sampleLogic.SubtractMessage(10, 7));
            sb.AppendLine(_sampleLogic.MultiplyMessage(10000, 5));
            sb.AppendLine(_sampleLogic.DivideMessage(2000, 2));

            foreach(string model in _sampleLogic.LoadSampleModel())
            {
                sb.AppendLine(model);
            }            

            return Content(sb.ToString());
        }
    }
}
