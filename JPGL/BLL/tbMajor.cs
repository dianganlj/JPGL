using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using JPGL.Model;
namespace JPGL.BLL
{
	/// <summary>
	/// tbMajor
	/// </summary>
	public partial class tbMajor
	{
		private readonly JPGL.DAL.tbMajor dal=new JPGL.DAL.tbMajor();
		public tbMajor()
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
		public bool Exists(int MajorNo)
		{
			return dal.Exists(MajorNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(JPGL.Model.tbMajor model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JPGL.Model.tbMajor model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MajorNo)
		{
			
			return dal.Delete(MajorNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MajorNolist )
		{
			return dal.DeleteList(MajorNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbMajor GetModel(int MajorNo)
		{
			
			return dal.GetModel(MajorNo);
		}
        public JPGL.Model.tbMajor GetModel(string  MajorName)
        {

            return dal.GetModel(MajorName);
        }


		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public JPGL.Model.tbMajor GetModelByCache(int MajorNo)
		{
			
			string CacheKey = "tbMajorModel-" + MajorNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MajorNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (JPGL.Model.tbMajor)objModel;
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
		public List<JPGL.Model.tbMajor> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JPGL.Model.tbMajor> DataTableToList(DataTable dt)
		{
			List<JPGL.Model.tbMajor> modelList = new List<JPGL.Model.tbMajor>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				JPGL.Model.tbMajor model;
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

