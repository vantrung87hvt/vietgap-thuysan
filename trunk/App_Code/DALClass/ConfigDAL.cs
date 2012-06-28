/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/27/2012 10:39:08 PM
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
    public class ConfigDAL : SqlProvider<ConfigEntity>
    {
        static ConfigDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ConfigEntity entity = new ConfigEntity();
				entity.iConfigID = Int32.Parse("0"+dr["iConfigID"].ToString());
				entity.sName = dr["sName"].ToString();
				entity.sValue = dr["sValue"].ToString();
                return entity;
            };
        }
        public static ConfigEntity GetOne(int iConfigID)
        {
            string cmdName = "spConfig_GetByPK";
            SqlParameter p = new SqlParameter("@iConfigID", iConfigID);
            ConfigEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ConfigEntity> GetAll()
        {
            string cmdName = "spConfig_Get";
            return GetList(cmdName);
        }
        
        public static int Add(ConfigEntity entity)
        {
            string cmdName = "spConfig_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ConfigEntity entity)
        {
            string cmdName = "spConfig_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iConfigID)
        {
            string cmdName = "spConfig_Delete";
            SqlParameter p = new SqlParameter("@iConfigID", iConfigID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ConfigEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@iConfigID", entity.iConfigID);
			p[1] = new SqlParameter("@sName", entity.sName);
			p[2] = new SqlParameter("@sValue", entity.sValue);
            return p;
        }
        #endregion
       
    }
}