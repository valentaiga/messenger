FROM debian:bookworm-slim AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install NativeAOT build prerequisites
RUN apt-get update
RUN apt-get install -y --no-install-recommends clang zlib1g-dev

COPY ["src/Backend/Messenger.Web/", "Messenger.Web/"]
# Messenger.Web.Api.WebSockets deps
COPY ["src/Backend/Messenger.Web.Api.WebSockets/", "Messenger.Web.Api.WebSockets/"]
COPY ["src/Backend/Messenger.Web.Api.Models/", "Messenger.Web.Api.Models/"]
COPY ["src/Backend/Messenger.Common/", "Messenger.Common/"]
# Messenger.Identity.App.Grpc.Client deps
COPY ["src/Backend/Messenger.Identity.App.Grpc.Client/", "Messenger.Identity.App.Grpc.Client/"]
COPY ["src/Backend/Messenger.Common.Grpc.Client/", "Messenger.Common.Grpc.Client/"]
COPY ["src/Backend/ProtoFiles/", "ProtoFiles/"]
RUN dotnet restore "Messenger.Web/Messenger.Web.csproj"

RUN dotnet build "Messenger.Web/Messenger.Web.csproj" -c $BUILD_CONFIGURATION --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Messenger.Web/Messenger.Web.csproj" -c $BUILD_CONFIGURATION /p:UseAppHost=false --self-contained true -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Messenger.Web"]
