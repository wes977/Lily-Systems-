///-------------------------------------------------------------------------------------------------
// file:	Security\security.cs
//
// summary:	Implements the security class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LS_APIs.Security
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A security. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class security
    {

        public static readonly string[] roleNames =
{
            "Super Admin",
            "Admin",
            "Manager",
            "Supervisor",
            "User"

        };
        //Create a membership user

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a new membership user with the specified parameters. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="username">         . </param>
        /// <param name="password">         . </param>
        /// <param name="email">            . </param>
        /// <param name="passwordQuestion"> . </param>
        /// <param name="passwordAnswer">   . </param>
        /// <param name="isApproved">       . </param>
        ///
        /// <returns>
        ///     MembershipUser - object for the newly created user. If no user was created, this method
        ///     returns null.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public MembershipUser AddUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved)
        {
            MembershipCreateStatus status;
            return Membership.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, out status);
            
        }

        //Validate User Login

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Accepts a users login credentials and tries to validate them against the database of
        ///     members.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="username"> . </param>
        /// <param name="password"> . </param>
        ///
        /// <returns>   true - if the user is validated false - if the user is not validated. </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool ValidateUserLogin(string username, string password)
        {
            return Membership.ValidateUser(username, password);          
        }

        //Check if a specific user is in a specific role

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Check whether the given username is in the given role. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="username"> . </param>
        /// <param name="roleName"> . </param>
        ///
        /// <returns>
        ///     true - if the user is in the provided role false - if the user is not in the provided
        ///     role.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool CheckUserInRole(string username, string roleName)
        {
            try
            {
               
                    bool temp  = Roles.IsUserInRole(username, roleName);
                return temp;
            }
            catch (Exception ex)
            {
                //System.ArgumentNullException -> username is null and/or roleName is null
                //System.ArgumentException -> username is an empty string or contains a comma and/or roleName is an empty string or contains a comma
                //System.Configuration.Provider.ProviderException -> role management is not enabled
                return false;
            }
        }

        //Check if the current user is in a specific role

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Checks if the currently logged in user is in the specified role. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="roleName"> . </param>
        ///
        /// <returns>
        ///     true - if the user is in the provided role false - if the user is not in the provided
        ///     role.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public bool CheckInRole(string roleName)
        {
            try { 
                return Roles.IsUserInRole(roleName);
            }
            catch (Exception ex)
            {
                //System.ArgumentNullException -> roleName is null or there is no user currently logged in
                //System.ArgumentException -> roleName is an empty string or contains a comma
                //System.Configuration.Provider.ProviderException -> role management is not enabled
                return false;
            }
        }

        //Add user to a role
        //Other possible methods if needed
        // - AddUsersToRole -> add multiple users to a role
        // - AddUsersToRoles -> add multiple users to multiple roles
        // - AddUserToRoles -> add a users to multiple roles


        public bool UpdateUserToRole(string username, string roleName)
        {
            try
            {
                bool  isInRole = false;

                foreach(string s in roleNames) // making sure role exist 
                {
                    isInRole = Roles.IsUserInRole(username, s); // clearing all old roles 
                    if (isInRole)                                      // yes 
                    {
                        Roles.RemoveUserFromRole(username, s); // remove all roles and all that 
                    }
                    if (s == roleName)
                    {
                        Roles.AddUserToRole(username, roleName);        // adding to new role 
                        //break;
                    }
                }


                return true;

            }
            catch (Exception ex)
            {
                return false;
                //System.ArgumentNullException -> username is null and/or roleName is null
                //System.ArgumentException -> username is an empty string or contains a comma and/or roleName is an empty string or contains a comma
                //System.Configuration.Provider.ProviderException -> role management is not enabled or user already belongs to role
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   User to role. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="username"> . </param>
        /// <param name="roleName"> . </param>
        ///-------------------------------------------------------------------------------------------------

        public void UserToRole(string username, string roleName)
        {
            try
            {
                Roles.AddUserToRole(username, roleName);
                bool temp = Roles.IsUserInRole(username, roleName);
            }
            catch (Exception ex)
            {
                //System.ArgumentNullException -> username is null and/or roleName is null
                //System.ArgumentException -> username is an empty string or contains a comma and/or roleName is an empty string or contains a comma
                //System.Configuration.Provider.ProviderException -> role management is not enabled or user already belongs to role
            }
        }
        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}