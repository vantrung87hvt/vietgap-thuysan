/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/23/2011 8:18:09 PM
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
    public class MasovietgapDAL : SqlProvider<MasovietgapEntity>
    {
        static MasovietgapDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                MasovietgapEntity entity = new MasovietgapEntity();
				entity.PK_iMasoVietGapID = Int64.Parse("0"+dr["PK_iMasoVietGapID"].ToString());
				entity.sMaso = dr["sMaso"].ToString();
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.FK_iCosonuoitrongID = Int64.Parse("0"+dr["FK_iCosonuoitrongID"].ToString());
				entity.dNgaycap =String.IsNullOrEmpty(dr["dNgaycap"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaycap"].ToString());
				entity.dNgayhethan =String.IsNullOrEmpty(dr["dNgayhethan"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgayhethan"].ToString());
				entity.iThoihan = Int16.Parse("0"+dr["iThoihan"].ToString());
				entity.iTrangthai = Int16.Parse("0"+dr["iTrangthai"].ToString());
				entity.iSanluongdukienmoi = Int64.Parse("0"+dr["iSanluongdukienmoi"].ToString());
				entity.fDientichmorong = float.Parse("0"+dr["fDientichmorong"].ToString());
                return entity;
            };
        }
        public static MasovietgapEntity GetOne(Int64 PK_iMasoVietGapID)
        {
            string cmdName = "spMasovietgap_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iMasoVietGapID", PK_iMasoVietGapID);
            MasovietgapEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<MasovietgapEntity> GetAll()
        {
            string cmdName = "spMasovietgap_Get";
            return GetList(cmdName);
        }
        public static List<MasovietgapEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spMasovietgap_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<MasovietgapEntity> list = GetList(cmdName, p);
			return list;
		}public static List<MasovietgapEntity> GetByFK_iCosonuoitrongID(Int64 FK_iCosonuoitrongID)
		{
			string cmdName = "spMasovietgap_GetByFK_FK_iCosonuoitrongID";
			SqlParameter p = new SqlParameter("@FK_iCosonuoitrongID",FK_iCosonuoitrongID);
			List<MasovietgapEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(MasovietgapEntity entity)
        {
            string cmdName = "spMasovietgap_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(MasovietgapEntity entity)
        {
            string cmdName = "spMasovietgap_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iMasoVietGapID)
        {
            string cmdName = "spMasovietgap_Delete";
            SqlParameter p = new SqlParameter("@PK_iMasoVietGapID", PK_iMasoVietGapID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(MasovietgapEntity entity)
        {
            SqlParameter[] p = new SqlParameter[10];
			p[0] = new SqlParameter("@PK_iMasoVietGapID", entity.PK_iMasoVietGapID);
			p[1] = new SqlParameter("@sMaso", entity.sMaso);
			p[2] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[3] = new SqlParameter("@FK_iCosonuoitrongID", entity.FK_iCosonuoitrongID);
			p[4] = new SqlParameter("@dNgaycap", entity.dNgaycap);
			p[5] = new SqlParameter("@dNgayhethan", entity.dNgayhethan);
			p[6] = new SqlParameter("@iThoihan", entity.iThoihan);
			p[7] = new SqlParameter("@iTrangthai", entity.iTrangthai);
			p[8] = new SqlParameter("@iSanluongdukienmoi", entity.iSanluongdukienmoi);
			p[9] = new SqlParameter("@fDientichmorong", entity.fDientichmorong);
            return p;
        }
        #endregion
       
    }
}