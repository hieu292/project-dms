using System;
using System.IO;
using System.Configuration;

using SCM.DataAccessObject;

namespace SCM.Utils
{
	/// <summary>
	/// Manage and Init Configurations.
	/// </summary>
	/// <remarks>
	/// Author:			NguyenLD. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsSystemConfig
	{
		protected static string m_Message = "";
		public static string GetMessage()
		{
			return m_Message;
		}

		protected static string m_ImageFolder = "";
		public static string ImageFolder
		{
			get{return m_ImageFolder;}
			set
			{
				m_ImageFolder = value;
				if(!m_ImageFolder.EndsWith("\\") && !m_ImageFolder.EndsWith("/"))
					m_ImageFolder = m_ImageFolder + "\\";
			}
		}

		protected static string m_IconFolder = "";
		public static string IconFolder
		{
			get{return m_IconFolder;}
			set
			{
				m_IconFolder = value;
				if(!m_IconFolder.EndsWith("\\") && !m_IconFolder.EndsWith("/"))
					m_IconFolder = m_IconFolder + "\\";
			}
		}

		protected static string m_UserName = "";
		public static string UserName
		{
			get{return m_UserName;}
			set{m_UserName = value;}
		}

		public clsSystemConfig(){}

		/// <summary>
		/// Init all configuration for system
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			NguyenLD. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public static bool Init()
		{
			try
			{
				clsSystemConfig.ImageFolder = ConfigurationManager.AppSettings["Resources.Images"];
				clsSystemConfig.IconFolder = ConfigurationManager.AppSettings["Resources.Icons"];
				log4net.Config.XmlConfigurator.Configure(new FileInfo("Log4Net.config"));
				clsBaseDAO.Init();
				clsResources.Init();
				clsFormManager.Config();
				clsStyleManager.Init();
				return true;
			}
			catch(Exception ex)
			{
				m_Message = ex.Message;
				return false;
			}
		}
	}
}
