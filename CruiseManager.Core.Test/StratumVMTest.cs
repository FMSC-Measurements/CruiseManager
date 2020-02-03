using CruiseDAL;
using CruiseManager.Core.Models;

namespace CruiseManager.Test
{
    public class StratumVMTest
    {
        public static string TEST_FILE_PATH = "Test.cruise";

        public static DAL GetTestDAL()
        {
            return new DAL(TEST_FILE_PATH);
        }

        public void StratumVMTestRead()
        {
            using (var db = GetTestDAL())
            {
                foreach (var st in db.From<StratumVM>().Query())
                {
                    //this.TestContext.WriteLine(st.Fields);
                }
            }
        }
    }
}