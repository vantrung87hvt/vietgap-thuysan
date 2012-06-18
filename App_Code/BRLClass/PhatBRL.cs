/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/27/2011 8:54:56 PM
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
    public class PhatBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Phat Này";
		private static string EX_SLYDO_EMPTY="sLydo không được để trống";
		private static string EX_IMUCDO_INVALID="iMucdo không hợp lệ";
		private static string EX_FK_ICOSONUOIID_INVALID="FK_iCosonuoiID không hợp lệ";
		private static string EX_DNGAYTHUCHIEN_INVALID="dNgaythuchien không hợp lệ";
		private static string EX_ID_INVALID="PK_iPhatDinhchiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Phat Theo ID
        /// </summary>
        /// <param name="PK_iPhatDinhchiID">Int32:Phat ID</param>
        /// <returns>PhatEntity</returns>        
        public static PhatEntity GetOne(Int32 PK_iPhatDinhchiID)
        {
            
			if(PK_iPhatDinhchiID<=0)
				throw new Exception(EX_ID_INVALID);
            return PhatDAL.GetOne(PK_iPhatDinhchiID);
        }
        /// <summary>
        /// Lấy về List các Phat
        /// </summary>
        /// <returns>List PhatEntity:List Phat Cần lấy</returns>
        public static List<PhatEntity> GetAll()
        {
            return PhatDAL.GetAll();
        }
        public static List<PhatEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			if(FK_iCosonuoiID<=0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			return PhatDAL.GetByFK_iCosonuoiID(FK_iCosonuoiID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Phat
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Phat Mới Thêm Vào</returns>
        public static Int32 Add(PhatEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PhatDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Phat
        /// </summary>
        /// <param name="entity">PhatEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PhatEntity entity)
        {
            checkExist(entity.PK_iPhatDinhchiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return PhatDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Phat
        /// </summary>
        /// <param name="PK_iPhatDinhchiID">Int32 : PK_iPhatDinhchiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iPhatDinhchiID)
        {
            checkExist(PK_iPhatDinhchiID);
            return PhatDAL.Remove(PK_iPhatDinhchiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iPhatDinhchiID)
        {
            PhatEntity oPhat=PhatDAL.GetOne(PK_iPhatDinhchiID);
            if(oPhat==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PhatEntity: entity</param>
        private static void checkLogic(PhatEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sLydo))
				throw new Exception(EX_SLYDO_EMPTY);
			if (entity.iMucdo < 0)
				throw new Exception(EX_IMUCDO_INVALID);
			if (entity.FK_iCosonuoiID < 0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaythuchien)
				throw new Exception(EX_DNGAYTHUCHIEN_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PhatEntity: PhatEntity</param>
        private static void checkDuplicate(PhatEntity entity,bool checkPK)
        {
            /* 
            Example
            List<PhatEntity> list = PhatDAL.GetAll();
            if (list.Exists(
                delegate(PhatEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iPhatDinhchiID != entity.PK_iPhatDinhchiID;
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
        /// <param name="entity">PhatEntity:entity</param>
        private static void checkFK(PhatEntity entity)
        {            
			CosonuoitrongEntity oCosonuoitrong = CosonuoitrongDAL.GetOne(entity.FK_iCosonuoiID);
			if (oCosonuoitrong==null)
			{
				throw new Exception("Không tìm thấy :FK_iCosonuoiID");
			}
        }
        #endregion
    }
}
