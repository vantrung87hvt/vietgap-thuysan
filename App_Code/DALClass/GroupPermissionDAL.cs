/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:11:15 PM
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
    public class GroupPermissionDAL : SqlProvider<GroupPermissionEntity>
    {
        static GroupPermissionDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                GroupPermissionEntity entity = new GroupPermissionEntity();
				entity.iGroupPermissionID = Int32.Parse("0"+dr["iGroupPermissionID"].ToString());
				entity.iGroupID = Int32.Parse("0"+dr["iGroupID"].ToString());
				entity.iPermissionID = Int32.Parse("0"+dr["iPermissionID"].ToString());
				entity.sValue = dr["sValue"].ToString();
                return entity;
            };
        }
        public static GroupPermissionEntity GetOne(Int32 iGroupPermissionID)
        {
            string cmdName = "spGroupPermission_GetByPK";
            SqlParameter p = new SqlParameter("@iGroupPermissionID", iGroupPermissionID);
            GroupPermissionEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<GroupPermissionEntity> GetAll()
        {
            string cmdName = "spGroupPermission_Get";
            return GetList(cmdName);
        }
        public static List<GroupPermissionEntity> GetByiGroupID(Int32 iGroupID)
		{
			string cmdName = "spGroupPermission_GetByFK_iGroupID";
			SqlParameter p = new SqlParameter("@iGroupID",iGroupID);
			List<GroupPermissionEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(GroupPermissionEntity entity)
        {
            string cmdName = "spGroupPermission_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(GroupPermissionEntity entity)
        {
            string cmdName = "spGroupPermission_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iGroupPermissionID)
        {
            string cmdName = "spGroupPermission_Delete";
            SqlParameter p = new SqlParameter("@iGroupPermissionID", iGroupPermissionID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(GroupPermissionEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@iGroupPermissionID", entity.iGroupPermissionID);
			p[1] = new SqlParameter("@iGroupID", entity.iGroupID);
			p[2] = new SqlParameter("@iPermissionID", entity.iPermissionID);
			p[3] = new SqlParameter("@sValue", entity.sValue);
            return p;
        }
        #endregion
       
    }
}