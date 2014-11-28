using MeHasVisto.Models;
using MeHasVisto.Models.Bussines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeHasVisto.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/

        /*public ActionResult Index()
        {
            var name = (string)RouteData.Values["id"];
            var model = null PetManagement.GetBYname(name);
            if(model == null)
            return RedirectToAction("NoFound");
            return View(model);
        }*/

        public FileResult DownLoadPicture()
        {
            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture, contentType);
        }

        public HttpStatusCodeResult UnanuthorizeError()
        {
            return new HttpUnauthorizedResult("Error de acceso no autorizado");
        }

        public ActionResult NotFoundError()
        {
            return HttpNotFound("Mascota No Encontrada");
        }

        public ActionResult NotFound()
        {
            //Metodo Nuevo
            ViewBag.ErrorCode = "NFE0001";
            ViewBag.Description = "La mascota no se encuentra" +
                " En la base de datos";
            //Metodo Antiguo
            /*ViewData["ErrorCode"] = "NFE0001";
            ViewData["Description"] = "La mascota no se encuentra" +
                " en la base dedatos";*/
            return View();
        }
        /*public string Index()
        {
            var id = int.Parse((string)RouteData.Values["id"]);
            id /= 2;
            var controler = (string)RouteData.Values["controler"];
            var action = (string)RouteData.Values["action"];
            return controler + "-->" + action + "-->" + id;
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if(model.PictureFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string saveFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(saveFileName);
                PetManagement.CreateThumbnail(fileName,
                    filePath, 100, 100, true);
            }
            return View(model);
        }
    }
}
