///-------------------------------------------------------------------------------------------------
// file:	models\store_info.cs
//
// summary:	Implements the store information class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Information about the store. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Store_Info
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="istore_ID">        Identifier for the istore. </param>
        /// <param name="icompanyID">       Identifier for the icompany. </param>
        /// <param name="icmpnName">        Name of the icmpn. </param>
        /// <param name="idivider">         The idivider. </param>
        /// <param name="istoreAddress">    The istore address. </param>
        /// <param name="ipostal">          The ipostal. </param>
        /// <param name="icountry">         The icountry. </param>
        /// <param name="icity">            The icity. </param>
        /// <param name="iphone">           The iPhone. </param>
        /// <param name="ifax">             The ifax. </param>
        /// <param name="iactive">          The iactive. </param>
        ///-------------------------------------------------------------------------------------------------

        public Store_Info(int istore_ID, int icompanyID, string icmpnName ,int idivider, string istoreAddress, string ipostal, string icountry, string icity, string iphone, string ifax, int iactive)
        {
            compName = icmpnName;
            store_id = istore_ID;
            company_id = icompanyID;
            divider = idivider;
            storeAddress = istoreAddress;
            postalCode = ipostal;
            country = icountry;
            city = icity;
            storePhone = iphone;
            fax = ifax;
            active = iactive;

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the store. </summary>
        ///
        /// <value> The identifier of the store. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int store_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the component. </summary>
        ///
        /// <value> The name of the component. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string compName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the company. </summary>
        ///
        /// <value> The identifier of the company. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int company_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the divider. </summary>
        ///
        /// <value> The divider. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int divider { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the store address. </summary>
        ///
        /// <value> The store address. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string storeAddress { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the postal code. </summary>
        ///
        /// <value> The postal code. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string postalCode { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the country. </summary>
        ///
        /// <value> The country. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string country { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the city. </summary>
        ///
        /// <value> The city. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string city { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the store phone. </summary>
        ///
        /// <value> The store phone. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string storePhone { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the fax. </summary>
        ///
        /// <value> The fax. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string fax { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the active. </summary>
        ///
        /// <value> The active. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int active { get; set; }


    }
}