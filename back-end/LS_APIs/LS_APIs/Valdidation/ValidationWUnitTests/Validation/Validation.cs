using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* FILE			: IValidation.cs
* PROJECT		: PROG(3220)-Systems Project
* FIRST VERSION : 2017-03-20
* DESCRIPTION	: This is a set of classes for validating users input
*/

namespace Validation
{
    public static class consts
    {
        public const int MinLength = 8;
        public const int MinPhoneNumberLength = 10;
        public const int MaxPhoneNumberLength = 15;
        public const int MaxDotCount = 1;
        public const int MaxAtCount = 1;
        public const int MaxNameLength = 20;
        public const int MaxEmailLength = 320;
        public const int MaxAddressLength = 100;
        public const int MaxPostalCodeLength = 10;
        public const int MaxCountryLength = 52;
        public const int MaxCityLength = 58;
        public const int MaxUserNameLength = 20;
        public const int MaxPasswordLength = 20;
        public const int MaxCompanyLength = 20;
        public const int MaxStoreLength = 20;
        public const int MaxFaxLength = 18;
        public const int YearLength = 4;
        public const int PostalCodeLengthWithSpace = 7;
        public const int PostalCodeLengthWithoutSpace = 6;
    }
    public static class kErrorCodes
    {
        public const int NoError = 0;
        public const int InputNeeded = 1;
        public const int InvalidCharacters = 2;
        public const int TooShort = 3;
        public const int notNumber = 4;
        public const int pNumTooLong = 5;
        public const int emailMissingAtSign = 6;
        public const int emailMissingEmailEnding = 7;
        public const int endTimeBeforeStartTime = 8;
        public const int pNumTooShort = 9;
        public const int tooManyAtSigns = 10;
        public const int tooManydots = 11;
        public const int notBoolean = 12;
        public const int invalidPostalCode = 13;
        public const int invalidCountry = 14;
        public const int cityNameTooLong = 15;
        public const int inputTooLong = 16;
        public const int invalidFaxFormat = 18;
        public const int invalidIncorpirationYear = 19;
        public const int invalidYearFormat = 20;
        public const int invalidStreetAddress = 21;
        public const int inputMustBePositive = 22;
        public const int notDateTime = 23;

