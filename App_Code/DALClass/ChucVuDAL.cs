/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:42:09 PM
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
    public class ChucVuDAL : SqlProvider<ChucVuEntity>
    {
        static ChucVuDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ChucVuEntity entity = new ChucVuEntity();
				entity.PK_iChucVuID = int.Parse("0"+dr["PK_iChucVuID"].ToString());
				entity.sTenChucVu = dr["sTenChucVu"].ToString();
				entity.sCongviecphutrach = dr["sCongviecphutrach"].ToString();
                return entity;
            };
        }
        public static ChucVuEntity GetOne(int PK_iChucVuID)
        {
            string cmdName = "spChucVu_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iChucVuID", PK_iChucVuID);
            ChucVuEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ChucVuEntity> GetAll()
        {
            string cmdName = "spChucVu_Get";
            return GetList(cmdName);
        }
        
        public static int Add(ChucVuEntity entity)
        {
            string cmdName = "spChucVu_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ChucVuEntity entity)
        {
            string cmdName = "spChucVu_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(int PK_iChucVuID)
        {
            string cmdName = "spChucVu_Delete";
            SqlParameter p = new SqlParameter("@PK_iChucVuID", PK_iChucVuID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ChucVuEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iChucVuID", entity.PK_iChucVuID);
			p[1] = new SqlParameter("@sTenChucVu", entity.sTenChucVu);
			p[2] = new SqlParameter("@sCongviecphutrach", entity.sCongviecphutrach);
            return p;
        }
        #endregion
       
    }
}