start /d "C:\Users\Jeroen\Documents\Visual Studio 2015\Projects\CollectiveInfluenceAlgorithm\CollectiveInfluenceAlgorithm\bin\Debug" CollectiveInfluenceAlgorithm.exe
wmic process where name="CollectiveInfluenceAlgorithm.exe" CALL setpriority "high priority"
