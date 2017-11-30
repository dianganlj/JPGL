using System;
namespace JPGL.Model
{
	/// <summary>
	/// tbSC:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbSC
	{
		public tbSC()
		{}
		#region Model
		private int _scno;
		private string _stuno;
		private string _jcno;
		private decimal? _corsescore;
		/// <summary>
		/// 
		/// </summary>
		public int SCNo
		{
			set{ _scno=value;}
			get{return _scno;}
		}
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
		public string JCNo
		{
			set{ _jcno=value;}
			get{return _jcno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CorseScore
		{
			set{ _corsescore=value;}
			get{return _corsescore;}
		}
		#endregion Model

	}
}

