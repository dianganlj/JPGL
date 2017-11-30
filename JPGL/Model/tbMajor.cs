using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbMajor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbMajor
	{
		public tbMajor()
		{}
		#region Model
		private int _majorno;
		private string _majorname;
		/// <summary>
		/// 
		/// </summary>
		public int MajorNo
		{
			set{ _majorno=value;}
			get{return _majorno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MajorName
		{
			set{ _majorname=value;}
			get{return _majorname;}
		}
		#endregion Model

	}
}

