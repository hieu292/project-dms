using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace DMS.Utils
{
    public class clsIOUtil
    {
        public static String GenerateTempFolderName(String zipFile)
        {
            FileInfo file = new FileInfo(zipFile);
            String folder = file.DirectoryName;
            String tmpFolder = folder + "/Tmp";
            if (!Directory.Exists(tmpFolder))
            {
                return tmpFolder;
            }
            else
            {
                int i = 0;
                while (true)
                {
                    String str = tmpFolder + i;
                    if (!Directory.Exists(str))
                        return str;
                    else
                        i++;
                }
            }
        }

        public static String GetFirstFile(String folder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            if (!dir.Exists)
                return null;
            FileInfo[] files = dir.GetFiles();
            if (files.Length == 0)
                return null;
            return files[0].FullName;
        }

        public static void DeleteFolder(String folder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            if (!dir.Exists)
                return;
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
                file.Delete();
            DirectoryInfo[] subDirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in subDirs)
            {
                DeleteFolder(subDir.FullName);
            }
            dir.Delete();
        }

        public static DataSet ReadZipFile(String filename)
        {
            FileInfo file = new FileInfo(filename);
            String tmpFolder = GenerateTempFolderName(file.FullName);
            Directory.CreateDirectory(tmpFolder);
            clsCryptography crypto = new clsCryptography();
            String pwd = crypto.GenPWDByFilename(file.Name);
            clsZip.UnzipFile(file.FullName, tmpFolder, pwd);
            String filename2 = GetFirstFile(tmpFolder);
            DataSet ds = new DataSet();
            ds.ReadXml(filename2);
            DeleteFolder(tmpFolder);
            return ds;
        }

        public static void SaveZipFile2(DataSet ds, String filename)
        {
            ds.WriteXml(filename, XmlWriteMode.WriteSchema);
            FileInfo file = new FileInfo(filename);
            String nameWithoutExt = GetNameWithoutExt(file.Name);
            String newName = file.DirectoryName + "/" + nameWithoutExt + ".zip";
            clsCryptography crypto = new clsCryptography();
            String pwd = crypto.GenPWDByFilename(newName);
            clsZip.ZipFiles(filename, newName, pwd);
            file.Delete();
        }
        public static void SaveZipFile(DataSet ds, String filename)
        {
            FileInfo file = new FileInfo(filename);
            String nameWithoutExt = GetNameWithoutExt(file.Name);
            String newName = file.DirectoryName + "/" + nameWithoutExt + ".xml";
            ds.WriteXml(newName, XmlWriteMode.WriteSchema);
            clsCryptography crypto = new clsCryptography();
            String pwd = crypto.GenPWDByFilename(filename);
            clsZip.ZipFiles(newName, filename, pwd);
            File.Delete(newName);
        }
        public static String GetNameWithoutExt(String filename)
        {
            int i = filename.LastIndexOf('.');
            if (i < 0)
                return filename;
            else
            {
                String str = filename.Substring(0, i);
                return str;
            }
        }
    }
}
