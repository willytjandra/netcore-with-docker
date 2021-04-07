FROM mcr.microsoft.com/dotnet/sdk:5.0.102-ca-patch-buster-slim-amd64 AS build
WORKDIR /src

COPY ./src ./
RUN dotnet restore HelloWorld.Api

RUN dotnet build HelloWorld.Api -c Release

FROM build AS publish
RUN dotnet publish HelloWorld.Api -c Release --no-build -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=publish /src/out .

ENTRYPOINT ["dotnet", "HelloWorld.Api.dll"]

