#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["samples/BlazorDevTools.Server/BlazorDevTools.Server.csproj", "samples/BlazorDevTools.Server/"]
COPY ["samples/BlazorDevTools.Client/BlazorDevTools.Client.csproj", "samples/BlazorDevTools.Client/"]
COPY ["src/H3x.BlazorCirrusComponents/H3x.BlazorCirrusComponents.csproj", "src/H3x.BlazorCirrusComponents/"]
RUN dotnet restore "samples/BlazorDevTools.Server/BlazorDevTools.Server.csproj"
COPY . .
WORKDIR "/src/samples/BlazorDevTools.Server"
RUN dotnet build "BlazorDevTools.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorDevTools.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorDevTools.Server.dll"]