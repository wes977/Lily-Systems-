/*
 File Name      :   Logic.cs
 Date           :   February 10, 2017
 Description    :   The logc class is responsible for the creating the sql query strings depending on the users requests.
                    Another responsibility of the logic class is to call the dal class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;
using System.Globalization;
using LS_APIs.ScheduleBuilder;
namespace LS_APIs.DAL
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A logic. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public class Logic
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the false. </summary>
        ///
        /// <value> The false. </value>
        ///-------------------------------------------------------------------------------------------------

        bool exists = false;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the false. </summary>
        ///
        /// <value> The false. </value>
        ///-------------------------------------------------------------------------------------------------

        bool ex = false;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The Read method calls the Select method from the ModularDAL class. Any command created in
        ///     the logic class that expects values back from the database use the Read method when
        ///     calling the ModularDAL class.
        /// </summary>
        ///
        
        ///
        /// <param name="command">  The SQL Server command string. </param>
        ///
        /// <returns>   DataTable - containing the response information from the database. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable Read(string command)
        {
            DataTable dt = new DataTable();
            ModularDAL dal = new ModularDAL();

            dt = dal.Select(command);
            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The Write method calls the InsertUpdateDelete methods from the ModularDAL class. Any
        ///     command created in the logic class that does not expect values back from the databse use
        ///     the Write method when calling the ModularDAL class, ie. Insert, Update and Delete
        ///     statements.
        /// </summary>
        ///
        
        ///
        /// <param name="command">  The SQL Server command string. </param>
        ///
        /// <returns>
        ///     true - if the write operation was a success, false - if it was not a success.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool Write(string command)
        {
            ModularDAL dal = new ModularDAL();

            dal.InsertUpdateDelete(command);

            return true;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     When the user selects multiple properties they want to search by ie. first name, last
        ///     name and phone number the query string needs to include those properties as a part of the
        ///     WHERE statement. This function is responsible for dynamically making the WHERE portion of
        ///     the SELECT command depending on which properties the user selects.
        /// </summary>
        ///
        
        ///
        /// <param name="prop"> The value that the cmd equals. </param>
        /// <param name="cmd">  The SQL Server WHERE statement ie. firstName = '...'. </param>
        ///
        /// <returns>   string - the select properties part of the select command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateSelectProperties(string prop, string cmd)
        {
            string ret = "";
            string and = " AND ";

            if (prop != "")
            {
                ret = String.Format(cmd, prop);
                if (exists)
                {
                    //if there is already a WHERE property then append AND to the beginning of the string
                    //append to the beginning so the last property does not have an empty AND at the end.
                    ret = and + ret;
                }
                else
                {
                    exists = true;
                }
            }

            return ret;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates the list of columns that need to be updated. </summary>
        ///
        
        ///
        /// <param name="param">    The column parameter apart of the sql server update command ie,
        ///                         UPDATE firstName = '...'. </param>
        /// <param name="val">      The value that the column is updated to. </param>
        ///
        /// <returns>   string - the update part of the command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateUpdateProperties(string param, string val)
        {
            string ret = "";
            string com = ", ";

            if (val != "")
            {
                ret = String.Format(param, val);
                if (ex)
                {
                    //if there already exists a column in the list then append a comma
                    //to the beginning of the string to create an additional property
                    ret = com + ret;
                }
                else
                {
                    ex = true;
                }
            }

            return ret;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates the final INSERT command string. </summary>
        ///
        
        ///
        /// <param name="table">        The table name in which the insert command will be applied to. </param>
        /// <param name="parameters">   The column name of the table. </param>
        /// <param name="values">       The values of the columns. </param>
        ///
        /// <returns>   string - the fully built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateInsertCommand(string table, string parameters, string values)
        {
            string command = String.Format("INSERT INTO {0} ({1}) VALUES ({2})", table, parameters, values);

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A slight modification of the first insert command string builder. This method creates an
        ///     insert command string, but uses a select statement as the values for the columns.
        /// </summary>
        ///
        
        ///
        /// <param name="table">    The table name in which the insert command will be applies to. </param>
        /// <param name="select">   The select command that retrieves the values used to insert into the
        ///                         table. </param>
        ///
        /// <returns>   string - the fully built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateSelectInsertCommand(string table, string select)
        {
            string command = String.Format("INSERT INTO {0} {1}", table, select);

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates an UPDATE command string. </summary>
        ///
        
        ///
        /// <param name="table">        The table in which the command string will be applied to. </param>
        /// <param name="parameters">   The columns of the table that will be updated. </param>
        /// <param name="where">        The where parameter of the sql server command string. </param>
        ///
        /// <returns>   The new update command. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateUpdateCommand(string table, string parameters, string where)
        {
            string command = String.Format("UPDATE {0} SET {1} WHERE {2}", table, parameters, where);

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates a table based on another tables values. </summary>
        ///
        
        ///
        /// <param name="table1">   First table's name. </param>
        /// <param name="table2">   Second table's name. </param>
        /// <param name="param">    The columns of the table that will be updated. </param>
        /// <param name="on">       The ON property that links the two tables. </param>
        /// <param name="where">    The where property. </param>
        ///
        /// <returns>   string - the built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateJoinUpdateCommand(string table1, string table2, string param, string on, string where)
        {
            string command = String.Format("UPDATE a SET {0} FROM {1} a INNER JOIN {2} b ON {3} WHERE {4}", param, table1, table2, on, where);

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a basic SELECT command string. </summary>
        ///
        
        ///
        /// <param name="table">    The table name the user wishes to select from. </param>
        /// <param name="where">    The where parameter that filters the select result. </param>
        ///
        /// <returns>   string - the fully built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        private string CreateSelectCommand(string table, string where)
        {
            string command = "";

            //if the where clause is empty then use a generic select command
            if (where == "")
            {
                command = String.Format("SELECT * FROM {0}", table);
            }
            else
            {
                //if the where clause contains an argument then include it in the select command
                command = String.Format("SELECT * FROM {0} WHERE {1}", table, where);
            }

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a command string that selects columns from two tables. </summary>
        ///
        
        ///
        /// <param name="table1">   First table. </param>
        /// <param name="table2">   Second table. </param>
        /// <param name="join">     Join clause of the command. </param>
        /// <param name="where">    Where clause of the command. </param>
        /// <param name="on">       On clause of the command. </param>
        /// <param name="select">   The columns that are being selected. </param>
        ///
        /// <returns>   string - fully built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateJoinSelectCommand(string table1, string table2, string join, string where, string on, string select)
        {
            string command = "";

            //if no where clause, dont add WHERE
            if (where == "")
            {
                command = String.Format("SELECT {0} FROM {1} a {2} {3} b ON {4}", select, table1, join, table2, on);
            }
            //if there is where clause, add WHERE
            else
            {
                command = String.Format("SELECT {0} FROM {1} a {2} {3} b ON {4} WHERE {5}", select, table1, join, table2, on, where);
            }

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a delete command string. </summary>
        ///
        
        ///
        /// <param name="table">    table name you wish to delete from. </param>
        /// <param name="where">    the where parameter the indicates on what grounds the delete occurs. </param>
        ///
        /// <returns>   string - fully built delete command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateDeleteCommand(string table, string where)
        {
            string command = String.Format("DELETE FROM {0} WHERE {1}", table, where);

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a delete command that deletes from a joined table. </summary>
        ///
        
        ///
        /// <param name="table1">   first table name. </param>
        /// <param name="table2">   second table name. </param>
        /// <param name="join">     the join type. </param>
        /// <param name="where">    the where clause that the delete occurs on. </param>
        /// <param name="on">       the property that connects the two tables. </param>
        ///
        /// <returns>   string - fully built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateJoinDeleteCommand(string table1, string table2, string join, string where, string on)
        {
            string command = "";

            if (where == "")
            {
                command = String.Format("DELETE a FROM {0} a {1} {2} b ON {3}", table1, join, table2, on);
            }
            else
            {
                command = String.Format("DELETE a FROM {0} a {1} {2} b ON {3} WHERE {4}", table1, join, table2, on, where);
            }

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a delete command that deleted from a double joined table. </summary>
        ///
        
        ///
        /// <param name="dcmd">     Takes an initial delete command and appends an additional join. </param>
        /// <param name="table3">   third table. </param>
        /// <param name="join2">    second join type. </param>
        /// <param name="on2">      second ON property that connects the third table. </param>
        /// <param name="where">    the where clause that the delete occurs on. </param>
        ///
        /// <returns>   string - fully built command string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string CreateDoubleJoinDeleteCommand(string dcmd, string table3, string join2, string on2, string where)
        {
            string command = string.Format("{0} {1} {2} c ON {3} WHERE {4}", dcmd, join2, table3, on2, where);

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Inserts a new row into the Messenger table. </summary>
        ///
        
        ///
        /// <param name="senderID">     ID of the sender. </param>
        /// <param name="ReceiverID">   ID of the receipiant. </param>
        /// <param name="subjectLine">  subject of the message. </param>
        /// <param name="words">        body of the message. </param>
        /// <param name="dateMSG">      date of the message. </param>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string Messenger( int senderID , int ReceiverID, string subjectLine, string words, DateTime dateMSG)
        {
            //Validation________________________________________________
            //Validation validate = new Validation();
            // ErrorMessages errMess = new ErrorMessages();
            string errMessage = "";
            int errCode = 0;

            // errCode = validate.validateCompanyName(cmpnyname);
            //__________________________________________________________

            if (errCode == 0)
            {
                string table = "Messenger";
                string param = "Sender_ID, Receiver_ID, Subject_Line, Words, messageDate";
                string value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}'", senderID, ReceiverID, subjectLine , words,dateMSG);

                string command = CreateInsertCommand(table, param, value);

                Write(command);
            }
            else
            {
                //  errMessage = errMess.errorMessage(errCode);
            }

            return errMessage;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Inserts a row into the Messenger table. </summary>
        ///
        
        ///
        /// <param name="senderID">     Id of the sender. </param>
        /// <param name="ReceiverID">   Id of the receipiant. </param>
        /// <param name="subjectLine">  subject of the message. </param>
        /// <param name="words">        body of the message. </param>
        /// <param name="dateMSG">      date of the message. </param>
        /// <param name="shiftReq">     Id of shift requested. </param>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string Messenger(int senderID, int ReceiverID, string subjectLine, string words, DateTime dateMSG,int shiftReq)
        {
            //Validation________________________________________________
            //Validation validate = new Validation();
            // ErrorMessages errMess = new ErrorMessages();
            string errMessage = "";
            int errCode = 0;

            // errCode = validate.validateCompanyName(cmpnyname);
            //__________________________________________________________

            if (errCode == 0)
            {
                string table = "Messenger";
                string param = "Sender_ID, Receiver_ID, Subject_Line, Words, messageDate, shiftReq";
                string value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", senderID, ReceiverID, subjectLine, words, dateMSG,shiftReq);

                string command = CreateInsertCommand(table, param, value);

                Write(command);
            }
            else
            {
                //  errMessage = errMess.errorMessage(errCode);
            }

            return errMessage;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select message from the message table based on the receiver id. </summary>
        ///
        
        ///
        /// <param name="cid">  Id of the receiver. </param>
        ///
        /// <returns>
        ///     DataTable - datatable containing all of the rows in message table with the reciever id.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sMessenger(string cid)
        {
            string table = "Messenger";

            string senderID = CreateSelectProperties(cid, "Receiver_ID = '{0}'");
            string where = senderID;
            string command = CreateSelectCommand(table, where);
            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select message(s) from the message table based on the sender's id. </summary>
        ///
        
        ///
        /// <param name="cid">  Id of the sender. </param>
        ///
        /// <returns>
        ///     DataTable - datatable containing all of the rows in message table with the sender id.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sentMail(string cid)
        {
            string table = "Messenger";

            string senderID = CreateSelectProperties(cid, "Sender_ID = '{0}'");
            string where = senderID;
            string command = CreateSelectCommand(table, where);
            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Deletes row in the message table based on the message id given. </summary>
        ///
        
        ///
        /// <param name="msgID">    Id of the message. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dMessenger(string msgID)
        {
            string table = "Messenger";
            string where = String.Format("Message_ID = '{0}'", msgID);

            string command = CreateDeleteCommand(table, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Inserts new row into the Company_Info table. </summary>
        ///
        
        ///
        /// <param name="cmpnyname">    Name of the company. </param>
        /// <param name="yoc">          Year of Incorporation. </param>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string Company(string cmpnyname, string yoc)
        {
            //Validation________________________________________________
            //Validation validate = new Validation();
            // ErrorMessages errMess = new ErrorMessages();
            string errMessage = "";
            int errCode = 0;

            // errCode = validate.validateCompanyName(cmpnyname);
            //__________________________________________________________

            if (errCode == 0)
            {
                string table = "Company_Info";
                string param = "companyName, yearOfIncorporation, active";
                string value = String.Format("'{0}', '{1}', '{2}'", cmpnyname, yoc, "1");

                string command = CreateInsertCommand(table, param, value);

                Write(command);
            }
            else
            {
                //  errMessage = errMess.errorMessage(errCode);
            }

            return errMessage;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates row in Compnay_Info table with the passed values. </summary>
        ///
        
        ///
        /// <param name="cid">      Id of company. </param>
        /// <param name="cname">    Company name. </param>
        /// <param name="yoc">      Year of Incorporation. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uCompany(string cid, string cname, string yoc)
        {
            string table = "Company_Info";
            string cn = CreateUpdateProperties("companyName = '{0}'", cname);
            string yc = CreateUpdateProperties("yearOfIncorporation = '{0}'", yoc);
            string where = String.Format("company_id = '{0}'", cid);

            string param = cn + yc;

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select all from the company_info table. </summary>
        ///
        
        ///
        /// <returns>   DataTable - containing all of the rows from the company info table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sCompany()
        {
            string table = "Company_Info";
            string where = "";

            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select rows from the company table using parameters as WHERE clause. </summary>
        ///
        
        ///
        /// <param name="cid">      Id of company. </param>
        /// <param name="cname">    Company name. </param>
        /// <param name="incorp">   Year of incorporation. </param>
        /// <param name="act">      active. </param>
        ///
        /// <returns>   A DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sCompany(string cid, string cname, string incorp, string act)
        {
            string table = "Company_Info";

            //create where clause part of the command string
            string cmpyid = CreateSelectProperties(cid, "company_id = '{0}'");
            string cmpyname = CreateSelectProperties(cname, "companyName = '{0}'");
            string yoc = CreateSelectProperties(incorp, "yearOfIncorporation = '{0}'");
            string active = CreateSelectProperties(act, "active = '{0}'");

            //append all of the where parameters together
            string where = cmpyid + cmpyname + yoc + active;
            //create the full command string
            string command = CreateSelectCommand(table, where);
            //send command string to the dal and return datatable
            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row from company info table based on company id. </summary>
        ///
        
        ///
        /// <param name="cid">  Id of company. </param>
        ///
        /// <returns>   A DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sCompany(string cid)
        {
            string table = "Company_Info";

            string cmpyid = CreateSelectProperties(cid, "company_id = '{0}'");


            string where = cmpyid;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete row from company info table based on company id. </summary>
        ///
        
        ///
        /// <param name="cmpyid">   Id of company. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dCompany(string cmpyid)
        {
            string table = "Company_Info";
            string param = String.Format("active = '{0}'", "0");
            string where = String.Format("company_id = '{0}'", cmpyid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Insert row into the Store info table. </summary>
        ///
        
        ///
        /// <param name="cmpid">    Id of company. </param>
        /// <param name="div">      Store's divider number (used to create schedules) </param>
        /// <param name="address">  Address store is located. </param>
        /// <param name="pc">       Postal code of store. </param>
        /// <param name="cntry">    Country the store resides in. </param>
        /// <param name="cty">      City the store resides in. </param>
        /// <param name="phone">    Store phonen number. </param>
        /// <param name="fax">      Store fax number. </param>
        ///-------------------------------------------------------------------------------------------------

        public void Store(string cmpid, string div, string address, string pc, string cntry, string cty, string phone, string fax)
        {
            string table = "Store_Info";
            string param = "company_id, divider, storeAddress, postalCode, country, city, storePhone, fax, active";
            string value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '1'", cmpid, div, address, pc, cntry, cty, phone, fax);

            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Update row in store info table with the parameters provided. </summary>
        ///
        
        ///
        /// <param name="sid">      store id. </param>
        /// <param name="cid">      Id of company. </param>
        /// <param name="div">      Store's divider number (used to create schedules) </param>
        /// <param name="add">      Address store is located. </param>
        /// <param name="pc">       Postal code of store. </param>
        /// <param name="ctry">     Country the store resides in. </param>
        /// <param name="cty">      City the store resides in. </param>
        /// <param name="phone">    Store phonen number. </param>
        /// <param name="fax">      Store fax number. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uStore(string sid, string cid, string div, string add, string pc, string ctry, string cty, string phone, string fax)
        {
            string table = "Store_Info";
            string where = String.Format("store_id = '{0}'", sid);

            //create update parameters
            string ci = CreateUpdateProperties("company_id = '{0}'", cid);
            string di = CreateUpdateProperties("divider = '{0}'", div);
            string ad = CreateUpdateProperties("storeAddress = '{0}'", add);
            string po = CreateUpdateProperties("postalCode = '{0}'", pc);
            string c = CreateUpdateProperties("country = '{0}'", ctry);
            string cc = CreateUpdateProperties("city = '{0}'", cty);
            string ph = CreateUpdateProperties("storePhone = '{0}'", phone);
            string fa = CreateUpdateProperties("fax = '{0}'", fax);

            //append update parameters
            string param = ci + di + ad + po + c + cc + ph + fa;

            //create full command string
            string command = CreateUpdateCommand(table, param, where);

            //pass command to dal 
            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects all rows from the store info table. </summary>
        ///
        
        ///
        /// <returns>   DataTable - rows from store info table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sStore()
        {
            string table = "Store_Info";
            string table2 = "Company_Info";
            string where = "";
            string on = "a.company_id = b.company_id";
            string select = "a.store_id,a.company_id, b.companyName, a.divider, a.storeAddress, a.postalCode, a.country, a.city, a.storePhone, a.fax, a.active";

            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects row from store info table based on store id. </summary>
        ///
        
        ///
        /// <param name="id">   Id of store. </param>
        ///
        /// <returns>   DataTable - row from store info table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sStore(string id)
        {
            string table = "Store_Info";
            string table2 = "Company_Info";
            string on = "a.company_id = b.company_id";
            string select = "a.store_id, b.company_id, b.companyName, a.divider, a.storeAddress, a.postalCode, a.country, a.city, a.storePhone, a.fax, a.active";

            string si = CreateSelectProperties(id, "a.store_id = '{0}'");


            string where = si;

            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);
            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects row(s) from store info table based on the parameters. </summary>
        ///
        
        ///
        /// <param name="id">       Id of store. </param>
        /// <param name="name">     Name of store. </param>
        /// <param name="div">      Store's divider number (used to make schedule) </param>
        /// <param name="add">      Address of store. </param>
        /// <param name="pc">       Postal code of store. </param>
        /// <param name="ctry">     Country store resides in. </param>
        /// <param name="cty">      City store resides in. </param>
        /// <param name="phone">    Phone number of store. </param>
        /// <param name="fax">      Fax number of store. </param>
        /// <param name="act">      Active stores. </param>
        ///
        /// <returns>   A DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sStore(string id, string name, string div, string add, string pc, string ctry, string cty, string phone, string fax, string act)
        {
            string table = "Store_Info";
            string table2 = "Company_Info";
            string on = "a.company_id = b.company_id";
            string select = "a.store_id, b.companyName, a.divider, a.storeAddress, a.postalCode, a.country, a.city, a.storePhone, a.fax, a.active";

            //create select properties
            string si = CreateSelectProperties(id, "a.store_id = '{0}'");
            string na = CreateSelectProperties(name, "b.companyName = '{0}'");
            string dv = CreateSelectProperties(div, "a.divider = '{0}'");
            string ad = CreateSelectProperties(add, "a.storeAddress = '{0}'");
            string po = CreateSelectProperties(pc, "a.postalCode = '{0}'");
            string c = CreateSelectProperties(ctry, "a.country = '{0}'");
            string cc = CreateSelectProperties(cty, "a.city = '{0}'");
            string sp = CreateSelectProperties(phone, "a.storePhone = '{0}'");
            string fa = CreateSelectProperties(fax, "a.fax = '{0}'");
            string ac = CreateSelectProperties(act, "a.active = '{0}'");

            //append select properties to make where clause
            string where = si + na + dv + ad + po + c + cc + sp + fa + ac;

            //create full command string
            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);
            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Deletes row in store info table based on store id. </summary>
        ///
        
        ///
        /// <param name="stid"> Id of store. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dStore(string stid)
        {
            string table = "Store_Info";
            string param = String.Format("active = '{0}'", "0");
            string where = String.Format("store_id = '{0}'", stid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Inserts row into the schedule table. </summary>
        ///
        
        ///
        /// <param name="storeid">  Id of store that belongs to the schedule. </param>
        ///-------------------------------------------------------------------------------------------------

        public void Schedule(string storeid)
        {
            string table = "Schedule";
            string param = "store_id";
            string value = String.Format("'{0}'", storeid);

            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   update row with schedule id. </summary>
        ///
        
        ///
        /// <param name="sid">  schedule id. </param>
        /// <param name="stid"> store id. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uSchedule(string sid, string stid)
        {
            string table = "Schedule";
            string where = String.Format("schedule_id = '{0}'", sid);
            string param = CreateUpdateProperties("store_id = '{0}'", stid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   select all rows from schedule table. </summary>
        ///
        
        ///
        /// <returns>   DataTable - all rows from schedule table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sSchedule()
        {
            string table = "Schedule";

            string command = CreateSelectCommand(table, "");

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select schedule based on parameters. </summary>
        ///
        
        ///
        /// <param name="schid">    schedule id. </param>
        /// <param name="stid">     store id. </param>
        ///
        /// <returns>   DataTable - rows that match the parameters. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sSchedule(string schid, string stid)
        {
            string table = "Schedule";
            string sc = CreateSelectProperties(schid, "schedule_id = '{0}'");
            string st = CreateSelectProperties(stid, "store_id = '{0}'");

            string where = sc + st;

            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete row from scheudle table with schedule id. </summary>
        ///
        
        ///
        /// <param name="schid">    schedule id. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dSchedule(string schid)
        {
            string table = "Schedule";
            string where = String.Format("schedule_id = '{0}'", schid);

            string command = CreateDeleteCommand(table, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Insert a new row into the Person Info table. </summary>
        ///
        
        ///
        /// <param name="fname">    first name of person. </param>
        /// <param name="lname">    last name of person. </param>
        /// <param name="phone">    phone number. </param>
        /// <param name="email">    email. </param>
        /// <param name="address">  address. </param>
        /// <param name="postal">   postal code. </param>
        /// <param name="country">  country. </param>
        /// <param name="city">     city. </param>
        ///-------------------------------------------------------------------------------------------------

        public void Person(string fname, string lname, string phone, string email, string address, string postal, string country, string city)
        {
            string table = "Person_Info";
            string param = "firstName, lastName, phoneNumber, email, personAddress, postalCode, country, city";
            string value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'", fname, lname, phone, email, address, postal, country, city);

            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Update row in person table with the parameter values. </summary>
        ///
        
        ///
        /// <param name="id">       Id of person. </param>
        /// <param name="fname">    first name. </param>
        /// <param name="lname">    last name. </param>
        /// <param name="phone">    phone number. </param>
        /// <param name="email">    email. </param>
        /// <param name="address">  address. </param>
        /// <param name="pc">       postal code. </param>
        /// <param name="country">  country. </param>
        /// <param name="city">     city. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uPerson(string id, string fname, string lname, string phone, string email, string address, string pc, string country, string city)
        {
            string table = "Person_Info";
            string fn = CreateUpdateProperties("firstName = '{0}'", fname);
            string ln = CreateUpdateProperties("lastName = '{0}'", lname);
            string ph = CreateUpdateProperties("phoneNumber = '{0}'", phone);
            string em = CreateUpdateProperties("email = '{0}'", email);
            string ad = CreateUpdateProperties("personAddress = '{0}'", address);
            string po = CreateUpdateProperties("postalCode = '{0}'", pc);
            string c = CreateUpdateProperties("country = '{0}'", country);
            string cc = CreateUpdateProperties("city = '{0}'", city);

            string param = fn + ln + ph + em + ad + po + c + cc;

            string where = String.Format("person_id = '{0}'", id);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select all rows from person table. </summary>
        ///
        
        ///
        /// <returns>   DataTable - all rows from person table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sPerson()
        {
            string table = "Person_Info";
            string where = "";
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row from person table with person id. </summary>
        ///
        
        ///
        /// <param name="id">   Id of person. </param>
        ///
        /// <returns>   A DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sPerson(string id)
        {
            string table = "Person_Info";

            string pi = CreateSelectProperties(id, "person_id = '{0}'");

            string where = pi;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row(s) from person table with parameter values. </summary>
        ///
        
        ///
        /// <param name="id">       Id of person. </param>
        /// <param name="fname">    first name. </param>
        /// <param name="lname">    lsat name. </param>
        /// <param name="phone">    phone number. </param>
        /// <param name="email">    email address. </param>
        /// <param name="add">      address. </param>
        /// <param name="po">       postal code. </param>
        /// <param name="country">  country. </param>
        /// <param name="city">     city. </param>
        ///
        /// <returns>   DataTable - resulting rows from person table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sPerson(string id, string fname, string lname, string phone, string email, string add, string po, string country, string city)
        {
            string table = "Person_Info";

            string ei = CreateSelectProperties(id, "employee_id = '{0}'");
            string fn = CreateSelectProperties(fname, "firstName = '{0}'");
            string ln = CreateSelectProperties(lname, "lastName = '{0}'");
            string ph = CreateSelectProperties(phone, "phoneNumber = '{0}'");
            string em = CreateSelectProperties(email, "email = '{0}'");
            string ad = CreateSelectProperties(add, "personAddress = '{0}'");
            string pc = CreateSelectProperties(po, "postalCode = '{0}'");
            string co = CreateSelectProperties(country, "country = '{0}'");
            string ci = CreateSelectProperties(city, "city = '{0}'");

            string where = ei + fn + ln + ph + em + ad + pc + co + ci;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Insert row into Employee table. </summary>
        ///
        
        ///
        /// <param name="user">     username. </param>
        /// <param name="pswrd">    password. </param>
        /// <param name="doh">      date of hire. </param>
        /// <param name="dot">      date of termination. </param>
        /// <param name="storeid">  store id. </param>
        /// <param name="cmpyid">   company id. </param>
        /// <param name="pid">      person id. </param>
        ///-------------------------------------------------------------------------------------------------

        public void Employee(string user, string pswrd, string doh, string dot, string storeid, string cmpyid, string pid)
        {
            string table = "Employee_Info";
            string param;
            string value;
            if (dot == "N/A")
            {        
                 param = "username, password, dateOfHire, store_id, company_id, person_id, active";
                 value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'", user, pswrd, doh,  storeid, cmpyid, pid, "1");
            }
            else
            {
                 param = "username, password, dateOfHire, dateOfTermination, store_id, company_id, person_id, active";
                 value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'", user, pswrd, doh, dot, storeid, cmpyid, pid, "1");
            }
            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Update row from employee table with parameter values. </summary>
        ///
        
        ///
        /// <param name="empid">    Id of employee. </param>
        /// <param name="user">     username. </param>
        /// <param name="pswrd">    password. </param>
        /// <param name="doh">      date of hire. </param>
        /// <param name="dot">      date of termination. </param>
        /// <param name="strid">    store id. </param>
        /// <param name="ncmpyid">  company id. </param>
        /// <param name="pid">      person id. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uEmployee(string empid, string user, string pswrd, string doh, string dot, string strid, string ncmpyid, string pid)
        {
            string table = "Employee_Info";
            string us = CreateUpdateProperties("username = '{0}'", user);
            string pw = CreateUpdateProperties("password = '{0}'", pswrd);
            string dh = CreateUpdateProperties("dateOfHire = '{0}'", doh);
            string dt = CreateUpdateProperties("dateOfTermination = '{0}'", dot);
            string si = CreateUpdateProperties("store_id = '{0}'", strid);
            string ci = CreateUpdateProperties("company_id = '{0}'", ncmpyid);
            string pi = CreateUpdateProperties("person_id = '{0}'", pid);

            string param = us + pw + si + ci + pi + dh + dt;

            string where = String.Format("employee_id = '{0}'", empid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select all rows from employee table. </summary>
        ///
        
        ///
        /// <returns>   DataTable - all rows from employee table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sEmployee()
        {
            string table = "Employee_Info";
            string where = "";
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row from employee table with employee id. </summary>
        ///
        
        ///
        /// <param name="empid">    Id of employee. </param>
        ///
        /// <returns>   DataTable - row with matching employee id. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sEmployee(string empid)
        {
            string table = "Employee_Info";

            string em = CreateSelectProperties(empid, "employee_id = '{0}'");


            string where = em;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row(s) from employee table with parameter values. </summary>
        ///
        
        ///
        /// <param name="empid">    Id of employee. </param>
        /// <param name="user">     username. </param>
        /// <param name="doh">      date of hire. </param>
        /// <param name="dot">      date of termination. </param>
        /// <param name="strid">    store id. </param>
        /// <param name="cmpyid">   company id. </param>
        /// <param name="pid">      person id. </param>
        /// <param name="act">      active. </param>
        ///
        /// <returns>   DataTable - matching rows from employee table. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sEmployee(string empid, string user, string doh, string dot, string strid, string cmpyid, string pid, string act)
        {
            string table = "Employee_Info";

            string em = CreateSelectProperties(empid, "employee_id = '{0}'");
            string us = CreateSelectProperties(user, "username = '{0}'");
            string si = CreateSelectProperties(strid, "store_id = '{0}'");
            string dh = CreateSelectProperties(doh, "dateOfHire = '{0}'");
            string te = CreateSelectProperties(dot, "dateOfTermination = '{0}'");
            string ci = CreateSelectProperties(cmpyid, "company_id = '{0}'");
            string pi = CreateSelectProperties(pid, "company_id = '{0}'");
            string ac = CreateSelectProperties(act, "active = '{0}'");

            string where = em + us + si + ci + pi + ac + dh + te;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete row from employee table. </summary>
        ///
        
        ///
        /// <param name="empid">    Id of employee. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dEmployee(string empid)
        {
            string table = "Employee_Info";
            string param = String.Format("active = '{0}'", "0");
            string where = String.Format("employee_id = '{0}'", empid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete all rows from the employee table with company id. </summary>
        ///
        
        ///
        /// <param name="cmpyid">   Company id. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dAllEmployee(string cmpyid)
        {
            string table = "Employee_Info";
            string param = String.Format("active = '{0}'", "0");
            string where = String.Format("company_id = '{0}'", cmpyid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete all rows from employee table with store id. </summary>
        ///
        
        ///
        /// <param name="stid"> Store id. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dAllEmployeeStore(string stid)
        {
            string table = "Employee_Info";
            string param = String.Format("active = '{0}'", "0");
            string where = String.Format("store_id = '{0}'", stid);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select rows from the employee table joined with the person table. </summary>
        ///
        
        ///
        /// <returns>   DataTable - Joined table of person and employee tables. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sEmployeeJoinPerson()
        {
            string table = "Person_Info";
            string table2 = "Employee_Info";

            string on = "a.person_id = b.person_id";

            string select = "a.person_id, a.firstName, a.lastName, a.phoneNumber, a.email, a.personAddress, a.postalCode, a.country, a.city, a.socialNumber, b.employee_id, b.username, b.password, b.dateOfHire, b.dateOfTermination, b.store_id, b.company_id, b.active";

            string where = "";

            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Select rows from employee table joined with person table with parameter values.
        /// </summary>
        ///
        
        ///
        /// <param name="pid">      Id of person. </param>
        /// <param name="fname">    first name. </param>
        /// <param name="lname">    last name. </param>
        /// <param name="phone">    phonen number. </param>
        /// <param name="email">    email. </param>
        /// <param name="add">      address. </param>
        /// <param name="po">       postal code. </param>
        /// <param name="cntry">    country. </param>
        /// <param name="cty">      city. </param>
        /// <param name="empid">    Id of employee. </param>
        /// <param name="user">     username. </param>
        /// <param name="doh">      date of hire. </param>
        /// <param name="dot">      date of termination. </param>
        /// <param name="strid">    store id. </param>
        /// <param name="cmpyid">   company id. </param>
        /// <param name="act">      active. </param>
        ///
        /// <returns>   DataTable - rows from a joined table of person and employee tables. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sEmployeeJoinPerson(string pid, string fname, string lname, string phone, string email, string add, string po, string cntry, string cty, string empid, string user, string doh, string dot, string strid, string cmpyid, string act)
        {
            string table = "Person_Info";
            string table2 = "Employee_Info";

            string on = "a.person_id = b.person_id";

            string select = "a.person_id, a.firstName, a.lastName, a.phoneNumber, a.email, a.personAddress, a.postalCode, a.country, a.city, a.socialNumber, b.employee_id, b.username, b.password, b.dateOfHire, b.dateOfTermination, b.store_id, b.company_id, b.active";

            string pi = CreateSelectProperties(pid, "a.person_id = '{0}'");
            string fn = CreateSelectProperties(fname, "a.firstName = '{0}'");
            string ln = CreateSelectProperties(lname, "a.lastName = '{0}'");
            string ph = CreateSelectProperties(phone, "a.phoneNumber = '{0}'");
            string em = CreateSelectProperties(email, "a.email = '{0}'");
            string ad = CreateSelectProperties(add, "a.personAddress = '{0}'");
            string pc = CreateSelectProperties(po, "a.postalCode = '{0}'");
            string co = CreateSelectProperties(cntry, "a.country = '{0}'");
            string cy = CreateSelectProperties(cty, "a.city = '{0}'");
            string ei = CreateSelectProperties(empid, "b.employee_id = '{0}'");
            string us = CreateSelectProperties(user, "b.username = '{0}'");
            string dh = CreateSelectProperties(doh, "b.dateOfHire = '{0}'");
            string te = CreateSelectProperties(dot, "b.dateOfTermination = '{0}'");
            string si = CreateSelectProperties(strid, "b.store_id = '{0}'");
            string ci = CreateSelectProperties(cmpyid, "b.company_id = '{0}'");
            string ac = CreateSelectProperties(act, "b.active = '{0}'");

            string where = pi + fn + ln + ph + em + ad + pc + co + cy + ei + us + dh + te + si + ci + ac;
            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);
            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Insert a row into the Shift Info table. </summary>
        ///
        
        ///
        /// <param name="empID">    Id of employee. </param>
        /// <param name="start">    shift start date and time. </param>
        /// <param name="end">      shift end date and time. </param>
        /// <param name="sid">      Id of schedule. </param>
        /// <param name="stid">     The stid. </param>
        ///-------------------------------------------------------------------------------------------------

        public void Shift(string empID, DateTime start, DateTime end, string sid, string stid)
        {
            string table = "Shift_Info";
            string param;
            string value;
            sid = "8";
            if (empID == "-1")
            {
                param = "startTime, endTime, schedule_id, store_id";
                value = String.Format("'{0}', '{1}', '{2}', '{3}'", start, end,  sid , stid);
            }
            else
            {
                 param = "startTime, endTime, employee_id, schedule_id, store_id";
                 value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}'", start, end, empID, sid, stid);

            }
            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Shifts. </summary>
        ///
        
        ///
        /// <param name="start">    . </param>
        /// <param name="end">      . </param>
        /// <param name="sid">      . </param>
        /// <param name="stid">     The stid. </param>
        ///-------------------------------------------------------------------------------------------------

        public void Shift(DateTime start, DateTime end, string sid,string stid)
        {
            string table = "Shift_Info";
            string param = "startTime, endTime, schedule_id, store_id";
            string value = String.Format("'{0}', '{1}', '{2}'", start, end, sid, stid);

            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Update row in Shift Info table with parameter values. </summary>
        ///
        
        ///
        /// <param name="id">       Id of shift. </param>
        /// <param name="start">    start time and date of shift. </param>
        /// <param name="end">      end time and date of shift. </param>
        /// <param name="eid">      Id of employee. </param>
        /// <param name="schid">    Id of schedule. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uShift(string id, string start, string end, string eid, string schid)
        {
            string table = "Shift_Info";

            string st = CreateUpdateProperties("startTime = '{0}'", start);
            string en = CreateUpdateProperties("endTime = '{0}'", end);
            string us = CreateUpdateProperties("employee_id = '{0}'", eid);
            string si = CreateUpdateProperties("schedule_id = '{0}'", schid);
            if (eid == "-1")
            {
                us = "employee_id = NULL";
            }
            string param = st + en + us + si;

            string where = String.Format("shift_id = '{0}'", id);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        public void uShift(string id, string start, string end, string eid, string schid, string storeID)
        {
            string table = "Shift_Info";

            string st = CreateUpdateProperties("startTime = '{0}'", start);
            string en = CreateUpdateProperties("endTime = '{0}'", end);
            string us = CreateUpdateProperties("employee_id = '{0}'", eid);
            string si = CreateUpdateProperties("schedule_id = '{0}'", schid);
            string sti = CreateUpdateProperties("store_id = '{0}'", storeID);
            
            if (eid == "-1")
            {
                us = ", employee_id = NULL";
            }

            string param = st + en + us + si + sti; // Non open shift and all that fun stuff 


            string where = String.Format("shift_id = '{0}'", id);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }


///-------------------------------------------------------------------------------------------------
/// <summary>   Select all rows from Shift Info table. </summary>
///

///
/// <returns>   DataTable - shift info table rows. </returns>
///-------------------------------------------------------------------------------------------------

public DataTable sShift()
        {
            string table = "Shift_Info";
            string where = "";
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row from shift info table with shift id. </summary>
        ///
        
        ///
        /// <param name="sid">  Id of shift. </param>
        ///
        /// <returns>   DataTable - row from shift info matching shift id. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sShift(string sid)
        {
            string table = "Shift_Info";

            string si = CreateSelectProperties(sid, "shift_id = '{0}'");


            string where = si;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select row(s) from Shift Info table with parameter values. </summary>
        ///
        
        ///
        /// <param name="sid">      Id of shift. </param>
        /// <param name="start">    shift start time and date. </param>
        /// <param name="end">      shift end time and date. </param>
        /// <param name="empid">    employee id. </param>
        /// <param name="schid">    schedule id. </param>
        ///
        /// <returns>   DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sShift(string sid, string start, string end, string empid, string schid)
        {
            string table = "Shift_Info";

            string si = CreateSelectProperties(sid, "shift_id = '{0}'");
            string st = CreateSelectProperties(start, "startTime = '{0}'");
            string en = CreateSelectProperties(end, "endTime = '{0}'");
            string ei = CreateSelectProperties(empid, "employee_id = '{0}'");
            string sc = CreateSelectProperties(schid, "schedule_id = '{0}'");

            string where = si + st + en + ei + sc;
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Inserts row into Open Shift Table. </summary>
        ///
        
        ///
        /// <param name="user"> Id of employee. </param>
        ///-------------------------------------------------------------------------------------------------

        public void mShift(string user)
        {
            string table = "Employee_Info";
            string table2 = "Shift_Info";

            string on = "b.employee_id = a.employee_id";

            string select = "store_id, b.shift_id";

            string where = String.Format("a.employee_id = '{0}'", user);

            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            command = CreateSelectInsertCommand("Open_Shifts", command);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   All shift. </summary>
        ///
        
        ///
        /// <param name="empid">    . </param>
        ///-------------------------------------------------------------------------------------------------

        public void dAllShift(string empid)
        {
            string table1 = "Shift_Info";
            string table2 = "Employee_Info";
            string on = "a.employee_id = b.employee_id";
            string where = String.Format("b.company_id = '{0}'", empid);

            string command = CreateJoinDeleteCommand(table1, table2, "INNER JOIN", where, on);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete all rows from Shift Info table where schedule id. </summary>
        ///
        
        ///
        /// <param name="schid">    Id of Schedule. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dAllShiftSchedule(string schid)
        {
            string table = "Shift_Info";
            string where = String.Format("schedule_id = '{0}'", schid);

            string command = CreateDeleteCommand(table, where);

            Write(command);
        }

        //broken

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete all rows from shift info table where store id. </summary>
        ///
        
        ///
        /// <param name="stid"> Id of store. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dAllShiftStore(string stid)
        {
            string table = "Shift_Info";
            string where = String.Format("store_id = '{0}'", stid);

            string command = CreateDeleteCommand(table, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   delete row from shift info table where shift id. </summary>
        ///
        
        ///
        /// <param name="id">   Id of shift. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dShift(string id)
        {
            string table = "Shift_Info";
            string where = String.Format("shift_id = '{0}'", id);

            string command = CreateDeleteCommand(table, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Insert row into Open Shift table. </summary>
        ///
        
        ///
        /// <param name="storeid">  Id of store. </param>
        /// <param name="shiftid">  Id of shift. </param>
        ///-------------------------------------------------------------------------------------------------

        public void OpenShift(string storeid, string shiftid)
        {
            string table = "Open_Shifts";
            string param = "store_id, shift_id";
            string value = String.Format("'{0}', '{1}'", storeid, shiftid);

            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Update row from open shift id with parameter values. </summary>
        ///
        
        ///
        /// <param name="id">       Id of open shift. </param>
        /// <param name="storeid">  Id of store. </param>
        /// <param name="shiftid">  Id of shift. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uOpenShift(string id, string storeid, string shiftid)
        {
            string table = "Open_Shifts";

            string si = CreateUpdateProperties("store_id = '{0}'", storeid);
            string sh = CreateUpdateProperties("shift_id = '{0}'", shiftid);

            string param = si + sh;

            string where = String.Format("openShift_id = '{0}'", id);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select the Open shift information, including information from shift table. </summary>
        ///
        
        ///
        /// <returns>   DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sOpenShift()
        {
            string table = "Open_Shifts";
            string table2 = "Shift_Info";

            string select = "a.openShift_id, a.store_id, a.shift_id, b.startTime, b.endTime, b.employee_id, b.schedule_id";

            string on = "a.shift_id = b.shift_id";

            string where = "";

            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select Open shift information where shift id. </summary>
        ///
        
        ///
        /// <param name="sid">  Id of shift. </param>
        ///
        /// <returns>   DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sOpenShift(string sid)
        {
            string table = "Open_Shifts";
            string table2 = "Shift_Info";

            string select = "a.openShift_id, a.store_id, a.shift_id, b.startTime, b.endTime, b.employee_id, b.schedule_id";

            string on = "a.shift_id = b.shift_id";

            string si = CreateSelectProperties(sid, "a.shift_id = '{0}'");


            string where = si;
            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select open shift information using parameter values. </summary>
        ///
        
        ///
        /// <param name="osid">     Id of open shift. </param>
        /// <param name="sid">      Id of shift. </param>
        /// <param name="stid">     Id of store. </param>
        /// <param name="start">    Shift start time and date. </param>
        /// <param name="end">      Shift end time and date. </param>
        /// <param name="empid">    Id of employee. </param>
        /// <param name="schid">    Id of schedule. </param>
        ///
        /// <returns>   A DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sOpenShift(string osid, string sid, string stid, string start, string end, string empid, string schid)
        {
            string table = "Open_Shifts";
            string table2 = "Shift_Info";

            string select = "a.openShift_id, a.store_id, a.shift_id, b.startTime, b.endTime, b.employee_id, b.schedule_id";

            string on = "a.shift_id = b.shift_id";

            string osi = CreateSelectProperties(osid, "a.openShift_id = '{0}'");
            string si = CreateSelectProperties(sid, "a.shift_id = '{0}'");
            string sti = CreateSelectProperties(stid, "a.store_id = '{0}'");
            string st = CreateSelectProperties(start, "b.startTime = '{0}'");
            string en = CreateSelectProperties(end, "b.endTime = '{0}'");
            string ei = CreateSelectProperties(empid, "b.employee_id = '{0}'");
            string sc = CreateSelectProperties(schid, "b.schedule_id = '{0}'");

            string where = osi + si + sti + st + en + ei + sc;
            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete all rows from Open shift table where company id. </summary>
        ///
        
        ///
        /// <param name="cmpid">    Id of company. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dAllOpenShift(string cmpid)
        {
            string table1 = "Open_Shifts";
            string table2 = "Shift_Info";
            string table3 = "Employee_Info";
            string on1 = "a.shift_id = b.shift_id";
            string on2 = "b.employee_id = c.employee_id";
            string where = String.Format("c.company_id = '{0}'", cmpid);

            string command = CreateDoubleJoinDeleteCommand(CreateJoinDeleteCommand(table1, table2, "INNER JOIN", "", on1), table3, "INNER JOIN", on2, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete all open shift where open shift id. </summary>
        ///
        
        ///
        /// <param name="id">   Id of open shift. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dOpenShift(string id)
        {
            string table = "Open_Shifts";
            string where = String.Format("openShift_id = '{0}'", id);

            string command = CreateDeleteCommand(table, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates row in shift info table with new employee that took open shift. </summary>
        ///
        
        ///
        /// <param name="empID">    Id of employee who took shift. </param>
        /// <param name="OSid">     Id of open shift that was taken. </param>
        ///-------------------------------------------------------------------------------------------------

        public void tOpenShift(string empID, string OSid)
        {
            string table1 = "Shift_Info";
            string table2 = "Open_Shifts";
            string param = String.Format("employee_id = '{0}'", empID);
            string where = String.Format("b.openShift_id = '{0}'", OSid);
            string on = "a.shift_id = b.shift_id";

            string command = CreateJoinUpdateCommand(table1, table2, param, on, where);

            Write(command);
        }

        //@wes
        //Call AddUser when you insert into Person_Info and Employee_Info
        //Supply the appropriate information from those two tables.
        //Will create a new MembershipUser
        //returns a status as a string:
        //DuplicateEmail
        //DuplicateProviderUserKey
        //DuplicateUserName
        //InvalidAnswer
        //InvalidEmail
        //InvalidPassword
        //InvalidProviderUserKey
        //InvalidQuestion
        //InvalidUserName
        //ProviderError
        //Success
        //UserRejected
        //List of MembershipCreateStatus member names and description visit: https://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus(v=vs.110).aspx

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a new ASP.net membership user. </summary>
        ///
        
        ///
        /// <param name="username">         username. </param>
        /// <param name="password">         password. </param>
        /// <param name="email">            email. </param>
        /// <param name="passwordQuestion"> password question. </param>
        /// <param name="passwordAnswer">   password answer. </param>
        /// <param name="isApproved">       Employee approved. </param>
        ///
        /// <returns>   string - Creation status. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string AddUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved)
        {
            MembershipCreateStatus createStatus;
            Membership.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, out createStatus);

            return createStatus.ToString();
        }

        //@wes
        //Call DeleteUser when you delete an employee
        //DeleteUser takes the username of the user you wish to delete as well as a bool indicating whether you want
        //to delete all related data as well.

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Delete a ASP.net membership user. </summary>
        ///
        
        ///
        /// <param name="username">             username. </param>
        /// <param name="deleteAllRelatedData"> deletes all related data to the user if true. </param>
        ///
        /// <returns>   bool - true if deleted, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return Membership.DeleteUser(username, deleteAllRelatedData);
        }

        //@wes
        //Call ValidateUser when you wish to check if the username and password supplied are valid
        //returns bool

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Check to see if the user is a ASP.net membership user. </summary>
        ///
        
        ///
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        ///
        /// <returns>   bool - true if validated, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool ValidateUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }

        //@wes
        //Changes password of the provided user.
        //returns bool

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the users password. </summary>
        ///
        
        ///
        /// <param name="username">     username. </param>
        /// <param name="oldPassword">  old password. </param>
        /// <param name="newPassword">  new password. </param>
        ///
        /// <returns>   bool - true if success, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            MembershipUser user = Membership.GetUser(username);
            return user.ChangePassword(oldPassword, newPassword);
        }

        //@wes
        //Updates the password question and password answer
        //need to pass the username and password of the user you wish to change as well as the new question and answer
        //returns bool

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the users password recovery question. </summary>
        ///
        
        ///
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <param name="question"> recovery question. </param>
        /// <param name="answer">   recovery answer. </param>
        ///
        /// <returns>   bool - true if success, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool UpdatePasswordQuestionAnswer(string username, string password, string question, string answer)
        {
            MembershipUser user = Membership.GetUser(username);
            return user.ChangePasswordQuestionAndAnswer(password, question, answer);
        }

        //@wes
        //Updates email, takes the username of the user you wish to update and the new email
        //returns bool.

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Update users email address. </summary>
        ///
        
        ///
        /// <param name="username"> username. </param>
        /// <param name="email">    email. </param>
        ///
        /// <returns>   bool - true if success, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool UpdateEmail(string username, string email)
        {
            bool success = true;
            try
            {
                MembershipUser user = Membership.GetUser(username);
                user.Email = email;
                Membership.UpdateUser(user);
            }
            catch (System.Configuration.Provider.ProviderException e)
            {
                string errorMsg = e.ToString();
                success = false;
            }

            return success;
        }

        //no method for changing username

        //JEN'S STUFF//

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Select divider information from the database. </summary>
        ///
        
        ///
        /// <param name="table">    name of the table. </param>
        /// <param name="what">     what information we want to pull from the table. </param>
        ///
        /// <returns>   string command: which holds the query string. </returns>
        ///-------------------------------------------------------------------------------------------------

        private string CreateSelectCommandForDivider(string table, string what)
        {
            string command = "";

            if (what == "")
            {
                command = String.Format("SELECT * FROM {0}", table);
            }
            else
            {
                command = String.Format("SELECT {0} FROM {1}", what, table);
            }

            return command;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Selecting all information that matches up with employee information and person
        ///     information inside of the two tables.
        /// </summary>
        ///
        
        ///
        /// <param name="empid">    ID of employee. </param>
        /// <param name="fname">    first name of employee. </param>
        /// <param name="lname">    last name of employee. </param>
        /// <param name="strid">    ID of store. </param>
        /// <param name="cmpyid">   ID of company. </param>
        ///
        /// <returns>
        ///     DataTable dt: contains all of the matching information as a table for further processing.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sEmployeeJoinPersonBuildSchedule(string empid, string fname, string lname, string strid, string cmpyid)
        {
            string table = "Person_Info";
            string table2 = "Employee_Info";

            string on = "a.person_id = b.person_id";

            string select = "b.employee_id, a.firstName, a.lastName, b.store_id, b.company_id";

            string ei = CreateSelectProperties(empid, "b.employee_id = '{0}'");
            string fn = CreateSelectProperties(fname, "a.firstName = '{0}'");
            string ln = CreateSelectProperties(lname, "a.lastName = '{0}'");
            string si = CreateSelectProperties(strid, "b.store_id = '{0}'");
            string ci = CreateSelectProperties(cmpyid, "b.company_id = '{0}'");

            string where = ei + fn + ln + si + ci;
            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects the information of sales per hour from the database. </summary>
        ///
        
        ///
        /// <returns>
        ///     DataTable dt: contains all of the matching information as a table for further processing.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sSalesPerHour()
        {
            string table = "Sales_Per_Hour";
            string where = "";

            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects the information of the sales divider from the database. </summary>
        ///
        
        ///
        /// <returns>   int divider: contains the divider. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int getSalesDivider()
        {
            string table = "Store_Info";
            string what = "divider";

            string command = CreateSelectCommandForDivider(table, what);

            DataTable dtDivider = Read(command);
            int divider = 0;
            foreach (DataRow dataRow in dtDivider.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    divider = Convert.ToInt32(item);
                }
            }
            return divider;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Selecting all information that matches up with shift preferences at specific times.
        /// </summary>
        ///
        
        ///
        /// <param name="day">          day of the week. </param>
        /// <param name="startTime">    start of the shift. </param>
        /// <param name="endTime">      end of the shift. </param>
        ///-------------------------------------------------------------------------------------------------

        public void ShiftPreference(string day, DateTime startTime, DateTime endTime)
        {
            string table = "Shift_Preference";
            string param = "day, startTime, endTime";
            string value = String.Format("'{0}', '{1}', '{2}'", day, startTime, endTime);

            string command = CreateInsertCommand(table, param, value);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects all shift preferences from the database. </summary>
        ///
        
        ///
        /// <returns>
        ///     DataTable dt: contains all of the shift preferences for further processing.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sShiftPreferences()
        {
            string table = "Shift_Preference";
            string where = "";
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Selecting all information that matches up with the day and start time variables in the
        ///     shift preferences table.
        /// </summary>
        ///
        
        ///
        /// <param name="day">          day of the week. </param>
        /// <param name="startTime">    start of the shift. </param>
        ///
        /// <returns>
        ///     DataTable dt: contains all of the matching information as a table for further processing.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sShiftPreferences(string day, string startTime)
        {
            string table = "Shift_Preference";
            string where = "day = '" + day + "' AND startTime <= '" + startTime + "' AND endTime >= '" + startTime + "'";
            string command = CreateSelectCommand(table, where);

            DataTable dtShiftPreferences = Read(command);


            return dtShiftPreferences;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the shift preferences table. </summary>
        ///
        
        ///
        /// <param name="id">           id of shift. </param>
        /// <param name="empID">        id of employee. </param>
        /// <param name="day">          day of the week. </param>
        /// <param name="startTime">    start of the shift. </param>
        /// <param name="endTime">      end of the shift. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uShiftPreference(string id, string empID, string day, DateTime startTime, DateTime endTime)
        {
            string table = "Shift_Preference";

            string dy = CreateUpdateProperties("day = '{0}'", day);
            string st = CreateUpdateProperties("startTime = '{0}'", startTime.ToString());
            string en = CreateUpdateProperties("endTime = '{0}'", endTime.ToString());

            string param = dy + st + en;

            string where = String.Format("shift_id = '{0}'", id);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   modifies the shift preferences table. </summary>
        ///
        
        ///
        /// <param name="empid">    id of employee. </param>
        ///-------------------------------------------------------------------------------------------------

        public void mShiftPreference(string empid)
        {
            string table = "Employee_Info";
            string table2 = "Shift_Preference";

            string on = "b.username = a.username";

            string select = "store_id, b.shift_id";

            string where = String.Format("a.employee_id = '{0}'", empid);

            string command = CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            command = CreateSelectInsertCommand("Shift_Preference", command);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   deletes an employees shift preference in the shift preferences table. </summary>
        ///
        
        ///
        /// <param name="empid">    id of employee. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dShiftPreference(string empid)
        {
            string table1 = "Shift_Preference";
            string table2 = "Employee_Info";
            string on = "a.username = b.username";
            string where = String.Format("b.employee_id = '{0}'", empid);

            string command = CreateJoinDeleteCommand(table1, table2, "INNER JOIN", where, on);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Populates the shift warnings table. </summary>
        ///
        
        ///
        /// <param name="warning">  class object for shift warnings containing all information added to
        ///                         it. </param>
        ///-------------------------------------------------------------------------------------------------

        public void ShiftWarnings(ShiftWarning warning)
        {

            string table = "Shift_Warning";
            string param = "shiftWarning, company_id, store_id, startTime, endTime";
            string value = String.Format("'{0}', {1}, {2}, '{3}', '{4}'", warning.warning, warning.companyID, warning.storeID, warning.startDateTime.ToString(), warning.endDateTime.ToString());

            string command = CreateInsertCommand(table, param, value);
            //Console.WriteLine("Warning Insert " + command);
            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects all shift warnings from the database. </summary>
        ///
        
        ///
        /// <returns>   DataTable dt: contains all of the shift warnings for further processing. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sShiftWarnings()
        {
            string table = "Shift_Warning";
            string where = "";
            string command = CreateSelectCommand(table, where);

            DataTable dt = Read(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Selects all shift warnings from the database that matches to the warning. </summary>
        ///
        
        ///
        /// <param name="shiftWarning"> holds the warning as a string. </param>
        ///
        /// <returns>   DataTable dt: contains all of the shift warnings for further processing. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable sShiftWarnings(string shiftWarning)
        {
            string table = "Shift_Warning";
            string where = "shiftWarning = '" + shiftWarning;
            string command = CreateSelectCommand(table, where);

            DataTable dtShiftPreferences = Read(command);


            return dtShiftPreferences;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     updates all shift warnings from the database that matches to the warning and id.
        /// </summary>
        ///
        
        ///
        /// <param name="id">           id of shift. </param>
        /// <param name="shiftWarning"> holds the warning as a string. </param>
        ///-------------------------------------------------------------------------------------------------

        public void uShiftWarnings(string id, string shiftWarning)
        {
            string table = "Shift_Warning";

            string sw = CreateUpdateProperties("shiftWarning = '{0}'", shiftWarning);

            string param = sw;

            string where = String.Format("shift_id = '{0}'", id);

            string command = CreateUpdateCommand(table, param, where);

            Write(command);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   deletes all shift warnings from the database that matches to the emp id. </summary>
        ///
        
        ///
        /// <param name="empid">    id of employee. </param>
        ///-------------------------------------------------------------------------------------------------

        public void dShiftWarnings(string empid)
        {
            string table1 = "Shift_Warning";
            string table2 = "Employee_Info";
            string on = "a.username = b.username";
            string where = String.Format("b.employee_id = '{0}'", empid);

            string command = CreateJoinDeleteCommand(table1, table2, "INNER JOIN", where, on);

            Write(command);
        }
    }

    // Enums 

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent employee status. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public enum EMPLOYEE_STATUS
    {
        /// <summary>   An enum constant representing the acvtive option. </summary>
        ACVTIVE,
        /// <summary>   An enum constant representing the layed off option. </summary>
        LAYED_OFF,
        /// <summary>   An enum constant representing the fired option. </summary>
        FIRED
    }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Values that represent recurings. </summary>
        ///
        
        ///-------------------------------------------------------------------------------------------------

        public enum RECURING
    {
        /// <summary>   An enum constant representing the daily option. </summary>
        DAILY,
        /// <summary>   An enum constant representing the weekday option. </summary>
        WEEKDAY,
        /// <summary>   An enum constant representing the weekend option. </summary>
        WEEKEND,
        /// <summary>   An enum constant representing the weekly option. </summary>
        WEEKLY,
        /// <summary>   An enum constant representing the monthy option. </summary>
        MONTHY,
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent day of weeks. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public enum DAY_OF_WEEK
    { 
        /// <summary>   An enum constant representing the sunday option. </summary>
        sunday,
        /// <summary>   An enum constant representing the monday option. </summary>
        monday,
        /// <summary>   An enum constant representing the tuesday option. </summary>
        tuesday,
        /// <summary>   An enum constant representing the wednesday option. </summary>
        wednesday,
        /// <summary>   An enum constant representing the thursday option. </summary>
        thursday,
        /// <summary>   An enum constant representing the friday option. </summary>
        friday,
        /// <summary>   An enum constant representing the saturday option. </summary>
        saturday,
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent requests. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public enum REQUEST
    {
        /// <summary>   An enum constant representing the off time option. </summary>
        OFF_TIME,
        /// <summary>   An enum constant representing the on time option. </summary>
        ON_TIME,
        /// <summary>   An enum constant representing the no prefference option. </summary>
        NO_PREFFERENCE,
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent ratings. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public enum RATING
    {
        /// <summary>   An enum constant representing the very bad option. </summary>
        VERY_BAD,
        /// <summary>   An enum constant representing the bad option. </summary>
        BAD,
        /// <summary>   An enum constant representing the neutral option. </summary>
        NEUTRAL,
        /// <summary>   An enum constant representing the good option. </summary>
        GOOD,
        /// <summary>   An enum constant representing the very good option. </summary>
        VERY_GOOD,
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent generic errors. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public enum GENERIC_ERROR
    {
        /// <summary>   An enum constant representing the user name not found option. </summary>
        USER_NAME_NOT_FOUND,
        /// <summary>   An enum constant representing the password not match username option. </summary>
        PASSWORD_NOT_MATCH_USERNAME,
    }
}
