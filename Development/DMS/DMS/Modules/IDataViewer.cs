using System;
using System.Data;

namespace SCM.Presentation
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDataViewer
	{
		DataTable DataSource{get;}
		void InitData();
		void BindDataToControl();
		void RefreshDB();
	}
}
