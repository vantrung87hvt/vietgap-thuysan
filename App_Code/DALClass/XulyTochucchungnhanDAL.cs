/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/28/2011 8:22:31 PM
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
    public class XulyTochucchungnhanDAL : SqlProvider<XulyTochucchungnhanEntity>
    {
        static XulyTochucchungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                XulyTochucchungnhanEntity entity = new XulyTochucchungnhanEntity();
				entity.PK_iXulyTochucchungnhanID = Int32.Parse("0"+dr["PK_iXulyTochucchungnhanID"].ToString());
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.sLydo = dr["sLydo"].ToString();
				entity.iMucdo = Int16.Parse("0"+dr["iMucdo"].ToString());
				entity.dNgaythuchien =String.IsNullOrEmpty(dr["dNgaythuchien"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaythuchien"].ToString());
                return entity;
            };
        }
        public static XulyTochucchungnhanEntity GetOne(Int32 PK_iXulyTochucchungnhanID)
        {
            string cmdName = "spXulyTochucchungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iXulyTochucchungnhanID", PK_iXulyTochucchungnhanID);
            XulyTochucchungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<XulyTochucchungnhanEntity> GetAll()
        {
            string cmdName = "spXulyTochucchungnhan_Get";
            return GetList(cmdName);
        }
        public static List<XulyTochucchungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spXulyTochucchungnhan_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<XulyTochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(XulyTochucchungnhanEntity entity)
        {
            string cmdName = "spXulyTochucchungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(XulyTochucchungnhanEntity entity)
        {
            string cmdName = "spXulyTochucchungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iXulyTochucchungnhanID)
        {
            string cmdName = "spXulyTochucchungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iXulyTochucchungnhanID", PK_iXulyTochucchungnhanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(XulyTochucchungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iXulyTochucchungnhanID", entity.PK_iXulyTochucchungnhanID);
			p[1] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[2] = new SqlParameter("@sLydo", entity.sLydo);
			p[3] = new SqlParameter("@iMucdo", entity.iMucdo);
			p[4] = new SqlParameter("@dNgaythuchien", entity.dNgaythuchien);
            return p;
        }
        #endregion
       
    }
}