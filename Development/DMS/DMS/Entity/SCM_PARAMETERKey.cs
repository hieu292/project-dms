

using System;
using System.Collections;

namespace SCM.DataAccessObject
{
	#region Class SCM_PARAMETERIdentity
	/// <summary>
	///    
	/// </summary>
	[Serializable]
	public class SCM_PARAMETERIdentity
	{   
		#region Private Members
	
	private string _ParamId;
	private string _ParamName;       
	#endregion // End of Private Members
		#region Default ( Empty ) Class Constuctor
	public SCM_PARAMETERIdentity()
	{
	
		_ParamId = String.Empty; 
		_ParamName = String.Empty; 
	}
	#endregion // End of Default ( Empty ) Class Constuctor
		#region Public Accessors 

/// <summary>
/// Encapsulate ParamId property
/// </summary>       
public string ParamId
{
    get { return _ParamId; }
    set    {_ParamId = value;}
}   


/// <summary>
/// Encapsulate ParamName property
/// </summary>       
public string ParamName
{
    get { return _ParamName; }
    set    {_ParamName = value;}
}   


#endregion // End of Public Accessors 
	}       
	#endregion // Class SCM_PARAMETER
}


