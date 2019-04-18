FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["GABTorino.csproj", "."]
RUN dotnet restore "GABTorino.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "GABTorino.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GABTorino.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GABTorino.dll"]