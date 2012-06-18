/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 10:42:01 PM
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
    public class DichvuDAL : SqlProvider<DichvuEntity>
    {
        static DichvuDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DichvuEntity entity = new DichvuEntity();
				entity.PK_iDichvuID = Int32.Parse("0"+dr["PK_iDichvuID"].ToString());
				entity.sTendichvu = dr["sTendichvu"].ToString();
				entity.sNoidung = dr["sNoidung"].ToString();
				entity.iCategoryID = Int32.Parse("0"+dr["iCategoryID"].ToString());
				entity.iTrangthai = Int16.Parse("0"+dr["iTrangthai"].ToString());
                return entity;
            };
        }
        public static DichvuEntity GetOne(Int32 PK_iDichvuID)
        {
            string cmdName = "spDichvu_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDichvuID", PK_iDichvuID);
            DichvuEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DichvuEntity> GetAll()
        {
            string cmdName = "spDichvu_Get";
            return GetList(cmdName);
        }
        
        public static int Add(DichvuEntity entity)
        {
            string cmdName = "spDichvu_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DichvuEntity entity)
        {
            string cmdName = "spDichvu_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDichvuID)
        {
            string cmdName = "spDichvu_Delete";
            SqlParameter p = new SqlParameter("@PK_iDichvuID", PK_iDichvuID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DichvuEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iDichvuID", entity.PK_iDichvuID);
			p[1] = new SqlParameter("@sTendichvu", entity.sTendichvu);
			p[2] = new SqlParameter("@sNoidung", entity.sNoidung);
			p[3] = new SqlParameter("@iCategoryID", entity.iCategoryID);
			p[4] = new SqlParameter("@iTrangthai", entity.iTrangthai);
            return p;
        }
        #endregion
       
    }
}