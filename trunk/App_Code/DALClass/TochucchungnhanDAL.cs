/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/7/2012 9:05:31 AM
------------------------------------------------------*/
using INVI.DataAccess.Base;
using INVI.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;

namespace INVI.DataAccess
{    
    public class TochucchungnhanDAL : SqlProvider<TochucchungnhanEntity>
    {
        static TochucchungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                TochucchungnhanEntity entity = new TochucchungnhanEntity();
				entity.PK_iTochucchungnhanID = Int32.Parse("0"+dr["PK_iTochucchungnhanID"].ToString());
				entity.sTochucchungnhan = dr["sTochucchungnhan"].ToString();
				entity.sKytuviettat = dr["sKytuviettat"].ToString();
				entity.sDiachi = dr["sDiachi"].ToString();
				entity.FK_iQuanHuyenID = Int64.Parse("0"+dr["FK_iQuanHuyenID"].ToString());
				entity.sSodienthoai = dr["sSodienthoai"].ToString();
                try
                {
                    entity.imgLogo = (byte[])(dr["imgLogo"]);
                }
                catch { }
				entity.sFax = dr["sFax"].ToString();
				entity.sEmail = dr["sEmail"].ToString();
				entity.sSodangkykinhdoanh = dr["sSodangkykinhdoanh"].ToString();
				entity.sCoquancap = dr["sCoquancap"].ToString();
				entity.dNgaycapdangkykinhdoanh =String.IsNullOrEmpty(dr["dNgaycapdangkykinhdoanh"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaycapdangkykinhdoanh"].ToString());
				entity.sNoicapdangkykinhdoanh = dr["sNoicapdangkykinhdoanh"].ToString();
				entity.iTrangthai = Int16.Parse("0"+dr["iTrangthai"].ToString());
				entity.bDuyet =String.IsNullOrEmpty(dr["bDuyet"].ToString())?false:Boolean.Parse(dr["bDuyet"].ToString());
				entity.FK_iCoquancaptrenID = Int32.Parse("0"+dr["FK_iCoquancaptrenID"].ToString());
				entity.sMaso = dr["sMaso"].ToString();
                return entity;
            };
        }
        public static TochucchungnhanEntity GetOne(int PK_iTochucchungnhanID)
        {
            string cmdName = "spTochucchungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iTochucchungnhanID", PK_iTochucchungnhanID);
            TochucchungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<TochucchungnhanEntity> GetAll()
        {
            string cmdName = "spTochucchungnhan_Get";
            return GetList(cmdName);
        }
        public static List<TochucchungnhanEntity> GetByFK_iQuanHuyenID(Int64 FK_iQuanHuyenID)
		{
			string cmdName = "spTochucchungnhan_GetByFK_FK_iQuanHuyenID";
			SqlParameter p = new SqlParameter("@FK_iQuanHuyenID",FK_iQuanHuyenID);
			List<TochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        
        public static int Add(TochucchungnhanEntity entity)
        {
            string cmdName = "spTochucchungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(TochucchungnhanEntity entity)
        {
            string cmdName = "spTochucchungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iTochucchungnhanID)
        {
            string cmdName = "spTochucchungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iTochucchungnhanID", PK_iTochucchungnhanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(TochucchungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[17];
            p[0] = new SqlParameter("@PK_iTochucchungnhanID", entity.PK_iTochucchungnhanID);
            p[1] = new SqlParameter("@sTochucchungnhan", entity.sTochucchungnhan);
            p[2] = new SqlParameter("@sKytuviettat", entity.sKytuviettat);
            p[3] = new SqlParameter("@sDiachi", entity.sDiachi);
            p[4] = new SqlParameter("@FK_iQuanHuyenID", entity.FK_iQuanHuyenID);
            p[5] = new SqlParameter("@sSodienthoai", entity.sSodienthoai);
            p[6] = new SqlParameter("@imgLogo", entity.imgLogo);
            p[7] = new SqlParameter("@sFax", entity.sFax);
            p[8] = new SqlParameter("@sEmail", entity.sEmail);
            p[9] = new SqlParameter("@sSodangkykinhdoanh", entity.sSodangkykinhdoanh);
            p[10] = new SqlParameter("@sCoquancap", entity.sCoquancap);
            p[11] = new SqlParameter("@dNgaycapdangkykinhdoanh", entity.dNgaycapdangkykinhdoanh);
            p[12] = new SqlParameter("@sNoicapdangkykinhdoanh", entity.sNoicapdangkykinhdoanh);
            p[13] = new SqlParameter("@iTrangthai", entity.iTrangthai);
            p[14] = new SqlParameter("@bDuyet", entity.bDuyet);
            p[15] = new SqlParameter("@FK_iCoquancaptrenID", entity.FK_iCoquancaptrenID);
            p[16] = new SqlParameter("@sMaso", entity.sMaso);
            return p;
        }
        #endregion
       
    }
}