///-------------------------------------------------------------------------------------------------
// file:	Models\Open_Shifts.cs
//
// summary:	Implements the open shifts class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An open shifts. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Open_Shifts
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the open shift. </summary>
        ///
        /// <value> The identifier of the open shift. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int openShift_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the store. </summary>
        ///
        /// <value> The identifier of the store. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int store_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the shift. </summary>
        ///
        /// <value> The identifier of the shift. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int shift_id { get; set; }
    }
}