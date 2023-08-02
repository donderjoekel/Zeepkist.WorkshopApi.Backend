FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Zeepkist.WorkshopApi/Zeepkist.WorkshopApi.csproj", "Zeepkist.WorkshopApi/"] 
RUN dotnet restore "Zeepkist.WorkshopApi/Zeepkist.WorkshopApi.csproj"
COPY . .
WORKDIR "/src/Zeepkist.WorkshopApi"
RUN dotnet build "Zeepkist.WorkshopApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zeepkist.WorkshopApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TNRD.Zeepkist.WorkshopApi.dll"]
