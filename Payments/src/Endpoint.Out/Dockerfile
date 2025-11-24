FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet8

WORKDIR /home/site/wwwroot
COPY . /home/site/wwwroot

ENV AzureWebJobsScriptRoot=/home/site/wwwroot
ENV AzureFunctionsJobHost__Logging__Console__IsEnabled=true