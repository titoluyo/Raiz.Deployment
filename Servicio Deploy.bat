net stop RaizDeploymentServicio
xcopy "D:\Fuentes\Raiz.Deployment\Raiz.Deployment\Raiz.Deployment.Svc.Cliente\bin\Debug" "D:\Fuentes\Raiz.Deployment\Output" /Y
net start RaizDeploymentServicio


