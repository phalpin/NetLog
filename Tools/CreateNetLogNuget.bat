REM ECHO PATH: %1bin\Release\NetLog.Client.dll
REM %1..\Tools\nuget.exe spec %1bin\Release\NetLog.Client.dll
%1..\Tools\nuget.exe pack %1NetLog.Client.csproj -outputdirectory %1..\Builds\