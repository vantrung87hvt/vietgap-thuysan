/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/1/2012 9:48:03 PM
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
    public class CoquancaptrenDAL : SqlProvider<CoquancaptrenEntity>
    {
        static CoquancaptrenDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                CoquancaptrenEntity entity = new CoquancaptrenEntity();
				entity.PK_iCoquancaptrenID = Int32.Parse("0"+dr["PK_iCoquancaptrenID"].ToString());
				entity.sTencoquan = dr["sTencoquan"].ToString();
                return entity;
            };
        }
        public static CoquancaptrenEntity GetOne(Int32 PK_iCoquancaptrenID)
        {
            string cmdName = "spCoquancaptren_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iCoquancaptrenID", PK_iCoquancaptrenID);
            CoquancaptrenEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<CoquancaptrenEntity> GetAll()
        {
            string cmdName = "spCoquancaptren_Get";
            return GetList(cmdName);
        }
        
        public static int Add(CoquancaptrenEntity entity)
        {
            string cmdName = "spCoquancaptren_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(CoquancaptrenEntity entity)
        {
            string cmdName = "spCoquancaptren_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iCoquancaptrenID)
        {
            string cmdName = "spCoquancaptren_Delete";
            SqlParameter p = new SqlParameter("@PK_iCoquancaptrenID", PK_iCoquancaptrenID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(CoquancaptrenEntity entity)
        {
            SqlParameter[] p = new SqlParameter[2];
			p[0] = new SqlParameter("@PK_iCoquancaptrenID", entity.PK_iCoquancaptrenID);
			p[1] = new SqlParameter("@sTencoquan", entity.sTencoquan);
            return p;
        }
        #endregion
       
    }
}