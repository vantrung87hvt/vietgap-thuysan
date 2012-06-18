/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:34 PM
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
    public class NewsDAL : SqlProvider<NewsEntity>
    {
        static NewsDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                NewsEntity entity = new NewsEntity();
				entity.iNewsID = Int32.Parse("0"+dr["iNewsID"].ToString());
				entity.sTitle = dr["sTitle"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
				entity.sContent = dr["sContent"].ToString();
				entity.sImage = dr["sImage"].ToString();
				entity.tDate =String.IsNullOrEmpty(dr["tDate"].ToString())?DateTime.Now:DateTime.Parse(dr["tDate"].ToString());
				entity.iViews = Int32.Parse("0"+dr["iViews"].ToString());
				entity.bVerified =String.IsNullOrEmpty(dr["bVerified"].ToString())?false:Boolean.Parse(dr["bVerified"].ToString());
				entity.sTag = dr["sTag"].ToString();
				entity.iUserID = Int32.Parse("0"+dr["iUserID"].ToString());
                return entity;
            };
        }
        public static NewsEntity GetOne(int iNewsID)
        {
            string cmdName = "spNews_GetByPK";
            SqlParameter p = new SqlParameter("@iNewsID", iNewsID);
            NewsEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<NewsEntity> GetAll()
        {
            string cmdName = "spNews_Get";
            return GetList(cmdName);
        }
        public static List<NewsEntity> GetByiUserID(Int32 iUserID)
		{
			string cmdName = "spNews_GetByFK_iUserID";
			SqlParameter p = new SqlParameter("@iUserID",iUserID);
			List<NewsEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(NewsEntity entity)
        {
            string cmdName = "spNews_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(NewsEntity entity)
        {
            string cmdName = "spNews_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iNewsID)
        {
            string cmdName = "spNews_Delete";
            SqlParameter p = new SqlParameter("@iNewsID", iNewsID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(NewsEntity entity)
        {
            SqlParameter[] p = new SqlParameter[10];
			p[0] = new SqlParameter("@iNewsID", entity.iNewsID);
			p[1] = new SqlParameter("@sTitle", entity.sTitle);
			p[2] = new SqlParameter("@sDesc", entity.sDesc);
			p[3] = new SqlParameter("@sContent", entity.sContent);
			p[4] = new SqlParameter("@sImage", entity.sImage);
			p[5] = new SqlParameter("@tDate", entity.tDate);
			p[6] = new SqlParameter("@iViews", entity.iViews);
			p[7] = new SqlParameter("@bVerified", entity.bVerified);
			p[8] = new SqlParameter("@sTag", entity.sTag);
			p[9] = new SqlParameter("@iUserID", entity.iUserID);
            return p;
        }
        #endregion
       
    }
}