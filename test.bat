@echo off

echo Building
msbuild /t:Clean,Rebuild /verbosity:quiet /nologo

echo Executing
MAS.App.Console\bin\Debug\MAS.App.Console.exe -d -v