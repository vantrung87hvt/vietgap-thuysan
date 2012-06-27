/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/27/2012 8:38:44 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DoandanhgiatochucchungnhanEntity
    {
        public DoandanhgiatochucchungnhanEntity()
        {
			m_pk_idoandanhgiatochucchungnhanid=0;
			m_fk_idanhgiatochucchungnhanid=0;
			m_fk_ichuyengiaid=0;
        }
		private Int32 m_pk_idoandanhgiatochucchungnhanid;
		public Int32 PK_iDoandanhgiatochucchungnhanID
		{
			get { return m_pk_idoandanhgiatochucchungnhanid ; }
			set { m_pk_idoandanhgiatochucchungnhanid = value; }
		}
		private Int32 m_fk_idanhgiatochucchungnhanid;
		public Int32 FK_iDanhgiatochucchungnhanID
		{
			get { return m_fk_idanhgiatochucchungnhanid ; }
			set { m_fk_idanhgiatochucchungnhanid = value; }
		}
		private Int32 m_fk_ichuyengiaid;
		public Int32 FK_iChuyengiaID
		{
			get { return m_fk_ichuyengiaid ; }
			set { m_fk_ichuyengiaid = value; }
		}

        #region Comparison
        public static List<DoandanhgiatochucchungnhanEntity> Sort(List<DoandanhgiatochucchungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DoandanhgiatochucchungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DoandanhgiatochucchungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DoandanhgiatochucchungnhanEntity> COMPARISON_PK_iDoandanhgiatochucchungnhanID
		{
			get
			{
				return delegate(DoandanhgiatochucchungnhanEntity entity,DoandanhgiatochucchungnhanEntity other)
				{
					return entity.PK_iDoandanhgiatochucchungnhanID.CompareTo(other.PK_iDoandanhgiatochucchungnhanID);
				};
			}
		}
		public static Comparison<DoandanhgiatochucchungnhanEntity> COMPARISON_FK_iDanhgiatochucchungnhanID
		{
			get
			{
				return delegate(DoandanhgiatochucchungnhanEntity entity,DoandanhgiatochucchungnhanEntity other)
				{
					return entity.FK_iDanhgiatochucchungnhanID.CompareTo(other.FK_iDanhgiatochucchungnhanID);
				};
			}
		}
		public static Comparison<DoandanhgiatochucchungnhanEntity> COMPARISON_FK_iChuyengiaID
		{
			get
			{
				return delegate(DoandanhgiatochucchungnhanEntity entity,DoandanhgiatochucchungnhanEntity other)
				{
					return entity.FK_iChuyengiaID.CompareTo(other.FK_iChuyengiaID);
				};
			}
		}
        #endregion
    }
}
