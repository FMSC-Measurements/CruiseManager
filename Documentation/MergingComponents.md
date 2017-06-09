#Merging Components
Related code files:

 - CruiseManager.Core
     * Components 
         * MergeComponetsPresenter - interacts with the view, loads components, orchestrates flow between each step of the merging process 
         * UpdateMasterWorker - used in MergeComponetsPresenter.InitializeComponent method. gives records GUIDs if they don't have them
         * PrepareMergeWorker - populates master database with data that will later be used to merge data, and detect collisions
     * FileMaintenance 
         * ConsolidateCountTreeScript.cs
 - CruiseManager.Winforms
     *  Components - all files
 
 ##MegeComponentsPresenter
 
 
