/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:42:10 PM
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
    public class UContactDAL : SqlProvider<UContactEntity>
    {
        static UContactDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                UContactEntity entity = new UContactEntity();
				entity.PK_iUContactID = int.Parse("0"+dr["PK_iUContactID"].ToString());
				entity.FK_iContactID = int.Parse("0"+dr["FK_iContactID"].ToString());
				entity.sEmail = dr["sEmail"].ToString();
				entity.sTitle = dr["sTitle"].ToString();
				entity.sContent = dr["sContent"].ToString();
				entity.tDate =String.IsNullOrEmpty(dr["tDate"].ToString())?DateTime.Now:DateTime.Parse(dr["tDate"].ToString());
                return entity;
            };
        }
        public static UContactEntity GetOne(int PK_iUContactID)
        {
            string cmdName = "spUContact_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iUContactID", PK_iUContactID);
            UContactEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<UContactEntity> GetAll()
        {
            string cmdName = "spUContact_Get";
            return GetList(cmdName);
        }
        
        public static int Add(UContactEntity entity)
        {
            string cmdName = "spUContact_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(UContactEntity entity)
        {
            string cmdName = "spUContact_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(int PK_iUContactID)
        {
            string cmdName = "spUContact_Delete";
            SqlParameter p = new SqlParameter("@PK_iUContactID", PK_iUContactID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(UContactEntity entity)
        {
            SqlParameter[] p = new SqlParameter[6];
			p[0] = new SqlParameter("@PK_iUContactID", entity.PK_iUContactID);
			p[1] = new SqlParameter("@FK_iContactID", entity.FK_iContactID);
			p[2] = new SqlParameter("@sEmail", entity.sEmail);
			p[3] = new SqlParameter("@sTitle", entity.sTitle);
			p[4] = new SqlParameter("@sContent", entity.sContent);
			p[5] = new SqlParameter("@tDate", entity.tDate);
            return p;
        }
        #endregion
       
    }
}