# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Define o diretório de trabalho
WORKDIR /app

# Copia os arquivos do projeto para o diretório de trabalho
COPY . ./

# Restaura as dependências e realiza o build do projeto
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Define a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Define o diretório de trabalho
WORKDIR /app

# Copia os arquivos de build para o diretório de trabalho
COPY --from=build /app/out ./

# Expõe a porta em que a aplicação irá escutar
EXPOSE 80

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "HttpHost.dll"]