        public const int InvalidName = 24;
        public const int InvalidCompanyName = 25;
        public const int InvalidStoreName = 26;
        public const int InvalidStoreDivider = 27;
        public const int InvalidAverageHours = 28;
        public const int InvalidPhoneNumber = 29;
        public const int InvalidEmail = 30;
        public const int InvalidDateTime = 31;
        public const int InvalidActive = 32;
        public const int InvalidPostalCode = 33;
        public const int InvalidCountry = 34;
        public const int InvalidCity = 35;
        public const int InvalidFax = 36;
        public const int InvalidYearOfIncorperation = 37;
        public const int InvalidStreetAddress = 38;
        public const int InvalidID = 39;
    }
    public class ErrorMessages
    {
        // FUNCTION     : errorMessage
        // DESCRIPTION  : returns that appropriate error message for the error number its given
        // PARAMETERS   : <int><errNum><error number that needs a error message>
        // RETURNS      : <string><message><error message for corrisponding number>
        public string errorMessage(int errorNum)
        {
            string message = "";
            if (errorNum == kErrorCodes.InputNeeded)
            {
                message = "No input. Input needed. ";
            }
            else if(errorNum == kErrorCodes.InvalidName)
            {
                message = "Invalid name. Name must be less than " + consts.MaxNameLength.ToString() + " characters in length and only includeenglish letters, periods, \"-\", or \"'\". ";
            }
            else if (errorNum == kErrorCodes.InvalidCompanyName)
            {
                message = "Invalid company name. Company name must be less than " + consts.MaxCompanyLength.ToString() + " characters in length";
            }
            else if(errorNum == kErrorCodes.InvalidStoreName)
            {
                message = "Invalid store name. Store Namme must be less than " + consts.MaxStoreLength.ToString() + " characters in length";
            }
            else if(errorNum == kErrorCodes.InvalidStoreDivider)
            {
                message = "Invalid store divider. Store divider must be a positive number";
            }
            else if (errorNum == kErrorCodes.InvalidAverageHours)
            {
                message = "Invalid average hours. Average hours must be a positive number";
            }
            else if(errorNum == kErrorCodes.InvalidPhoneNumber)
            {
                message = "Invalid phone number. Phone number must be between " + consts.MinPhoneNumberLength.ToString() + " and " + consts.MaxPhoneNumberLength.ToString() + " characters in length. phone numbers can only include numbers, brackets(), dashes-, periods., or spaces";
            }
            else if (errorNum == kErrorCodes.InvalidEmail)
            {
                message = "Invalid email. Email must be less than " + consts.MaxEmailLength.ToString() + " characters in length. Email address also cannot have two periods in a row. Email address cannot have more than two @ symbols. Email address must end in .com or .ca";
            }
            else if(errorNum == kErrorCodes.InvalidDateTime)
            {
                message= "Invalid datetime. End date must be after start date";
            }
            else if (errorNum == kErrorCodes.InvalidActive)
            {
                message = "Invalid active. Active must be a bool";
            }
            else if(errorNum == kErrorCodes.InvalidPostalCode)
            {
                message = "Invalid Please use the following format: A1A 1A1 or A1A1A1.";
            }
            else if(errorNum == kErrorCodes.InvalidCountry)
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
            else if(errorNum == kErrorCodes.InvalidYearOfIncorperation)
            {
                message = "Invalid year of incorperation. year must be a number greater than 999 and less than or equal to current year";
            }
            else if(errorNum == kErrorCodes.InvalidStreetAddress)
            {
                message = "Invalid street address. Street address can only include numbers, letters, ', -, space, or commas. Street address must be less than " + consts.MaxAddressLength.ToString() + "characters in length";
            }
            else if (errorNum == kErrorCodes.InvalidID)
            {
                message = "Invalid ID. ID must be a number";
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

            return message;
        }
    }

    public class Validation
    {
        // FUNCTION     : checkForInput
        // DESCRIPTION  : returns error code if there is no input
        // PARAMETERS   : <string><input><string to check if it conitains any input>
        // RETURNS      : <int><retVal><error code or zero if there is no error>
        public int checkForInput(string input)
        {
            int retVal = kErrorCodes.NoError;
            string trimmedInput = input.Trim();
            if (input.Length <= 0)
            {
                retVal = kErrorCodes.InputNeeded;
            }
            return retVal;
        }

