using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace DMS.Utils
{
	/// <summary>
	/// Summary description for clsZip.
	/// </summary>
	public class clsZip
	{
		public clsZip()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Zip a set of files
		/// </summary>
		/// <remarks>
		/// Author			: Le Tien Phat - FSOFT G3
		/// Modifications	: Created 24-Apr-2011
		/// </remarks>
		/// <param name="fileNames">Name of files are not equal</param>
		/// <param name="zipFileName"></param>
		/// <param name="password">null if do not use password</param>
		public static void ZipFiles(string[] fileNames, string zipFileName, string password)
		{					
			Crc32 crc = new Crc32();
			ZipOutputStream s = new ZipOutputStream(File.Create(zipFileName));
		
			try
			{
				s.Password = password;
				s.SetLevel(6); // 0 - store only to 9 - means best compression
		
				foreach (string file in fileNames) 
				{
					FileStream fs = File.OpenRead(file);
					byte[] buffer;
					ZipEntry entry;
			
					try
					{
						buffer = new byte[fs.Length];
						fs.Read(buffer, 0, buffer.Length);
						entry = new ZipEntry(Path.GetFileName(file));
			
						entry.DateTime = DateTime.Now;
			
						// set Size and the crc, because the information
						// about the size and crc should be stored in the header
						// if it is not set it is automatically written in the footer.
						// (in this case size == crc == -1 in the header)
						// Some ZIP programs have problems with zip files that don't store
						// the size and crc in the header.
						entry.Size = fs.Length;
						fs.Close();
					}
					catch(Exception ex)
					{
						if(fs != null)
						{
							fs.Close();
						}
						throw ex;
					}
			
					crc.Reset();
					crc.Update(buffer);
			
					entry.Crc  = crc.Value;
			
					s.PutNextEntry(entry);
			
					s.Write(buffer, 0, buffer.Length);
			
				}
		
				s.Finish();
				s.Close();
			}
			catch(Exception ex)
			{
				if(s != null)
				{
					s.Close();
				}
				throw ex;
			}
		}

		/// <summary>
		/// Zip a file
		/// </summary>
		/// <remarks>
		/// Author			: Pham Duong Vu - FSOFT G3
		/// Modifications	: Created 25-Apr-2011
		/// </remarks>
		/// <param name="strFileName">File name need to zip</param>
		/// <param name="strZipFileName">File name to zip ext: .zip </param>
		/// <param name="strPassword">null if do not use password</param>
		public static void ZipFiles(string strFileName, string strZipFileName, string strPassword)
		{					
			Crc32 crc = new Crc32();
			ZipOutputStream s = new ZipOutputStream(File.Create(strZipFileName));
		
			try
			{
				s.Password = strPassword;
				s.SetLevel(6); // 0 - store only to 9 - means best compression
		
		
				FileStream fs = File.OpenRead(strFileName);
				byte[] buffer;
				ZipEntry entry;
		
				try
				{
					buffer = new byte[fs.Length];
					fs.Read(buffer, 0, buffer.Length);
					entry = new ZipEntry(Path.GetFileName(strFileName));
		
					entry.DateTime = DateTime.Now;
		
					// set Size and the crc, because the information
					// about the size and crc should be stored in the header
					// if it is not set it is automatically written in the footer.
					// (in this case size == crc == -1 in the header)
					// Some ZIP programs have problems with zip files that don't store
					// the size and crc in the header.
					entry.Size = fs.Length;
					fs.Close();
				}
				catch(Exception ex)
				{
					if(fs != null)
					{
						fs.Close();
					}
					throw ex;
				}
		
				crc.Reset();
				crc.Update(buffer);
		
				entry.Crc  = crc.Value;
		
				s.PutNextEntry(entry);
		
				s.Write(buffer, 0, buffer.Length);
		
				s.Finish();
				s.Close();
			}
			catch(Exception ex)
			{
				if(s != null)
				{
					s.Close();
				}
				throw ex;
			}
		}

		/// <summary>
		/// Unzip a file
		/// </summary>
		/// <remarks>
		/// Author			: Le Tien Phat - FSOFT G3
		/// Modifications	: Created 24-Apr-2011
		/// </remarks>
		/// <param name="zipFileName">Name of files are not equal</param>
		/// <param name="path"></param>
		/// <param name="password">null if do not use password</param>
		public static void UnzipFile(string zipFileName, string path, string password)
		{
			ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName));

			try
			{		
				ZipEntry theEntry;
				s.Password = password;

				while ((theEntry = s.GetNextEntry()) != null) 
				{																		
					string fileName = RemoveEndBackSlash(path) + @"\" + Path.GetFileName(theEntry.Name);			
			
					if (fileName != String.Empty) 
					{
						FileStream streamWriter = File.Create(fileName);
				
						try
						{
							int size = 2048;
							byte[] data = new byte[2048];
							while (true) 
							{
								size = s.Read(data, 0, data.Length);
								if (size > 0) 
								{
									streamWriter.Write(data, 0, size);
								} 
								else 
								{
									break;
								}
							}
				
							streamWriter.Close();
						}
						catch(Exception ex)
						{
							if(streamWriter != null)
							{
								streamWriter.Close();
							}
							throw ex;
						}
					}
				}
				s.Close();
			}
			catch(Exception ex)
			{
				if(s != null)
				{
					s.Close();
				}
				throw ex;
			}
		}

		/// <summary>
		/// Check zip file is encrypted or not
		/// </summary>
		/// <param name="zipFileName"></param>
		/// <returns></returns>
		public static bool IsEncrypt(string zipFileName)
		{
			bool blnReturn;
			ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName));
		
			try
			{
				ZipEntry theEntry = s.GetNextEntry();
				blnReturn =  theEntry.IsCrypted;
				s.Close();			
				return blnReturn;
			}
			catch(Exception ex)
			{
				if(s != null)
				{
					s.Close();
				}
				throw ex;
			}
		}

		/// <summary>
		/// Remove end back slash in path string
		/// </summary>
		/// <remarks>
		/// Author			: Le Tien Phat - FSOFT G3
		/// Modifications	: Created 19-Apr-2011
		/// </remarks>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string RemoveEndBackSlash(string path)
		{
			if(path.Substring(path.Length - 1, 1)== "\\")
				return path.Substring(0, path.Length - 1);
			else
				return path;
		}
	}
}
