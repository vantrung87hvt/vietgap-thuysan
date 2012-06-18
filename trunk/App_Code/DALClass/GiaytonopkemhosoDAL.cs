/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 5:33:33 PM
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
    public class GiaytonopkemhosoDAL : SqlProvider<GiaytonopkemhosoEntity>
    {
        static GiaytonopkemhosoDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                GiaytonopkemhosoEntity entity = new GiaytonopkemhosoEntity();
				entity.PK_iGiaytoguikemID = Int64.Parse("0"+dr["PK_iGiaytoguikemID"].ToString());
				entity.FK_iGiaytoID = Int32.Parse("0"+dr["FK_iGiaytoID"].ToString());
				entity.bTrangthai =String.IsNullOrEmpty(dr["bTrangthai"].ToString())?false:Boolean.Parse(dr["bTrangthai"].ToString());
				entity.PK_iHosodangkychungnhanID = Int64.Parse("0"+dr["PK_iHosodangkychungnhanID"].ToString());
                return entity;
            };
        }
        public static GiaytonopkemhosoEntity GetOne(Int64 PK_iGiaytoguikemID)
        {
            string cmdName = "spGiaytonopkemhoso_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iGiaytoguikemID", PK_iGiaytoguikemID);
            GiaytonopkemhosoEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<GiaytonopkemhosoEntity> GetAll()
        {
            string cmdName = "spGiaytonopkemhoso_Get";
            return GetList(cmdName);
        }
        public static List<GiaytonopkemhosoEntity> GetByFK_iGiaytoID(Int32 FK_iGiaytoID)
		{
			string cmdName = "spGiaytonopkemhoso_GetByFK_FK_iGiaytoID";
			SqlParameter p = new SqlParameter("@FK_iGiaytoID",FK_iGiaytoID);
			List<GiaytonopkemhosoEntity> list = GetList(cmdName, p);
			return list;
		}public static List<GiaytonopkemhosoEntity> GetByPK_iHosodangkychungnhanID(Int64 PK_iHosodangkychungnhanID)
		{
			string cmdName = "spGiaytonopkemhoso_GetByFK_PK_iHosodangkychungnhanID";
			SqlParameter p = new SqlParameter("@PK_iHosodangkychungnhanID",PK_iHosodangkychungnhanID);
			List<GiaytonopkemhosoEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(GiaytonopkemhosoEntity entity)
        {
            string cmdName = "spGiaytonopkemhoso_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(GiaytonopkemhosoEntity entity)
        {
            string cmdName = "spGiaytonopkemhoso_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iGiaytoguikemID)
        {
            string cmdName = "spGiaytonopkemhoso_Delete";
            SqlParameter p = new SqlParameter("@PK_iGiaytoguikemID", PK_iGiaytoguikemID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(GiaytonopkemhosoEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@PK_iGiaytoguikemID", entity.PK_iGiaytoguikemID);
			p[1] = new SqlParameter("@FK_iGiaytoID", entity.FK_iGiaytoID);
			p[2] = new SqlParameter("@bTrangthai", entity.bTrangthai);
			p[3] = new SqlParameter("@PK_iHosodangkychungnhanID", entity.PK_iHosodangkychungnhanID);
            return p;
        }
        #endregion
       
    }
}