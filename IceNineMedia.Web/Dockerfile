# Dev-time image with hot reload
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev
WORKDIR /src

# Install Node.js for Tailwind workflow
RUN apt-get update && apt-get install -y curl gnupg \
    && curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs \
    && rm -rf /var/lib/apt/lists/*

# Copy project files for restore caching (only local projects in this repo)
COPY IceNineMedia.Web/IceNineMedia.Web.csproj IceNineMedia.Web/
COPY IceNineMedia.Core/IceNineMedia.Core.csproj IceNineMedia.Core/

# Restore dependencies for the web project
RUN dotnet restore IceNineMedia.Web/IceNineMedia.Web.csproj

# Copy full source for the local repo
COPY . .

WORKDIR /src/IceNineMedia.Web

# Install npm dependencies for Tailwind
RUN npm install

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

# Persist Umbraco data between runs
VOLUME ["/src/IceNineMedia.Web/umbraco", "/src/IceNineMedia.Web/wwwroot"]

# Run Tailwind watcher and dotnet hot reload together
ENTRYPOINT ["bash", "-c", "npm run watch:css & dotnet watch run --no-restore --project IceNineMedia.Web.csproj"]