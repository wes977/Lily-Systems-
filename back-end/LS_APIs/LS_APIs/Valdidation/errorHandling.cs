using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LS_APIs.Models;
using System.Data;
using LS_APIs.DAL;
using System.Web.Security;
using LS_APIs.Security;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
namespace LS_APIs.Validation
{
    enum errorPlacement
    {
        companyName,
        YOC,

    }

    /// <summary>   List of names of the columns. </summary>


    public class errorHandling
    {
        public static readonly string[] columnNames = { "employee_id", "username", "password", "dateOfHire", "dateOfTermination", "store_id", "company_id", "person_id", "active" };
        /// <summary>   The second column names. </summary>
        public static readonly string[] columnNames2 = {
            "person_id",
            "firstName",
            "lastName",
            "phoneNumber",
            "email",
            "personAddress",
            "postalCode",
            "country",
            "city",
            "socialNumber"};

        /// <summary>   List of names of the roles. </summary>
        public static readonly string[] roleNames =
    {
            "Super Admin",
            "Admin",
            "Manager",
            "Supervisor",
            "User"

        };
        public List<errorMSG> companyEH(string companyName, string YOC, string id = "0")
        {
            IValidation val = new IValidation();
            ErrorMessages eMSG = new ErrorMessages();
            errorMSG returnMsg = new errorMSG();
            returnMsg.errorMsg = "";
            returnMsg.errorCode = kErrorCodes.NoError;
            List<errorMSG> errorList = new List<errorMSG>();
            Logic mDAL = new Logic();
            int errorCode = kErrorCodes.NoError;
            try
            {
                if ((errorCode = val.checkForInput(id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                if ((errorCode = val.checkForInput(companyName)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                if ((errorCode = val.checkForInput(YOC)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                if ((errorCode = val.validateID(id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if (id != "0")
                {
                    DataTable tempDT = mDAL.sCompany(id.ToString());
                    if (tempDT.Rows.Count != 1)
                    {
                        errorList.Add(returnMsg = new errorMSG(405, "No company Found with that ID"));
                    }
                }

                if ((errorCode = val.validateStoreName(companyName)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                if ((errorCode = val.validateYearOfIncorperation(YOC)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                return errorList;
            }
            catch (Exception e)
            {
                returnMsg.errorMsg = e.ToString();
                returnMsg.errorCode = 404;
                errorList.Add(returnMsg = new errorMSG(404, e.ToString()));
                return errorList;
            }
        }

        public List<errorMSG> uEmployeeEH(Employee_Info value, string empID = "0")
        {
            Logic mDAL = new Logic();
            security sec = new security();
            JArray tempList = new JArray();
            DataTable tempDT = mDAL.sPerson(value.person_id.ToString());
            errorMSG returnMsg = new errorMSG();
            List<errorMSG> errorList = new List<errorMSG>();
            if (tempDT.Rows.Count != 1)                                                             // Making sure there is a person with that information 
            {
                errorList.Add(returnMsg = new errorMSG(404, "No person with that ID !"));
                return errorList;
            }
            else
            {
                Person_Info tempPI = new Person_Info();
                IValidation val = new IValidation();
                ErrorMessages eMSG = new ErrorMessages();
                returnMsg.errorMsg = "";
                returnMsg.errorCode = kErrorCodes.NoError;
                int errorCode = kErrorCodes.NoError;
                try
                {
                    // Password 
                    if ((errorCode = val.checkForInput(value.password)) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                    }
                    else if ((errorCode = val.validatePassword(value.password)) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // The actualy validation 
                    }
                    // Roles
                    if ((errorCode = val.checkForInput(value.role)) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                    }
                    int counter = 0;
                    foreach (string r in roleNames)
                    {
                        if (value.role == r)
                        {
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    if (counter == roleNames.Length)
                    {
                        errorList.Add(returnMsg = new errorMSG(1, "Could Find Role!"));   // The actualy validation 
                    }
                    // Date of Hire && Date of termination 
                    if ((errorCode = val.checkForInput(value.dateOfTerm)) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                    }
                    if ((errorCode = val.checkForInput(value.dateOfHire.ToString())) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                    }

                    // Membership 
                    if (Membership.ValidateUser(value.uName, value.password))
                    {
                        errorList.Add(returnMsg = new errorMSG(23, "Membership Validation error"));   // The actualy validation 
                    }

                    // Store ID  
                    if ((errorCode = val.checkForInput(value.store_id.ToString())) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                    }
                    // Store ID  
                    if ((errorCode = val.validateID(value.store_id.ToString())) != kErrorCodes.NoError)
                    {
                        errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                    }

                    return errorList;
                }
                catch (Exception e)
                {
                    returnMsg.errorMsg = e.ToString();
                    returnMsg.errorCode = 404;
                    return errorList;
                }
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Employee eh. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-18. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   A List&lt;errorMSG&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        public List<errorMSG> iEmployeeEH(Employee_Info value)
        {
            Logic mDAL = new Logic();
            security sec = new security();
            JArray tempList = new JArray();
            DataTable tempDT = mDAL.sPerson(value.person_id.ToString());
            errorMSG returnMsg = new errorMSG();
            List<errorMSG> errorList = new List<errorMSG>();


            Person_Info tempPI = new Person_Info();
            IValidation val = new IValidation();
            ErrorMessages eMSG = new ErrorMessages();
            returnMsg.errorMsg = "";
            returnMsg.errorCode = kErrorCodes.NoError;
            int errorCode = kErrorCodes.NoError;
            try
            {
                // Username 
                if ((errorCode = val.checkForInput(value.uName)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }
                else if ((errorCode = val.validateName(value.uName)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   //  Actually Validating the Username 
                }
                // Password 
                if ((errorCode = val.checkForInput(value.password)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }
                else if ((errorCode = val.validatePassword(value.password)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // The actualy validation 
                }
                // Roles
                if ((errorCode = val.checkForInput(value.role)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }
                int counter = 0;
                foreach (string r in roleNames)
                {
                    if (value.role == r)
                    {
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                if (counter == roleNames.Length)
                {
                    errorList.Add(returnMsg = new errorMSG(1, "Could Find Role!"));   // The actualy validation 
                }
                // Date of Hire && Date of termination 
                if ((errorCode = val.checkForInput(value.dateOfTerm)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }
                if ((errorCode = val.checkForInput(value.dateOfHire.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }

                // Membership 
                if (Membership.ValidateUser(value.uName, value.password))
                {
                    errorList.Add(returnMsg = new errorMSG(23, "Membership Validation error"));   // The actualy validation 
                }

                // Store ID  
                if ((errorCode = val.checkForInput(value.store_id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }
                // Store ID  
                if ((errorCode = val.validateID(value.store_id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));   // Making sure something is there 
                }

                // No other errors check for the existing person 
                if (tempDT.Rows.Count != 1 && errorList.Count == 0)                                                             // Making sure there is a person with that information 
                {
                    errorList.Add(returnMsg = new errorMSG(6969, "Please fill out all personal!"));
                    return errorList;
                }
                return errorList;
            }
            catch (Exception e)
            {
                returnMsg.errorMsg = e.ToString();
                returnMsg.errorCode = 404;
                return errorList;
            }

        }


        public List<errorMSG> personEH(string fname, string lName, string phone, string email, string personAddress, string postal, string country, string city, string id = "0")
        {
            IValidation val = new IValidation();
            ErrorMessages eMSG = new ErrorMessages();
            errorMSG returnMsg = new errorMSG();
            returnMsg.errorMsg = "";
            returnMsg.errorCode = kErrorCodes.NoError;
            List<errorMSG> errorList = new List<errorMSG>();
            Logic mDAL = new Logic();
            int errorCode = kErrorCodes.NoError;
            try
            {
                DataTable dt = mDAL.sPerson();
                foreach (DataRow row in dt.Rows)
                {
                    Person_Info tempEI = new Person_Info(
                        Int32.Parse(row[columnNames2[0]].ToString()),
                        row[columnNames2[1]].ToString(),
                        row[columnNames2[2]].ToString(),
                        row[columnNames2[3]].ToString(),
                        row[columnNames2[4]].ToString(),
                        row[columnNames2[5]].ToString(),
                        row[columnNames2[6]].ToString(),
                        row[columnNames2[7]].ToString(),
                        row[columnNames2[8]].ToString(),
                        row[columnNames2[9]].ToString());
                    if (tempEI.fName == fname &&
                        tempEI.lName == lName &&
                        tempEI.phoneNum == phone &&
                        tempEI.email == email &&
                        tempEI.personAddress == personAddress &&
                        tempEI.postalCode == postal &&
                        tempEI.country == country &&
                        tempEI.city == city
                        )
                    {
                        errorList.Add(returnMsg = new errorMSG(343434, "Validation"));
                        break; 
                    }
                }

                // First Name 
                // Validation 
                if ((errorCode = val.checkForInput(fname)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateName(fname)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Last Name 
                // Validation 
                if ((errorCode = val.checkForInput(lName)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateName(lName)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Phone
                // Validation 
                if ((errorCode = val.checkForInput(phone)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validatePhoneNum(phone)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // email
                // Validation 
                if ((errorCode = val.checkForInput(email)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateEmail(email)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Address
                // Validation 
                if ((errorCode = val.checkForInput(personAddress)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateStreetAddress(personAddress)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Postakl Code 
                // Validation 
                if ((errorCode = val.checkForInput(postal)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validatePostalCode(postal)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Country 
                // Validation 
                if ((errorCode = val.checkForInput(country)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateCountry(country)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // City 
                // Validation 
                if ((errorCode = val.checkForInput(city)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateCity(city)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }


                // Person ID  
                // Validation 
                if ((errorCode = val.validateID(id)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if (id != "0")
                {
                    DataTable tempDT = mDAL.sPerson(id.ToString());
                    if (tempDT.Rows.Count != 1)
                    {
                        errorList.Add(returnMsg = new errorMSG(405, "No person Found with that ID"));
                    }
                }
                return errorList;
            }
            catch (Exception e)
            {
                errorList.Add(returnMsg = new errorMSG(404, e.ToString()));
                return errorList;
            }
        }


        public List<errorMSG> storeEH(Store_Info value, string id = "0")
        {
            IValidation val = new IValidation();
            ErrorMessages eMSG = new ErrorMessages();
            errorMSG returnMsg = new errorMSG();
            List<errorMSG> errorList = new List<errorMSG>();
            returnMsg.errorMsg = "";
            returnMsg.errorCode = kErrorCodes.NoError;
            Logic mDAL = new Logic();
            int errorCode = kErrorCodes.NoError;
            try
            {
                // Store ID 

                if ((errorCode = val.checkForInput(id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateID(id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if (id != "0")
                {
                    DataTable tempDT = mDAL.sStore(id.ToString());
                    if (tempDT.Rows.Count != 1)
                    {
                        errorList.Add(returnMsg = new errorMSG(405, "No store Found"));
                    }
                }

                // Company ID 

                if ((errorCode = val.checkForInput(value.company_id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateID(value.company_id.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Divider

                if ((errorCode = val.checkForInput(value.divider.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateStoreDivider(value.divider.ToString())) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Address 

                if ((errorCode = val.checkForInput(value.storeAddress)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validateStreetAddress(value.storeAddress)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Postal

                if ((errorCode = val.checkForInput(value.postalCode)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validatePostalCode(value.postalCode)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Coutnry 

                if ((errorCode = val.checkForInput(value.country)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                if ((errorCode = val.validateCountry(value.country)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                //City

                if ((errorCode = val.checkForInput(value.city)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                if ((errorCode = val.validateCity(value.city)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // store phone 

                if ((errorCode = val.checkForInput(value.storePhone)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validatePhoneNum(value.storePhone)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                // Store  fax 

                if ((errorCode = val.checkForInput(value.fax)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }
                else if ((errorCode = val.validatePhoneNum(value.fax)) != kErrorCodes.NoError)
                {
                    errorList.Add(returnMsg = new errorMSG(errorCode, eMSG.errorMessage(errorCode)));
                }

                return errorList;
            }
            catch (Exception e)
            {
                errorList.Add(returnMsg = new errorMSG(405, e.ToString()));
                return errorList;
            }
        }

    }
}

