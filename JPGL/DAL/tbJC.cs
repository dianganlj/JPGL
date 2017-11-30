using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace JPGL.DAL
{
	/// <summary>
	/// 数据访问类:tbJC
	/// </summary>
	public partial class tbJC
	{
		public tbJC()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JCNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbJC");
			strSql.Append(" where JCNo=@JCNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@JCNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = JCNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JPGL.Model.tbJC model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbJC(");
			strSql.Append("JCNo,CourseNo,TeacherNo,JCRoom)");
			strSql.Append(" values (");
			strSql.Append("@JCNo,@CourseNo,@TeacherNo,@JCRoom)");
			SqlParameter[] parameters = {
					new SqlParameter("@JCNo", SqlDbType.VarChar,50),
					new SqlParameter("@CourseNo", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
					new SqlParameter("@JCRoom", SqlDbType.VarChar,50)};
			parameters[0].Value = model.JCNo;
			parameters[1].Value = model.CourseNo;
			parameters[2].Value = model.TeacherNo;
			parameters[3].Value = model.JCRoom;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JPGL.Model.tbJC model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbJC set ");
			strSql.Append("CourseNo=@CourseNo,");
			strSql.Append("TeacherNo=@TeacherNo,");
			strSql.Append("JCRoom=@JCRoom");
			strSql.Append(" where JCNo=@JCNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseNo", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
					new SqlParameter("@JCRoom", SqlDbType.VarChar,50),
					new SqlParameter("@JCNo", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CourseNo;
			parameters[1].Value = model.TeacherNo;
			parameters[2].Value = model.JCRoom;
			parameters[3].Value = model.JCNo;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string JCNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbJC ");
			strSql.Append(" where JCNo=@JCNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@JCNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = JCNo;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string JCNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbJC ");
			strSql.Append(" where JCNo in ("+JCNolist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbJC GetModel(string JCNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 JCNo,CourseNo,TeacherNo,JCRoom from tbJC ");
			strSql.Append(" where JCNo=@JCNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@JCNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = JCNo;

			JPGL.Model.tbJC model=new JPGL.Model.tbJC();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbJC DataRowToModel(DataRow row)
		{
			JPGL.Model.tbJC model=new JPGL.Model.tbJC();
			if (row != null)
			{
				if(row["JCNo"]!=null)
				{
					model.JCNo=row["JCNo"].ToString();
				}
				if(row["CourseNo"]!=null)
				{
					model.CourseNo=row["CourseNo"].ToString();
				}
				if(row["TeacherNo"]!=null)
				{
					model.TeacherNo=row["TeacherNo"].ToString();
				}
				if(row["JCRoom"]!=null)
				{
					model.JCRoom=row["JCRoom"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select JCNo,CourseNo,TeacherNo,JCRoom ");
			strSql.Append(" FROM tbJC ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" JCNo,CourseNo,TeacherNo,JCRoom ");
			strSql.Append(" FROM tbJC ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbJC ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.JCNo desc");
			}
			strSql.Append(")AS Row, T.*  from tbJC T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tbJC";
			parameters[1].Value = "JCNo";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

