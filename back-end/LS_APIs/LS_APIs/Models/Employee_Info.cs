///-------------------------------------------------------------------------------------------------
// file:	Models\Employee_Info.cs
//
// summary:	Implements the employee information class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Information about the employee. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Employee_Info
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="eID">          The identifier. </param>
        /// <param name="userName">     Name of the user. </param>
        /// <param name="pword">        The pword. </param>
        /// <param name="idateofHire">  The idateof hire Date/Time. </param>
        /// <param name="idateofTerm">  The idateof term. </param>
        /// <param name="storeID">      Identifier for the store. </param>
        /// <param name="compID">       Identifier for the component. </param>
        /// <param name="perID">        Identifier for the per. </param>
        /// <param name="iActive">      Zero-based index of the active. </param>
        ///-------------------------------------------------------------------------------------------------

        public Employee_Info(int eID,string userName, string pword, DateTime idateofHire, string idateofTerm, int storeID, int compID, int perID, int iActive)
        {
            employee_id = eID;
            uName = userName;
            password = pword;
            dateOfHire = idateofHire;
            dateOfTerm = idateofTerm;
            store_id = storeID;
            company_id = compID;
            person_id = perID;
            active = iActive;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="eID">          The identifier. </param>
        /// <param name="userName">     Name of the user. </param>
        /// <param name="pword">        The pword. </param>
        /// <param name="idateofHire">  The idateof hire Date/Time. </param>
        /// <param name="storeID">      Identifier for the store. </param>
        /// <param name="compID">       Identifier for the component. </param>
        /// <param name="perID">        Identifier for the per. </param>
        /// <param name="iActive">      Zero-based index of the active. </param>
        ///-------------------------------------------------------------------------------------------------

        public Employee_Info(int eID, string userName, string pword, DateTime idateofHire,  int storeID, int compID, int perID, int iActive)
        {
            employee_id = eID;
            uName = userName;
            password = pword;
            dateOfHire = idateofHire;
            dateOfTerm = "N/A";
            store_id = storeID;
            company_id = compID;
            person_id = perID;
            active = iActive;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        
        ///-------------------------------------------------------------------------------------------------

        public Employee_Info()
        {
            uName = "";
            password = "";
            store_id = -1;
            company_id = -1;
            employee_id = -1;
            active = -1;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the employee. </summary>
        ///
        /// <value> The identifier of the employee. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int employee_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The u name. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string uName { get; set; } // Needs to be limits to max 20 chars 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the password. </summary>
        ///
        /// <value> The password. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string password { get; set; } // 20

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the date of hire. </summary>
        ///
        /// <value> The date of hire. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public DateTime dateOfHire { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the date of term. </summary>
        ///
        /// <value> The date of term. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string dateOfTerm { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the store. </summary>
        ///
        /// <value> The identifier of the store. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int store_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the company. </summary>
        ///
        /// <value> The identifier of the company. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int company_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the person. </summary>
        ///
        /// <value> The identifier of the person. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int person_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the active. </summary>
        ///
        /// <value> The active. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int active { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the role. </summary>
        ///
        /// <value> The role. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string role { get; set; } // 20
    }
}