        // FUNCTION     : validateName
        // DESCRIPTION  : returns error code if name is invlaid
        // PARAMETERS   : <string><name><string to check if valid>
        // RETURNS      : <int><retVal><error code or zero if there is no error>
        public int validateName(string Name)
        {
            int retVal = kErrorCodes.NoError;

            if (Name.Length > consts.MaxNameLength)
            {
                retVal = kErrorCodes.InvalidName;//retVal = kErrorCodes.inputTooLong;
            }
            else if (!Regex.IsMatch(Name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                retVal = kErrorCodes.InvalidName;//retVal = kErrorCodes.InvalidCharacters;
            }
            return retVal;
        }

        // FUNCTION     : validateUserName
        // DESCRIPTION  : returns error code if userName is invlaid
        // PARAMETERS   : <string><userName><string to check if valid>
        // RETURNS      : <int><retVal><error code or zero if there is no error>
        public int validateUserName(string userName)
        {
            int retval = kErrorCodes.NoError;
            if (userName.Length < consts.MinLength)
            {
                retval = kErrorCodes.TooShort;
            }
            else if (userName.Length > consts.MaxUserNameLength)
            {
                retval = kErrorCodes.inputTooLong;
            }
            return retval;
        }

        // FUNCTION     : validatePassword
        // DESCRIPTION  : returns error code if password is invlaid
        // PARAMETERS   : <string><pass><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validatePassword(string pass)
        {
            int retval = kErrorCodes.NoError;
            if (pass.Length < consts.MinLength)
            {
                retval = kErrorCodes.TooShort;
            }
            else if (pass.Length > consts.MaxPasswordLength)
            {
                retval = kErrorCodes.inputTooLong;
            }
            return retval;
        }

        // FUNCTION     : validateCompanyName
        // DESCRIPTION  : returns error code if company name is invlaid
        // PARAMETERS   : <string><company><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateCompanyName(string company)
        {
            int retval = kErrorCodes.NoError;
            if (company.Length > consts.MaxCompanyLength)
            {
                retval = kErrorCodes.inputTooLong;
            }
            return retval;
        }

        // FUNCTION     : validateStoreName
        // DESCRIPTION  : returns error code if store name is invlaid
        // PARAMETERS   : <string><storeName><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateStoreName(string storeName)
        {
            int retval = kErrorCodes.NoError;
            if (storeName.Length > consts.MaxStoreLength)
            {
                retval = kErrorCodes.InvalidStoreName;//retval = kErrorCodes.inputTooLong;
            }
            return retval;
        }

        // FUNCTION     : validateStoreDivider
        // DESCRIPTION  : returns error code if store divider is invlaid
        // PARAMETERS   : <string><divider><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateStoreDivider(string divider)
        {
            int retval = kErrorCodes.NoError;
            float f = 0;
            int i = 0;
            if (!float.TryParse(divider, out f) && !int.TryParse(divider, out i))
            {
                retval = kErrorCodes.InvalidStoreDivider;//retval = kErrorCodes.notNumber;
            }
            else if(i <= 0 && f <= 0)
            {
                retval = kErrorCodes.InvalidStoreDivider;//retval = kErrorCodes.inputMustBePositive;
            }
            return retval;
        }

        // FUNCTION     : validateStoreAvgHrs
        // DESCRIPTION  : returns error code if store average hours is invlaid
        // PARAMETERS   : <string><avgHrs><string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateStoreAvgHrs(string avgHrs)
        {
            int retval = kErrorCodes.NoError;
            float f = 0;
            int i = 0;
            if (!float.TryParse(avgHrs, out f) && !int.TryParse(avgHrs, out i))
            {
                retval = kErrorCodes.InvalidAverageHours;//retval = kErrorCodes.notNumber;
            }
            else if (i <= 0 && f <= 0)
            {
                retval = kErrorCodes.InvalidAverageHours;//retval = kErrorCodes.inputMustBePositive;
            }
            return retval;
        }

        // FUNCTION     : validateStore
        // DESCRIPTION  : validates all attrivutes of a store and returns a error code if any of the elements failed
        // PARAMETERS   : <string><name><name of store string to check if valid> : <string><divider><string to check if valid> : <string><avgHrs><average shift hours string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateStore(string name, string divider, string avgHrs)
        {
            int retval = kErrorCodes.NoError;
            retval = validateCompanyName(name);
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
        public int validatePhoneNum(string pNum)
        {
            int retval = kErrorCodes.NoError;
            //potential problems:
            /*phone number may have long distance code on it. do we want to store that? ex: +1,1
             * phone number may contain brackets and/or dashes and/or spaces. do we want to preserve that? ex: () -
             * foreign countries like germany don't have a standardized phone number format. do we want to handle that? ex +49 - 89 - 343 80 - 14, +49 (89) 343 80 - 14, 0049 (0) 89 343 80 - 14, (089) 343 80 - 14, 089 / 343 80 - 14, 089 343 80 14
             * here i am going to assume that the only phone number i should execpt and store is just the 10 numbers of a basic phone number
             */
            if (!Regex.IsMatch(pNum, @"^1?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
            {
                retval = kErrorCodes.InvalidPhoneNumber;//retval = kErrorCodes.notNumber;
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
        public int validateEmail(string email)
        {
            int retval = kErrorCodes.NoError;

            int atCount = email.Split('@').Length - 1;
            int dotCount = email.Split('.').Length - 1;
            if (email.Length > consts.MaxEmailLength)
            {
                retval = kErrorCodes.InvalidEmail;//retval = kErrorCodes.inputTooLong;
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
        public int validateDateTime(string start, string end)
        {
            int retval = kErrorCodes.NoError;

            DateTime startDate;
            DateTime endDate;

            if (start.Length <= 0 || end.Length <= 0)
            {
                retval = kErrorCodes.InvalidDateTime;//retval = kErrorCodes.InputNeeded;
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
        public int validateActive(string active)
        {

            int retval = kErrorCodes.NoError;
            if (active.Length <= 0)
            {
                retval = kErrorCodes.InvalidActive;//retval = kErrorCodes.InputNeeded;
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
        public int validatePostalCode(string postalCode)
        {
            int retval = kErrorCodes.NoError;
            if (postalCode.Length > consts.MaxPostalCodeLength)
            {
                retval = kErrorCodes.InvalidPostalCode;//retval = kErrorCodes.inputTooLong;
            }
            else if (Regex.IsMatch(postalCode.ToUpper(), @"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]+$") && (postalCode.Length == consts.PostalCodeLengthWithSpace || postalCode.Length == consts.PostalCodeLengthWithoutSpace))
            {
                retval = kErrorCodes.NoError;
                if (!postalCode.Contains(" ") && postalCode.Length == consts.PostalCodeLengthWithSpace)
                {
                    retval = kErrorCodes.InvalidPostalCode; //retval = kErrorCodes.invalidPostalCode;
                }
            }
            else
            {
                retval = kErrorCodes.InvalidPostalCode; //retval = kErrorCodes.invalidPostalCode;
            }
            return retval;
        }

        // FUNCTION     : validateCountry
        // DESCRIPTION  : returns error code if country is invlaid
        // PARAMETERS   : <string><Country><Country string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
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


            if (Country.ToLower() != "canada")
            {
                retval = kErrorCodes.InvalidCountry;//retval = kErrorCodes.invalidCountry;
            }

            return retval;
        }

        // FUNCTION     : validateCity
        // DESCRIPTION  : returns error code if city is invlaid
        // PARAMETERS   : <string><city><city string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateCity(string city)
        {
            int retval = kErrorCodes.NoError;

            if (city.Length > consts.MaxCityLength)
            {
                retval = kErrorCodes.InvalidCity;//retval = kErrorCodes.inputTooLong;
            }
            else if (!Regex.IsMatch(city, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                retval = kErrorCodes.InvalidCity;//retval = kErrorCodes.InvalidCharacters;
            }

            return retval;
        }

        // FUNCTION     : validateFax
        // DESCRIPTION  : returns error code if fax is invlaid
        // PARAMETERS   : <string><fax><fax string to check if valid>
        // RETURNS      : <int><retval><error code or zero if there is no error>
        public int validateFax(string fax)
        {
            int retval = kErrorCodes.NoError;
            if (fax.Length > consts.MaxFaxLength)
            {
                retval = kErrorCodes.InvalidFax;//retval = kErrorCodes.inputTooLong;
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
        public int validateYearOfIncorperation(string year)
        {
            int retval = kErrorCodes.NoError;
            int i = 0;
            bool isNum = int.TryParse(year, out i);
            if (isNum == false)
            {
                retval = kErrorCodes.InvalidYearOfIncorperation;//retval = kErrorCodes.notNumber;
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
        public int validateStreetAddress(string address)
        {
            int retval = kErrorCodes.NoError;

            const string exp = @"^[0-9A-Za-z'\.\-\s\,]*$";
            var regex = new Regex(exp);
            if(address.Length >= consts.MaxAddressLength)
            {
                retval = kErrorCodes.InvalidStreetAddress;//retval = kErrorCodes.inputTooLong;
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
        public int validateID(string ID)
        {
            int retval = kErrorCodes.NoError;

            int i = 0;
            if (!int.TryParse(ID, out i))
            {
                retval = kErrorCodes.InvalidID;//retval = kErrorCodes.notNumber;
            }

            return retval;
        }
    }
}