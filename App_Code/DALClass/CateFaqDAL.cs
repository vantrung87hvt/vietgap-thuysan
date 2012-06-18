/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/24/2011 10:25:04 PM
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
    public class CateFaqDAL : SqlProvider<CateFaqEntity>
    {
        static CateFaqDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                CateFaqEntity entity = new CateFaqEntity();
				entity.PK_iFaqCateID = Int32.Parse("0"+dr["PK_iFaqCateID"].ToString());
				entity.sCateName = dr["sCateName"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
                return entity;
            };
        }
        public static CateFaqEntity GetOne(Int32 PK_iFaqCateID)
        {
            string cmdName = "spCateFaq_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iFaqCateID", PK_iFaqCateID);
            CateFaqEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<CateFaqEntity> GetAll()
        {
            string cmdName = "spCateFaq_Get";
            return GetList(cmdName);
        }
        
        public static int Add(CateFaqEntity entity)
        {
            string cmdName = "spCateFaq_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(CateFaqEntity entity)
        {
            string cmdName = "spCateFaq_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iFaqCateID)
        {
            string cmdName = "spCateFaq_Delete";
            SqlParameter p = new SqlParameter("@PK_iFaqCateID", PK_iFaqCateID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(CateFaqEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iFaqCateID", entity.PK_iFaqCateID);
			p[1] = new SqlParameter("@sCateName", entity.sCateName);
			p[2] = new SqlParameter("@sDesc", entity.sDesc);
            return p;
        }
        #endregion
       
    }
}