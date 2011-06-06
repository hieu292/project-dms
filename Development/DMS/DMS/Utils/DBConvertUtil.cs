using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SCM.Utils
{
    /// <summary>
    /// This class is used to get data value from DataReader and return formatted data.
    /// </summary>
    /// <author>Generated by <a href="mailto:nguyenld2020@gmail.com">Nguyen Le Dinh</a></author>
    public static class DBConvertUtil
    {
        /// <summary>
        /// Get String value from Datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string ParseDBToString(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? string.Empty : (string)dataReader[column];
        }

        /// <summary>
        /// Get DateTime value from Datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static DateTime ParseDBToDateTime(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? DateTime.MinValue : (DateTime)dataReader[column];
        }

        /// <summary>
        /// Get Int value from Datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static Int32 ParseDBToInt(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? Int32.MinValue : (Int32)dataReader[column];
        }

        /// <summary>
        /// Get short value from Datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static short ParseDBToShort(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? short.MinValue : (short)dataReader[column];
        }

        /// <summary>
        /// Get float value from Datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static float ParseDBToFloat(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? float.MinValue : (float)dataReader[column];
        }

        /// <summary>
        /// Get Double Value from datareader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static Double ParseDBToDouble(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? Double.MinValue : (Double)dataReader[column];
        }

        public static Decimal ParseDBToDecimal(IDataReader dataReader, string column)
        {
            return dataReader[column] == DBNull.Value ? Decimal.MinValue : (Decimal)dataReader[column];
        }

        /// <summary>
        /// Parse string value to Database value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ParseStringToDB(string value)
        {
            if (value == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Parse Datetime value to Database value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ParseDatetimeToDB(DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Parse Int value to Database value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ParseIntToDB(int value)
        {
            if (value == int.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Parse Double value to Database value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ParseDBToDouble(double value)
        {
            if (value == double.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }
}