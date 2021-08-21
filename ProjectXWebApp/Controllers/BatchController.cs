using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectXBL;
using ProjectXDTO;
using ProjectXWebApp.Models;

namespace ProjectXWebApp.Controllers
{
    public class BatchController : Controller
    {
        BatchBL batchBLObj;
        // GET: Batch
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetAllBatches()
        {
            batchBLObj = new BatchBL();
            var resultDTO = batchBLObj.GetAllBatches();

            List<Models.BatchView> lstDeptObj = new List<Models.BatchView>();
            foreach (var item in resultDTO)
            {
                lstDeptObj.Add(new Models.BatchView()
                {
                    BatchName = item.BatchName,
                    BatchId =item.BatchId,
                    Batch=item.Batch, 
                    NoOfStudent=item.NoOfStudent, 
                    SessionQuarter =item.SessionQuarter
                });

            }
            return View(resultDTO);
        }




        [HttpGet]
        public ActionResult AddNewBatch()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddNewBatch(BatchView obj)
        {
            batchBLObj = new BatchBL();
            BatchDTO batchDTOObj = new BatchDTO()
            {
                BatchId =obj.BatchId,
                BatchName =obj.BatchName,
                Batch =obj.Batch,
                NoOfStudent =obj.NoOfStudent,
                SessionQuarter =obj.SessionQuarter
            };
            var res = batchBLObj.AddNewBatch(batchDTOObj);
            if (res == 1)
            {
                return RedirectToAction("GetAllBatches");
            }
            else
            {
                return View("Error");
            }
        }



    }
}