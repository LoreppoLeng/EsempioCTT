using System.Linq;
using System.Web.Mvc;
using TestCTT.DAL;
using TestCTT.Domain;
using TestCTT.Models;

namespace TestCTT.Controllers
{
    public class DataController : Controller
    {
        public JsonResult Users()
        {
            var result = MockRepository.GetAllUsers();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult User(int Id = 0)
        {
            return Json(MockRepository.GetUserById(Id), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult User(User clienteToAddOrEdit)
        {
            MockRepository.AddUser(clienteToAddOrEdit);
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public JsonResult MenuVoices()
        {
            User user = Session["user"] as User;
            if (user != null)
            {
                var voices = MockRepository.GetAllMenuVoices();
                var map = MockRepository.GetUserVoiceMapping();

                var result = voices.Where(v => map.Where(m => m.idUser == user.id).Select(m => m.idVoice).Contains(v.id));

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            Session["user"] = MockRepository.GetUserById(model.Id);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ActionResult Log()
        {
            return View();

        }

        [HttpGet]
        public ActionResult Catalogo()
        {
            return View();

        }
    }
}