/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:11:13 PM
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
    public class UserDAL : SqlProvider<UserEntity>
    {
        static UserDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                UserEntity entity = new UserEntity();
				entity.iUserID = Int64.Parse("0"+dr["iUserID"].ToString());
				entity.sUsername = dr["sUsername"].ToString();
				entity.sPassword = dr["sPassword"].ToString();
				entity.sEmail = dr["sEmail"].ToString();
				entity.bActive =String.IsNullOrEmpty(dr["bActive"].ToString())?false:Boolean.Parse(dr["bActive"].ToString());
				entity.tLastVisit =String.IsNullOrEmpty(dr["tLastVisit"].ToString())?DateTime.Now:DateTime.Parse(dr["tLastVisit"].ToString());
				entity.sIP = dr["sIP"].ToString();
				entity.iGroupID = Int32.Parse("0"+dr["iGroupID"].ToString());
                return entity;
            };
        }
        public static UserEntity GetOne(Int64 iUserID)
        {
            string cmdName = "spUser_GetByPK";
            SqlParameter p = new SqlParameter("@iUserID", iUserID);
            UserEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<UserEntity> GetAll()
        {
            string cmdName = "spUser_Get";
            return GetList(cmdName);
        }
        public static List<UserEntity> GetByiGroupID(Int32 iGroupID)
		{
			string cmdName = "spUser_GetByFK_iGroupID";
			SqlParameter p = new SqlParameter("@iGroupID",iGroupID);
			List<UserEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(UserEntity entity)
        {
            string cmdName = "spUser_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(UserEntity entity)
        {
            string cmdName = "spUser_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 iUserID)
        {
            string cmdName = "spUser_Delete";
            SqlParameter p = new SqlParameter("@iUserID", iUserID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(UserEntity entity)
        {
            SqlParameter[] p = new SqlParameter[8];
			p[0] = new SqlParameter("@iUserID", entity.iUserID);
			p[1] = new SqlParameter("@sUsername", entity.sUsername);
			p[2] = new SqlParameter("@sPassword", entity.sPassword);
			p[3] = new SqlParameter("@sEmail", entity.sEmail);
			p[4] = new SqlParameter("@bActive", entity.bActive);
			p[5] = new SqlParameter("@tLastVisit", entity.tLastVisit);
			p[6] = new SqlParameter("@sIP", entity.sIP);
			p[7] = new SqlParameter("@iGroupID", entity.iGroupID);
            return p;
        }
        #endregion
       
    }
}