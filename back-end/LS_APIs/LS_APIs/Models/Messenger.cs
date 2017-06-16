///-------------------------------------------------------------------------------------------------
// file:	Models\Messenger.cs
//
// summary:	Implements the messenger class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A messenger. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Messenger
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="iMessenger_ID">    Identifier for the messenger. </param>
        /// <param name="iSender_ID">       Identifier for the sender. </param>
        /// <param name="iRec_ID">          Identifier for the record. </param>
        /// <param name="iSubject">         Zero-based index of the subject. </param>
        /// <param name="iWords">           Zero-based index of the words. </param>
        /// <param name="iMsgDate">         The message date. </param>
        /// <param name="iShiftReq">        (Optional) Zero-based index of the shift request. </param>
        ///-------------------------------------------------------------------------------------------------

        public Messenger(int iMessenger_ID, int iSender_ID, int iRec_ID, string iSubject, string iWords, DateTime iMsgDate, int iShiftReq = 0)
        {
            Messenger_ID = iMessenger_ID;
            Sender_ID = iSender_ID;
            Rec_ID = iRec_ID;
            Subject = iSubject;
            Words = iWords;
            messageDate = iMsgDate;
            shiftReq = iShiftReq;

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the messenger. </summary>
        ///
        /// <value> The identifier of the messenger. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int Messenger_ID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the sender. </summary>
        ///
        /// <value> The identifier of the sender. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int Sender_ID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the record. </summary>
        ///
        /// <value> The identifier of the record. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int Rec_ID { get; set; } // Needs to be limits to max 20 chars 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the subject. </summary>
        ///
        /// <value> The subject. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string Subject { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the words. </summary>
        ///
        /// <value> The words. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string Words { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the message date. </summary>
        ///
        /// <value> The message date. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public DateTime messageDate { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the shift request. </summary>
        ///
        /// <value> The shift request. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int shiftReq { get; set; }
    }
}