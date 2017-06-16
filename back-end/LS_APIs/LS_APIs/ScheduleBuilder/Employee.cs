/*
 File Name      :   Employee.cs
 Date           :   February 10, 2017
 Description    :   The employee class is responsible for dealing with the employee information of the users
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Enums. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public enum EMPLOYEE_TYPE
    {
        /// <summary>   An enum constant representing the casual option. </summary>
        CASUAL,
        /// <summary>   An enum constant representing the part time option. </summary>
        PART_TIME,
        /// <summary>   An enum constant representing the full time option. </summary>
        FULL_TIME
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent security levels. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public enum SECURITY_LEVELS
    {
        /// <summary>   An enum constant representing the manager option. </summary>
        MANAGER,
        /// <summary>   An enum constant representing the supervisor option. </summary>
        SUPERVISOR,
        /// <summary>   An enum constant representing the worker option. </summary>
        WORKER,
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   This is the Employee class containing the information of each employee. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Employee
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the security level. </summary>
        ///
        /// <value> The security level. </value>
        ///-------------------------------------------------------------------------------------------------

        public SECURITY_LEVELS securityLevel { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the type of the employee. </summary>
        ///
        /// <value> The type of the employee. </value>
        ///-------------------------------------------------------------------------------------------------

        public EMPLOYEE_TYPE employeeType { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the employee. </summary>
        ///
        /// <value> The identifier of the employee. </value>
        ///-------------------------------------------------------------------------------------------------

        public int employeeID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the employee first. </summary>
        ///
        /// <value> The name of the employee first. </value>
        ///-------------------------------------------------------------------------------------------------

        public string employeeFirstName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the employee last. </summary>
        ///
        /// <value> The name of the employee last. </value>
        ///-------------------------------------------------------------------------------------------------

        public string employeeLastName { get; set; }
        /// <summary>   The phone number. </summary>
        private string phoneNumber;
        /// <summary>   The email. </summary>
        private string email;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the store. </summary>
        ///
        /// <value> The identifier of the store. </value>
        ///-------------------------------------------------------------------------------------------------

        public int storeID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the company. </summary>
        ///
        /// <value> The identifier of the company. </value>
        ///-------------------------------------------------------------------------------------------------

        public int companyID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   This is the constructor for the employee class using default values. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public Employee()
        {
            securityLevel = SECURITY_LEVELS.WORKER;
            employeeType = EMPLOYEE_TYPE.CASUAL;
            employeeID = 0;
            employeeFirstName = "";
            employeeLastName = "";
            phoneNumber = "";
            email = "";
            storeID = 0;
            companyID = 0;
        }
    }
}