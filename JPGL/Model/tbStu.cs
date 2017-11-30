using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbStu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbStu
	{
		public tbStu()
		{}
		#region Model
		private string _stuno;
		private string _stuname;
		private  tbMajor _tbmajor;
		private string _stugrade;
		private string _stutel;
		private decimal? _stucredit;
		/// <summary>
		/// 
		/// </summary>
		public string StuNo
		{
			set{ _stuno=value;}
			get{return _stuno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuName
		{
			set{ _stuname=value;}
			get{return _stuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public tbMajor tbMajor
		{
            set { _tbmajor = value; }
            get { return _tbmajor; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuGrade
		{
			set{ _stugrade=value;}
			get{return _stugrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuTel
		{
			set{ _stutel=value;}
			get{return _stutel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StuCredit
		{
			set{ _stucredit=value;}
			get{return _stucredit;}
		}
		#endregion Model

	}
}

