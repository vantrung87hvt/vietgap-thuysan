/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/13/2012 11:25:46 AM
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
    public class CosonuoitrongDAL : SqlProvider<CosonuoitrongEntity>
    {
        static CosonuoitrongDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                CosonuoitrongEntity entity = new CosonuoitrongEntity();
				entity.PK_iCosonuoitrongID = Int64.Parse("0"+dr["PK_iCosonuoitrongID"].ToString());
				entity.sMaso_vietgap = dr["sMaso_vietgap"].ToString();
				entity.sTencoso = dr["sTencoso"].ToString();
				entity.sTenchucoso = dr["sTenchucoso"].ToString();
				entity.sAp = dr["sAp"].ToString();
				entity.sXa = dr["sXa"].ToString();
				entity.FK_iQuanHuyenID = Int64.Parse("0"+dr["FK_iQuanHuyenID"].ToString());
				entity.sDienthoai = dr["sDienthoai"].ToString();
				entity.fTongdientich = float.Parse("0"+dr["fTongdientich"].ToString());
				entity.fTongdientichmatnuoc = float.Parse("0"+dr["fTongdientichmatnuoc"].ToString());
				entity.FK_iToadoID = Int32.Parse("0"+dr["FK_iToadoID"].ToString());
				entity.sSodoaonuoi = dr["sSodoaonuoi"].ToString();
				entity.FK_iDoituongnuoiID = Int32.Parse("0"+dr["FK_iDoituongnuoiID"].ToString());
				entity.iNamsanxuat = Int32.Parse("0"+dr["iNamsanxuat"].ToString());
				entity.iChukynuoi = Int32.Parse("0"+dr["iChukynuoi"].ToString());
				entity.dNgaydangky =String.IsNullOrEmpty(dr["dNgaydangky"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaydangky"].ToString());
				entity.bDuyet =String.IsNullOrEmpty(dr["bDuyet"].ToString())?false:Boolean.Parse(dr["bDuyet"].ToString());
				entity.sMasocoso = dr["sMasocoso"].ToString();
				entity.iSanluongdukien = Int32.Parse("0"+dr["iSanluongdukien"].ToString());
				entity.fDientichAolang = float.Parse("0"+dr["fDientichAolang"].ToString());
				entity.FK_iHinhthucnuoiID = Int32.Parse("0"+dr["FK_iHinhthucnuoiID"].ToString());
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.FK_iUserID = Int64.Parse("0"+dr["FK_iUserID"].ToString());
				entity.bXoa =String.IsNullOrEmpty(dr["bXoa"].ToString())?false:Boolean.Parse(dr["bXoa"].ToString());
                return entity;
            };
        }
        public static CosonuoitrongEntity GetOne(Int64 PK_iCosonuoitrongID)
        {
            string cmdName = "spCosonuoitrong_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iCosonuoitrongID", PK_iCosonuoitrongID);
            CosonuoitrongEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<CosonuoitrongEntity> GetAll()
        {
            string cmdName = "spCosonuoitrong_Get";
            return GetList(cmdName);
        }
        public static List<CosonuoitrongEntity> GetByFK_iQuanHuyenID(Int64 FK_iQuanHuyenID)
		{
			string cmdName = "spCosonuoitrong_GetByFK_FK_iQuanHuyenID";
			SqlParameter p = new SqlParameter("@FK_iQuanHuyenID",FK_iQuanHuyenID);
			List<CosonuoitrongEntity> list = GetList(cmdName, p);
			return list;
		}public static List<CosonuoitrongEntity> GetByFK_iToadoID(Int32 FK_iToadoID)
		{
			string cmdName = "spCosonuoitrong_GetByFK_FK_iToadoID";
			SqlParameter p = new SqlParameter("@FK_iToadoID",FK_iToadoID);
			List<CosonuoitrongEntity> list = GetList(cmdName, p);
			return list;
		}public static List<CosonuoitrongEntity> GetByFK_iDoituongnuoiID(Int32 FK_iDoituongnuoiID)
		{
			string cmdName = "spCosonuoitrong_GetByFK_FK_iDoituongnuoiID";
			SqlParameter p = new SqlParameter("@FK_iDoituongnuoiID",FK_iDoituongnuoiID);
			List<CosonuoitrongEntity> list = GetList(cmdName, p);
			return list;
		}public static List<CosonuoitrongEntity> GetByFK_iHinhthucnuoiID(Int32 FK_iHinhthucnuoiID)
		{
			string cmdName = "spCosonuoitrong_GetByFK_FK_iHinhthucnuoiID";
			SqlParameter p = new SqlParameter("@FK_iHinhthucnuoiID",FK_iHinhthucnuoiID);
			List<CosonuoitrongEntity> list = GetList(cmdName, p);
			return list;
		}public static List<CosonuoitrongEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spCosonuoitrong_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<CosonuoitrongEntity> list = GetList(cmdName, p);
			return list;
		}public static List<CosonuoitrongEntity> GetByFK_iUserID(Int64 FK_iUserID)
		{
			string cmdName = "spCosonuoitrong_GetByFK_FK_iUserID";
			SqlParameter p = new SqlParameter("@FK_iUserID",FK_iUserID);
			List<CosonuoitrongEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(CosonuoitrongEntity entity)
        {
            string cmdName = "spCosonuoitrong_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(CosonuoitrongEntity entity)
        {
            string cmdName = "spCosonuoitrong_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iCosonuoitrongID)
        {
            string cmdName = "spCosonuoitrong_Delete";
            SqlParameter p = new SqlParameter("@PK_iCosonuoitrongID", PK_iCosonuoitrongID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(CosonuoitrongEntity entity)
        {
            SqlParameter[] p = new SqlParameter[24];
			p[0] = new SqlParameter("@PK_iCosonuoitrongID", entity.PK_iCosonuoitrongID);
			p[1] = new SqlParameter("@sMaso_vietgap", entity.sMaso_vietgap);
			p[2] = new SqlParameter("@sTencoso", entity.sTencoso);
			p[3] = new SqlParameter("@sTenchucoso", entity.sTenchucoso);
			p[4] = new SqlParameter("@sAp", entity.sAp);
			p[5] = new SqlParameter("@sXa", entity.sXa);
			p[6] = new SqlParameter("@FK_iQuanHuyenID", entity.FK_iQuanHuyenID);
			p[7] = new SqlParameter("@sDienthoai", entity.sDienthoai);
			p[8] = new SqlParameter("@fTongdientich", entity.fTongdientich);
			p[9] = new SqlParameter("@fTongdientichmatnuoc", entity.fTongdientichmatnuoc);
			p[10] = new SqlParameter("@FK_iToadoID", entity.FK_iToadoID);
			p[11] = new SqlParameter("@sSodoaonuoi", entity.sSodoaonuoi);
			p[12] = new SqlParameter("@FK_iDoituongnuoiID", entity.FK_iDoituongnuoiID);
			p[13] = new SqlParameter("@iNamsanxuat", entity.iNamsanxuat);
			p[14] = new SqlParameter("@iChukynuoi", entity.iChukynuoi);
			p[15] = new SqlParameter("@dNgaydangky", entity.dNgaydangky);
			p[16] = new SqlParameter("@bDuyet", entity.bDuyet);
			p[17] = new SqlParameter("@sMasocoso", entity.sMasocoso);
			p[18] = new SqlParameter("@iSanluongdukien", entity.iSanluongdukien);
			p[19] = new SqlParameter("@fDientichAolang", entity.fDientichAolang);
			p[20] = new SqlParameter("@FK_iHinhthucnuoiID", entity.FK_iHinhthucnuoiID);
			p[21] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[22] = new SqlParameter("@FK_iUserID", entity.FK_iUserID);
			p[23] = new SqlParameter("@bXoa", entity.bXoa);
            return p;
        }
        #endregion
       
    }
}