FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
RUN apt update && \
    apt install -y clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Messenger.WebApi/Messenger.WebApi.csproj", "src/Messenger.WebApi/"]
RUN dotnet restore "src/Messenger.WebApi/Messenger.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Messenger.WebApi"
RUN dotnet build "./Messenger.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Messenger.WebApi.csproj" -r linux-x64 -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Messenger.WebApi"]
