

using System;
using System.Collections;

namespace SCM.DataAccessObject
{
	#region Class SCM_PARAMETER
	/// <summary>
	///    
	/// </summary>
	[Serializable]
	public class SCM_PARAMETER
	{
		#region Private Members
	
	private string _ParamId;
	private string _ParamName;
	private string _ParamValue;
	private string _Description;       
	#endregion // End of Private Members

		#region Default ( Empty ) Class Constuctor
	public SCM_PARAMETER()
	{
	
	_ParamId = String.Empty; 
	_ParamName = String.Empty; 
	_ParamValue = String.Empty; 
	_Description = String.Empty; 
	}
	#endregion // End of Default ( Empty ) Class Constuctor

		#region Public Accessors 

	/// <summary>
	/// Encapsulate ParamId property
	/// </summary>       
	public string ParamId
	{
		get { return _ParamId; }
		set { _ParamId = value; }
	}
	

	/// <summary>
	/// Encapsulate ParamName property
	/// </summary>       
	public string ParamName
	{
		get { return _ParamName; }
		set { _ParamName = value; }
	}
	

	/// <summary>
	/// Encapsulate ParamValue property
	/// </summary>       
	public string ParamValue
	{
		get { return _ParamValue; }
		set { _ParamValue = value; }
	}
	

	/// <summary>
	/// Encapsulate Description property
	/// </summary>       
	public string Description
	{
		get { return _Description; }
		set { _Description = value; }
	}
	

	#endregion // End of Public Accessors 
	}       
	#endregion // Class SCM_PARAMETER
}

