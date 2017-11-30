using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbAdmin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbAdmin
	{
		public tbAdmin()
		{}
		#region Model
		private int? _adminid;
		private string _adminno;
		private string _adminname;
		private string _admintel;
		/// <summary>
		/// 
		/// </summary>
		public int? AdminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminNo
		{
			set{ _adminno=value;}
			get{return _adminno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminName
		{
			set{ _adminname=value;}
			get{return _adminname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminTel
		{
			set{ _admintel=value;}
			get{return _admintel;}
		}
		#endregion Model

	}
}

