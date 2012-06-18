/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:31/10/2011 7:38:23 CH
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
    public class QuanHuyenBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại QuanHuyen Này";
		private static string EX_STEN_EMPTY="sTen không được để trống";
		private static string EX_SKYTUVIETTAT_EMPTY="sKytuviettat không được để trống";
		private static string EX_FK_ITINHTHANHID_INVALID="FK_iTinhThanhID không hợp lệ";
		private static string EX_ID_INVALID="PK_iQuanHuyenID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get QuanHuyen Theo ID
        /// </summary>
        /// <param name="PK_iQuanHuyenID">Int64:QuanHuyen ID</param>
        /// <returns>QuanHuyenEntity</returns>        
        public static QuanHuyenEntity GetOne(Int64 PK_iQuanHuyenID)
        {
            
			if(PK_iQuanHuyenID<=0)
				throw new Exception(EX_ID_INVALID);
            return QuanHuyenDAL.GetOne(PK_iQuanHuyenID);
        }
        /// <summary>
        /// Lấy về List các QuanHuyen
        /// </summary>
        /// <returns>List QuanHuyenEntity:List QuanHuyen Cần lấy</returns>
        public static List<QuanHuyenEntity> GetAll()
        {
            return QuanHuyenDAL.GetAll();
        }
        public static List<QuanHuyenEntity> GetByFK_iTinhThanhID(Int16 FK_iTinhThanhID)
		{
			if(FK_iTinhThanhID<=0)
				throw new Exception(EX_FK_ITINHTHANHID_INVALID);
			return QuanHuyenDAL.GetByFK_iTinhThanhID(FK_iTinhThanhID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới QuanHuyen
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của QuanHuyen Mới Thêm Vào</returns>
        public static Int32 Add(QuanHuyenEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return QuanHuyenDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa QuanHuyen
        /// </summary>
        /// <param name="entity">QuanHuyenEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(QuanHuyenEntity entity)
        {
            checkExist(entity.PK_iQuanHuyenID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return QuanHuyenDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá QuanHuyen
        /// </summary>
        /// <param name="PK_iQuanHuyenID">Int64 : PK_iQuanHuyenID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iQuanHuyenID)
        {
            checkExist(PK_iQuanHuyenID);
            return QuanHuyenDAL.Remove(PK_iQuanHuyenID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iQuanHuyenID)
        {
            QuanHuyenEntity oQuanHuyen=QuanHuyenDAL.GetOne(PK_iQuanHuyenID);
            if(oQuanHuyen==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">QuanHuyenEntity: entity</param>
        private static void checkLogic(QuanHuyenEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTen))
				throw new Exception(EX_STEN_EMPTY);
			if (String.IsNullOrEmpty(entity.sKytuviettat))
				throw new Exception(EX_SKYTUVIETTAT_EMPTY);
			if (entity.FK_iTinhThanhID < 0)
				throw new Exception(EX_FK_ITINHTHANHID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">QuanHuyenEntity: QuanHuyenEntity</param>
        private static void checkDuplicate(QuanHuyenEntity entity,bool checkPK)
        {
            /* 
            Example
            List<QuanHuyenEntity> list = QuanHuyenDAL.GetAll();
            if (list.Exists(
                delegate(QuanHuyenEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iQuanHuyenID != entity.PK_iQuanHuyenID;
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
        /// <param name="entity">QuanHuyenEntity:entity</param>
        private static void checkFK(QuanHuyenEntity entity)
        {            
			TinhEntity oTinh = TinhDAL.GetOne(entity.FK_iTinhThanhID);
			if (oTinh==null)
			{
				throw new Exception("Không tìm thấy :FK_iTinhThanhID");
			}
        }
        #endregion
    }
}
