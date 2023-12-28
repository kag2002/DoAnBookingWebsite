FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BookingWebsite.Web.Host/BookingWebsite.Web.Host.csproj", "src/BookingWebsite.Web.Host/"]
COPY ["src/BookingWebsite.Web.Core/BookingWebsite.Web.Core.csproj", "src/BookingWebsite.Web.Core/"]
COPY ["src/BookingWebsite.Application/BookingWebsite.Application.csproj", "src/BookingWebsite.Application/"]
COPY ["src/BookingWebsite.Core/BookingWebsite.Core.csproj", "src/BookingWebsite.Core/"]
COPY ["src/BookingWebsite.EntityFrameworkCore/BookingWebsite.EntityFrameworkCore.csproj", "src/BookingWebsite.EntityFrameworkCore/"]
WORKDIR "/src/src/BookingWebsite.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BookingWebsite.Web.Host", "src/BookingWebsite.Web.Host"]
COPY ["src/BookingWebsite.Web.Core", "src/BookingWebsite.Web.Core"]
COPY ["src/BookingWebsite.Application", "src/BookingWebsite.Application"]
COPY ["src/BookingWebsite.Core", "src/BookingWebsite.Core"]
COPY ["src/BookingWebsite.EntityFrameworkCore", "src/BookingWebsite.EntityFrameworkCore"]
WORKDIR "/src/src/BookingWebsite.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BookingWebsite.Web.Host.dll"]
