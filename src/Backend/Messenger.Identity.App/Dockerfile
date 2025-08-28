FROM mcr.microsoft.com/dotnet/nightly/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5010

FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install NativeAOT build prerequisites
RUN apt-get update
RUN apt-get install -y --no-install-recommends clang zlib1g-dev

COPY ["src/Backend/Messenger.Identity.App/", "Messenger.Identity.App/"]
COPY ["src/Backend/ProtoFiles/", "ProtoFiles/"]
RUN dotnet restore "Messenger.Identity.App/Messenger.Identity.App.csproj"

RUN dotnet build "Messenger.Identity.App/Messenger.Identity.App.csproj" -c $BUILD_CONFIGURATION --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Messenger.Identity.App/Messenger.Identity.App.csproj" -c $BUILD_CONFIGURATION /p:UseAppHost=false --self-contained true -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Messenger.Identity.App"]
