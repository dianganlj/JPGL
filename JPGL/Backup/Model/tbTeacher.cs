using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbTeacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbTeacher
	{
		public tbTeacher()
		{}
		#region Model
		private string _teacherno;
		private string _teachername;
		private string _teacherlevel;
		private string _teacherdepart;
		private string _teachertel;
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
		public string TeacherName
		{
			set{ _teachername=value;}
			get{return _teachername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherLevel
		{
			set{ _teacherlevel=value;}
			get{return _teacherlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherDepart
		{
			set{ _teacherdepart=value;}
			get{return _teacherdepart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherTel
		{
			set{ _teachertel=value;}
			get{return _teachertel;}
		}
		#endregion Model

	}
}

