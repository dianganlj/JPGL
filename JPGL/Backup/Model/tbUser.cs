using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbUser
	{
		public tbUser()
		{}
		#region Model
		private string _userno;
		private string _username;
		private string _userpwd;
		private int? _roleno;
		/// <summary>
		/// 
		/// </summary>
		public string UserNo
		{
			set{ _userno=value;}
			get{return _userno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPWD
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleNo
		{
			set{ _roleno=value;}
			get{return _roleno;}
		}
		#endregion Model

	}
}

