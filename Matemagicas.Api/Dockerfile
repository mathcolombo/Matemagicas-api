FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
# O WORKDIR é a raiz do contêiner, onde a solução será copiada
WORKDIR /src
# Copia toda a solução para o contêiner
COPY . .

# Navega para a pasta do projeto API para o build
WORKDIR "/src/Matemagicas.Api"

# Restaura as dependências, que agora podem ver os outros projetos
RUN dotnet restore

# Constrói o projeto
RUN dotnet build "Matemagicas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# Publica o projeto a partir da mesma pasta
RUN dotnet publish "Matemagicas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matemagicas.Api.dll"]