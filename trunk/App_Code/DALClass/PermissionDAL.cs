/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:35 PM
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
    public class PermissionDAL : SqlProvider<PermissionEntity>
    {
        static PermissionDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PermissionEntity entity = new PermissionEntity();
				entity.iPermissionID = Int32.Parse("0"+dr["iPermissionID"].ToString());
				entity.sName = dr["sName"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
                return entity;
            };
        }
        public static PermissionEntity GetOne(int iPermissionID)
        {
            string cmdName = "spPermission_GetByPK";
            SqlParameter p = new SqlParameter("@iPermissionID", iPermissionID);
            PermissionEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PermissionEntity> GetAll()
        {
            string cmdName = "spPermission_Get";
            return GetList(cmdName);
        }
        
        public static int Add(PermissionEntity entity)
        {
            string cmdName = "spPermission_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PermissionEntity entity)
        {
            string cmdName = "spPermission_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iPermissionID)
        {
            string cmdName = "spPermission_Delete";
            SqlParameter p = new SqlParameter("@iPermissionID", iPermissionID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PermissionEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@iPermissionID", entity.iPermissionID);
			p[1] = new SqlParameter("@sName", entity.sName);
			p[2] = new SqlParameter("@sDesc", entity.sDesc);
            return p;
        }
        #endregion
       
    }
}