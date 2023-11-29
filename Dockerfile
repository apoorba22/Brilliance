# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY BrillianceCodeAssessment/*.csproj .
RUN dotnet restore

# copy everything else and build app
COPY BrillianceCodeAssessment/. .
WORKDIR /source
RUN dotnet publish -c release -o /BrillianceCodeAssessment --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
WORKDIR /BrillianceCodeAssessment
COPY --from=build /BrillianceCodeAssessment .
ENTRYPOINT ["dotnet", "BrillianceCodeAssessment.dll"]
