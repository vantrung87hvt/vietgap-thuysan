/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/6/2012 11:12:42 AM
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
    public class GiaytoDAL : SqlProvider<GiaytoEntity>
    {
        static GiaytoDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                GiaytoEntity entity = new GiaytoEntity();
				entity.PK_iGiaytoID = Int32.Parse("0"+dr["PK_iGiaytoID"].ToString());
				entity.sTengiayto = dr["sTengiayto"].ToString();
				entity.bCSNT =String.IsNullOrEmpty(dr["bCSNT"].ToString())?false:Boolean.Parse(dr["bCSNT"].ToString());
                return entity;
            };
        }
        public static GiaytoEntity GetOne(Int32 PK_iGiaytoID)
        {
            string cmdName = "spGiayto_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iGiaytoID", PK_iGiaytoID);
            GiaytoEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<GiaytoEntity> GetAll()
        {
            string cmdName = "spGiayto_Get";
            return GetList(cmdName);
        }
        
        public static int Add(GiaytoEntity entity)
        {
            string cmdName = "spGiayto_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(GiaytoEntity entity)
        {
            string cmdName = "spGiayto_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iGiaytoID)
        {
            string cmdName = "spGiayto_Delete";
            SqlParameter p = new SqlParameter("@PK_iGiaytoID", PK_iGiaytoID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(GiaytoEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iGiaytoID", entity.PK_iGiaytoID);
			p[1] = new SqlParameter("@sTengiayto", entity.sTengiayto);
			p[2] = new SqlParameter("@bCSNT", entity.bCSNT);
            return p;
        }
        #endregion
       
    }
}