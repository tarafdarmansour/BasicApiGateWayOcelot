# BasicApiGateWayOcelot
This project demonestarte simple Api GateWay using Ocelot in .Net Core 5.
There was a [good example](https://www.c-sharpcorner.com/article/building-api-gateway-using-ocelot-in-asp-net-core/) in c-sharpcorner but it was out of date.

## UseIIS vs UseKestrel
This example fully work in development and contianerized environment. I Used "UseIIS" in development and "UseKestrel" in contianerized environment while starting program at APIGateWay/Program/Main.


### Development Env: Win10, .Net Core 5, VS 2019
### Container Env: mcr.microsoft.com/dotnet/aspnet:5.0


I hope you enjoy.

