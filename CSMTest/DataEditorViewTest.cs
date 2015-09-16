using CSM.Winforms.DataEditor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CruiseDAL.DataObjects;
using System.Collections.Generic;
using CSM.Logic;
using CSM.Models;

namespace CSMTest
{
    
    
    /// <summary>
    ///This is a test class for DataEditorViewTest and is intended
    ///to contain all DataEditorViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataEditorViewTest
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

        public static string readTestFile;


        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            readTestFile = testContext.TestDir + "\\testmeth.Cruise";
        }
        
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
        ///A test for ReadTrees
        ///</summary>
        [TestMethod()]
        public void ReadTreesTest()
        {
            IWindowPresenter wp = new WindowPresenterStub() { Database = new CruiseDAL.DAL(readTestFile) };
            PrivateObject param0 = new PrivateObject(new DataEditorView(wp));
            DataEditorView_Accessor target = new DataEditorView_Accessor(param0);

            CuttingUnitDO cu = new CuttingUnitDO() { rowID = 1 };
            StratumDO st = new StratumDO() { rowID = 1 };
            SampleGroupDO sg = new SampleGroupDO() { rowID = 1 };
            TreeDefaultValueDO tdv = new TreeDefaultValueDO() { rowID = 1 };

            List<TreeVM> actual;
            actual = target.ReadTrees(cu, st, sg, tdv);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///A test for ReadPlots
        ///</summary>
        [TestMethod()]
        public void ReadPlotsTest()
        {
            IWindowPresenter wp = new WindowPresenterStub() { Database = new CruiseDAL.DAL(readTestFile) };
            PrivateObject param0 = new PrivateObject(new DataEditorView(wp));
            DataEditorView_Accessor target = new DataEditorView_Accessor(param0);

            CuttingUnitDO cu = new CuttingUnitDO() { rowID = 1 };
            StratumDO st = new StratumDO() { rowID = 1 };

            List<PlotDO> expected = null; // TODO: Initialize to an appropriate value
            List<PlotDO> actual;
            actual = target.ReadPlots(cu, st);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadLogs
        ///</summary>
        [TestMethod()]
        public void ReadLogsTest()
        {
            IWindowPresenter wp = new WindowPresenterStub() { Database = new CruiseDAL.DAL(readTestFile) };
            PrivateObject param0 = new PrivateObject(new DataEditorView(wp));
            DataEditorView_Accessor target = new DataEditorView_Accessor(param0);

            CuttingUnitDO cu = new CuttingUnitDO() { rowID = 1 };
            StratumDO st = new StratumDO() { rowID = 1 };
            SampleGroupDO sg = new SampleGroupDO() { rowID = 1 };
            TreeDefaultValueDO tdv = new TreeDefaultValueDO() { rowID = 1 };

            List<LogVM> actual;
            actual = target.ReadLogs(cu, st, sg, tdv);

            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadCounts
        ///</summary>
        [TestMethod()]
        public void ReadCountsTest()
        {
            IWindowPresenter wp = new WindowPresenterStub() { Database = new CruiseDAL.DAL(readTestFile) };
            PrivateObject param0 = new PrivateObject( new DataEditorView(wp));
            DataEditorView_Accessor target = new DataEditorView_Accessor(param0);

            CuttingUnitDO cu = new CuttingUnitDO() { rowID = 1 };
            StratumDO st = new StratumDO() { rowID = 1 };
            SampleGroupDO sg = new SampleGroupDO() { rowID = 1 };

            List<CountTreeDO> expected = null; // TODO: Initialize to an appropriate value
            List<CountTreeDO> actual;
            actual = target.ReadCounts(cu, st, sg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
