/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/18/2012 8:29:36 PM
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
    public class FaqDAL : SqlProvider<FaqEntity>
    {
        static FaqDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                FaqEntity entity = new FaqEntity();
				entity.PK_iFaqID = Int64.Parse("0"+dr["PK_iFaqID"].ToString());
				entity.FK_iFaqCateID = Int32.Parse("0"+dr["FK_iFaqCateID"].ToString());
				entity.sQuestion = dr["sQuestion"].ToString();
				entity.dDate =String.IsNullOrEmpty(dr["dDate"].ToString())?DateTime.Now:DateTime.Parse(dr["dDate"].ToString());
				entity.iViews = Int64.Parse("0"+dr["iViews"].ToString());
				entity.FK_iUserID = Int64.Parse("0"+dr["FK_iUserID"].ToString());
                return entity;
            };
        }
        public static FaqEntity GetOne(Int64 PK_iFaqID)
        {
            string cmdName = "spFaq_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iFaqID", PK_iFaqID);
            FaqEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<FaqEntity> GetAll()
        {
            string cmdName = "spFaq_Get";
            return GetList(cmdName);
        }
        
        public static int Add(FaqEntity entity)
        {
            string cmdName = "spFaq_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(FaqEntity entity)
        {
            string cmdName = "spFaq_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iFaqID)
        {
            string cmdName = "spFaq_Delete";
            SqlParameter p = new SqlParameter("@PK_iFaqID", PK_iFaqID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(FaqEntity entity)
        {
            SqlParameter[] p = new SqlParameter[6];
			p[0] = new SqlParameter("@PK_iFaqID", entity.PK_iFaqID);
			p[1] = new SqlParameter("@FK_iFaqCateID", entity.FK_iFaqCateID);
			p[2] = new SqlParameter("@sQuestion", entity.sQuestion);
			p[3] = new SqlParameter("@dDate", entity.dDate);
			p[4] = new SqlParameter("@iViews", entity.iViews);
			p[5] = new SqlParameter("@FK_iUserID", entity.FK_iUserID);
            return p;
        }
        #endregion
       
    }
}