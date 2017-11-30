using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace JPGL.DAL
{
	/// <summary>
	/// 数据访问类:tbTeacher
	/// </summary>
	public partial class tbTeacher
	{
		public tbTeacher()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TeacherNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbTeacher");
			strSql.Append(" where TeacherNo=@TeacherNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = TeacherNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JPGL.Model.tbTeacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbTeacher(");
			strSql.Append("TeacherNo,TeacherName,TeacherLevel,TeacherDepart,TeacherTel)");
			strSql.Append(" values (");
			strSql.Append("@TeacherNo,@TeacherName,@TeacherLevel,@TeacherDepart,@TeacherTel)");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherName", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherLevel", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherDepart", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherTel", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TeacherNo;
			parameters[1].Value = model.TeacherName;
			parameters[2].Value = model.TeacherLevel;
			parameters[3].Value = model.TeacherDepart;
			parameters[4].Value = model.TeacherTel;

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
		public bool Update(JPGL.Model.tbTeacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbTeacher set ");
			strSql.Append("TeacherName=@TeacherName,");
			strSql.Append("TeacherLevel=@TeacherLevel,");
			strSql.Append("TeacherDepart=@TeacherDepart,");
			strSql.Append("TeacherTel=@TeacherTel");
			strSql.Append(" where TeacherNo=@TeacherNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherName", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherLevel", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherDepart", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherTel", SqlDbType.VarChar,50),
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TeacherName;
			parameters[1].Value = model.TeacherLevel;
			parameters[2].Value = model.TeacherDepart;
			parameters[3].Value = model.TeacherTel;
			parameters[4].Value = model.TeacherNo;

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
		public bool Delete(string TeacherNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbTeacher ");
			strSql.Append(" where TeacherNo=@TeacherNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = TeacherNo;

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
		public bool DeleteList(string TeacherNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbTeacher ");
			strSql.Append(" where TeacherNo in ("+TeacherNolist + ")  ");
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
		public JPGL.Model.tbTeacher GetModel(string TeacherNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TeacherNo,TeacherName,TeacherLevel,TeacherDepart,TeacherTel from tbTeacher ");
			strSql.Append(" where TeacherNo=@TeacherNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = TeacherNo;

			JPGL.Model.tbTeacher model=new JPGL.Model.tbTeacher();
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
		public JPGL.Model.tbTeacher DataRowToModel(DataRow row)
		{
			JPGL.Model.tbTeacher model=new JPGL.Model.tbTeacher();
			if (row != null)
			{
				if(row["TeacherNo"]!=null)
				{
					model.TeacherNo=row["TeacherNo"].ToString();
				}
				if(row["TeacherName"]!=null)
				{
					model.TeacherName=row["TeacherName"].ToString();
				}
				if(row["TeacherLevel"]!=null)
				{
					model.TeacherLevel=row["TeacherLevel"].ToString();
				}
				if(row["TeacherDepart"]!=null)
				{
					model.TeacherDepart=row["TeacherDepart"].ToString();
				}
				if(row["TeacherTel"]!=null)
				{
					model.TeacherTel=row["TeacherTel"].ToString();
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
			strSql.Append("select TeacherNo,TeacherName,TeacherLevel,TeacherDepart,TeacherTel ");
			strSql.Append(" FROM tbTeacher ");
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
			strSql.Append(" TeacherNo,TeacherName,TeacherLevel,TeacherDepart,TeacherTel ");
			strSql.Append(" FROM tbTeacher ");
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
			strSql.Append("select count(1) FROM tbTeacher ");
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
				strSql.Append("order by T.TeacherNo desc");
			}
			strSql.Append(")AS Row, T.*  from tbTeacher T ");
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
			parameters[0].Value = "tbTeacher";
			parameters[1].Value = "TeacherNo";
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

