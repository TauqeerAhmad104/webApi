#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM microsoft/dotnet:2.1-sdk AS build


ENV ASPNETCORE_ENVIRONMENT=Development #Add this line.

EXPOSE 4441
WORKDIR /src
COPY ["webApi/webApi.csproj", "webApi/"]
RUN dotnet restore "webApi/webApi.csproj"

COPY . .
WORKDIR "/src/webApi"

RUN dotnet build "webApi.csproj" -c Release -o /app/build

ENTRYPOINT ["dotnet", "webApi.dll"]



#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#ENV ASPNETCORE_ENVIRONMENT=Development
#WORKDIR /src
#COPY ["webApi/webApi.csproj", "webApi/"]
#RUN dotnet restore "webApi/webApi.csproj"
#COPY . .
#WORKDIR "/src/webApi"
#RUN dotnet build "webApi.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "webApi.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "webApi.dll"]
