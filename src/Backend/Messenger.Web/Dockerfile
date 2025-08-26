FROM debian:bookworm-slim AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# nativeAOT required
RUN apt update && \
    apt install -y gcc

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Backend/Messenger.Web/Messenger.Web.csproj", "Messenger.Web/"]
COPY ["src/Backend/Messenger.Web.Api/Messenger.Web.Api.csproj", "Messenger.Web.Api/"]
COPY ["src/Backend/Messenger.Web.Api.Models/Messenger.Web.Api.Models.csproj", "Messenger.Web.Api.Models/"]
COPY ["src/Backend/Messenger.Web.Api.WebSockets/Messenger.Web.Api.WebSockets.csproj", "Messenger.Web.Api.WebSockets/"]
COPY ["src/Backend/Messenger.Common/Messenger.Common.csproj", "Messenger.Common/"]
RUN dotnet restore "Messenger.Web/Messenger.Web.csproj"

WORKDIR /src/Messenger.Web
COPY . .
RUN dotnet build "./Messenger.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Messenger.Web.csproj" -c $BUILD_CONFIGURATION /p:UseAppHost=false --self-contained true -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Messenger.Web"]
