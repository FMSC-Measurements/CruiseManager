using CSM.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CSMTest
{
    
    
    /// <summary>
    ///This is a test class for COConverterTest and is intended
    ///to contain all COConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class COConverterTest
    {
        public readonly string TEST_CRZ_FILE = "TESTMETH.crz";
        public readonly string OUTPUT_CURSE_FILE = "TESTMETH_CONVERTED_TEST.cruise";

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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for COConverter Constructor
        ///</summary>
        [TestMethod()]
        public void COConverterConstructorTest()
        {
            String testdir = testContextInstance.TestDeploymentDir;
            COConverter target = new COConverter();
            string targetPath = String.Format("{0}\\{1}", testdir, TEST_CRZ_FILE);
            string outputPath = String.Format("{0}\\{1}", testdir, OUTPUT_CURSE_FILE);
            ProcessUpdateEventHandler updateCaller = null;
            bool expected = true;
            bool actual;
            IAsyncResult result =  target.BenginConvert(targetPath, outputPath, null, null);
            actual = target.EndConvert(result);
            if (actual != expected)
            {
                foreach (String s in target.Output)
                {
                    testContextInstance.WriteLine("{0}",s);
                    
                }
                testContextInstance.WriteLine("{0}",target.ErrorOutput);
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
