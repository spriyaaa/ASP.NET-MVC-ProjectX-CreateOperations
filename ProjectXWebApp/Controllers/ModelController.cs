using ProjectXBL;
using ProjectXDTO;
using ProjectXWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectXWebApp.Controllers
{
    public class ModelController : Controller
    {
        ModelBL modelBLObj;
        // GET: Model
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult GetAllModels()
        {
            modelBLObj = new ModelBL();
            var resDTO = modelBLObj.GetAllModels();
            List<Models.ModelView> lstModelObj = new List<Models.ModelView>();
            foreach (var item in resDTO)
            {
                lstModelObj.Add(new Models.ModelView()
                {
                    ModelId = item.ModelId,
                    ModelName = item.ModelName

                });
            }
            return View(lstModelObj);
        }


     
     
        [HttpGet]
        public ActionResult AddNewModel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewModel(ModelView obj)
        {
            modelBLObj = new ModelBL();
            ModelDTO modelDTOObj =new ModelDTO()
            {
                ModelId=obj.ModelId,
                ModelName=obj.ModelName

            };

            var result = modelBLObj.AddNewModel(modelDTOObj);
            if (result == 1)
            {
                return RedirectToAction("GetModel");
            }
            else
            {
                return View("Error");
            }

        }

    }
}