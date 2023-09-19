#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ContactsApi/ContactsApi.csproj", "ContactsApi/"]
COPY ["Contacts.Application/Contacts.Application.csproj", "Contacts.Application/"]
COPY ["Contacts.Core/Contacts.Shared.csproj", "Contacts.Core/"]
COPY ["Contacts.Infrastructure/Contacts.Infrastructure.csproj", "Contacts.Infrastructure/"]
COPY ["Contacts.Domain/Contacts.Domain.csproj", "Contacts.Domain/"]
RUN dotnet restore "ContactsApi/ContactsApi.csproj"
COPY . .
WORKDIR "/src/ContactsApi"
RUN dotnet build "ContactsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactsApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactsApi.dll"]