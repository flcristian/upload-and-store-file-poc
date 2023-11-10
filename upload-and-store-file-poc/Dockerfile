FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["upload-and-store-file-poc/upload-and-store-file-poc.csproj", "upload-and-store-file-poc/"]
RUN dotnet restore "upload-and-store-file-poc/upload-and-store-file-poc.csproj"
COPY . .
WORKDIR "/src/upload-and-store-file-poc"
RUN dotnet build "upload-and-store-file-poc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "upload-and-store-file-poc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "upload-and-store-file-poc.dll"]
