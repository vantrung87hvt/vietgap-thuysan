/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:42 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class PollAnswerEntity
    {
        public PollAnswerEntity()
        {
			m_ianswerid=0;
			m_sanswer="";
			m_icount=0;
			m_ipollid=0;
        }
		private Int32 m_ianswerid;
		public Int32 iAnswerID
		{
			get { return m_ianswerid ; }
			set { m_ianswerid = value; }
		}
		private String m_sanswer;
		public String sAnswer
		{
			get { return m_sanswer ; }
			set { m_sanswer = value; }
		}
		private Int32 m_icount;
		public Int32 iCount
		{
			get { return m_icount ; }
			set { m_icount = value; }
		}
		private Int32 m_ipollid;
		public Int32 iPollID
		{
			get { return m_ipollid ; }
			set { m_ipollid = value; }
		}

        #region Comparison
        public static List<PollAnswerEntity> Sort(List<PollAnswerEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PollAnswerEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PollAnswerEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PollAnswerEntity> COMPARISON_iAnswerID
		{
			get
			{
				return delegate(PollAnswerEntity entity,PollAnswerEntity other)
				{
					return entity.iAnswerID.CompareTo(other.iAnswerID);
				};
			}
		}
		public static Comparison<PollAnswerEntity> COMPARISON_sAnswer
		{
			get
			{
				return delegate(PollAnswerEntity entity,PollAnswerEntity other)
				{
					return entity.sAnswer.CompareTo(other.sAnswer);
				};
			}
		}
		public static Comparison<PollAnswerEntity> COMPARISON_iCount
		{
			get
			{
				return delegate(PollAnswerEntity entity,PollAnswerEntity other)
				{
					return entity.iCount.CompareTo(other.iCount);
				};
			}
		}
		public static Comparison<PollAnswerEntity> COMPARISON_iPollID
		{
			get
			{
				return delegate(PollAnswerEntity entity,PollAnswerEntity other)
				{
					return entity.iPollID.CompareTo(other.iPollID);
				};
			}
		}
        #endregion
    }
}
