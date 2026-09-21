FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY CarShop.API/CarShop.API.csproj CarShop.API/
COPY CarShop.BusinessLogic/CarShop.BusinessLogic.csproj CarShop.BusinessLogic/
COPY CarShop.Core/CarShop.Core.csproj CarShop.Core/
COPY CarShop.DataAccess/CarShop.DataAccess.csproj CarShop.DataAccess/

RUN dotnet restore CarShop.API/CarShop.API.csproj

COPY . .
RUN dotnet publish CarShop.API/CarShop.API.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CarShop.API.dll"]