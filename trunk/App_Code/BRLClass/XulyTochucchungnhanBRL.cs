/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/28/2011 8:22:24 PM
------------------------------------------------------*/
using INVI.Entity;
using INVI.DataAccess;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace INVI.Business
{
    public class XulyTochucchungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại XulyTochucchungnhan Này";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_SLYDO_EMPTY="sLydo không được để trống";
		private static string EX_IMUCDO_INVALID="iMucdo không hợp lệ";
		private static string EX_DNGAYTHUCHIEN_INVALID="dNgaythuchien không hợp lệ";
		private static string EX_ID_INVALID="PK_iXulyTochucchungnhanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get XulyTochucchungnhan Theo ID
        /// </summary>
        /// <param name="PK_iXulyTochucchungnhanID">Int32:XulyTochucchungnhan ID</param>
        /// <returns>XulyTochucchungnhanEntity</returns>        
        public static XulyTochucchungnhanEntity GetOne(Int32 PK_iXulyTochucchungnhanID)
        {
            
			if(PK_iXulyTochucchungnhanID<=0)
				throw new Exception(EX_ID_INVALID);
            return XulyTochucchungnhanDAL.GetOne(PK_iXulyTochucchungnhanID);
        }
        /// <summary>
        /// Lấy về List các XulyTochucchungnhan
        /// </summary>
        /// <returns>List XulyTochucchungnhanEntity:List XulyTochucchungnhan Cần lấy</returns>
        public static List<XulyTochucchungnhanEntity> GetAll()
        {
            return XulyTochucchungnhanDAL.GetAll();
        }
        public static List<XulyTochucchungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return XulyTochucchungnhanDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới XulyTochucchungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của XulyTochucchungnhan Mới Thêm Vào</returns>
        public static Int32 Add(XulyTochucchungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return XulyTochucchungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa XulyTochucchungnhan
        /// </summary>
        /// <param name="entity">XulyTochucchungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(XulyTochucchungnhanEntity entity)
        {
            checkExist(entity.PK_iXulyTochucchungnhanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return XulyTochucchungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá XulyTochucchungnhan
        /// </summary>
        /// <param name="PK_iXulyTochucchungnhanID">Int32 : PK_iXulyTochucchungnhanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iXulyTochucchungnhanID)
        {
            checkExist(PK_iXulyTochucchungnhanID);
            return XulyTochucchungnhanDAL.Remove(PK_iXulyTochucchungnhanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iXulyTochucchungnhanID)
        {
            XulyTochucchungnhanEntity oXulyTochucchungnhan=XulyTochucchungnhanDAL.GetOne(PK_iXulyTochucchungnhanID);
            if(oXulyTochucchungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">XulyTochucchungnhanEntity: entity</param>
        private static void checkLogic(XulyTochucchungnhanEntity entity)
        {   
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (String.IsNullOrEmpty(entity.sLydo))
				throw new Exception(EX_SLYDO_EMPTY);
			if (entity.iMucdo < 0)
				throw new Exception(EX_IMUCDO_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaythuchien)
				throw new Exception(EX_DNGAYTHUCHIEN_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">XulyTochucchungnhanEntity: XulyTochucchungnhanEntity</param>
        private static void checkDuplicate(XulyTochucchungnhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<XulyTochucchungnhanEntity> list = XulyTochucchungnhanDAL.GetAll();
            if (list.Exists(
                delegate(XulyTochucchungnhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iXulyTochucchungnhanID != entity.PK_iXulyTochucchungnhanID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_FIELD_EXISTED);
            }
            */
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">XulyTochucchungnhanEntity:entity</param>
        private static void checkFK(XulyTochucchungnhanEntity entity)
        {            
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
        }
        #endregion
    }
}
