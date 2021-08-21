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
    public class GraderController : Controller
    {
        GraderBL graderBLObj;
        // GET: Grader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllGrader()
        {
            graderBLObj = new GraderBL();
            var resultDTO = graderBLObj.GetAllGraders();

            List<Models.GraderView> lstDeptObj = new List<Models.GraderView>();
            foreach (var item in resultDTO)
            {
                lstDeptObj.Add(new Models.GraderView()
                {
                    FacultyId = item.FacultyId,
                    CourseId = item.CourseId,
                    ParticipantId = item.ParticipantId,
                    TotalMarks = item.TotalMarks,
                    AreaOfImprovement = item.AreaOfImprovement,
                    AreaOfExcellence=item.AreaOfExcellence
                });

            }
            return View(resultDTO);
        }




        [HttpGet]
        public ActionResult AddNewGrader()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddNewGrader(GraderView obj)
        {
            graderBLObj = new GraderBL();
            GraderDTO graderDTOObj = new GraderDTO()
            {
                FacultyId = obj.FacultyId,
                CourseId = obj.CourseId,
                ParticipantId = obj.ParticipantId,
                TotalMarks = obj.TotalMarks,
                AreaOfImprovement = obj.AreaOfImprovement,
                AreaOfExcellence = obj.AreaOfExcellence

            };
            var result = graderBLObj.AddNewGrader(graderDTOObj);
            if(result==1)
            {
                return RedirectToAction("GetAllGrader");
            }


            else
            {
                return View("Error");
            }

        }
    }
    
}