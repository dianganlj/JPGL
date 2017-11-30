using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using JPGL.Model;
namespace JPGL.BLL
{
	/// <summary>
	/// tbStu
	/// </summary>
	public partial class tbStu
	{
		private readonly JPGL.DAL.tbStu dal=new JPGL.DAL.tbStu();
		public tbStu()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StuNo)
		{
			return dal.Exists(StuNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JPGL.Model.tbStu model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JPGL.Model.tbStu model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StuNo)
		{
			
			return dal.Delete(StuNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StuNolist )
		{
			return dal.DeleteList(StuNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbStu GetModel(string StuNo)
		{
			
			return dal.GetModel(StuNo);
		}

       


		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public JPGL.Model.tbStu GetModelByCache(string StuNo)
		{
			
			string CacheKey = "tbStuModel-" + StuNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StuNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (JPGL.Model.tbStu)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JPGL.Model.tbStu> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JPGL.Model.tbStu> DataTableToList(DataTable dt)
		{
			List<JPGL.Model.tbStu> modelList = new List<JPGL.Model.tbStu>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				JPGL.Model.tbStu model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

