///-------------------------------------------------------------------------------------------------
// file:	App_Start\FilterConfig.cs
//
// summary:	Implements the filter configuration class
///-------------------------------------------------------------------------------------------------

using System.Web;
using System.Web.Mvc;

namespace LS_APIs
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A filter configuration. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class FilterConfig
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Registers the global filters described by filters. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="filters">  The filters. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
