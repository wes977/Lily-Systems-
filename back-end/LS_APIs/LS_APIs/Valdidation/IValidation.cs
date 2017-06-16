///-------------------------------------------------------------------------------------------------
// file:	valdidation\ivalidation.cs
//
// summary:	Implements the ivalidation class
///-------------------------------------------------------------------------------------------------

using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
/*
* FILE			: IValidation.cs
* PROJECT		: PROG(3220)-Systems Project
* FIRST VERSION : 2017-03-20
* DESCRIPTION	: This is a set of classes for validating users input
*/

namespace LS_APIs.Validation
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A consts. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public static class consts
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 8. </summary>
        ///
        /// <value> The 8. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MinLength = 0;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 10. </summary>
        ///
        /// <value> The 10. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MinPhoneNumberLength = 10;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 15. </summary>
        ///
        /// <value> The 15. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxPhoneNumberLength = 15;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 1. </summary>
        ///
        /// <value> The 1. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxDotCount = 1;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 1. </summary>
        ///
        /// <value> The 1. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxAtCount = 1;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 20. </summary>
        ///
        /// <value> The 20. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxNameLength = 20;
        

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 320. </summary>
        ///
        /// <value> The 320. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxEmailLength = 320;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 100. </summary>
        ///
        /// <value> The 100. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxAddressLength = 100;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 10. </summary>
        ///
        /// <value> The 10. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxPostalCodeLength = 10;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 52. </summary>
        ///
        /// <value> The 52. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxCountryLength = 52;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 58. </summary>
        ///
        /// <value> The 58. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxCityLength = 58;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 20. </summary>
        ///
        /// <value> The 20. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxUserNameLength = 20;

        //make this whatever you want, idc
        public const int MinUserNameLength = 1;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 20. </summary>
        ///
        /// <value> The 20. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxPasswordLength = 20;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 20. </summary>
        ///
        /// <value> The 20. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxCompanyLength = 20;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 20. </summary>
        ///
        /// <value> The 20. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxStoreLength = 20;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 18. </summary>
        ///
        /// <value> The 18. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int MaxFaxLength = 18;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 4. </summary>
        ///
        /// <value> The 4. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int YearLength = 4;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 7. </summary>
        ///
        /// <value> The 7. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int PostalCodeLengthWithSpace = 7;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 6. </summary>
        ///
        /// <value> The 6. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int PostalCodeLengthWithoutSpace = 6;
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An error codes. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public static class kErrorCodes
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 0. </summary>
        ///
        /// <value> The 0. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int NoError = 0;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 1. </summary>
        ///
        /// <value> The 1. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int InvalidCharacters = 1;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 2. </summary>
        ///
        /// <value> The 2. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int InputNeeded = 2;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 3. </summary>
        ///
        /// <value> The 3. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int TooShort = 3;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 4. </summary>
        ///
        /// <value> The 4. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int notNumber = 4;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 5. </summary>
        ///
        /// <value> The 5. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int pNumTooLong = 5;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 6. </summary>
        ///
        /// <value> The 6. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int emailMissingAtSign = 6;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 7. </summary>
        ///
        /// <value> The 7. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int emailMissingEmailEnding = 7;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 8. </summary>
        ///
        /// <value> The 8. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int endTimeBeforeStartTime = 8;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 9. </summary>
        ///
        /// <value> The 9. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int pNumTooShort = 9;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 10. </summary>
        ///
        /// <value> The 10. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int tooManyAtSigns = 10;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 11. </summary>
        ///
        /// <value> The 11. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int tooManydots = 11;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 12. </summary>
        ///
        /// <value> The 12. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int notBoolean = 12;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 13. </summary>
        ///
        /// <value> The 13. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int invalidPostalCode = 13;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 14. </summary>
        ///
        /// <value> The 14. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int invalidCountry = 14;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 15. </summary>
        ///
        /// <value> The 15. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int cityNameTooLong = 15;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 16. </summary>
        ///
        /// <value> The 16. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int inputTooLong = 16;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 18. </summary>
        ///
        /// <value> The 18. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int invalidFaxFormat = 18;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 19. </summary>
        ///
        /// <value> The 19. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int invalidIncorpirationYear = 19;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 20. </summary>
        ///
        /// <value> The 20. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int invalidYearFormat = 20;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 21. </summary>
        ///
        /// <value> The 21. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int invalidStreetAddress = 21;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 22. </summary>
        ///
        /// <value> The 22. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int inputMustBePositive = 22;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the 23. </summary>
        ///
        /// <value> The 23. </value>
        ///-------------------------------------------------------------------------------------------------

        public const int notDateTime = 23;

        /// <summary>
        /// Invalid password - must be at least 6 characters long, contain one number, and one special character
        /// </summary>
        public const int invalidPassword = 24;

        /// <summary>
        /// Invalid Username - Must be at least 1 characters long, and no more than 20 character long.
        /// </summary>
        public const int invalidUsername = 25;

        public const int InvalidName = 26;
        public const int InvalidCompanyName = 27;
        public const int InvalidStoreName = 28;
        public const int InvalidStoreDivider = 29;
        public const int InvalidAverageHours = 30;
        public const int InvalidPhoneNumber = 31;
        public const int InvalidEmail = 32;
        public const int InvalidDateTime = 33;
        public const int InvalidActive = 34;
        public const int InvalidPostalCode = 35;
        public const int InvalidCountry = 36;
        public const int InvalidCity = 37;
        public const int InvalidFax = 38;
        public const int InvalidYearOfIncorperation = 39;
        public const int InvalidStreetAddress = 40;
        public const int InvalidID = 41;
        public const int PasswordLength = 42;
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An error messages. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public class ErrorMessages
    {
        // FUNCTION     : errorMessage
        // DESCRIPTION  : returns that appropriate error message for the error number its given
        // PARAMETERS   : <int><errNum><error number that needs a error message>
        // RETURNS      : <string><message><error message for corrisponding number>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Error message. </summary>
        ///
        
        ///
        /// <param name="errorNum"> The error number. </param>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string errorMessage(int errorNum)
        {
            string message = "";
            if (errorNum == kErrorCodes.InputNeeded)
            {
                message = "No input. Input needed. ";
            }
            else if (errorNum == kErrorCodes.InvalidName)
            {
                message = "Invalid name. Name must be less than " + consts.MaxNameLength.ToString() + " characters in length and only include english letters, periods, \"-\", or \"'\". ";
            }
            else if (errorNum == kErrorCodes.InvalidCompanyName)
            {
                message = "Invalid company name. Company name must be less than " + consts.MaxCompanyLength.ToString() + " characters in length";
            }
            else if (errorNum == kErrorCodes.InvalidStoreName)
            {
                message = "Invalid store name. Store Namme must be less than " + consts.MaxStoreLength.ToString() + " characters in length";
            }
            else if (errorNum == kErrorCodes.InvalidStoreDivider)
            {
                message = "Invalid store divider. Store divider must be a positive number";
            }
            else if (errorNum == kErrorCodes.InvalidAverageHours)
            {
                message = "Invalid average hours. Average hours must be a positive number";
            }
            else if (errorNum == kErrorCodes.InvalidPhoneNumber)
            {
                message = "Invalid phone number. Phone number must be between " + consts.MinPhoneNumberLength.ToString() + " and " + consts.MaxPhoneNumberLength.ToString() + " characters in length. phone numbers can only include numbers, brackets(), dashes-, periods., or spaces";
            }
            else if (errorNum == kErrorCodes.InvalidEmail)
            {
                message = "Invalid email. Email must be less than " + consts.MaxEmailLength.ToString() + " characters in length. Email address also cannot have two periods in a row. Email address cannot have more than two @ symbols. Email address must end in .com or .ca";
            }
            else if (errorNum == kErrorCodes.InvalidDateTime)
            {
                message = "Invalid datetime. End date must be after start date";
            }
            else if (errorNum == kErrorCodes.InvalidActive)
            {
                message = "Invalid active. Active must be a bool";
            }
            else if (errorNum == kErrorCodes.InvalidPostalCode)
            {
                message = "Invalid Please use the following format: A1A 1A1 or A1A1A1.";
            }
            else if (errorNum == kErrorCodes.InvalidCountry)
            {
                message = "Invalid country. Canada is the only that is valid";
            }
            else if (errorNum == kErrorCodes.InvalidCity)
            {
                message = "Invalid city. City must be less than " + consts.MaxCityLength.ToString() + " characters in length. City can only contain letters ', space, ., and -'s";
            }
            else if (errorNum == kErrorCodes.InvalidFax)
            {
                message = "Invalid fax. Fax number should be in +44 (161) 999 8888 format. Fax number must be less than " + consts.MaxFaxLength.ToString() + " characters in length";
            }
            else if (errorNum == kErrorCodes.InvalidYearOfIncorperation)
            {
                message = "Invalid year of incorperation. year must be a number greater than 999 and less than or equal to current year";
            }
            else if (errorNum == kErrorCodes.InvalidStreetAddress)
            {
                message = "Invalid street address. Street address can only include numbers, letters, ', -, space, or commas. Street address must be less than " + consts.MaxAddressLength.ToString() + "characters in length";
            }
            else if (errorNum == kErrorCodes.InvalidID)
            {
                message = "Invalid ID. ID must be a number";
            }
            else if (errorNum == kErrorCodes.PasswordLength)
            {
                message = "The Password Has to be " + Membership.MinRequiredPasswordLength + "in length";
            }






            //else if (errorNum == kErrorCodes.InvalidCharacters)
            //{
            //    message = "Invlaid character(s). Please only use english letters, periods, \"-\", or \"'\". ";
            //}
            //else if (errorNum == kErrorCodes.TooShort)
            //{
            //    message = "Input too short. Input must contain at least " + consts.MinLength.ToString() + " characters. ";
            //}
            //else if (errorNum == kErrorCodes.pNumTooShort)
            //{
            //    message = "Phone number too short. Phone number must contain " + consts.MinPhoneNumberLength.ToString() + " numbers. ";
            //}
            //else if (errorNum == kErrorCodes.pNumTooLong)
            //{
            //    message = "Phone number too long. Phone number must contain " + consts.MaxPhoneNumberLength.ToString() + " numbers. ";
            //}
            //else if (errorNum == kErrorCodes.notNumber)
            //{
            //    message = "Invalid input. Input must be a number. ";
            //}
            //else if (errorNum == kErrorCodes.emailMissingAtSign)
            //{
            //    message = @"Email was missing an @ sign. ";
            //}
            //else if (errorNum == kErrorCodes.emailMissingEmailEnding)
            //{
            //    message = "Email address must end with .com or .ca. ";
            //}
            //else if (errorNum == kErrorCodes.endTimeBeforeStartTime)
            //{
            //    message = "Start time must be before the end time. ";
            //}
            //else if (errorNum == kErrorCodes.tooManyAtSigns)
            //{
            //    message = @"Too many @ signs. Cannot contain more than " + consts.MaxAtCount.ToString() + @" @ signs. ";
            //}
            //else if (errorNum == kErrorCodes.tooManydots)
            //{
            //    message = "Too many periods. Cannot contain more than " + consts.MaxDotCount.ToString() + " periods in a row";
            //}
            //else if (errorNum == kErrorCodes.notBoolean)
            //{
            //    message = "Input must be a Boolean. Invalid input please try agian. ";
            //}
            //else if (errorNum == kErrorCodes.invalidPostalCode)
            //{
            //    message = "Invalid postal code format. Please use the following format: A1A 1A1 or A1A1A1. ";
            //}
            //else if (errorNum == kErrorCodes.invalidCountry)
            //{
            //    message = "Invalid Country. The country you entered was not recognized, please try again. ";
            //}
            //else if (errorNum == kErrorCodes.inputTooLong)
            //{
            //    message = "Input was too long, please shorten your input. ";
            //}
            //else if (errorNum == kErrorCodes.invalidFaxFormat)
            //{
            //    message = "Invalid fax format. Fax number should be in +44 (161) 999 8888 format. ";
            //}
            //else if (errorNum == kErrorCodes.invalidIncorpirationYear)
            //{
            //    message = "Invalid Year. Year must be less than or equal to Current year. ";
            //}
            //else if (errorNum == kErrorCodes.invalidYearFormat)
            //{
            //    message = "Invalid year format. Year must be in YYYY format. ";
            //}
            //else if (errorNum == kErrorCodes.invalidStreetAddress)
            //{
            //    message = "Invalid Street Address Format. Please use a valid street address format ex. 123 SampleStreet Road. Address can only contain letters, numbers, commas, and periods. ";
            //}
            //else if (errorNum == kErrorCodes.inputMustBePositive)
            //{
            //    message = "Invaild Number. Number must be positive";
            //}
            //else if (errorNum == kErrorCodes.notDateTime)
            //{
            //    message = "Invaild DateTime. Input must be a DateTime";
            //}


            else if(errorNum == kErrorCodes.invalidPassword)
            {
                message = "Invalid password - must be at least 7 characters long, contain one number, and one special character";
            }
            else if (errorNum == kErrorCodes.invalidUsername)
            {
                message = String.Format("Invalid Username - Must be at least {0} characters long, and no more than {1} character long", consts.MinUserNameLength, consts.MaxUserNameLength);
            }

            return message;
        }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A validation. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public class IValidation
    {
        // FUNCTION     : checkForInput
        // DESCRIPTION  : returns error code if there is no input
        // PARAMETERS   : <string><input><string to check if it conitains any input>
        // RETURNS      : <int><retVal><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Check for input. </summary>
        ///
        
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int checkForInput(string input)
        {
            int retVal = kErrorCodes.NoError;
            string trimmedInput = input.Trim();
            if (trimmedInput.Length <= 0) // 
            {
                retVal = kErrorCodes.InputNeeded;
            }
            return retVal;
        }

        // FUNCTION     : validateName
        // DESCRIPTION  : returns error code if name is invlaid
        // PARAMETERS   : <string><name><string to check if valid>
        // RETURNS      : <int><retVal><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the name described by Name. </summary>
        ///
        
        ///
        /// <param name="Name"> The name. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateName(string Name)
        {
            int retVal = kErrorCodes.NoError;

            if (Name.Length > consts.MaxNameLength)
            {
                retVal = kErrorCodes.InvalidName;//retVal = kErrorCodes.inputTooLong;
            }
            else if (!Regex.IsMatch(Name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                retVal = kErrorCodes.InvalidName; //retVal = kErrorCodes.InvalidCharacters;
            }
            return retVal;
        }

        // FUNCTION     : validateUserName
        // DESCRIPTION  : returns error code if userName is invlaid
        // PARAMETERS   : <string><userName><string to check if valid>
        // RETURNS      : <int><retVal><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the user name described by userName. </summary>
        ///
        
        ///
        /// <param name="userName"> Name of the user. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateUserName(string userName)
        {
            int retVal = kErrorCodes.NoError;

            if (userName.Length > consts.MaxUserNameLength || userName.Length < consts.MinUserNameLength)
            {
                retVal = kErrorCodes.invalidUsername;
            }
            else if (!Regex.IsMatch(userName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                retVal = kErrorCodes.invalidUsername;
            }
            return retVal;
        }

        // FUNCTION     : validatePassword
        // DESCRIPTION  : returns error code if password is invlaid
        // PARAMETERS   : <string><pass><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the password described by pass. </summary>
        ///
        
        ///
        /// <param name="pass"> The pass. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validatePassword(string pass)
        {
            int retval = kErrorCodes.NoError;
            string pwordRX = Membership.PasswordStrengthRegularExpression;
            Regex r = new Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");

            if ((pass.Length < Membership.MinRequiredPasswordLength))
            {
                retval = kErrorCodes.invalidPassword;
            }
            if (!r.IsMatch(pass))
            {
                retval = kErrorCodes.invalidPassword;
            }

            return retval;
        }

        // FUNCTION     : validateCompanyName
        // DESCRIPTION  : returns error code if company name is invlaid
        // PARAMETERS   : <string><company><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the company name described by company. </summary>
        ///
        
        ///
        /// <param name="company">  The company. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateCompanyName(string company)
        {
            int retval = kErrorCodes.NoError;
            if (company.Length > consts.MaxCompanyLength)
            {
                retval = kErrorCodes.InvalidCompanyName;
            }
            return retval;
        }

        // FUNCTION     : validateStoreName
        // DESCRIPTION  : returns error code if store name is invlaid
        // PARAMETERS   : <string><storeName><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the store name described by storeName. </summary>
        ///

        ///
        /// <param name="storeName">    Name of the store. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateStoreName(string storeName)
        {
            int retval = kErrorCodes.NoError;
            if (storeName.Length > consts.MaxStoreLength)
            {
                retval = kErrorCodes.InvalidStoreName;
            }
            return retval;
        }

        // FUNCTION     : validateStoreDivider
        // DESCRIPTION  : returns error code if store divider is invlaid
        // PARAMETERS   : <string><divider><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the store divider described by divider. </summary>
        ///

        ///
        /// <param name="divider">  The divider. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateStoreDivider(string divider)
        {
            int retval = kErrorCodes.NoError;
            float f = 0;
            int i = 0;
            if (!float.TryParse(divider, out f) && !int.TryParse(divider, out i))
            {
                retval = kErrorCodes.InvalidStoreDivider;//retval = kErrorCodes.notNumber;
            }
            else if (i <= 0 && f <= 0)
            {
                retval = kErrorCodes.InvalidStoreDivider;//retval = kErrorCodes.inputMustBePositive;
            }
            return retval;
        }

        // FUNCTION     : validateStoreAvgHrs
        // DESCRIPTION  : returns error code if store average hours is invlaid
        // PARAMETERS   : <string><avgHrs><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the store average hrs described by avgHrs. </summary>
        ///
        
        ///
        /// <param name="avgHrs">   The average hrs. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateStoreAvgHrs(string avgHrs)
        {
            int retval = kErrorCodes.NoError;
            float f = 0;
            int i = 0;
            if (!float.TryParse(avgHrs, out f) && !int.TryParse(avgHrs, out i))
            {
                retval = kErrorCodes.InvalidAverageHours; //retval = kErrorCodes.notNumber;
            }
            else if (i <= 0 && f <= 0)
            {
                retval = kErrorCodes.InvalidAverageHours; //retval = kErrorCodes.inputMustBePositive;
            }
            return retval;
        }

        // FUNCTION     : validateStore
        // DESCRIPTION  : validates all attrivutes of a store and returns a error code if any of the elements failed
        // PARAMETERS   : <string><name><name of store string to check if valid> : <string><divider><string to check if valid> : <string><avgHrs><average shift hours string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the store. </summary>
        ///
        
        ///
        /// <param name="name">     The name. </param>
        /// <param name="divider">  The divider. </param>
        /// <param name="avgHrs">   The average hrs. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateStore(string name, string divider, string avgHrs)
        {
            int retval = kErrorCodes.NoError;
            retval = validateStoreName(name);
            if (retval == kErrorCodes.NoError)
            {
                validateStoreDivider(divider);
                if (retval == kErrorCodes.NoError)
                {
                    validateStoreAvgHrs(avgHrs);
                }
            }
            return retval;
        }

        // FUNCTION     : validatePhoneNum
        // DESCRIPTION  : returns error code if store phone number is invlaid
        // PARAMETERS   : <string><pNum><phone number string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the phone number described by pNum. </summary>
        ///
        
        ///
        /// <param name="pNum"> Number of. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validatePhoneNum(string pNum)
        {
            int retval = kErrorCodes.NoError;
            //potential problems:
            /*phone number may have long distance code on it. do we want to store that? ex: +1,1
             * phone number may contain brackets and/or dashes and/or spaces. do we want to preserve that? ex: () -
             * foreign countries like germany don't have a standardized phone number format. do we want to handle that? ex +49 - 89 - 343 80 - 14, +49 (89) 343 80 - 14, 0049 (0) 89 343 80 - 14, (089) 343 80 - 14, 089 / 343 80 - 14, 089 343 80 14
             * here i am going to assume that the only phone number i should execpt and store is just the 10 numbers of a basic phone number
             */
            if (!Regex.IsMatch(pNum.Trim(), @"^1?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
            {
                retval = kErrorCodes.InvalidPhoneNumber; //retval = kErrorCodes.notNumber;
            }
            if (pNum.Length < consts.MinPhoneNumberLength)//phone number too short
            {
                retval = kErrorCodes.InvalidPhoneNumber; //retval = kErrorCodes.pNumTooShort;
            }
            if (pNum.Length > consts.MaxPhoneNumberLength)//phone number too long
            {
                retval = kErrorCodes.InvalidPhoneNumber; //retval = kErrorCodes.pNumTooLong;
            }
            return retval;
        }

        // FUNCTION     : validateEmail
        // DESCRIPTION  : returns error code if email is invlaid
        // PARAMETERS   : <string><email><email string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the email described by email. </summary>
        ///
        
        ///
        /// <param name="email">    The email. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateEmail(string email)
        {
            int retval = kErrorCodes.NoError;

            int atCount = email.Split('@').Length - 1;
            int dotCount = email.Split('.').Length - 1;
            if (email.Length > consts.MaxEmailLength)
            {
                retval = kErrorCodes.InvalidEmail; //retval = kErrorCodes.inputTooLong;
            }
            else if (atCount > consts.MaxAtCount)
            {
                retval = kErrorCodes.InvalidEmail; //retval = kErrorCodes.tooManyAtSigns;
            }
            else if (email.Contains(".."))
            {
                retval = kErrorCodes.InvalidEmail; //retval = kErrorCodes.tooManydots;
            }
            else if (!email.Contains(@"@"))
            {
                retval = kErrorCodes.InvalidEmail; //retval = kErrorCodes.emailMissingAtSign;
            }
            else if (!email.EndsWith(".com") && !email.EndsWith(".ca"))
            {
                retval = kErrorCodes.InvalidEmail; //retval = kErrorCodes.emailMissingEmailEnding;
            }
            return retval;
        }

        // FUNCTION     : validateDateTime
        // DESCRIPTION  : returns error code if daate times are invlaid
        // PARAMETERS   : <string><start><start datetime to validate against end datetime> : <string><end><end datetime to validate against start datetime>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the time. </summary>
        ///
        
        ///
        /// <param name="start">    The start. </param>
        /// <param name="end">      The end. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateDateTime(string start, string end)
        {
            int retval = kErrorCodes.NoError;

            DateTime startDate;
            DateTime endDate;

            if (start.Length <= 0 || end.Length <= 0)
            {
                retval = kErrorCodes.InvalidDateTime; //retval = kErrorCodes.InputNeeded;
            }
            else if (!DateTime.TryParse(start, out startDate) || !DateTime.TryParse(end, out endDate))
            {
                retval = kErrorCodes.InvalidDateTime; //retval = kErrorCodes.notDateTime;
            }
            else if (startDate > endDate)
            {
                retval = kErrorCodes.InvalidDateTime; //retval = kErrorCodes.endTimeBeforeStartTime;
            }

            return retval;
        }

        // FUNCTION     : validateActive
        // DESCRIPTION  : returns error code if active flag is invlaid
        // PARAMETERS   : <string><active><active string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the active described by active. </summary>
        ///
        
        ///
        /// <param name="active">   The active. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateActive(string active)
        {

            int retval = kErrorCodes.NoError;
            if (active.Length <= 0)
            {
                retval = kErrorCodes.InvalidActive; //retval = kErrorCodes.InputNeeded;
            }
            else
            {
                try
                {
                    Convert.ToBoolean(active);
                }
                catch
                {
                    retval = kErrorCodes.InvalidActive; //retval = kErrorCodes.notBoolean;
                }
            }

            return retval;
        }

        // FUNCTION     : validatePostalCode
        // DESCRIPTION  : returns error code if postal code is invlaid
        // PARAMETERS   : <string><postalCode><postal code string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the postal code described by postalCode. </summary>
        ///
        
        ///
        /// <param name="postalCode">   The postal code. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validatePostalCode(string postalCode)
        {
            int retval = kErrorCodes.NoError;
            if (postalCode.Length > consts.MaxPostalCodeLength)
            {
                retval = kErrorCodes.InvalidPostalCode; //retval = kErrorCodes.inputTooLong;
            }
            else if (Regex.IsMatch(postalCode.ToUpper().Trim(), @"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]+$") && (postalCode.Length == consts.PostalCodeLengthWithSpace || postalCode.Length == consts.PostalCodeLengthWithoutSpace))
            {
                retval = kErrorCodes.NoError;
                if ((!postalCode.Contains(" ") && postalCode.Trim().Length > consts.PostalCodeLengthWithSpace) || postalCode.Length >= consts.MaxPostalCodeLength)
                {
                    retval = kErrorCodes.InvalidPostalCode; //retval = kErrorCodes.invalidPostalCode;
                    
                }
            }
            else
            {
                retval = kErrorCodes.InvalidPostalCode; //retval = kErrorCodes.invalidPostalCode;
            }

            //System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy][0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxy] ?[0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxy][0-9]");

            //if (!r.IsMatch(postalCode))
            //{
            //    retval = kErrorCodes.invalidPostalCode;
            //}
            return retval;
        }

        // FUNCTION     : validateCountry
        // DESCRIPTION  : returns error code if country is invlaid
        // PARAMETERS   : <string><Country><Country string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the country described by Country. </summary>
        ///
        
        ///
        /// <param name="Country">  The country. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateCountry(string Country)
        {
            int retval = kErrorCodes.NoError;
            //List<string> countryList = new List<string>();

            //if (Country.Length > consts.MaxCountryLength)
            //{
            //    retval = kErrorCodes.inputTooLong;
            //}
            //else
            //{
            //    CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            //    foreach (CultureInfo culture in cultures)
            //    {
            //        RegionInfo region = new RegionInfo(culture.LCID);
            //        if (!(countryList.Contains(region.EnglishName)))
            //        {
            //            countryList.Add(region.EnglishName.ToUpper());
            //        }
            //    }
            //    if (countryList.Contains(Country.ToUpper()) == false)//case of letter doesnt matter
            //    {
            //        retval = kErrorCodes.invalidCountry;
            //    }
            //}


            if (Country.Trim().ToLower() != "canada" || Country.Length > consts.MaxCountryLength)
            {
                retval = kErrorCodes.InvalidCountry; //retval = kErrorCodes.invalidCountry;
            }

            return retval;
        }

        // FUNCTION     : validateCity
        // DESCRIPTION  : returns error code if city is invlaid
        // PARAMETERS   : <string><city><city string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the city described by city. </summary>
        ///
        
        ///
        /// <param name="city"> The city. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateCity(string city)
        {
            int retval = kErrorCodes.NoError;

            if (city.Length > consts.MaxCityLength)
            {
                retval = kErrorCodes.InvalidCity; //retval = kErrorCodes.inputTooLong;
            }
            else if (!Regex.IsMatch(city, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                retval = kErrorCodes.InvalidCity; //retval = kErrorCodes.InvalidCharacters;
            }

            return retval;
        }

        // FUNCTION     : validateFax
        // DESCRIPTION  : returns error code if fax is invlaid
        // PARAMETERS   : <string><fax><fax string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the fax described by fax. </summary>
        ///
        
        ///
        /// <param name="fax">  The fax. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateFax(string fax)
        {
            int retval = kErrorCodes.NoError;
            if (fax.Length > consts.MaxFaxLength)
            {
                retval = kErrorCodes.InvalidFax; //retval = kErrorCodes.inputTooLong;
            }
            else if (!Regex.IsMatch(fax, @"^\+[0-9]{1,3}\([0-9]{3}\)[0-9]{7}$"))
            {
                retval = kErrorCodes.InvalidFax; //retval = kErrorCodes.invalidFaxFormat;
            }
            return retval;
        }

        // FUNCTION     : validateYearOfIncorperation
        // DESCRIPTION  : returns error code if year is invlaid
        // PARAMETERS   : <string><year><year of incorperation string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the year of incorperation described by year. </summary>
        ///
        
        ///
        /// <param name="year"> The year. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateYearOfIncorperation(string year)
        {
            int retval = kErrorCodes.NoError;
            int i = 0;
            bool isNum = int.TryParse(year, out i);
            if (isNum == false)
            {
                retval = kErrorCodes.InvalidYearOfIncorperation; //retval = kErrorCodes.notNumber;
            }
            else
            {
                if (i > DateTime.Now.Year)
                {
                    retval = kErrorCodes.InvalidYearOfIncorperation; //retval = kErrorCodes.invalidIncorpirationYear;
                }
                else if (year.Length != consts.YearLength)
                {
                    retval = kErrorCodes.InvalidYearOfIncorperation; //retval = kErrorCodes.invalidYearFormat;
                }
            }

            return retval;
        }

        // FUNCTION     : validateStreetAddress
        // DESCRIPTION  : returns error code if street address is invlaid
        // PARAMETERS   : <string><address><street address string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the street address described by address. </summary>
        ///
        
        ///
        /// <param name="address">  The address. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateStreetAddress(string address)
        {
            int retval = kErrorCodes.NoError;

            const string exp = @"^[0-9A-Za-z'\.\-\s\,]*$";
            var regex = new Regex(exp);
            if (address.Length >= consts.MaxAddressLength)
            {
                retval = kErrorCodes.InvalidStreetAddress; //retval = kErrorCodes.inputTooLong;
            }
            else if (regex.IsMatch(address) == false)
            {
                retval = kErrorCodes.InvalidStreetAddress; //retval = kErrorCodes.invalidStreetAddress;
            }

            return retval;
        }

        // FUNCTION     : validateID
        // DESCRIPTION  : returns error code if ID is invlaid
        // PARAMETERS   : <string><ID><ID string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Validates the identifier described by ID. </summary>
        ///
        
        ///
        /// <param name="ID">   The identifier. </param>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int validateID(string ID)
        {
            int retval = kErrorCodes.NoError;

            int i = 0;
            if (!int.TryParse(ID, out i))
            {
                retval = kErrorCodes.InvalidID; //retval = kErrorCodes.notNumber;
            }

            return retval;
        }
    }
}