FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["csharp-webapi-boilerplate/csharp-webapi-boilerplate.csproj", "csharp-webapi-boilerplate/"]
RUN dotnet restore "csharp-webapi-boilerplate/csharp-webapi-boilerplate.csproj"
COPY . .
WORKDIR "/src/csharp-webapi-boilerplate"
RUN dotnet build "csharp-webapi-boilerplate.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "csharp-webapi-boilerplate.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "csharp-webapi-boilerplate.dll"]
