# Multi-stage build for ASP.NET Core application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install necessary packages
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl \
    gnupg \
    && rm -rf /var/lib/apt/lists/*

# Create a non-root user
RUN groupadd -r appuser && useradd -r -g appuser appuser
RUN chown -R appuser:appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["PortfolioWebsite.csproj", "./"]
COPY ["NuGet.config", "./"]
RUN dotnet restore "PortfolioWebsite.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src"
RUN dotnet build "PortfolioWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioWebsite.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Copy published application
COPY --from=publish --chown=appuser:appuser /app/publish .

# Create necessary directories with proper permissions
RUN mkdir -p /app/wwwroot/images/uploads && \
    mkdir -p /app/wwwroot/documents && \
    mkdir -p /app/Data && \
    chown -R appuser:appuser /app/wwwroot/images/uploads /app/wwwroot/documents /app/Data

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:80/health/live || exit 1

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Entry point
ENTRYPOINT ["dotnet", "PortfolioWebsite.dll"]