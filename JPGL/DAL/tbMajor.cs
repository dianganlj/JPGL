using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace JPGL.DAL
{
	/// <summary>
	/// 数据访问类:tbMajor
	/// </summary>
	public partial class tbMajor
	{
		public tbMajor()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MajorNo", "tbMajor"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MajorNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbMajor");
			strSql.Append(" where MajorNo=@MajorNo");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorNo", SqlDbType.Int,4)
			};
			parameters[0].Value = MajorNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(JPGL.Model.tbMajor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbMajor(");
			strSql.Append("MajorName)");
			strSql.Append(" values (");
			strSql.Append("@MajorName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.MajorName;

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
		public bool Update(JPGL.Model.tbMajor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbMajor set ");
			strSql.Append("MajorName=@MajorName");
			strSql.Append(" where MajorNo=@MajorNo");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorName", SqlDbType.VarChar,50),
					new SqlParameter("@MajorNo", SqlDbType.Int,4)};
			parameters[0].Value = model.MajorName;
			parameters[1].Value = model.MajorNo;

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
		public bool Delete(int MajorNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbMajor ");
			strSql.Append(" where MajorNo=@MajorNo");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorNo", SqlDbType.Int,4)
			};
			parameters[0].Value = MajorNo;

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
		public bool DeleteList(string MajorNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbMajor ");
			strSql.Append(" where MajorNo in ("+MajorNolist + ")  ");
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
		public JPGL.Model.tbMajor GetModel(int MajorNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MajorNo,MajorName from tbMajor ");
			strSql.Append(" where MajorNo=@MajorNo");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorNo", SqlDbType.Int,4)
			};
			parameters[0].Value = MajorNo;

			JPGL.Model.tbMajor model=new JPGL.Model.tbMajor();
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
        public JPGL.Model.tbMajor GetModel(string  MajorName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MajorNo,MajorName from tbMajor ");
            strSql.Append(" where MajorName=@MajorName");
            SqlParameter[] parameters = {
					new SqlParameter("@MajorName", SqlDbType.VarChar,50)
			};
            parameters[0].Value = MajorName;

            JPGL.Model.tbMajor model = new JPGL.Model.tbMajor();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public JPGL.Model.tbMajor DataRowToModel(DataRow row)
		{
			JPGL.Model.tbMajor model=new JPGL.Model.tbMajor();
			if (row != null)
			{
				if(row["MajorNo"]!=null && row["MajorNo"].ToString()!="")
				{
					model.MajorNo=int.Parse(row["MajorNo"].ToString());
				}
				if(row["MajorName"]!=null)
				{
					model.MajorName=row["MajorName"].ToString();
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
			strSql.Append("select MajorNo,MajorName ");
			strSql.Append(" FROM tbMajor ");
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
			strSql.Append(" MajorNo,MajorName ");
			strSql.Append(" FROM tbMajor ");
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
			strSql.Append("select count(1) FROM tbMajor ");
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
				strSql.Append("order by T.MajorNo desc");
			}
			strSql.Append(")AS Row, T.*  from tbMajor T ");
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
			parameters[0].Value = "tbMajor";
			parameters[1].Value = "MajorNo";
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

