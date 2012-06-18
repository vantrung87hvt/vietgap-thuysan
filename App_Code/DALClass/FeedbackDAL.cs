/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:33 PM
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
    public class FeedbackDAL : SqlProvider<FeedbackEntity>
    {
        static FeedbackDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                FeedbackEntity entity = new FeedbackEntity();
				entity.iFeedbackID = Int32.Parse("0"+dr["iFeedbackID"].ToString());
				entity.iNewsID = Int32.Parse("0"+dr["iNewsID"].ToString());
				entity.sName = dr["sName"].ToString();
				entity.sEmail = dr["sEmail"].ToString();
				entity.sTitle = dr["sTitle"].ToString();
				entity.sContent = dr["sContent"].ToString();
				entity.tDate =String.IsNullOrEmpty(dr["tDate"].ToString())?DateTime.Now:DateTime.Parse(dr["tDate"].ToString());
				entity.bVerified =String.IsNullOrEmpty(dr["bVerified"].ToString())?false:Boolean.Parse(dr["bVerified"].ToString());
                return entity;
            };
        }
        public static FeedbackEntity GetOne(int iFeedbackID)
        {
            string cmdName = "spFeedback_GetByPK";
            SqlParameter p = new SqlParameter("@iFeedbackID", iFeedbackID);
            FeedbackEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<FeedbackEntity> GetAll()
        {
            string cmdName = "spFeedback_Get";
            return GetList(cmdName);
        }
        public static List<FeedbackEntity> GetByiNewsID(Int32 iNewsID)
		{
			string cmdName = "spFeedback_GetByFK_iNewsID";
			SqlParameter p = new SqlParameter("@iNewsID",iNewsID);
			List<FeedbackEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(FeedbackEntity entity)
        {
            string cmdName = "spFeedback_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(FeedbackEntity entity)
        {
            string cmdName = "spFeedback_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iFeedbackID)
        {
            string cmdName = "spFeedback_Delete";
            SqlParameter p = new SqlParameter("@iFeedbackID", iFeedbackID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(FeedbackEntity entity)
        {
            SqlParameter[] p = new SqlParameter[8];
			p[0] = new SqlParameter("@iFeedbackID", entity.iFeedbackID);
			p[1] = new SqlParameter("@iNewsID", entity.iNewsID);
			p[2] = new SqlParameter("@sName", entity.sName);
			p[3] = new SqlParameter("@sEmail", entity.sEmail);
			p[4] = new SqlParameter("@sTitle", entity.sTitle);
			p[5] = new SqlParameter("@sContent", entity.sContent);
			p[6] = new SqlParameter("@tDate", entity.tDate);
			p[7] = new SqlParameter("@bVerified", entity.bVerified);
            return p;
        }
        #endregion
       
    }
}