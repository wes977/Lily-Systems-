///-------------------------------------------------------------------------------------------------
// file:	DAL\ModularDAL.cs
//
// summary:	Implements the modular dal class
///-------------------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Web;
using System.Data.SqlClient;

using System.Configuration;
using System.Collections.Generic;

namespace LS_APIs.DAL
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A modular dal. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    class ModularDAL
    {
        /// <summary>   The connection. </summary>
        SqlConnection conn;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        
        ///-------------------------------------------------------------------------------------------------

        public ModularDAL()
        {
            ConnectionStringSettings connSettings = ConfigurationManager.ConnectionStrings["conn"];

            conn = new SqlConnection(connSettings.ConnectionString);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Inserts an update delete described by command. </summary>
        ///
        
        ///
        /// <param name="command">  The command. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool InsertUpdateDelete(string command)
        {
            bool ret = false;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();

                ret = true;
            }
            catch
            {
                //did not write to db
            }

            return ret;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects. </summary>
        ///
        
        ///
        /// <param name="command">  The command. </param>
        ///
        /// <returns>   A DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable Select(string command)
        {
            
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(command);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            return dt;
        }
    }
}
