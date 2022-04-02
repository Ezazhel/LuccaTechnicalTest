#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Lucca.Api/Lucca.Api.csproj", "Lucca.Api/"]
COPY ["Lucca.Services/Lucca.Services.csproj", "Lucca.Services/"]
COPY ["Lucca.Services.Abstractions/Lucca.Services.Abstractions.csproj", "Lucca.Services.Abstractions/"]
COPY ["Lucca.Contracts/Lucca.Contracts.csproj", "Lucca.Contracts/"]
COPY ["Lucca.Domain/Lucca.Domain.csproj", "Lucca.Domain/"]
COPY ["Persistence/Lucca.Persistence.csproj", "Persistence/"]
COPY ["Presentation/Lucca.Presentation.csproj", "Presentation/"]
RUN dotnet restore "Lucca.Api/Lucca.Api.csproj"
COPY . .
WORKDIR "/src/Lucca.Api"
RUN dotnet build "Lucca.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lucca.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lucca.Api.dll"]
