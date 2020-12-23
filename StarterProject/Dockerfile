#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["StarterProject/StarterProject.csproj", "StarterProject/"]
RUN dotnet restore "StarterProject/StarterProject.csproj"
COPY . .
WORKDIR "/src/StarterProject"
RUN dotnet build "StarterProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StarterProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StarterProject.dll"]
