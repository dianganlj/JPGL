using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace JPGL.DAL
{
	/// <summary>
	/// 数据访问类:tbAdmin
	/// </summary>
	public partial class tbAdmin
	{
		public tbAdmin()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JPGL.Model.tbAdmin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbAdmin(");
			strSql.Append("AdminID,AdminNo,AdminName,AdminTel)");
			strSql.Append(" values (");
			strSql.Append("@AdminID,@AdminNo,@AdminName,@AdminTel)");
			SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@AdminNo", SqlDbType.VarChar,50),
					new SqlParameter("@AdminName", SqlDbType.VarChar,50),
					new SqlParameter("@AdminTel", SqlDbType.VarChar,50)};
			parameters[0].Value = model.AdminID;
			parameters[1].Value = model.AdminNo;
			parameters[2].Value = model.AdminName;
			parameters[3].Value = model.AdminTel;

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
		public bool Update(JPGL.Model.tbAdmin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbAdmin set ");
			strSql.Append("AdminID=@AdminID,");
			strSql.Append("AdminNo=@AdminNo,");
			strSql.Append("AdminName=@AdminName,");
			strSql.Append("AdminTel=@AdminTel");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@AdminNo", SqlDbType.VarChar,50),
					new SqlParameter("@AdminName", SqlDbType.VarChar,50),
					new SqlParameter("@AdminTel", SqlDbType.VarChar,50)};
			parameters[0].Value = model.AdminID;
			parameters[1].Value = model.AdminNo;
			parameters[2].Value = model.AdminName;
			parameters[3].Value = model.AdminTel;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbAdmin ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbAdmin GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AdminID,AdminNo,AdminName,AdminTel from tbAdmin ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			JPGL.Model.tbAdmin model=new JPGL.Model.tbAdmin();
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
		public JPGL.Model.tbAdmin DataRowToModel(DataRow row)
		{
			JPGL.Model.tbAdmin model=new JPGL.Model.tbAdmin();
			if (row != null)
			{
				if(row["AdminID"]!=null && row["AdminID"].ToString()!="")
				{
					model.AdminID=int.Parse(row["AdminID"].ToString());
				}
				if(row["AdminNo"]!=null)
				{
					model.AdminNo=row["AdminNo"].ToString();
				}
				if(row["AdminName"]!=null)
				{
					model.AdminName=row["AdminName"].ToString();
				}
				if(row["AdminTel"]!=null)
				{
					model.AdminTel=row["AdminTel"].ToString();
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
			strSql.Append("select AdminID,AdminNo,AdminName,AdminTel ");
			strSql.Append(" FROM tbAdmin ");
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
			strSql.Append(" AdminID,AdminNo,AdminName,AdminTel ");
			strSql.Append(" FROM tbAdmin ");
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
			strSql.Append("select count(1) FROM tbAdmin ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from tbAdmin T ");
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
			parameters[0].Value = "tbAdmin";
			parameters[1].Value = "";
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

