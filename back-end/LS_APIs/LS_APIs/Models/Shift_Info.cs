///-------------------------------------------------------------------------------------------------
// file:	Models\Shift_Info.cs
//
// summary:	Implements the shift information class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Information about the shift. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Shift_Info
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public Shift_Info()
        {
           
            employee_id = 0;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the shift. </summary>
        ///
        /// <value> The identifier of the shift. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int shift_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the start time. </summary>
        ///
        /// <value> The start time. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public DateTime startTime { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the end time. </summary>
        ///
        /// <value> The end time. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public DateTime endTime { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the employee. </summary>
        ///
        /// <value> The identifier of the employee. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int  employee_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the schedule. </summary>
        ///
        /// <value> The identifier of the schedule. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int schedule_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the store. </summary>
        ///
        /// <value> The identifier of the store. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int store_id { get; set; }
    }
}