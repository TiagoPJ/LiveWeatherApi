#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["LiveWeather/Api/Api.csproj", "Api/"]
COPY ["LiveWeather/Dominio/Domain.csproj", "Dominio/"]
COPY ["LiveWeather/Servico/Service.csproj", "Servico/"]
COPY ["LiveWeather/Aplicacao/Application.csproj", "Aplicacao/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/LiveWeather/Api"
RUN dotnet build "Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]