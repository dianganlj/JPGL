using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace JPGL.DAL
{
	/// <summary>
	/// 数据访问类:tbRole
	/// </summary>
	public partial class tbRole
	{
		public tbRole()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleNo", "tbRole"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbRole");
			strSql.Append(" where RoleNo=@RoleNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleNo", SqlDbType.Int,4)			};
			parameters[0].Value = RoleNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JPGL.Model.tbRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbRole(");
			strSql.Append("RoleNo,RoleName)");
			strSql.Append(" values (");
			strSql.Append("@RoleNo,@RoleName)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleNo", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RoleNo;
			parameters[1].Value = model.RoleName;

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
		public bool Update(JPGL.Model.tbRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbRole set ");
			strSql.Append("RoleName=@RoleName");
			strSql.Append(" where RoleNo=@RoleNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleNo", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RoleNo;

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
		public bool Delete(int RoleNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbRole ");
			strSql.Append(" where RoleNo=@RoleNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleNo", SqlDbType.Int,4)			};
			parameters[0].Value = RoleNo;

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
		public bool DeleteList(string RoleNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbRole ");
			strSql.Append(" where RoleNo in ("+RoleNolist + ")  ");
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
		public JPGL.Model.tbRole GetModel(int RoleNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleNo,RoleName from tbRole ");
			strSql.Append(" where RoleNo=@RoleNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleNo", SqlDbType.Int,4)			};
			parameters[0].Value = RoleNo;

			JPGL.Model.tbRole model=new JPGL.Model.tbRole();
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
		public JPGL.Model.tbRole DataRowToModel(DataRow row)
		{
			JPGL.Model.tbRole model=new JPGL.Model.tbRole();
			if (row != null)
			{
				if(row["RoleNo"]!=null && row["RoleNo"].ToString()!="")
				{
					model.RoleNo=int.Parse(row["RoleNo"].ToString());
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
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
			strSql.Append("select RoleNo,RoleName ");
			strSql.Append(" FROM tbRole ");
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
			strSql.Append(" RoleNo,RoleName ");
			strSql.Append(" FROM tbRole ");
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
			strSql.Append("select count(1) FROM tbRole ");
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
				strSql.Append("order by T.RoleNo desc");
			}
			strSql.Append(")AS Row, T.*  from tbRole T ");
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
			parameters[0].Value = "tbRole";
			parameters[1].Value = "RoleNo";
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

