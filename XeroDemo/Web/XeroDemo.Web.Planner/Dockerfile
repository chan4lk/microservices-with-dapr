#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM nginx:alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web/XeroDemo.Web.Planner/XeroDemo.Web.Planner.csproj", "Web/XeroDemo.Web.Planner/"]
RUN dotnet restore "Web/XeroDemo.Web.Planner/XeroDemo.Web.Planner.csproj"
COPY . .
WORKDIR "/src/Web/XeroDemo.Web.Planner"
RUN dotnet build "XeroDemo.Web.Planner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XeroDemo.Web.Planner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
COPY --from=publish /src/Web/XeroDemo.Web.Planner/nginx.conf /etc/nginx/nginx.conf

