#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 2.2.1

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["ProAgilAPI/ProAgilAPI.csproj", "ProAgilAPI/"]
RUN dotnet restore "ProAgilAPI/ProAgilAPI.csproj"
COPY . .
WORKDIR "/src/ProAgilAPI"
RUN dotnet build "ProAgilAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProAgilAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProAgilAPI.dll"]