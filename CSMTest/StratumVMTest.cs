using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CruiseDAL;
using CSM.Logic;
using CSM.DataTypes;

namespace CSMTest
{
    /// <summary>
    /// Summary description for StratumVMTest
    /// </summary>
    [TestClass]
    public class StratumVMTest
    {
        public static string TEST_FILE_PATH = "Test.cruise";

        public StratumVMTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public static DAL GetTestDAL()
        {
            return new DAL(TEST_FILE_PATH);
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void StratumVMTestRead()
        {
            DAL db = GetTestDAL();

            foreach (StratumVM st in db.Read<StratumVM>("Stratum", null))
            {
                this.TestContext.WriteLine(st.Fields);
            }

        }
    }
}
