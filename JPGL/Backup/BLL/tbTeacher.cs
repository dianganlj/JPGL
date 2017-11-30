﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using JPGL.Model;
namespace JPGL.BLL
{
	/// <summary>
	/// tbTeacher
	/// </summary>
	public partial class tbTeacher
	{
		private readonly JPGL.DAL.tbTeacher dal=new JPGL.DAL.tbTeacher();
		public tbTeacher()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TeacherNo)
		{
			return dal.Exists(TeacherNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JPGL.Model.tbTeacher model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JPGL.Model.tbTeacher model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string TeacherNo)
		{
			
			return dal.Delete(TeacherNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TeacherNolist )
		{
			return dal.DeleteList(TeacherNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JPGL.Model.tbTeacher GetModel(string TeacherNo)
		{
			
			return dal.GetModel(TeacherNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public JPGL.Model.tbTeacher GetModelByCache(string TeacherNo)
		{
			
			string CacheKey = "tbTeacherModel-" + TeacherNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TeacherNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (JPGL.Model.tbTeacher)objModel;
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
		public List<JPGL.Model.tbTeacher> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JPGL.Model.tbTeacher> DataTableToList(DataTable dt)
		{
			List<JPGL.Model.tbTeacher> modelList = new List<JPGL.Model.tbTeacher>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				JPGL.Model.tbTeacher model;
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

