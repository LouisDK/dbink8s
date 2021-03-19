FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NAPI/NAPI.csproj", "NAPI/"]
COPY ["Utils/Utils.csproj", "Utils/"]

RUN dotnet restore "NAPI/NAPI.csproj"
COPY . .
WORKDIR "/src/NAPI"
RUN dotnet build "NAPI.csproj" -c Release -o /app/build

FROM build AS publish 
RUN dotnet publish "NAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NAPI.dll"]