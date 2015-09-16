using CSM.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CSM.Logic.Components;
using System.Collections.Generic;
using System;
using CSM.Common;
namespace CSMTest
{    
    /// <summary>
    ///This is a test class for MergeComponentsPresenterTest and is intended
    ///to contain all MergeComponentsPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MergeComponentsPresenterTest
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
       
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        public DAL GetMaster()
        {
            return new DAL("Components\\Bad\\RedSquirt.M.cruise");
        }


        [TestMethod]
        public void InitializeTest()
        {
            WindowPresenterStub wPresenter = new WindowPresenterStub();
            using (DAL master = GetMaster())
            {
                wPresenter.Database = master;
                MergeComponentsPresenter cmPresenter = new MergeComponentsPresenter(wPresenter, null);

                Assert.IsTrue(cmPresenter.MissingComponents.Count == 0);

            }

        }

        //[TestMethod]
        //public void UpdateAndMergeTest()
        //{
        //    WindowPresenterStub wPresenter = new WindowPresenterStub();
        //    using (DAL master = GetMaster())
        //    {
        //        wPresenter.Database = master;
        //        MergeComponentsPresenter cmPresenter = new MergeComponentsPresenter(wPresenter);

        //        List<String> missingFiles = new List<String>();
        //        cmPresenter.FindComponents(out missingFiles);
        //        Assert.IsTrue(missingFiles.Count == 0);

        //        cmPresenter.ReadyComponents();
        //        cmPresenter.BuildMergeTables();


        //        cmPresenter.ProcessMergeTables();
        //    }

        //}

        [TestMethod]
        public void PrepareMergeTest()
        {
            WindowPresenterStub wPresenter = new WindowPresenterStub();
            using (DAL master = GetMaster())
            {
                wPresenter.Database = master;
                MergeComponentsPresenter cmPresenter = new MergeComponentsPresenter(wPresenter, null);

                Assert.IsTrue(cmPresenter.MissingComponents.Count == 0);

                PrepareMergeWorker worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();
            }

        }

        [TestMethod]
        public void PerformMergeTest()
        {
            WindowPresenterStub wPresenter = new WindowPresenterStub();
            using (DAL master = GetMaster())
            {
                wPresenter.Database = master;
                MergeComponentsPresenter cmPresenter = new MergeComponentsPresenter(wPresenter, null);

                Assert.IsTrue(cmPresenter.MissingComponents.Count == 0);

                PrepareMergeWorker worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();

                MergeSyncWorker syncWorker = new MergeSyncWorker(cmPresenter);
                syncWorker.ProgressChanged += HandleProgressChanged;

                syncWorker.BeginWork();

                syncWorker.Wait();

            }
        }

        public void HandleProgressChanged(object sender, WorkerProgressChangedEventArgs e)
        {
            TestContext.WriteLine("{0} done: {1} Tick:", e.ProgressPercentage * 100.0, e.Message); 
            
        }

    }
}
