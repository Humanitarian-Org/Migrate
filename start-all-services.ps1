
cd "C:\Dev\AcmeCorp\Acme-Platform\Platform\src\UI" && npm start  
cd "C:\Dev\AcmeCorp\Acme-Platform\Platform\src\Api" && func start --port 7071 --cors "http://localhost:3000" 
cd "C:\Dev\AcmeCorp\Acme-Platform\Platform\src\endpoint.In" && func start --port 7072   
cd "C:\Dev\AcmeCorp\Acme-Platform\Payments\src\endpoint.In" && func start --port 7074  
cd "C:\Dev\AcmeCorp\Acme-Platform\Payments\src\Api" && func start --port 7075 --cors "http://localhost:3000"   
  