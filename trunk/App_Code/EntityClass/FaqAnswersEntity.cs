/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/18/2012 8:05:24 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class FaqAnswersEntity
    {
        public FaqAnswersEntity()
        {
			m_pk_ifaqanswerid=0;
			m_fk_ifaqid=0;
			m_scontent="";
        }
		private Int64 m_pk_ifaqanswerid;
		public Int64 PK_iFaqAnswerID
		{
			get { return m_pk_ifaqanswerid ; }
			set { m_pk_ifaqanswerid = value; }
		}
		private Int64 m_fk_ifaqid;
		public Int64 FK_iFaqID
		{
			get { return m_fk_ifaqid ; }
			set { m_fk_ifaqid = value; }
		}
		private String m_scontent;
		public String sContent
		{
			get { return m_scontent ; }
			set { m_scontent = value; }
		}

        #region Comparison
        public static List<FaqAnswersEntity> Sort(List<FaqAnswersEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(FaqAnswersEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<FaqAnswersEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<FaqAnswersEntity> COMPARISON_PK_iFaqAnswerID
		{
			get
			{
				return delegate(FaqAnswersEntity entity,FaqAnswersEntity other)
				{
					return entity.PK_iFaqAnswerID.CompareTo(other.PK_iFaqAnswerID);
				};
			}
		}
		public static Comparison<FaqAnswersEntity> COMPARISON_FK_iFaqID
		{
			get
			{
				return delegate(FaqAnswersEntity entity,FaqAnswersEntity other)
				{
					return entity.FK_iFaqID.CompareTo(other.FK_iFaqID);
				};
			}
		}
		public static Comparison<FaqAnswersEntity> COMPARISON_sContent
		{
			get
			{
				return delegate(FaqAnswersEntity entity,FaqAnswersEntity other)
				{
					return entity.sContent.CompareTo(other.sContent);
				};
			}
		}
        #endregion
    }
}
