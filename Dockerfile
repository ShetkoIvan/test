FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY PatientService.API/PatientService.API.csproj PatientService.API/
COPY PatientService.Application/PatientService.Application.csproj PatientService.Application/
COPY PatientService.Infrastructure/PatientService.Infrastructure.csproj PatientService.Infrastructure/
COPY PatientService.Domain/PatientService.Domain.csproj PatientService.Domain/

RUN dotnet restore PatientService.API/PatientService.API.csproj

COPY . .
RUN dotnet publish PatientService.API/PatientService.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PatientService.API.dll"]