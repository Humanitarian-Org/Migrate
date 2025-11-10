
cd "C:\Dev\Humanitarian-org\Migrate\Platform\src\UI" && npm start  
cd "C:\Dev\humanitarian-org\Migrate\Platform\src\Api" && func start --port 7071 --cors "http://localhost:3000" 
cd "C:\Dev\humanitarian-org\Migrate\Platform\src\endpoint.In" && func start --port 7072   
cd "C:\Dev\humanitarian-org\migrate\beneficiary\src\endpoint.In" && func start --port 7074  
cd "C:\Dev\humanitarian-org\Migrate\Beneficiary\src\Api" && func start --port 7075 --cors "http://localhost:3000"   

  