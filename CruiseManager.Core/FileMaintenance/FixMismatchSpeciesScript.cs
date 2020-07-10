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
            return database.ExecuteScalar<int>("select count(*) from tree as t join treedefaultvalue as tdv using (treedefaultvalue_cn) WHERE t.species != tdv.species;") > 0;
        }

        public void Execute(DAL database)
        {
            database.Execute(
@"update tree as t 
set species = (select species from treedefaultvalue as tdv where t.treedefaultvalue_cn = tdv.treedefaultvalue_cn) 
where tree_cn in (
	select tree_cn from tree as t 
	join treedefaultvalue as tdv using (treedefaultvalue_cn)
	where t.species != tdv.species);");
        }
    }
}
