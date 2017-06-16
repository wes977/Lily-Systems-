///-------------------------------------------------------------------------------------------------
// file:	models\company_info.cs
//
// summary:	Implements the company information class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Information about the company. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Company_Info
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="iCID">     Zero-based index of the cid. </param>
        /// <param name="iCName">   Name of the c. </param>
        /// <param name="YOI">      The yoi. </param>
        /// <param name="iActive">  Zero-based index of the active. </param>
        ///-------------------------------------------------------------------------------------------------

        public Company_Info(int iCID,string iCName,string YOI,int iActive)
        {
            company_ID = iCID;
            companyName = iCName;
            active = iActive;
            yearOfInc = YOI;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the company. </summary>
        ///
        /// <value> The identifier of the company. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int company_ID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the company. </summary>
        ///
        /// <value> The name of the company. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string companyName { get; set; } // Needs to be limits to max 20 chars 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the active. </summary>
        ///
        /// <value> The active. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int active { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the year of increment. </summary>
        ///
        /// <value> The year of increment. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string yearOfInc { get; set; }


    }
}