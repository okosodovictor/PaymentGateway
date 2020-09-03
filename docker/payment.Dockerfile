FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY PaymentGateway.API/**.csproj ./PaymentGateway.API/
COPY PaymentGateway.Domain/**.csproj ./PaymentGateway.Domain/
COPY PaymentGateway.Persistence/**.csproj ./PaymentGateway.Persistence/
COPY PaymentGateway.Application/**.csproj ./PaymentGateway.Application/
COPY PaymentGateway.Banks/**.csproj ./PaymentGateway.Banks/

WORKDIR /app/PaymentGateway.API
RUN dotnet restore

# Copy everything else and build
COPY . /app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/PaymentGateway.API/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]