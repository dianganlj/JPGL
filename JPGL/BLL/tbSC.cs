using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using JPGL.Model;
namespace JPGL.BLL
{
	/// <summary>
	/// tbSC
	/// </summary>
	public partial class tbSC
	{
		private readonly JPGL.DAL.tbSC dal=new JPGL.DAL.tbSC();
		public tbSC()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SCNo)
		{
			return dal.Exists(SCNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(JPGL.Model.tbSC model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JPGL.Model.tbSC model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SCNo)
		{
			
			return dal.Delete(SCNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SCNolist )
		{
			return dal.DeleteList(SCNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbSC GetModel(int SCNo)
		{
			
			return dal.GetModel(SCNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public JPGL.Model.tbSC GetModelByCache(int SCNo)
		{
			
			string CacheKey = "tbSCModel-" + SCNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SCNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (JPGL.Model.tbSC)objModel;
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
		public List<JPGL.Model.tbSC> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JPGL.Model.tbSC> DataTableToList(DataTable dt)
		{
			List<JPGL.Model.tbSC> modelList = new List<JPGL.Model.tbSC>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				JPGL.Model.tbSC model;
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

