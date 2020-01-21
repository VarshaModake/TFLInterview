# TFLInterview
Solution is build under .NetFramework 4.5
1)Update App_Id and App_Key in appseting of App.Config File located at (TFLRoadStatus\TFLRoadStatus).
2)Save the changes.
3)Build the Code.
How to build the code :
-Build the solution using MSBuild
1)open cmd prompt and give path of MSBuild.exe normally to change the directory (eg : C\:> cd C:\Windows\Microsoft.Net\Framework64\v4.0.30319)
2)once navigate to C:\Windows\Microsoft.Net\Framework64\v4.0.30319> MSBuild.exe "Path for Project sln" 
(eg:  C:\Windows\Microsoft.Net\Framework64\v4.0.30319> MSBuild.exe  H:\myapp\TFLRoadStatus\TFLRoadStatus.sln) 
3)Above command will build the project.(Used your specific path)
4)Run the Solution:
How to Run the Solution:
1)change the directory to TFLRoadStatus.exe present in bin\Debug folder (eg : H:\myapp\TFLRoadStatus\TFLRoadStatus\bin\Debug)
 sample 
eg : c:\> cd H:\myapp\TFLRoadStatus\TFLRoadStatus\bin\Debug

2)run project exe and provide RoadId as input
sample eg : H:\myapp\TFLRoadStatus\TFLRoadStatus\bin\Debug> TFLRoadStatus.exe A2
It will print desire out put.

Code will run for multiple input as well
eg : TFLRoadStatus.exe A2 A1 will return status of A1 and A2
 

Run Test Case Using MSTest;
Need to update Mock data for config parameter.
Hardcoded value of App_Id and App_Key in TestGetRoadInformation.cs  for testing:  Update value
change directory to point MSTest.exe file which present at (c:\program files (x86)\microsoft Visual studio\2017\Community\Common7\IDE

once change the directory Run Command
> mstest /testcontainer :"\TFLRoadStatus\TFLRoadStatus.Tests\bin\Debug\TFLRoadStatus.Test.dll"
