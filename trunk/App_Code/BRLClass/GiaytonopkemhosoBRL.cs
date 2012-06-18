/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 5:32:38 PM
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
    public class GiaytonopkemhosoBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Giaytonopkemhoso Này";
		private static string EX_FK_IGIAYTOID_INVALID="FK_iGiaytoID không hợp lệ";
		private static string EX_PK_IHOSODANGKYCHUNGNHANID_INVALID="PK_iHosodangkychungnhanID không hợp lệ";
		private static string EX_ID_INVALID="PK_iGiaytoguikemID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Giaytonopkemhoso Theo ID
        /// </summary>
        /// <param name="PK_iGiaytoguikemID">Int64:Giaytonopkemhoso ID</param>
        /// <returns>GiaytonopkemhosoEntity</returns>        
        public static GiaytonopkemhosoEntity GetOne(Int64 PK_iGiaytoguikemID)
        {
            
			if(PK_iGiaytoguikemID<=0)
				throw new Exception(EX_ID_INVALID);
            return GiaytonopkemhosoDAL.GetOne(PK_iGiaytoguikemID);
        }
        /// <summary>
        /// Lấy về List các Giaytonopkemhoso
        /// </summary>
        /// <returns>List GiaytonopkemhosoEntity:List Giaytonopkemhoso Cần lấy</returns>
        public static List<GiaytonopkemhosoEntity> GetAll()
        {
            return GiaytonopkemhosoDAL.GetAll();
        }
        public static List<GiaytonopkemhosoEntity> GetByFK_iGiaytoID(Int32 FK_iGiaytoID)
		{
			if(FK_iGiaytoID<=0)
				throw new Exception(EX_FK_IGIAYTOID_INVALID);
			return GiaytonopkemhosoDAL.GetByFK_iGiaytoID(FK_iGiaytoID);
		}public static List<GiaytonopkemhosoEntity> GetByPK_iHosodangkychungnhanID(Int64 PK_iHosodangkychungnhanID)
		{
			if(PK_iHosodangkychungnhanID<=0)
				throw new Exception(EX_PK_IHOSODANGKYCHUNGNHANID_INVALID);
			return GiaytonopkemhosoDAL.GetByPK_iHosodangkychungnhanID(PK_iHosodangkychungnhanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Giaytonopkemhoso
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Giaytonopkemhoso Mới Thêm Vào</returns>
        public static Int32 Add(GiaytonopkemhosoEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return GiaytonopkemhosoDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Giaytonopkemhoso
        /// </summary>
        /// <param name="entity">GiaytonopkemhosoEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(GiaytonopkemhosoEntity entity)
        {
            checkExist(entity.PK_iGiaytoguikemID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return GiaytonopkemhosoDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Giaytonopkemhoso
        /// </summary>
        /// <param name="PK_iGiaytoguikemID">Int64 : PK_iGiaytoguikemID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iGiaytoguikemID)
        {
            checkExist(PK_iGiaytoguikemID);
            return GiaytonopkemhosoDAL.Remove(PK_iGiaytoguikemID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iGiaytoguikemID)
        {
            GiaytonopkemhosoEntity oGiaytonopkemhoso=GiaytonopkemhosoDAL.GetOne(PK_iGiaytoguikemID);
            if(oGiaytonopkemhoso==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">GiaytonopkemhosoEntity: entity</param>
        private static void checkLogic(GiaytonopkemhosoEntity entity)
        {   
			if (entity.FK_iGiaytoID < 0)
				throw new Exception(EX_FK_IGIAYTOID_INVALID);
			if (entity.PK_iHosodangkychungnhanID < 0)
				throw new Exception(EX_PK_IHOSODANGKYCHUNGNHANID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">GiaytonopkemhosoEntity: GiaytonopkemhosoEntity</param>
        private static void checkDuplicate(GiaytonopkemhosoEntity entity,bool checkPK)
        {
            /* 
            Example
            List<GiaytonopkemhosoEntity> list = GiaytonopkemhosoDAL.GetAll();
            if (list.Exists(
                delegate(GiaytonopkemhosoEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iGiaytoguikemID != entity.PK_iGiaytoguikemID;
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
        /// <param name="entity">GiaytonopkemhosoEntity:entity</param>
        private static void checkFK(GiaytonopkemhosoEntity entity)
        {            
			GiaytoEntity oGiayto = GiaytoDAL.GetOne(entity.FK_iGiaytoID);
			if (oGiayto==null)
			{
				throw new Exception("Không tìm thấy :FK_iGiaytoID");
			}
			HosodangkychungnhanEntity oHosodangkychungnhan = HosodangkychungnhanDAL.GetOne(entity.PK_iHosodangkychungnhanID);
			if (oHosodangkychungnhan==null)
			{
				throw new Exception("Không tìm thấy :PK_iHosodangkychungnhanID");
			}
        }
        #endregion
    }
}
