using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using KPIV_CO.Models;
using System.Web.Mvc;

namespace KPIV_CO.Repository
{
    public class HomeRepository
    {
        string Sql = "";
        OracleConnection connMoat = new OracleConnection();
        DataTable dt = new DataTable();

        public DataSet getCABINET()
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();

                string Sql = "";
                Sql += " SELECT c.CABINETCD,c.LOCATIONCD from KPIV_CO_MASCABINET c ORDER BY LPAD(c.CABINETCD, 10) ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }

        public DataSet getMAINITEM(string lotno)
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();

                string Sql = "";
                Sql += " SELECT RTRIM(a.MAINITEMCD) MAINITEMCD ";
                Sql += " FROM MAS_ITEM@MOIST a, ";
                Sql += "   RTL_STOCK@MOIST b ";
                Sql += " WHERE b.ITEMCD    =a.ITEMCD ";
                Sql += " AND b.LOCATIONCD IN ('CO','CO2') ";
                Sql += " AND b.LOTNO       = '"+ lotno + "' ";
                Sql += " AND b.STOCKQTY > 0 ";
                Sql += " AND b.STOCKDIV = '1' ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }

        public DataSet getMACHINE()
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();

                string Sql = "";
                Sql += " SELECT DISTINCT(machinename) ";
                Sql += " FROM mas_machine@MOIST ";
                Sql += " WHERE opercd        IN ('320','323') ";
                Sql += " AND machinetype      = 'SGC-22SA' ";
                Sql += " AND disabledres     <> '1' ";
                Sql += " AND machinename NOT IN ";
                Sql += "   (SELECT MACHINENO ";
                Sql += "   FROM KPIV_CO_RTLRECISSRESULT A ";
                Sql += "   WHERE OPERSEQNO IN ('23','40') ";
                Sql += "   ) ";
                Sql += " ORDER BY machinename ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }

        public DataSet getCabinetStatus()
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();

                string Sql = "";
                Sql += " SELECT a.SEQCD, ";
                Sql += "   RTRIM(a.MAINITEMCD) MAINITEMCD, ";
                Sql += "   (SELECT b.NLOCATIONCD ";
                Sql += "   FROM KPIV_CO_MASOPERATIONORDER b ";
                Sql += "   WHERE b.OPERSEQNO=a.OPERSEQNO ";
                Sql += "   ) LOCATIONCD, ";
                Sql += "   a.MACHINENO, ";
                Sql += "   a.RECISSUEQTY, ";
                Sql += "   a.OPERSEQNO, ";
                Sql += "   RTRIM(a.CABINETCD) CABINETCD, ";
                Sql += "   a.LAYERCD, ";
                Sql += "   a.SIDECD, ";
                Sql += "   a.ITEMSIDECD, ";
                Sql += "   a.LOTNO ";
                Sql += " FROM ";
                Sql += "   (SELECT c.*, ";
                Sql += "     rank() over (partition BY c.LOTNO,c.SEQCD order by c.OPERSEQNO DESC) rnk ";
                Sql += "   FROM KPIV_CO_RTLRECISSRESULT c ";
                Sql += "   ) a ";
                Sql += " WHERE a.rnk      = 1 ";
                Sql += " AND a.OPERSEQNO IN ('20','28','30','37','45','47') ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }

        public DataSet getSTATUS(string lotno)
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();

                string Sql = "";
                Sql += " SELECT a.SEQCD, ";
                Sql += "   RTRIM(a.MAINITEMCD) MAINITEMCD, ";
                Sql += "   (SELECT b.NLOCATIONCD ";
                Sql += "   FROM KPIV_CO_MASOPERATIONORDER b ";
                Sql += "   WHERE b.OPERSEQNO=a.OPERSEQNO ";
                Sql += "   ) LOCATIONCD, ";
                Sql += "   a.MACHINENO, ";
                Sql += "   a.RECISSUEQTY, ";
                Sql += "   a.OPERSEQNO, ";
                Sql += "   RTRIM(a.CABINETCD) CABINETCD, ";
                Sql += "   a.LAYERCD, ";
                Sql += "   a.SIDECD, ";
                Sql += "   a.ITEMSIDECD, ";
                Sql += "   a.LOTNO ";
                Sql += " FROM ";
                Sql += "   (SELECT c.*, ";
                Sql += "     rank() over (partition BY c.LOTNO,c.SEQCD order by c.OPERSEQNO DESC) rnk ";
                Sql += "   FROM KPIV_CO_RTLRECISSRESULT c ";
                Sql += "   WHERE c.LOTNO = '"+lotno+"' ";
                Sql += "   ) a ";
                Sql += " WHERE a.rnk      = 1  ";
                Sql += " AND a.OPERSEQNO IN ('20','28','30','37','45','47')  ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }

