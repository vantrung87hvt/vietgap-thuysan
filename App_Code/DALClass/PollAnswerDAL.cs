/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:36 PM
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
    public class PollAnswerDAL : SqlProvider<PollAnswerEntity>
    {
        static PollAnswerDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PollAnswerEntity entity = new PollAnswerEntity();
				entity.iAnswerID = Int32.Parse("0"+dr["iAnswerID"].ToString());
				entity.sAnswer = dr["sAnswer"].ToString();
				entity.iCount = Int32.Parse("0"+dr["iCount"].ToString());
				entity.iPollID = Int32.Parse("0"+dr["iPollID"].ToString());
                return entity;
            };
        }
        public static PollAnswerEntity GetOne(int iAnswerID)
        {
            string cmdName = "spPollAnswer_GetByPK";
            SqlParameter p = new SqlParameter("@iAnswerID", iAnswerID);
            PollAnswerEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PollAnswerEntity> GetAll()
        {
            string cmdName = "spPollAnswer_Get";
            return GetList(cmdName);
        }
        public static List<PollAnswerEntity> GetByiPollID(Int32 iPollID)
		{
			string cmdName = "spPollAnswer_GetByFK_iPollID";
			SqlParameter p = new SqlParameter("@iPollID",iPollID);
			List<PollAnswerEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(PollAnswerEntity entity)
        {
            string cmdName = "spPollAnswer_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PollAnswerEntity entity)
        {
            string cmdName = "spPollAnswer_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iAnswerID)
        {
            string cmdName = "spPollAnswer_Delete";
            SqlParameter p = new SqlParameter("@iAnswerID", iAnswerID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PollAnswerEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@iAnswerID", entity.iAnswerID);
			p[1] = new SqlParameter("@sAnswer", entity.sAnswer);
			p[2] = new SqlParameter("@iCount", entity.iCount);
			p[3] = new SqlParameter("@iPollID", entity.iPollID);
            return p;
        }
        #endregion
       
    }
}