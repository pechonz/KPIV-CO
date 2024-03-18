using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPIV_CO.Models
{
    public class HomeModels
    {

        public string CABINETID { get; set; }
        public string LOCATIONCD { get; set; }

        public string MAINITEMCD { get; set; }
        public string ITEMSIDECD { get; set; }
        public string LOTNO { get; set; }

        public string MACHINENAME { get; set; }
        public string SEQCD { get; set; }
        public string RECISSUEQTY { get; set; }
        public string STATUS { get; set; }
        public string CABINETCD { get; set; }
        public string LAYERCD { get; set; }
        public string SIDECD { get; set; }

        public string CREATEDATE { get; set; }
        public string STARTCD { get; set; }
        public string TOPQTY { get; set; }
        public string CENQTY { get; set; }
        public string BOTQTY { get; set; }

        public string WORKSTDATE { get; set; }
        public string WORKEDDATE { get; set; }
        public string WORKER { get; set; }
        public string ITEMCD { get; set; }
        public string QTY { get; set; }
        public string LAYER { get; set; }
        public string WORKTYPE { get; set; }
        public string PATTERNTYPE { get; set; }
        public string REMARK { get; set; }
        public string RATIO { get; set; }

        public string STEPCD { get; set; }
        public string STATECD { get; set; }
        public string CLQTY { get; set; }
        public string TIMESET { get; set; }
        public string UCLOFFSET { get; set; }
        public string LCLOFFSET { get; set; }

    }
}