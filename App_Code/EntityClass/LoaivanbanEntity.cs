/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/21/2011 4:39:36 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class LoaivanbanEntity
    {
        public LoaivanbanEntity()
        {
			m_pk_iloaivanbanid=0;
			m_stenloai="";
        }
		private Int32 m_pk_iloaivanbanid;
		public Int32 PK_iLoaivanbanID
		{
			get { return m_pk_iloaivanbanid ; }
			set { m_pk_iloaivanbanid = value; }
		}
		private String m_stenloai;
		public String sTenloai
		{
			get { return m_stenloai ; }
			set { m_stenloai = value; }
		}

        #region Comparison
        public static List<LoaivanbanEntity> Sort(List<LoaivanbanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(LoaivanbanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<LoaivanbanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<LoaivanbanEntity> COMPARISON_PK_iLoaivanbanID
		{
			get
			{
				return delegate(LoaivanbanEntity entity,LoaivanbanEntity other)
				{
					return entity.PK_iLoaivanbanID.CompareTo(other.PK_iLoaivanbanID);
				};
			}
		}
		public static Comparison<LoaivanbanEntity> COMPARISON_sTenloai
		{
			get
			{
				return delegate(LoaivanbanEntity entity,LoaivanbanEntity other)
				{
					return entity.sTenloai.CompareTo(other.sTenloai);
				};
			}
		}
        #endregion
    }
}
