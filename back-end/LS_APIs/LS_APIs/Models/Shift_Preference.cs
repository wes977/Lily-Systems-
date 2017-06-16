///-------------------------------------------------------------------------------------------------
// file:	models\shift_preference.cs
//
// summary:	Implements the shift preference class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A shift preference. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Shift_Preference // The SQL does not really make sense to me 
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the shift prefernce. </summary>
        ///
        /// <value> The identifier of the shift prefernce. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private int shift_Prefernce_ID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the employee. </summary>
        ///
        /// <value> The identifier of the employee. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private int employee_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the day. </summary>
        ///
        /// <value> The day. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private string day { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the start time. </summary>
        ///
        /// <value> The start time. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private DateTime startTime { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the end time. </summary>
        ///
        /// <value> The end time. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private DateTime endTime { get; set; }

    }
}