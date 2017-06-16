///-------------------------------------------------------------------------------------------------
// file:	Models\Schedule.cs
//
// summary:	Implements the schedule class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A schedule. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Schedule
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the schedule. </summary>
        ///
        /// <value> The identifier of the schedule. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private int schedule_ID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the store. </summary>
        ///
        /// <value> The identifier of the store. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        private int store_ID { get; set; }
    }
}