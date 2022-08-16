#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["WebApiForHookahv1.0/WebApiForHookahv1.0.csproj", "WebApiForHookahv1.0/"]
RUN dotnet restore "WebApiForHookahv1.0/WebApiForHookahv1.0.csproj"
COPY . .
WORKDIR "/src/WebApiForHookahv1.0"
RUN dotnet build "WebApiForHookahv1.0.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApiForHookahv1.0.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApiForHookahv1.0.dll"]