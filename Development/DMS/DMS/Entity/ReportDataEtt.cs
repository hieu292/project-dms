using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace SCM.DataAccessObject
{
    #region Class ReportData
    /// <summary>
    ///    
    /// </summary>
    [Serializable]
    public class ReportDataEtt
    {
        #region Private Members
        private List<ReportParamEtt> parameters;
        private List<DataTable> datasource;
        private string path;
        private string pageTitle;
        private string name;
        private string bannerName;
        private string imgUrl;

        public string BannerName
        {
            get { return bannerName; }
            set { bannerName = value; }
        }

        public string ImgUrl
        {
            get { return imgUrl; }
            set { imgUrl = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PageTitle
        {
            get { return pageTitle; }
            set { pageTitle = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public List<ReportParamEtt> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public List<DataTable> Datasource
        {
            get { return datasource; }
            set { datasource = value; }
        }
        #endregion // End of Private Members

        #region Default ( Empty ) Class Constuctor
        public ReportDataEtt()
        {
            parameters = new List<ReportParamEtt>();
            datasource = new List<DataTable>();
        }
        #endregion // End of Default ( Empty ) Class Constuctor
    }
    #endregion // Class User
}

