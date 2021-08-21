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
    public class CourseController : Controller
    {
        CourseBL courseBLObj;
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCourses()
        {
            courseBLObj = new CourseBL();
            var resDTO = courseBLObj.GetAllCourses();
            List<Models.CourseView> lstCourseObj = new List<Models.CourseView>();
            foreach (var item in resDTO)
            {
                lstCourseObj.Add(new Models.CourseView()
                {
                    CourseID = item.CourseID,
                    CourseTitle = item.CourseTitle,
                    NoOfHours = item.NoOfHours,
                    CourseOwner_ID = item.CourseOwner_ID

                });
            }
            return View(lstCourseObj);
        }




        [HttpGet]
        public ActionResult AddNewCourse()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddNewCourse(CourseView obj)
        {
            courseBLObj = new CourseBL();
            CourseDTO newCourseDTOObj = new CourseDTO()
            {
                CourseID = obj.CourseID,
                CourseTitle = obj.CourseTitle,
                NoOfHours = obj.NoOfHours,
                CourseOwner_ID = obj.CourseOwner_ID
            };
            var res = courseBLObj.AddNewCourse(newCourseDTOObj);
            if (res == 1)
            {
                return RedirectToAction("GetAllCourses");
            }
            else
            {
                return View("Error");
            }
        }
    }
}