# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WS.WebAPI/WS.WebAPI.csproj", "WS.WebAPI/"]
COPY ["Services/Auth/WS.Auth.ApplicationService/WS.Auth.ApplicationService.csproj", "Services/Auth/WS.Auth.ApplicationService/"]
COPY ["Services/shared/WS.Constant/WS.Constant.csproj", "Services/shared/WS.Constant/"]
COPY ["Services/shared/WS.Shared.ApplicationService/WS.Shared.ApplicationService.csproj", "Services/shared/WS.Shared.ApplicationService/"]
COPY ["Services/Product/WS.Product.Domain/WS.Product.Domain.csproj", "Services/Product/WS.Product.Domain/"]
COPY ["Services/Product/WS.Product.Dtos/WS.Product.Dtos.csproj", "Services/Product/WS.Product.Dtos/"]
COPY ["Services/Product/WS.Product.Infrastructure/WS.Product.Infrastructure.csproj", "Services/Product/WS.Product.Infrastructure/"]
COPY ["Services/Auth/WS.Auth.Dtos/WS.Auth.Dtos.csproj", "Services/Auth/WS.Auth.Dtos/"]
COPY ["Services/Auth/WS.Auth.Infrastructure/WS.Auth.Infrastructure.csproj", "Services/Auth/WS.Auth.Infrastructure/"]
COPY ["Services/Auth/WS.Auth.Domain/WS.Auth.Domain.csproj", "Services/Auth/WS.Auth.Domain/"]
COPY ["Services/Notification/WS.Notification.ApplicationService/WS.Notification.ApplicationService.csproj", "Services/Notification/WS.Notification.ApplicationService/"]
COPY ["Services/Notification/WS.Notification.Dtos/WS.Notification.Dtos.csproj", "Services/Notification/WS.Notification.Dtos/"]
COPY ["Services/Notification/WS.Notification.Infrastructure/WS.Notification.Infrastructure.csproj", "Services/Notification/WS.Notification.Infrastructure/"]
COPY ["Services/Notification/WS.Notification.Domain/WS.Notification.Domain.csproj", "Services/Notification/WS.Notification.Domain/"]
COPY ["Services/Order/WS.Order.ApplicationService/WS.Order.ApplicationService.csproj", "Services/Order/WS.Order.ApplicationService/"]
COPY ["Services/Order/WS.Order.Dtos/WS.Order.Dtos.csproj", "Services/Order/WS.Order.Dtos/"]
COPY ["Services/Order/WS.Order.Infrastructure/WS.Order.Infrastructure.csproj", "Services/Order/WS.Order.Infrastructure/"]
COPY ["Services/Order/WS.Order.Domain/WS.Order.Domain.csproj", "Services/Order/WS.Order.Domain/"]
COPY ["Services/Product/WS.Product.ApplicationService/WS.Product.ApplicationService.csproj", "Services/Product/WS.Product.ApplicationService/"]
RUN dotnet restore "./WS.WebAPI/WS.WebAPI.csproj"
COPY . .
WORKDIR "/src/WS.WebAPI"
RUN dotnet build "./WS.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WS.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WS.WebAPI.dll"]