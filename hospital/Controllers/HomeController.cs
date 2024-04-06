using hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("getNews")]
        public ActionResult<List<Newsdata>> getNews()
        {
            DBconnect dbmanager = new DBconnect();
            List<Newsdata> datalist = dbmanager.GetNewsdata();
            try
            {
                Console.WriteLine("獲取新聞資訊");
                ViewBag.datalist = datalist;
                ViewBag.errmsg ="errmsg";
            }
            catch
            {
                Console.WriteLine("獲取資訊失敗");
            }
            return datalist;
        }
        //控制傳遞醫院介面之相關資料
        public ActionResult HospitalComment()
        {
            DBconnect dbmanager = new DBconnect();
            try
            {
                Console.WriteLine("獲取醫院評論資訊");
                (List<HospitalCommentdata> HospitalComment, List<HospitalINF> Hospital) = dbmanager.GetHospitalCommentdata();
                Console.WriteLine("test1");
                ViewBag.datalist = HospitalComment;
                ViewBag.Hospitaldatalist = Hospital;
                Console.WriteLine("test2");
                ViewBag.errmsg = "errmsg";
            }
            catch
            {
                Console.WriteLine("獲取醫院評論資訊失敗");
            }
            return View();
        }
        //控制傳入醫院介面之評論資料
        [HttpPost]
        public ActionResult HospitalComment(HospitalCommentdata data,string SelectResult)
        {
            DBconnect dbmanager = new DBconnect();
            Console.WriteLine(data.HospitalComment_Comment);
            Console.WriteLine(data.HospitalComment_HospitalName);
            Console.WriteLine(data.HospitalComment_Star);
            Console.WriteLine(data.HospitalComment_Positive);
            Console.WriteLine(data.HospitalComment_Name);
            Console.WriteLine(data.HospitalComment_Time);

            try
            {
                string x=dbmanager.PutHospitalCommentdata(data);
                HttpContext.Session.SetString("select", SelectResult);
                HttpContext.Session.SetInt32("star", data.HospitalComment_Star);
                TempData["select"] = HttpContext.Session.GetString("select");
                TempData["star"] = HttpContext.Session.GetInt32("star");
                Console.WriteLine(x);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("控制傳入醫院介面之評論出現問題");

            }
            return RedirectToAction() ;
        }
        public ActionResult SearchHospital(int? cityId)
        {
            DBconnect dbmanager = new DBconnect();
            try
            {
                Console.WriteLine("查詢醫院介面");
                (List<HospitalCommentdata> HospitalComment, List<HospitalINF> Hospital) = dbmanager.GetHospitalCommentdata();
                Console.WriteLine("test1");
                ViewBag.datalist = HospitalComment;
                ViewBag.Hospitaldatalist = Hospital;
                Console.WriteLine("test2");
                ViewBag.errmsg = "errmsg";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("查詢醫院介面");
            }
            return View();
        }
        public ActionResult index1()
        {
            return View();
        }
    }
}



//信件
/*
[NonAction]
protected void SendEmail(User user, EmailTemplete templete)
{
    var email = new EMailContent();
    email.System = Session["SystemTitle"] as string;
    email.Name = user.UserName;

    var content = RenderViewToString("~/Views/Email/Active.cshtml", email);
    SiteUtility.SendEmail(user.Email, email.System + "帳號啟用通知", content);
}

[NonAction]
protected string RenderViewToString(string viewName, object model)
{
    this.ViewData.Model = model;
    try
    {
        using (StringWriter sw = new StringWriter())
        {
            ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);
            ViewContext viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
            viewResult.View.Render(viewContext, sw);

            return sw.GetStringBuilder().ToString();
        }
    }
    catch (Exception ex)
    {
        return ex.ToString();
    }
}
}
*/