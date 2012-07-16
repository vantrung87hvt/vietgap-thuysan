/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/24/2012 2:35:37 PM
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
    public class ChuyengiaBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Chuyengia Này";
		private static string EX_SHOTEN_EMPTY="sHoten không được để trống";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_INAMKINHNGHIEM_INVALID="iNamkinhnghiem không hợp lệ";
		private static string EX_ITRANGTHAI_INVALID="iTrangthai không hợp lệ";
		private static string EX_IMANH_INVALID="imAnh không hợp lệ";
		private static string EX_FK_ITRINHDOID_INVALID="FK_iTrinhdoID không hợp lệ";
		private static string EX_ID_INVALID="PK_iChuyengiaID không hợp lệ";
        private static string EX_INAMSINH_INVALID = "iNamsinh không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Chuyengia Theo ID
        /// </summary>
        /// <param name="PK_iChuyengiaID">Int32:Chuyengia ID</param>
        /// <returns>ChuyengiaEntity</returns>        
        public static ChuyengiaEntity GetOne(Int32 PK_iChuyengiaID)
        {
            
			if(PK_iChuyengiaID<=0)
				throw new Exception(EX_ID_INVALID);
            return ChuyengiaDAL.GetOne(PK_iChuyengiaID);
        }
        /// <summary>
        /// Lấy về List các Chuyengia
        /// </summary>
        /// <returns>List ChuyengiaEntity:List Chuyengia Cần lấy</returns>
        public static List<ChuyengiaEntity> GetAll()
        {
            return ChuyengiaDAL.GetAll();
        }
        public static List<ChuyengiaEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return ChuyengiaDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}public static List<ChuyengiaEntity> GetByFK_iTrinhdoID(Int16 FK_iTrinhdoID)
		{
			if(FK_iTrinhdoID<=0)
				throw new Exception(EX_FK_ITRINHDOID_INVALID);
			return ChuyengiaDAL.GetByFK_iTrinhdoID(FK_iTrinhdoID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Chuyengia
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Chuyengia Mới Thêm Vào</returns>
        public static Int32 Add(ChuyengiaEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ChuyengiaDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Chuyengia
        /// </summary>
        /// <param name="entity">ChuyengiaEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ChuyengiaEntity entity)
        {
            checkExist(entity.PK_iChuyengiaID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ChuyengiaDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Chuyengia
        /// </summary>
        /// <param name="PK_iChuyengiaID">Int32 : PK_iChuyengiaID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iChuyengiaID)
        {
            checkExist(PK_iChuyengiaID);
            return ChuyengiaDAL.Remove(PK_iChuyengiaID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iChuyengiaID)
        {
            ChuyengiaEntity oChuyengia=ChuyengiaDAL.GetOne(PK_iChuyengiaID);
            if(oChuyengia==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ChuyengiaEntity: entity</param>
        private static void checkLogic(ChuyengiaEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sHoten))
				throw new Exception(EX_SHOTEN_EMPTY);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (entity.iNamkinhnghiem < 0)
				throw new Exception(EX_INAMKINHNGHIEM_INVALID);
			if (entity.iTrangthai < 0)
				throw new Exception(EX_ITRANGTHAI_INVALID);
			if (entity.imAnh==null)
				throw new Exception(EX_IMANH_INVALID);
			if (entity.FK_iTrinhdoID < 0)
				throw new Exception(EX_FK_ITRINHDOID_INVALID);
            if (entity.iNamsinh < 0)
                throw new Exception(EX_INAMSINH_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ChuyengiaEntity: ChuyengiaEntity</param>
        private static void checkDuplicate(ChuyengiaEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ChuyengiaEntity> list = ChuyengiaDAL.GetAll();
            if (list.Exists(
                delegate(ChuyengiaEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iChuyengiaID != entity.PK_iChuyengiaID;
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
        /// <param name="entity">ChuyengiaEntity:entity</param>
        private static void checkFK(ChuyengiaEntity entity)
        {            
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
			TrinhdoChuyengiaEntity oTrinhdoChuyengia = TrinhdoChuyengiaDAL.GetOne(entity.FK_iTrinhdoID);
			if (oTrinhdoChuyengia==null)
			{
				throw new Exception("Không tìm thấy :FK_iTrinhdoID");
			}
        }
        #endregion
    }
}
