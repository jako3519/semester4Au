# herynder defineres.NET SDK som base image.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

#wORKDIR definerer arbeidsmappen for image
WORKDIR /app

# herunder kopieres csproj filene til /app mappen
COPY *.csproj ./

# Herunder restore de nødvendige dependencies
RUN dotnet restore

# Herunder kopieres source filene til /app mappen
COPY . ./

# herunder buildes projektet
RUN dotnet publish -c Release -o /app/publish

# herunder defineres samme image som runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# kopierer filerne fra build image til runtime image
COPY --from=build /app/publish .

# entrypoint definerer hvilken filer der skal køres når containeren startes
ENTRYPOINT ["dotnet", "webApi.dll"]
