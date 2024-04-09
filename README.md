# udv_webapp

## Как развернуть бд:
```
cd .\UDV_WebApp.API
docker-compose up -d
cd ..
dotnet ef migrations add init -s .\UDV_WebApp.API\ -p .\UDV_WebApp.DataAccess\
dotnet ef database update -s .\UDV_WebApp.API\ -p .\UDV_WebApp.DataAccess\
```
