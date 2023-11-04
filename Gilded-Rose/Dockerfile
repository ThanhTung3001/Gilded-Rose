FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Gided-Rose/Gided-Rose.csproj", "Gided-Rose/"]
RUN dotnet restore "Gided-Rose/Gided-Rose.csproj"
COPY . .
WORKDIR "/src/Gided-Rose"
RUN dotnet build "Gided-Rose.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gided-Rose.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gided-Rose.dll"]
