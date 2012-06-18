/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/24/2011 10:25:06 PM
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
    public class FaqCategoryDAL : SqlProvider<FaqCategoryEntity>
    {
        static FaqCategoryDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                FaqCategoryEntity entity = new FaqCategoryEntity();
				entity.PK_iFaqCategoryID = Int64.Parse("0"+dr["PK_iFaqCategoryID"].ToString());
				entity.FK_iFaqID = Int64.Parse("0"+dr["FK_iFaqID"].ToString());
				entity.iCateFaqID = Int32.Parse("0"+dr["iCateFaqID"].ToString());
                return entity;
            };
        }
        public static FaqCategoryEntity GetOne(Int64 PK_iFaqCategoryID)
        {
            string cmdName = "spFaqCategory_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iFaqCategoryID", PK_iFaqCategoryID);
            FaqCategoryEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<FaqCategoryEntity> GetAll()
        {
            string cmdName = "spFaqCategory_Get";
            return GetList(cmdName);
        }
        public static List<FaqCategoryEntity> GetByFK_iFaqID(Int64 FK_iFaqID)
		{
			string cmdName = "spFaqCategory_GetByFK_FK_iFaqID";
			SqlParameter p = new SqlParameter("@FK_iFaqID",FK_iFaqID);
			List<FaqCategoryEntity> list = GetList(cmdName, p);
			return list;
		}public static List<FaqCategoryEntity> GetByiCateFaqID(Int32 iCateFaqID)
		{
			string cmdName = "spFaqCategory_GetByFK_iCateFaqID";
			SqlParameter p = new SqlParameter("@iCateFaqID",iCateFaqID);
			List<FaqCategoryEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(FaqCategoryEntity entity)
        {
            string cmdName = "spFaqCategory_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(FaqCategoryEntity entity)
        {
            string cmdName = "spFaqCategory_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iFaqCategoryID)
        {
            string cmdName = "spFaqCategory_Delete";
            SqlParameter p = new SqlParameter("@PK_iFaqCategoryID", PK_iFaqCategoryID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(FaqCategoryEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iFaqCategoryID", entity.PK_iFaqCategoryID);
			p[1] = new SqlParameter("@FK_iFaqID", entity.FK_iFaqID);
			p[2] = new SqlParameter("@iCateFaqID", entity.iCateFaqID);
            return p;
        }
        #endregion
       
    }
}