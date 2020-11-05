using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.FileMaintenance
{
    public class FixMismatchSpeciesScript : ISimpleSQLScript
    {
        public string Name => "FixMismatchSpecies";

        public string Description => "Fix tree species values to match Tree Default Values";

        public bool CheckCanExecute(DAL database)
        {
            var result = database.ExecuteScalar<int>("SELECT count(*) FROM Tree AS t join TreeDefaultValue AS tdv USING (TreeDefaultValue_cn) WHERE t.Species != tdv.Species;"); 
            return result > 0;
        }

        public void Execute(DAL database)
        {
            database.Execute(
@"UPDATE Tree AS t 
SET Species = (SELECT Species FROM TreeDefaultValue AS tdv WHERE t.TreeDefaultValue_cn = tdv.TreeDefaultValue_cn) 
WHERE Tree_CN IN (
	SELECT Tree_CN FROM Tree AS t 
	JOIN TreeDefaultValue AS tdv USING (TreeDefaultValue_CN)
	WHERE t.Species != tdv.Species);");
        }
    }
}
