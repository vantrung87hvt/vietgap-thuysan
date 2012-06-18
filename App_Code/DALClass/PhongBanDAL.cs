/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:42:06 PM
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
    public class PhongBanDAL : SqlProvider<PhongBanEntity>
    {
        static PhongBanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PhongBanEntity entity = new PhongBanEntity();
				entity.PK_iPhongBanID = int.Parse("0"+dr["PK_iPhongBanID"].ToString());
				entity.sTenPhong = dr["sTenPhong"].ToString();
				entity.sDienThoai = dr["sDienThoai"].ToString();
				entity.sFax = dr["sFax"].ToString();
                return entity;
            };
        }
        public static PhongBanEntity GetOne(int PK_iPhongBanID)
        {
            string cmdName = "spPhongBan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iPhongBanID", PK_iPhongBanID);
            PhongBanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PhongBanEntity> GetAll()
        {
            string cmdName = "spPhongBan_Get";
            return GetList(cmdName);
        }
        
        public static int Add(PhongBanEntity entity)
        {
            string cmdName = "spPhongBan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PhongBanEntity entity)
        {
            string cmdName = "spPhongBan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(int PK_iPhongBanID)
        {
            string cmdName = "spPhongBan_Delete";
            SqlParameter p = new SqlParameter("@PK_iPhongBanID", PK_iPhongBanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PhongBanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@PK_iPhongBanID", entity.PK_iPhongBanID);
			p[1] = new SqlParameter("@sTenPhong", entity.sTenPhong);
			p[2] = new SqlParameter("@sDienThoai", entity.sDienThoai);
			p[3] = new SqlParameter("@sFax", entity.sFax);
            return p;
        }
        #endregion
       
    }
}