/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:31/10/2011 7:38:18 CH
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
    public class QuanHuyenDAL : SqlProvider<QuanHuyenEntity>
    {
        static QuanHuyenDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                QuanHuyenEntity entity = new QuanHuyenEntity();
                entity.PK_iQuanHuyenID = Int32.Parse("0" + dr["PK_iQuanHuyenID"].ToString());
				entity.sTen = dr["sTen"].ToString();
				entity.bQuanHuyen =String.IsNullOrEmpty(dr["bQuanHuyen"].ToString())?false:Boolean.Parse(dr["bQuanHuyen"].ToString());
				entity.sKytuviettat = dr["sKytuviettat"].ToString();
				entity.FK_iTinhThanhID = Int16.Parse("0"+dr["FK_iTinhThanhID"].ToString());
                return entity;
            };
        }
        public static QuanHuyenEntity GetOne(Int64 PK_iQuanHuyenID)
        {
            string cmdName = "spQuanHuyen_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iQuanHuyenID", PK_iQuanHuyenID);
            QuanHuyenEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<QuanHuyenEntity> GetAll()
        {
            string cmdName = "spQuanHuyen_Get";
            return GetList(cmdName);
        }
        public static List<QuanHuyenEntity> GetByFK_iTinhThanhID(Int16 FK_iTinhThanhID)
		{
			string cmdName = "spQuanHuyen_GetByFK_FK_iTinhThanhID";
			SqlParameter p = new SqlParameter("@FK_iTinhThanhID",FK_iTinhThanhID);
			List<QuanHuyenEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(QuanHuyenEntity entity)
        {
            string cmdName = "spQuanHuyen_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(QuanHuyenEntity entity)
        {
            string cmdName = "spQuanHuyen_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iQuanHuyenID)
        {
            string cmdName = "spQuanHuyen_Delete";
            SqlParameter p = new SqlParameter("@PK_iQuanHuyenID", PK_iQuanHuyenID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(QuanHuyenEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iQuanHuyenID", entity.PK_iQuanHuyenID);
			p[1] = new SqlParameter("@sTen", entity.sTen);
			p[2] = new SqlParameter("@bQuanHuyen", entity.bQuanHuyen);
			p[3] = new SqlParameter("@sKytuviettat", entity.sKytuviettat);
			p[4] = new SqlParameter("@FK_iTinhThanhID", entity.FK_iTinhThanhID);
            return p;
        }
        #endregion
       
    }
}