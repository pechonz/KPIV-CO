using KPIV_CO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.DirectoryServices;
using KPIV_CO.Models;

namespace KPIV_CO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult getCABINET()
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getCABINET();
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    CABINETCD = (ds.Tables[0].Rows[i].ItemArray[0].ToString()),
                    LOCATIONCD = (ds.Tables[0].Rows[i].ItemArray[1].ToString())
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getMAINITEM(string lotno)
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getMAINITEM(lotno);
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    MAINITEMCD = (ds.Tables[0].Rows[i].ItemArray[0].ToString())
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getMACHINE()
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getMACHINE();
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    MACHINENAME = (ds.Tables[0].Rows[i].ItemArray[0].ToString())
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCabinetStatus()
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getCabinetStatus();
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    SEQCD = (ds.Tables[0].Rows[i].ItemArray[0].ToString()),
                    MAINITEMCD = (ds.Tables[0].Rows[i].ItemArray[1].ToString()),
                    LOCATIONCD = (ds.Tables[0].Rows[i].ItemArray[2].ToString()),
                    MACHINENAME = (ds.Tables[0].Rows[i].ItemArray[3].ToString()),
                    RECISSUEQTY = (ds.Tables[0].Rows[i].ItemArray[4].ToString()),
                    STATUS = (ds.Tables[0].Rows[i].ItemArray[5].ToString()),
                    CABINETCD = (ds.Tables[0].Rows[i].ItemArray[6].ToString()),
                    LAYERCD = (ds.Tables[0].Rows[i].ItemArray[7].ToString()),
                    SIDECD = (ds.Tables[0].Rows[i].ItemArray[8].ToString()),
                    ITEMSIDECD = (ds.Tables[0].Rows[i].ItemArray[9].ToString()),
                    LOTNO = (ds.Tables[0].Rows[i].ItemArray[10].ToString())
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSTATUS(string lotno)
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getSTATUS(lotno);
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    SEQCD = (ds.Tables[0].Rows[i].ItemArray[0].ToString()),
                    MAINITEMCD = (ds.Tables[0].Rows[i].ItemArray[1].ToString()),
                    LOCATIONCD = (ds.Tables[0].Rows[i].ItemArray[2].ToString()),
                    MACHINENAME = (ds.Tables[0].Rows[i].ItemArray[3].ToString()),
                    RECISSUEQTY = (ds.Tables[0].Rows[i].ItemArray[4].ToString()),
                    STATUS = (ds.Tables[0].Rows[i].ItemArray[5].ToString()),
                    CABINETCD = (ds.Tables[0].Rows[i].ItemArray[6].ToString()),
                    LAYERCD = (ds.Tables[0].Rows[i].ItemArray[7].ToString()),
                    SIDECD = (ds.Tables[0].Rows[i].ItemArray[8].ToString()),
                    ITEMSIDECD = (ds.Tables[0].Rows[i].ItemArray[9].ToString()),
                    LOTNO = (ds.Tables[0].Rows[i].ItemArray[10].ToString())
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public String mergeWorkList(string machinename, string itemcd, string qty, string layer, string workstdate, string worktype, string pattern, string remark, string worker)
        {
            HomeRepository st = new HomeRepository();
            string res = st.mergeWorkList(machinename, itemcd, qty, layer, workstdate, worktype, pattern, remark, worker);
            return res;
        }

        public String mergestdCtrl(string ctrldata)
        {
            HomeRepository st = new HomeRepository();
            string res = st.mergestdCtrl(ctrldata);
            return res;
        }

        public JsonResult getEmpList()
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getEmpList();
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    WORKER = (ds.Tables[0].Rows[i].ItemArray[0].ToString())
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getWorkedList(string workstdate, string workeddate)
        {
            DataSet ds;
            HomeRepository st = new HomeRepository();
            List<HomeModels> items = new List<HomeModels>();

            ds = st.getWorkedList(workstdate, workeddate);
            int numRows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                items.Add(new HomeModels
                {
                    MACHINENAME = (ds.Tables[0].Rows[i].ItemArray[0].ToString()),
                    ITEMCD = (ds.Tables[0].Rows[i].ItemArray[1].ToString()),
                    QTY = (ds.Tables[0].Rows[i].ItemArray[2].ToString()),
                    LAYER = (ds.Tables[0].Rows[i].ItemArray[3].ToString()),
                    WORKSTDATE = (ds.Tables[0].Rows[i].ItemArray[4].ToString()),
                    WORKEDDATE = (ds.Tables[0].Rows[i].ItemArray[5].ToString()),
                    WORKTYPE = (ds.Tables[0].Rows[i].ItemArray[6].ToString()),
                    PATTERNTYPE = (ds.Tables[0].Rows[i].ItemArray[7].ToString()),
                    REMARK = (ds.Tables[0].Rows[i].ItemArray[8].ToString()),
                    WORKER = (ds.Tables[0].Rows[i].ItemArray[9].ToString()),
                    RATIO = (ds.Tables[0].Rows[i].ItemArray[10].ToString()),
                }
                );
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType,
            Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}