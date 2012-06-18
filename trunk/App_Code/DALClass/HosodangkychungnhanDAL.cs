/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/6/2012 10:05:53 AM
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
    public class HosodangkychungnhanDAL : SqlProvider<HosodangkychungnhanEntity>
    {
        static HosodangkychungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                HosodangkychungnhanEntity entity = new HosodangkychungnhanEntity();
				entity.PK_iHosodangkychungnhanID = Int64.Parse("0"+dr["PK_iHosodangkychungnhanID"].ToString());
				entity.dNgaydangky =String.IsNullOrEmpty(dr["dNgaydangky"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaydangky"].ToString());
				entity.FK_iCosonuoiID = Int64.Parse("0"+dr["FK_iCosonuoiID"].ToString());
				entity.bLandau =String.IsNullOrEmpty(dr["bLandau"].ToString())?false:Boolean.Parse(dr["bLandau"].ToString());
				entity.iTrangthai = Int16.Parse("0"+dr["iTrangthai"].ToString());
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
                return entity;
            };
        }
        public static HosodangkychungnhanEntity GetOne(Int64 PK_iHosodangkychungnhanID)
        {
            string cmdName = "spHosodangkychungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iHosodangkychungnhanID", PK_iHosodangkychungnhanID);
            HosodangkychungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<HosodangkychungnhanEntity> GetAll()
        {
            string cmdName = "spHosodangkychungnhan_Get";
            return GetList(cmdName);
        }
        public static List<HosodangkychungnhanEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			string cmdName = "spHosodangkychungnhan_GetByFK_FK_iCosonuoiID";
			SqlParameter p = new SqlParameter("@FK_iCosonuoiID",FK_iCosonuoiID);
			List<HosodangkychungnhanEntity> list = GetList(cmdName, p);
			return list;
		}public static List<HosodangkychungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spHosodangkychungnhan_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<HosodangkychungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(HosodangkychungnhanEntity entity)
        {
            string cmdName = "spHosodangkychungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(HosodangkychungnhanEntity entity)
        {
            string cmdName = "spHosodangkychungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iHosodangkychungnhanID)
        {
            string cmdName = "spHosodangkychungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iHosodangkychungnhanID", PK_iHosodangkychungnhanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(HosodangkychungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[6];
			p[0] = new SqlParameter("@PK_iHosodangkychungnhanID", entity.PK_iHosodangkychungnhanID);
			p[1] = new SqlParameter("@dNgaydangky", entity.dNgaydangky);
			p[2] = new SqlParameter("@FK_iCosonuoiID", entity.FK_iCosonuoiID);
			p[3] = new SqlParameter("@bLandau", entity.bLandau);
			p[4] = new SqlParameter("@iTrangthai", entity.iTrangthai);
			p[5] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
            return p;
        }
        #endregion
       
    }
}