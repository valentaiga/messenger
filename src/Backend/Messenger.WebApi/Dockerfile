FROM debian:bookworm-slim AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# nativeAOT required
RUN apt update && \
    apt install -y gcc \

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Backend/Messenger.WebApi/Messenger.WebApi.csproj", "Messenger.WebApi/"]
COPY ["src/Backend/Messenger.WebApi.WebSockets/Messenger.WebApi.WebSockets.csproj", "Messenger.WebApi.WebSockets/"]
COPY ["src/Backend/Messenger.Common/Messenger.Common.csproj", "Messenger.Common/"]
RUN dotnet restore "Messenger.WebApi/Messenger.WebApi.csproj" -r linux-x64

WORKDIR /src/Messenger.WebApi
COPY . .
RUN dotnet build "./Messenger.WebApi.csproj" -c $BUILD_CONFIGURATION -r linux-x64 -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Messenger.WebApi.csproj" -r linux-x64 -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Messenger.WebApi"]
