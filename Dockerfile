# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e publica
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "MenuOn.dll"]
