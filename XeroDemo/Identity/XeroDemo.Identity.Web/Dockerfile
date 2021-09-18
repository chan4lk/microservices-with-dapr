#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Identity/XeroDemo.Identity.Web/XeroDemo.Identity.Web.csproj", "Identity/XeroDemo.Identity.Web/"]
RUN dotnet restore "Identity/XeroDemo.Identity.Web/XeroDemo.Identity.Web.csproj"
COPY . .
WORKDIR "/src/Identity/XeroDemo.Identity.Web"
RUN dotnet build "XeroDemo.Identity.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XeroDemo.Identity.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XeroDemo.Identity.Web.dll"]
