FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME


COPY APIGateWay/APIGateWay.csproj $APP_HOME/APIGateWay/
RUN  cd $APP_HOME/APIGateWay && dotnet restore

COPY APIGateWay/. $APP_HOME/APIGateWay/
RUN cd $APP_HOME/APIGateWay && dotnet build


FROM build AS publish
WORKDIR $APP_HOME/APIGateWay
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /opt/app/APIGateWay/out ./
ENTRYPOINT ["dotnet", "APIGateWay.dll"]