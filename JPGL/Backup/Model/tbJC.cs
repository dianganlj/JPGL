using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbJC:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbJC
	{
		public tbJC()
		{}
		#region Model
		private string _jcno;
		private string _courseno;
		private string _teacherno;
		private string _jcroom;
		/// <summary>
		/// 
		/// </summary>
		public string JCNo
		{
			set{ _jcno=value;}
			get{return _jcno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CourseNo
		{
			set{ _courseno=value;}
			get{return _courseno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherNo
		{
			set{ _teacherno=value;}
			get{return _teacherno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JCRoom
		{
			set{ _jcroom=value;}
			get{return _jcroom;}
		}
		#endregion Model

	}
}

