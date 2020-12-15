#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Apps/ESC.Admin/ESC.Admin.csproj", "src/Apps/ESC.Admin/"]
RUN dotnet restore "src/Apps/ESC.Admin/ESC.Admin.csproj"
COPY . .
WORKDIR "/src/src/Apps/ESC.Admin"
RUN dotnet build "ESC.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESC.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESC.Admin.dll"]