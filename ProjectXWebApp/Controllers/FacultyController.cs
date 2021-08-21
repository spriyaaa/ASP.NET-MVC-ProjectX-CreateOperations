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
    public class FacultyController : Controller
    {
        FacultyBL facultyBLObj;
        // GET: Faculty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllFaculties()
        {
            facultyBLObj = new FacultyBL();
            var resDTO = facultyBLObj.GetAllFaculties();
            List<Models.FacultyView> lstFacultyObj = new List<Models.FacultyView>();
            foreach (var item in resDTO)
            {
                lstFacultyObj.Add(new Models.FacultyView()
                {
                    FacultyID = item.FacultyID,
                    EmailId = item.EmailId,
                    Name = item.Name

                });
            }
            return View(lstFacultyObj);
        }




        [HttpGet]
        public ActionResult AddNewFaculty()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddNewFaculty(FacultyView obj)
        {
            facultyBLObj = new FacultyBL();
            FacultyDTO facDTOObj = new FacultyDTO()
            {
                FacultyID = obj.FacultyID,
                EmailId = obj.EmailId,
                Name = obj.Name,
            };
            var res = facultyBLObj.AddNewFaculty(facDTOObj);
            if (res == 1)
            {
                return RedirectToAction("GetFaculties");
            }
            else
            {
                return View("Error");
            }
        }
    }
}