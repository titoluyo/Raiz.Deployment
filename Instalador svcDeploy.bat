@ECHO OFF  

REM The following directory is for .NET 2.0 


set PATH=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319

cd %PATH%

echo Installing MyService... 
echo ---------------------------------------------------
installutil /i "D:\Fuentes\Raiz.Deployment\Output\Raiz.Deployment.Svc.Cliente.exe"
echo --------------------------------------------------- 
echo Done.
pause