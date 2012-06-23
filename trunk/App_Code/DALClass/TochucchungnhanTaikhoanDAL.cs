/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/18/2012 11:24:40 AM
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
    public class TochucchungnhanTaikhoanDAL : SqlProvider<TochucchungnhanTaikhoanEntity>
    {
        static TochucchungnhanTaikhoanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                TochucchungnhanTaikhoanEntity entity = new TochucchungnhanTaikhoanEntity();
				entity.PK_iTochucchungnhanTaikhoanID = Int32.Parse("0"+dr["PK_iTochucchungnhanTaikhoanID"].ToString());
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.FK_iTaikhoanID = Int64.Parse("0"+dr["FK_iTaikhoanID"].ToString());
				entity.dNgaythuchien =String.IsNullOrEmpty(dr["dNgaythuchien"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaythuchien"].ToString());
				entity.bActive =String.IsNullOrEmpty(dr["bActive"].ToString())?false:Boolean.Parse(dr["bActive"].ToString());
                return entity;
            };
        }
        public static TochucchungnhanTaikhoanEntity GetOne(int PK_iTochucchungnhanTaikhoanID)
        {
            string cmdName = "spTochucchungnhanTaikhoan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iTochucchungnhanTaikhoanID", PK_iTochucchungnhanTaikhoanID);
            TochucchungnhanTaikhoanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<TochucchungnhanTaikhoanEntity> GetAll()
        {
            string cmdName = "spTochucchungnhanTaikhoan_Get";
            return GetList(cmdName);
        }
        public static List<TochucchungnhanTaikhoanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spTochucchungnhanTaikhoan_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<TochucchungnhanTaikhoanEntity> list = GetList(cmdName, p);
			return list;
		}public static List<TochucchungnhanTaikhoanEntity> GetByFK_iTaikhoanID(Int64 FK_iTaikhoanID)
		{
			string cmdName = "spTochucchungnhanTaikhoan_GetByFK_FK_iTaikhoanID";
			SqlParameter p = new SqlParameter("@FK_iTaikhoanID",FK_iTaikhoanID);
			List<TochucchungnhanTaikhoanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(TochucchungnhanTaikhoanEntity entity)
        {
            string cmdName = "spTochucchungnhanTaikhoan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(TochucchungnhanTaikhoanEntity entity)
        {
            string cmdName = "spTochucchungnhanTaikhoan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iTochucchungnhanTaikhoanID)
        {
            string cmdName = "spTochucchungnhanTaikhoan_Delete";
            SqlParameter p = new SqlParameter("@PK_iTochucchungnhanTaikhoanID", PK_iTochucchungnhanTaikhoanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(TochucchungnhanTaikhoanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iTochucchungnhanTaikhoanID", entity.PK_iTochucchungnhanTaikhoanID);
			p[1] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[2] = new SqlParameter("@FK_iTaikhoanID", entity.FK_iTaikhoanID);
			p[3] = new SqlParameter("@dNgaythuchien", entity.dNgaythuchien);
			p[4] = new SqlParameter("@bActive", entity.bActive);
            return p;
        }
        #endregion
       
    }
}