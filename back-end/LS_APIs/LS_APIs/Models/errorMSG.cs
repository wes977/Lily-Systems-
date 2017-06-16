///-------------------------------------------------------------------------------------------------
// file:	models\errormsg.cs
//
// summary:	Implements the errormsg class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An error message. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public class errorMSG
    {

        public errorMSG(int iErrorCode, string iErrorMsg)
        {
            errorCode = iErrorCode;
            errorMsg = iErrorMsg;
        }

        public errorMSG()
        {
            errorCode = 0;
            errorMsg = "";
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets a message describing the error. </summary>
        ///
        /// <value> A message describing the error. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string errorMsg { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the error code. </summary>
        ///
        /// <value> The error code. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int errorCode { get; set; }

    }
}