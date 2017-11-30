using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace JPGL.DAL
{
	/// <summary>
	/// 数据访问类:tbSC
	/// </summary>
	public partial class tbSC
	{
		public tbSC()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SCNo", "tbSC"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SCNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbSC");
			strSql.Append(" where SCNo=@SCNo");
			SqlParameter[] parameters = {
					new SqlParameter("@SCNo", SqlDbType.Int,4)
			};
			parameters[0].Value = SCNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(JPGL.Model.tbSC model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbSC(");
			strSql.Append("StuNo,JCNo,CorseScore)");
			strSql.Append(" values (");
			strSql.Append("@StuNo,@JCNo,@CorseScore)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,50),
					new SqlParameter("@JCNo", SqlDbType.VarChar,50),
					new SqlParameter("@CorseScore", SqlDbType.Float,8)};
			parameters[0].Value = model.StuNo;
			parameters[1].Value = model.JCNo;
			parameters[2].Value = model.CorseScore;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(JPGL.Model.tbSC model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbSC set ");
			strSql.Append("StuNo=@StuNo,");
			strSql.Append("JCNo=@JCNo,");
			strSql.Append("CorseScore=@CorseScore");
			strSql.Append(" where SCNo=@SCNo");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,50),
					new SqlParameter("@JCNo", SqlDbType.VarChar,50),
					new SqlParameter("@CorseScore", SqlDbType.Float,8),
					new SqlParameter("@SCNo", SqlDbType.Int,4)};
			parameters[0].Value = model.StuNo;
			parameters[1].Value = model.JCNo;
			parameters[2].Value = model.CorseScore;
			parameters[3].Value = model.SCNo;

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
		public bool Delete(int SCNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbSC ");
			strSql.Append(" where SCNo=@SCNo");
			SqlParameter[] parameters = {
					new SqlParameter("@SCNo", SqlDbType.Int,4)
			};
			parameters[0].Value = SCNo;

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
		public bool DeleteList(string SCNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbSC ");
			strSql.Append(" where SCNo in ("+SCNolist + ")  ");
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
		public JPGL.Model.tbSC GetModel(int SCNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SCNo,StuNo,JCNo,CorseScore from tbSC ");
			strSql.Append(" where SCNo=@SCNo");
			SqlParameter[] parameters = {
					new SqlParameter("@SCNo", SqlDbType.Int,4)
			};
			parameters[0].Value = SCNo;

			JPGL.Model.tbSC model=new JPGL.Model.tbSC();
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
		public JPGL.Model.tbSC DataRowToModel(DataRow row)
		{
			JPGL.Model.tbSC model=new JPGL.Model.tbSC();
			if (row != null)
			{
				if(row["SCNo"]!=null && row["SCNo"].ToString()!="")
				{
					model.SCNo=int.Parse(row["SCNo"].ToString());
				}
				if(row["StuNo"]!=null)
				{
					model.StuNo=row["StuNo"].ToString();
				}
				if(row["JCNo"]!=null)
				{
					model.JCNo=row["JCNo"].ToString();
				}
				if(row["CorseScore"]!=null && row["CorseScore"].ToString()!="")
				{
					model.CorseScore=decimal.Parse(row["CorseScore"].ToString());
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
			strSql.Append("select SCNo,StuNo,JCNo,CorseScore ");
			strSql.Append(" FROM tbSC ");
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
			strSql.Append(" SCNo,StuNo,JCNo,CorseScore ");
			strSql.Append(" FROM tbSC ");
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
			strSql.Append("select count(1) FROM tbSC ");
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
				strSql.Append("order by T.SCNo desc");
			}
			strSql.Append(")AS Row, T.*  from tbSC T ");
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
			parameters[0].Value = "tbSC";
			parameters[1].Value = "SCNo";
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

