FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5050

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

COPY ShaNetHolidayApi/ShaNetHolidayApi.csproj /ShaNetHolidayApi/ 
RUN dotnet restore /ShaNetHolidayApi/ShaNetHolidayApi.csproj
COPY . .
WORKDIR "/src/ShaNetHolidayApi"
RUN dotnet build ShaNetHolidayApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ShaNetHolidayApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShaNetHolidayApi.dll"]







