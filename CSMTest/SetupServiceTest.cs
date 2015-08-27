using CSM.Utility.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CruiseDAL.DataObjects;
using System.IO;
using System;

namespace CSMTest
{
    
    
    /// <summary>
    ///This is a test class for SetupServiceTest and is intended
    ///to contain all SetupServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SetupServiceTest
    {


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
        ///A test for checkFileExists
        ///</summary>
        [TestMethod()]
        public void checkFileExistsTest()
        {
            SetupService target = SetupService.GetHandle();
            try
            {
                target.checkFileExists();
            }
            catch (Exception e)
            {
                Assert.Fail("Check File Exists Test threw {0} : {1}", e.GetType().Name, e.Message);
            }
        }



        /// <summary>
        ///A test for GetCruiseMethods
        ///</summary>
        [TestMethod()]
        public void GetCruiseMethodsTest()
        {
            SetupService target = SetupService.GetHandle();           
            List<CruiseMethod> list;
            list = target.GetCruiseMethods();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetHandle
        ///</summary>
        [TestMethod()]
        public void GetHandleTest()
        {
            SetupService target = SetupService.GetHandle();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for GetLogFieldSetups
        ///</summary>
        [TestMethod()]
        public void GetLogFieldSetupsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<LogFieldSetupDO> list;
            list = target.GetLogFieldSetups();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetLoggingMethods
        ///</summary>
        [TestMethod()]
        public void GetLoggingMethodsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<LoggingMethod> list;
            list = target.GetLoggingMethods();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetProductCodes
        ///</summary>
        [TestMethod()]
        public void GetProductCodesTest()
        {
            SetupService target = SetupService.GetHandle();
            List<ProductCode> list;
            list = target.GetProductCodes();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetRegions
        ///</summary>
        [TestMethod()]
        public void GetRegionsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<Region> list;
            list = target.GetRegions();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetThreePCodes
        ///</summary>
        [TestMethod()]
        public void GetThreePCodesTest()
        {
            SetupService target = SetupService.GetHandle();
            List<ThreePCode> list;
            list = target.GetThreePCodes();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetTreeDefaults
        ///</summary>
        [TestMethod()]
        public void GetTreeDefaultsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<TreeDefaultValueDO> list;
            list = target.GetTreeDefaults();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetTreeFieldSetups
        ///</summary>
        [TestMethod()]
        public void GetTreeFieldSetupsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<TreeFieldSetupDO> list;
            list = target.GetTreeFieldSetups();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for GetUOMCodes
        ///</summary>
        [TestMethod()]
        public void GetUOMCodesTest()
        {
            SetupService target = SetupService.GetHandle();
            List<UOMCode> list;
            list = target.GetUOMCodes();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count != 0);
        }

        /// <summary>
        ///A test for SaveCruiseMethods
        ///</summary>
        [TestMethod()]
        public void SaveCruiseMethodsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<CruiseMethod> list;
            list = target.GetCruiseMethods();
            list.RemoveAt(0);
            target.SaveCruiseMethods(list);
            List<CruiseMethod> listB = target.GetCruiseMethods();
            Assert.IsTrue(list.Count == listB.Count);
        }

        /// <summary>
        ///A test for SaveLoggingMethods
        ///</summary>
        [TestMethod()]
        public void SaveLoggingMethodsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<LoggingMethod> list;
            list = target.GetLoggingMethods();
            
            list.RemoveAt(0);
            target.SaveLoggingMethods(list);
            List<LoggingMethod> listB = target.GetLoggingMethods();
            Assert.IsTrue(list.Count == listB.Count);
        }

        /// <summary>
        ///A test for SaveProductCodes
        ///</summary>
        [TestMethod()]
        public void SaveProductCodesTest()
        {
            SetupService target = SetupService.GetHandle();
            List<ProductCode> list;
            list = target.GetProductCodes();
            list.RemoveAt(0);
            target.SaveProductCodes(list);
            List<ProductCode> listB = target.GetProductCodes();
            Assert.IsTrue(list.Count == listB.Count);
        }

        /// <summary>
        ///A test for SaveRegions
        ///</summary>
        [TestMethod()]
        public void SaveRegionsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<Region> list;
            list = target.GetRegions();
            list.RemoveAt(0);
            target.SaveRegions(list);
            List<Region> listB = target.GetRegions();
            Assert.IsTrue(list.Count == listB.Count);
        }

        /// <summary>
        ///A test for SaveTreeDefaults
        ///</summary>
        [TestMethod()]
        public void SaveTreeDefaultsTest()
        {
            SetupService target = SetupService.GetHandle();
            List<TreeDefaultValueDO> list;
            list = target.GetTreeDefaults();
            list.RemoveAt(0);
            target.SaveTreeDefaults(list);
            List<TreeDefaultValueDO> listB = target.GetTreeDefaults();
            Assert.IsTrue(list.Count == listB.Count);
        }

        /// <summary>
        ///A test for SaveUOMCodes
        ///</summary>
        [TestMethod()]
        public void SaveUOMCodesTest()
        {
            SetupService target = SetupService.GetHandle();
            List<UOMCode> list;
            list = target.GetUOMCodes();
            list.RemoveAt(0);
            target.SaveUOMCodes(list);
            List<UOMCode> listB = target.GetUOMCodes();
            Assert.IsTrue(list.Count == listB.Count);
        }
    }
}
