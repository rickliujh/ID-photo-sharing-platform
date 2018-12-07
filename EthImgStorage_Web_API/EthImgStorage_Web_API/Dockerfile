FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["EthImgStorage_Web_API/EthImgStorage_Web_API.csproj", "EthImgStorage_Web_API/"]
RUN dotnet restore "EthImgStorage_Web_API/EthImgStorage_Web_API.csproj"
COPY . .
WORKDIR "/src/EthImgStorage_Web_API"
RUN dotnet build "EthImgStorage_Web_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EthImgStorage_Web_API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EthImgStorage_Web_API.dll"]