        public String mergeWorkList(string machinename, string itemcd, string qty, string layer, string workstdate, string worktype, string pattern, string remark, string worker)
        {
            string res;
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();
                OracleTransaction transaction;
                OracleCommand command = oc.CreateCommand();
                transaction = oc.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = transaction;

                Sql += " MERGE INTO zapj_rtl_anresult e USING ( ";
                Sql += " SELECT '" + machinename + "' machinename, '" + itemcd + "' itemcd, '" + qty + "' qty, '" + layer + "' layer, (TO_DATE('" + workstdate + "', 'mm/dd/yyyy hh24:mi:ss')) workstdate, '' workeddate, '" + worktype + "' worktype, '" + pattern + "' patterntype, sysdate insdate, '" + remark + "' remark, '" + worker + "' insuserid FROM dual ";
                Sql += " ) h ";
                Sql += " ON (e.machinename = h.machinename AND e.workstdate = h.workstdate) ";
                Sql += " WHEN MATCHED THEN ";
                Sql += "   UPDATE ";
                Sql += "   SET e.itemcd    = h.itemcd, ";
                Sql += "     e.worktype    = h.worktype, ";
                Sql += "     e.patterntype = h.patterntype, ";
                Sql += "     e.upddate = sysdate, ";
                Sql += "     e.upduserid   = h.insuserid WHEN NOT MATCHED THEN ";
                Sql += "   INSERT ";
                Sql += "     ( ";
                Sql += "       machinename, ";
                Sql += "       itemcd, ";
                Sql += "       qty, ";
                Sql += "       layer, ";
                Sql += "       workstdate, ";
                Sql += "       workeddate, ";
                Sql += "       worktype, ";
                Sql += "       patterntype, ";
                Sql += "       insdate, ";
                Sql += "       insuserid, ";
                Sql += "       remark ";
                Sql += "     ) ";
                Sql += "     VALUES ";
                Sql += "     ( ";
                Sql += "       h.machinename, ";
                Sql += "       h.itemcd, ";
                Sql += "       h.qty, ";
                Sql += "       h.layer, ";
                Sql += "       h.workstdate, ";
                Sql += "       h.workeddate, ";
                Sql += "       h.worktype, ";
                Sql += "       h.patterntype, ";
                Sql += "       h.insdate, ";
                Sql += "       h.insuserid, ";
                Sql += "       h.remark ";
                Sql += "     ) ";

                try
                {
                    command.CommandText = Sql;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    res = "Updated";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    res = e.Message;
                }
                oc.Dispose();
                oc.Close();
                return res;
            }
        }

        public String mergestdCtrl(string ctrldata)
        {
            string res;
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();
                OracleTransaction transaction;
                OracleCommand command = oc.CreateCommand();
                transaction = oc.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = transaction;

                Sql += " MERGE INTO ZAPJ_MAS_ANPTN pt USING ";
                Sql += " (SELECT "+ ctrldata + " FROM dual ";
                Sql += " ) ps ON (pt.PTNCD = ps.PTNCD AND pt.STEPCD = ps.STEPCD) ";
                Sql += " WHEN MATCHED THEN ";
                Sql += "   UPDATE ";
                Sql += "   SET pt.STATECD=ps.STATECD, ";
                Sql += "     pt.CLQTY    =ps.CLQTY, ";
                Sql += "     pt.TIMESET  =ps.TIMESET, ";
                Sql += "     pt.UCLOFFSET=ps.UCLOFFSET, ";
                Sql += "     pt.LCLOFFSET=ps.LCLOFFSET, ";
                Sql += "     pt.UPDUSERID=ps.INSUSERID, ";
                Sql += "     pt.UPDDATE  = sysdate WHEN NOT MATCHED THEN ";
                Sql += "   INSERT ";
                Sql += "     ( ";
                Sql += "       pt.PTNCD, ";
                Sql += "       pt.STEPCD, ";
                Sql += "       pt.STATECD, ";
                Sql += "       pt.CLQTY, ";
                Sql += "       pt.TIMESET, ";
                Sql += "       pt.UCLOFFSET, ";
                Sql += "       pt.LCLOFFSET, ";
                Sql += "       pt.INSDATE, ";
                Sql += "       pt.INSUSERID ";
                Sql += "     ) ";
                Sql += "     VALUES ";
                Sql += "     ( ";
                Sql += "       ps.PTNCD, ";
                Sql += "       ps.STEPCD, ";
                Sql += "       ps.STATECD, ";
                Sql += "       ps.CLQTY, ";
                Sql += "       ps.TIMESET, ";
                Sql += "       ps.UCLOFFSET, ";
                Sql += "       ps.LCLOFFSET, ";
                Sql += "       sysdate, ";
                Sql += "       ps.INSUSERID ";
                Sql += "     ) ";

                try
                {
                    command.CommandText = Sql;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    res = "Updated";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    res = e.Message;
                }
                oc.Dispose();
                oc.Close();
                return res;
            }
        }

        public DataSet getEmpList()
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();
                string Sql = "";
                Sql += " SELECT RTRIM(EMPCODE) FROM TLS_VIEW_EMPMSTR WHERE EMPWORKSTATUS = 'Active' AND EMPWORKPLACE = 'GMO' AND EMPORGNAME = 'GMO-AN' ORDER BY EMPCODE DESC ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }

        public DataSet getWorkedList(string workstdate, string workeddate)
        {
            using (OracleConnection oc = new OracleConnection())
            {
                oc.ConnectionString = "User ID=moat; Password=moat; Data Source=MOAT;";
                oc.Open();
                string Sql = "";
                Sql += " SELECT MACHINENAME,ITEMCD,QTY,LAYER,WORKSTDATE,WORKEDDATE,WORKTYPE,PATTERNTYPE,REMARK,RTRIM(INSUSERID),ROUND((LAYER/(SELECT LAYERQTY FROM ZAPJ_MAS_MACHINESOURCE b WHERE b.MACHINENAME=a.MACHINENAME))*100,2) FR FROM ZAPJ_RTL_ANRESULT a WHERE WORKSTDATE BETWEEN (TO_DATE('" + workstdate + "', 'dd/mon/yyyy hh24:mi:ss')) AND (TO_DATE('" + workeddate + "', 'dd/mon/yyyy hh24:mi:ss')) AND ITEMCD <> 'T' AND WORKTYPE <> 'T' AND PATTERNTYPE <> 'T' ORDER BY MACHINENAME,ITEMCD,WORKSTDATE ";

                OracleDataAdapter oda = new OracleDataAdapter(Sql, oc);
                var dt = new DataSet();
                oda.Fill(dt);

                oc.Dispose();
                oc.Close();
                return dt;
            }
        }
    }
}