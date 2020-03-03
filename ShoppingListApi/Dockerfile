FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./ShoppingListApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# Set default environment variables
ENV ConnectionString="Server=127.0.0.1;Port=5432;Database=shoppinglist;User Id=shoppinglistadmin;Password=shoppinglistadmin;"

ENTRYPOINT ["dotnet", "ShoppingListApi.dll"]