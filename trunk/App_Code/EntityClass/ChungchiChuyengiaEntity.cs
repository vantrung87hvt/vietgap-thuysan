/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 3:45:51 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ChungchiChuyengiaEntity
    {
        public ChungchiChuyengiaEntity()
        {
			m_pk_ichungchichuyengiaid=0;
			m_fk_ichuyengiaid=0;
			m_fk_ichungchiid=0;
        }
		private Int32 m_pk_ichungchichuyengiaid;
		public Int32 PK_iChungchiChuyengiaID
		{
			get { return m_pk_ichungchichuyengiaid ; }
			set { m_pk_ichungchichuyengiaid = value; }
		}
		private Int32 m_fk_ichuyengiaid;
		public Int32 FK_iChuyengiaID
		{
			get { return m_fk_ichuyengiaid ; }
			set { m_fk_ichuyengiaid = value; }
		}
		private Int32 m_fk_ichungchiid;
		public Int32 FK_iChungchiID
		{
			get { return m_fk_ichungchiid ; }
			set { m_fk_ichungchiid = value; }
		}

        #region Comparison
        public static List<ChungchiChuyengiaEntity> Sort(List<ChungchiChuyengiaEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ChungchiChuyengiaEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ChungchiChuyengiaEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ChungchiChuyengiaEntity> COMPARISON_PK_iChungchiChuyengiaID
		{
			get
			{
				return delegate(ChungchiChuyengiaEntity entity,ChungchiChuyengiaEntity other)
				{
					return entity.PK_iChungchiChuyengiaID.CompareTo(other.PK_iChungchiChuyengiaID);
				};
			}
		}
		public static Comparison<ChungchiChuyengiaEntity> COMPARISON_FK_iChuyengiaID
		{
			get
			{
				return delegate(ChungchiChuyengiaEntity entity,ChungchiChuyengiaEntity other)
				{
					return entity.FK_iChuyengiaID.CompareTo(other.FK_iChuyengiaID);
				};
			}
		}
		public static Comparison<ChungchiChuyengiaEntity> COMPARISON_FK_iChungchiID
		{
			get
			{
				return delegate(ChungchiChuyengiaEntity entity,ChungchiChuyengiaEntity other)
				{
					return entity.FK_iChungchiID.CompareTo(other.FK_iChungchiID);
				};
			}
		}
        #endregion
    }
}
