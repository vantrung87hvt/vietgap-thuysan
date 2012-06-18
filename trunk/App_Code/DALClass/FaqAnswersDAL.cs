/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/18/2012 8:05:33 PM
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
    public class FaqAnswersDAL : SqlProvider<FaqAnswersEntity>
    {
        static FaqAnswersDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                FaqAnswersEntity entity = new FaqAnswersEntity();
				entity.PK_iFaqAnswerID = Int64.Parse("0"+dr["PK_iFaqAnswerID"].ToString());
				entity.FK_iFaqID = Int64.Parse("0"+dr["FK_iFaqID"].ToString());
				entity.sContent = dr["sContent"].ToString();
                return entity;
            };
        }
        public static FaqAnswersEntity GetOne(Int64 PK_iFaqAnswerID)
        {
            string cmdName = "spFaqAnswers_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iFaqAnswerID", PK_iFaqAnswerID);
            FaqAnswersEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<FaqAnswersEntity> GetAll()
        {
            string cmdName = "spFaqAnswers_Get";
            return GetList(cmdName);
        }
        public static List<FaqAnswersEntity> GetByFK_iFaqID(Int64 FK_iFaqID)
		{
			string cmdName = "spFaqAnswers_GetByFK_FK_iFaqID";
			SqlParameter p = new SqlParameter("@FK_iFaqID",FK_iFaqID);
			List<FaqAnswersEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(FaqAnswersEntity entity)
        {
            string cmdName = "spFaqAnswers_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(FaqAnswersEntity entity)
        {
            string cmdName = "spFaqAnswers_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iFaqAnswerID)
        {
            string cmdName = "spFaqAnswers_Delete";
            SqlParameter p = new SqlParameter("@PK_iFaqAnswerID", PK_iFaqAnswerID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(FaqAnswersEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iFaqAnswerID", entity.PK_iFaqAnswerID);
			p[1] = new SqlParameter("@FK_iFaqID", entity.FK_iFaqID);
			p[2] = new SqlParameter("@sContent", entity.sContent);
            return p;
        }
        #endregion
       
    }
}