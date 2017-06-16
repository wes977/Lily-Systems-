///-------------------------------------------------------------------------------------------------
// file:	DALTests.cs
//
// summary:	Implements the dal tests class
///-------------------------------------------------------------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LS_APIs.DAL;
using LS_APIs.Validation;

namespace DalUnitTests
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   (Unit Test Class) a dal tests. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [TestClass]
    public class DALTests
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates select properties string normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateSelectPropertiesString_Normal()
        {
            Logic log = new Logic();
            string senderID = log.CreateSelectProperties("1", "Receiver_ID = '{0}'");
            string where = senderID;

            Assert.AreEqual(where, "Receiver_ID = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates select properties string boundary. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateSelectPropertiesString_Boundary()
        {
            Logic log = new Logic();
            string cmpyid = log.CreateSelectProperties("1", "company_id = '{0}'");
            string cmpyname = log.CreateSelectProperties("test", "companyName = '{0}'");

            string where = cmpyid + cmpyname;

            Assert.AreEqual(where, "company_id = '1' AND companyName = 'test'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates update properties string normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateUpdatePropertiesString_Normal()
        {
            Logic log = new Logic();
            string cn = log.CreateUpdateProperties("companyName = '{0}'", "test");
            string where = cn;

            Assert.AreEqual(where, "companyName = 'test'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates update properties string boundary. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateUpdatePropertiesString_Boundary()
        {
            Logic log = new Logic();
            string cn = log.CreateUpdateProperties("companyName = '{0}'", "test");
            string yc = log.CreateUpdateProperties("yearOfIncorporation = '{0}'", "2001");
            string where = cn + yc;

            Assert.AreEqual(where, "companyName = 'test', yearOfIncorporation = '2001'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates insert command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateInsertCommand_Normal()
        {
            Logic log = new Logic();
            string table = "Messenger";
            string param = "Sender_ID, Receiver_ID, Subject_Line, Words, messageDate";
            string value = String.Format("'{0}', '{1}', '{2}', '{3}', '{4}'", "1", "1", "subject", "body", "2001-01-01");
            string command = log.CreateInsertCommand(table, param, value);

            Assert.AreEqual(command, "INSERT INTO Messenger (Sender_ID, Receiver_ID, Subject_Line, Words, messageDate) VALUES ('1', '1', 'subject', 'body', '2001-01-01')");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates join select command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateJoinSelectCommand_Normal()
        {
            Logic log = new Logic();
            string table = "Employee_Info";
            string table2 = "Shift_Info";

            string on = "b.employee_id = a.employee_id";

            string select = "store_id, b.shift_id";

            string where = String.Format("a.employee_id = '{0}'", "1");

            string command = log.CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            Assert.AreEqual(command, "SELECT store_id, b.shift_id FROM Employee_Info a INNER JOIN Shift_Info b ON b.employee_id = a.employee_id WHERE a.employee_id = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates select insert command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateSelectInsertCommand_Normal()
        {
            Logic log = new Logic();
            string table = "Employee_Info";
            string table2 = "Shift_Info";

            string on = "b.employee_id = a.employee_id";

            string select = "store_id, b.shift_id";

            string where = String.Format("a.employee_id = '{0}'", "1");

            string command = log.CreateJoinSelectCommand(table, table2, "INNER JOIN", where, on, select);

            command = log.CreateSelectInsertCommand("Open_Shifts", command);

            Assert.AreEqual(command, "INSERT INTO Open_Shifts SELECT store_id, b.shift_id FROM Employee_Info a INNER JOIN Shift_Info b ON b.employee_id = a.employee_id WHERE a.employee_id = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates update command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateUpdateCommand_Normal()
        {
            Logic log = new Logic();

            string table = "Company_Info";
            string cn = log.CreateUpdateProperties("companyName = '{0}'", "test");
            string yc = log.CreateUpdateProperties("yearOfIncorporation = '{0}'", "2001");
            string where = String.Format("company_id = '{0}'", "1");

            string param = cn + yc;

            string command = log.CreateUpdateCommand(table, param, where);

            Assert.AreEqual(command, "UPDATE Company_Info SET companyName = 'test', yearOfIncorporation = '2001' WHERE company_id = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates join update command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateJoinUpdateCommand_Normal()
        {
            Logic log = new Logic();

            string table1 = "Shift_Info";
            string table2 = "Open_Shifts";
            string param = String.Format("employee_id = '{0}'", "1");
            string where = String.Format("b.openShift_id = '{0}'", "1");
            string on = "a.shift_id = b.shift_id";

            string command = log.CreateJoinUpdateCommand(table1, table2, param, on, where);

            Assert.AreEqual(command, "UPDATE a SET employee_id = '1' FROM Shift_Info a INNER JOIN Open_Shifts b ON a.shift_id = b.shift_id WHERE b.openShift_id = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates delete command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateDeleteCommand_Normal()
        {
            Logic log = new Logic();

            string table = "Messenger";
            string where = String.Format("Message_ID = '{0}'", "1");

            string command = log.CreateDeleteCommand(table, where);

            Assert.AreEqual(command, "DELETE FROM Messenger WHERE Message_ID = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates join delete command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateJoinDeleteCommand_Normal()
        {
            Logic log = new Logic();

            string table1 = "Shift_Info";
            string table2 = "Employee_Info";
            string on = "a.employee_id = b.employee_id";
            string where = String.Format("b.company_id = '{0}'", "1");

            string command = log.CreateJoinDeleteCommand(table1, table2, "INNER JOIN", where, on);

            Assert.AreEqual(command, "DELETE a FROM Shift_Info a INNER JOIN Employee_Info b ON a.employee_id = b.employee_id WHERE b.company_id = '1'");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates join delete command boundary. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateJoinDeleteCommand_Boundary()
        {
            Logic log = new Logic();

            string table1 = "Shift_Info";
            string table2 = "Employee_Info";
            string on = "a.employee_id = b.employee_id";
            string where = "";

            string command = log.CreateJoinDeleteCommand(table1, table2, "INNER JOIN", where, on);

            Assert.AreEqual(command, "DELETE a FROM Shift_Info a INNER JOIN Employee_Info b ON a.employee_id = b.employee_id");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates double join delete command normal. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CreateDoubleJoinDeleteCommand_Normal()
        {
            Logic log = new Logic();

            string table1 = "Open_Shifts";
            string table2 = "Shift_Info";
            string table3 = "Employee_Info";
            string on1 = "a.shift_id = b.shift_id";
            string on2 = "b.employee_id = c.employee_id";
            string where = String.Format("c.company_id = '{0}'", "1");

            string command = log.CreateDoubleJoinDeleteCommand(log.CreateJoinDeleteCommand(table1, table2, "INNER JOIN", "", on1), table3, "INNER JOIN", on2, where);

            Assert.AreEqual(command, "DELETE a FROM Open_Shifts a INNER JOIN Shift_Info b ON a.shift_id = b.shift_id INNER JOIN Employee_Info c ON b.employee_id = c.employee_id WHERE c.company_id = '1'");
        }

        [TestMethod]
        public void validatePasswordTest_Normal()
        {
            IValidation val = new IValidation();
            int ret = val.validatePassword("aaaaaaard!1");

            Assert.AreEqual(kErrorCodes.NoError, ret);
        }

        [TestMethod]
        public void validateUsernameTest_Normal()
        {
            IValidation val = new IValidation();
            int ret = val.validateUserName("ed");

            Assert.AreEqual(kErrorCodes.NoError, ret);
        }

        [TestMethod]
        public void validatePostalCode_Normal()
        {
            IValidation val = new IValidation();
            int ret = val.validatePostalCode("n3B 1A2");

            Assert.AreEqual(kErrorCodes.NoError, ret);
        }

        [TestMethod]
        public void validateCompanyName_Normal()
        {
            IValidation val = new IValidation();
            int ret = val.validateCompanyName("company1");

            Assert.AreEqual(kErrorCodes.NoError, ret);
        }
    }
}
