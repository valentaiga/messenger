FROM debian:bookworm-slim AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5010

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# nativeAOT required
RUN apt update && \
    apt install -y gcc

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Backend/Messenger.Identity.App/Messenger.Identity.App.csproj", "Messenger.Identity.App/"]
RUN dotnet restore "Messenger.Identity.App/Messenger.Identity.App.csproj"

WORKDIR /src/Messenger.Identity.App
COPY . .
RUN dotnet build "./Messenger.Identity.App.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Messenger.Identity.App.csproj" -c $BUILD_CONFIGURATION /p:UseAppHost=false --self-contained true -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Messenger.Identity.App"]
