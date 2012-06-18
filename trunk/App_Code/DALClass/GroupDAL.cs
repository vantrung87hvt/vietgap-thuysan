/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:11:14 PM
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
    public class GroupDAL : SqlProvider<GroupEntity>
    {
        static GroupDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                GroupEntity entity = new GroupEntity();
				entity.iGroupID = Int32.Parse("0"+dr["iGroupID"].ToString());
				entity.sName = dr["sName"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
                return entity;
            };
        }
        public static GroupEntity GetOne(Int32 iGroupID)
        {
            string cmdName = "spGroup_GetByPK";
            SqlParameter p = new SqlParameter("@iGroupID", iGroupID);
            GroupEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<GroupEntity> GetAll()
        {
            string cmdName = "spGroup_Get";
            return GetList(cmdName);
        }
        
        public static int Add(GroupEntity entity)
        {
            string cmdName = "spGroup_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(GroupEntity entity)
        {
            string cmdName = "spGroup_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iGroupID)
        {
            string cmdName = "spGroup_Delete";
            SqlParameter p = new SqlParameter("@iGroupID", iGroupID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(GroupEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@iGroupID", entity.iGroupID);
			p[1] = new SqlParameter("@sName", entity.sName);
			p[2] = new SqlParameter("@sDesc", entity.sDesc);
            return p;
        }
        #endregion
       
    }
}