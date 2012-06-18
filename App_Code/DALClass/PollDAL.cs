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
    public class PollDAL : SqlProvider<PollEntity>
    {
        static PollDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PollEntity entity = new PollEntity();
				entity.iPollID = Int32.Parse("0"+dr["iPollID"].ToString());
				entity.sQuestion = dr["sQuestion"].ToString();
				entity.iOrder = Int16.Parse("0"+dr["iOrder"].ToString());
				entity.tDate =String.IsNullOrEmpty(dr["tDate"].ToString())?DateTime.Now:DateTime.Parse(dr["tDate"].ToString());
				entity.bHomepage =String.IsNullOrEmpty(dr["bHomepage"].ToString())?false:Boolean.Parse(dr["bHomepage"].ToString());
				entity.iNewsID = Int32.Parse("0"+dr["iNewsID"].ToString());
                return entity;
            };
        }
        public static PollEntity GetOne(int iPollID)
        {
            string cmdName = "spPoll_GetByPK";
            SqlParameter p = new SqlParameter("@iPollID", iPollID);
            PollEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PollEntity> GetAll()
        {
            string cmdName = "spPoll_Get";
            return GetList(cmdName);
        }
        public static List<PollEntity> GetByiNewsID(Int32 iNewsID)
		{
			string cmdName = "spPoll_GetByFK_iNewsID";
			SqlParameter p = new SqlParameter("@iNewsID",iNewsID);
			List<PollEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(PollEntity entity)
        {
            string cmdName = "spPoll_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PollEntity entity)
        {
            string cmdName = "spPoll_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iPollID)
        {
            string cmdName = "spPoll_Delete";
            SqlParameter p = new SqlParameter("@iPollID", iPollID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PollEntity entity)
        {
            SqlParameter[] p = new SqlParameter[6];
			p[0] = new SqlParameter("@iPollID", entity.iPollID);
			p[1] = new SqlParameter("@sQuestion", entity.sQuestion);
			p[2] = new SqlParameter("@iOrder", entity.iOrder);
			p[3] = new SqlParameter("@tDate", entity.tDate);
			p[4] = new SqlParameter("@bHomepage", entity.bHomepage);
			p[5] = new SqlParameter("@iNewsID", entity.iNewsID);
            return p;
        }
        #endregion
       
    }
}