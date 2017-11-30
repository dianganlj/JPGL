using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbRole
	{
		public tbRole()
		{}
		#region Model
		private int _roleno;
		private string _rolename;
		/// <summary>
		/// 
		/// </summary>
		public int RoleNo
		{
			set{ _roleno=value;}
			get{return _roleno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		#endregion Model

	}
}

