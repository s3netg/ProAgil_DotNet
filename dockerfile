FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["ProAgil.Api/ProAgil.Api.csproj", "ProAgil.Api/"]
COPY ["ProAgil.Domain/ProAgil.Domain.csproj", "ProAgil.Domain/"]
COPY ["ProAgil.Repository/ProAgil.Repository.csproj", "ProAgil.Repository/"]
COPY ["ProAgil.Api/ProAgil.db","ProAgil.Api/"]

RUN dotnet restore "ProAgil.Api/ProAgil.Api.csproj"
COPY . .
WORKDIR "/src/ProAgil.Api"
RUN dotnet build "ProAgil.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "ProAgil.Api.csproj" -c Release -o /app/publish
COPY ["ProAgil.Api/ProAgil.db","/app/publish"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProAgil.Api.dll"]