#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["microservices/academe/SchoolMngr.Services.Academe.Api/SchoolMngr.Services.Academe.csproj", "microservices/academe/SchoolMngr.Services.Academe.Api/"]
COPY ["microservices/academe/SchoolMngr.Services.Academe.Persistence/SchoolMngr.Services.Academe.Persistence.csproj", "microservices/academe/SchoolMngr.Services.Academe.Persistence/"]
COPY ["microservices/academe/SchoolMngr.Services.Academe.Application/SchoolMngr.Services.Academe.Application.csproj", "microservices/academe/SchoolMngr.Services.Academe.Application/"]
COPY ["microservices/academe/SchoolMngr.Services.Academe.Domain/SchoolMngr.Services.Academe.Domain.csproj", "microservices/academe/SchoolMngr.Services.Academe.Domain/"]
COPY ["infrastructure/shared/SchoolMngr.Infrastructure.Shared.csproj", "infrastructure/shared/"]
COPY ["../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base.csproj", "../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base/"]
COPY ["../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base.Abstractions/Codeit.NetStdLibrary.Base.Abstractions.csproj", "../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base.Abstractions/"]
COPY ["microservices/academe/SchoolMngr.Services.Academe.Infrastructure/SchoolMngr.Services.Academe.Infrastructure.csproj", "microservices/academe/SchoolMngr.Services.Academe.Infrastructure/"]
RUN dotnet restore "microservices/academe/SchoolMngr.Services.Academe.Api/SchoolMngr.Services.Academe.csproj"
COPY . .
WORKDIR "/src/microservices/academe/SchoolMngr.Services.Academe.Api"
RUN dotnet build "SchoolMngr.Services.Academe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolMngr.Services.Academe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolMngr.Services.Academe.dll"]