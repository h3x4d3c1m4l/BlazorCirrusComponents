#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["samples/BlazorDevTools/BlazorDevTools.csproj", "samples/BlazorDevTools/"]
COPY ["src/H3x.BlazorCirrusComponents/H3x.BlazorCirrusComponents.csproj", "src/H3x.BlazorCirrusComponents/"]
RUN dotnet restore "samples/BlazorDevTools/BlazorDevTools.csproj"
COPY . .
WORKDIR "/src/samples/BlazorDevTools"
RUN dotnet build "BlazorDevTools.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorDevTools.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorDevTools.dll"]