FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
# Copia toda a sua solução (agora o .sln e as pastas de projeto estão no contexto)
COPY . .

# Restaura as dependências a partir do arquivo de solução.
# O Docker agora pode encontrar o arquivo .sln
RUN dotnet restore "Matemagicas-api.sln"

# Navega para a pasta do projeto da API
WORKDIR "Matemagicas.Api"

# Constrói o projeto
RUN dotnet build "Matemagicas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# Publica o projeto
RUN dotnet publish "Matemagicas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matemagicas.Api.dll"]