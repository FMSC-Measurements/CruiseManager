using CSM.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CruiseDAL;
using CruiseDAL.DataObjects;
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
            testUpdateTreesComp = this.TestContext.TestDir + "\\testUpdateTreesC.Cruise";
            testUpdateTreesMaster = this.TestContext.TestDir + "\\testUpdateTreesM.Cruise";

            testUpdatePlotsComp = this.TestContext.TestDir + "\\testUpdatePlotsC.Cruise";
            testUpdatePlotsMaster = this.TestContext.TestDir + "\\testUpdatePlotsM.Cruise";
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        public string testUpdateTreesMaster;
        public string testUpdateTreesComp;

        public string testUpdatePlotsMaster;
        public string testUpdatePlotsComp;



        [TestMethod]
        public void TestUpdateTrees()
        {
            using (DAL master = new DAL(testUpdateTreesMaster,true))
            using (DAL component = new DAL(testUpdateTreesComp, true))
            {
                

                WindowPresenterStub wPresenter = new WindowPresenterStub()
                {
                    Database = master
                };

                MergeComponentsPresenter presenter = new MergeComponentsPresenter(wPresenter);


                TreeDO treeC = new TreeDO(component);

                treeC.StartWrite();
                treeC.rowID = 1;
                treeC.TreeDefaultValue_CN = 1;
                treeC.SampleGroup_CN = 1;
                treeC.CuttingUnit_CN = 1;
                treeC.Stratum_CN = 1;
                treeC.TreeNumber = 1;
                treeC.EndWrite();

                treeC.Save();

                try
                {

                    presenter.MergeTrees(component);

                    TreeDO treeM = master.ReadSingleRow<TreeDO>("Tree", "WHERE TreeNumber = 1");
                    Assert.IsTrue(treeM != null, "read tree from master fail(1)");

                    treeC.Slope = 16.6f;
                    treeC.Save();


                    presenter.MergeTrees(component);

                    treeM = master.ReadSingleRow<TreeDO>("Tree", "WHERE TreeNumber = 1");
                    Assert.IsTrue(treeM != null, "read tree from master fail(2)");
                    Assert.IsTrue(treeM.Slope == 16.6f, "data copy test fail");
                }
                finally
                {
                    //master.EndTransaction();
                }
            }

        }



        [TestMethod]
        public void TestUpdatePlot()
        {
            using (DAL master = new DAL(testUpdatePlotsMaster, true))
            using (DAL component = new DAL(testUpdatePlotsComp, true))
            {

                WindowPresenterStub wPresenter = new WindowPresenterStub()
                {
                    Database = master
                };

                MergeComponentsPresenter presenter = new MergeComponentsPresenter(wPresenter);


                PlotDO plotC = new PlotDO(component);
                plotC.StartWrite();
                plotC.rowID = 1;
                plotC.PlotNumber = 1;
                plotC.CuttingUnit_CN = 1;
                plotC.Stratum_CN = 1;
                plotC.EndWrite();
                plotC.Save();

               
                presenter.MergePlots(component);

                PlotDO plotM = master.ReadSingleRow<PlotDO>("Plot", "WHERE PlotNumber = 1");
                Assert.IsTrue(plotM != null, "read plot from master fail(1)");

                plotC.Slope = 16.6f;
                plotC.Save();

                presenter.MergePlots(component);


                plotM = master.ReadSingleRow<PlotDO>("Plot", "WHERE PlotNumber = 1");
                Assert.IsTrue(plotM != null, "read plot from master fail(2)");
                Assert.IsTrue(plotM.Slope == 16.6f, "data copy test fail");
            }

        }

    }
}
