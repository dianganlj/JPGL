using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbCourse:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbCourse
	{
		public tbCourse()
		{}
		#region Model
		private string _courseno;
		private string _coursename;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private decimal? _coursecredit;
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
		public string CourseName
		{
			set{ _coursename=value;}
			get{return _coursename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Endtime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CourseCredit
		{
			set{ _coursecredit=value;}
			get{return _coursecredit;}
		}
		#endregion Model

	}
}

