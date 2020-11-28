FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY RT.Foxy/*.csproj ./RT.Foxy/
WORKDIR /app/RT.Foxy
RUN dotnet restore RT.Foxy.csproj
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
ENV ASPNETCORE_ENVIRONMENT='Development'
ENV logPath='/var/log'

# Copy everything else and build
WORKDIR /app
COPY . .
WORKDIR /app/RT.Foxy
ENV ASPNETCORE_ENVIRONMENT='Development'
RUN dotnet build RT.Foxy.csproj
WORKDIR /app/RT.Foxy
RUN dotnet publish RT.Foxy.csproj -c Release -o ../out
RUN dotnet ef database update

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0
ENV logPath='/var/log'
ENV ASPNETCORE_ENVIRONMENT='Development'
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "RT.Foxy.dll"]