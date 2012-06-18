/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/14/2012 10:49:57 AM
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
    public class DangkyHoatdongchungnhanDAL : SqlProvider<DangkyHoatdongchungnhanEntity>
    {
        static DangkyHoatdongchungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DangkyHoatdongchungnhanEntity entity = new DangkyHoatdongchungnhanEntity();
				entity.PK_iDangkyChungnhanVietGapID = Int32.Parse("0"+dr["PK_iDangkyChungnhanVietGapID"].ToString());
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.iTrangthaidangky = Int16.Parse("0"+dr["iTrangthaidangky"].ToString());
				entity.dNgaydangky =String.IsNullOrEmpty(dr["dNgaydangky"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaydangky"].ToString());
				entity.iLandangky = Int16.Parse("0"+dr["iLandangky"].ToString());
                return entity;
            };
        }
        public static DangkyHoatdongchungnhanEntity GetOne(Int32 PK_iDangkyChungnhanVietGapID)
        {
            string cmdName = "spDangkyHoatdongchungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDangkyChungnhanVietGapID", PK_iDangkyChungnhanVietGapID);
            DangkyHoatdongchungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DangkyHoatdongchungnhanEntity> GetAll()
        {
            string cmdName = "spDangkyHoatdongchungnhan_Get";
            return GetList(cmdName);
        }
        public static List<DangkyHoatdongchungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spDangkyHoatdongchungnhan_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<DangkyHoatdongchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(DangkyHoatdongchungnhanEntity entity)
        {
            string cmdName = "spDangkyHoatdongchungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DangkyHoatdongchungnhanEntity entity)
        {
            string cmdName = "spDangkyHoatdongchungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDangkyChungnhanVietGapID)
        {
            string cmdName = "spDangkyHoatdongchungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iDangkyChungnhanVietGapID", PK_iDangkyChungnhanVietGapID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DangkyHoatdongchungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iDangkyChungnhanVietGapID", entity.PK_iDangkyChungnhanVietGapID);
			p[1] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[2] = new SqlParameter("@iTrangthaidangky", entity.iTrangthaidangky);
			p[3] = new SqlParameter("@dNgaydangky", entity.dNgaydangky);
			p[4] = new SqlParameter("@iLandangky", entity.iLandangky);
            return p;
        }
        #endregion
       
    }
}