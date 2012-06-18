/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:31/10/2011 7:40:59 CH
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DoituongnuoiEntity
    {
        public DoituongnuoiEntity()
        {
			m_pk_idoituongnuoiid=0;
			m_stendoituong="";
			m_skytu="";
        }
		private Int32 m_pk_idoituongnuoiid;
		public Int32 PK_iDoituongnuoiID
		{
			get { return m_pk_idoituongnuoiid ; }
			set { m_pk_idoituongnuoiid = value; }
		}
		private String m_stendoituong;
		public String sTendoituong
		{
			get { return m_stendoituong ; }
			set { m_stendoituong = value; }
		}
		private String m_skytu;
		public String sKytu
		{
			get { return m_skytu ; }
			set { m_skytu = value; }
		}

        #region Comparison
        public static List<DoituongnuoiEntity> Sort(List<DoituongnuoiEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DoituongnuoiEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DoituongnuoiEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DoituongnuoiEntity> COMPARISON_PK_iDoituongnuoiID
		{
			get
			{
				return delegate(DoituongnuoiEntity entity,DoituongnuoiEntity other)
				{
					return entity.PK_iDoituongnuoiID.CompareTo(other.PK_iDoituongnuoiID);
				};
			}
		}
		public static Comparison<DoituongnuoiEntity> COMPARISON_sTendoituong
		{
			get
			{
				return delegate(DoituongnuoiEntity entity,DoituongnuoiEntity other)
				{
					return entity.sTendoituong.CompareTo(other.sTendoituong);
				};
			}
		}
		public static Comparison<DoituongnuoiEntity> COMPARISON_sKytu
		{
			get
			{
				return delegate(DoituongnuoiEntity entity,DoituongnuoiEntity other)
				{
					return entity.sKytu.CompareTo(other.sKytu);
				};
			}
		}
        #endregion
    }
}
