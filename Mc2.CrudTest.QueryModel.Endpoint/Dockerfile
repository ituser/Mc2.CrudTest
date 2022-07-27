#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mc2.CrudTest.QueryModel.Endpoint/Mc2.CrudTest.QueryModel.Endpoint.csproj", "Mc2.CrudTest.QueryModel.Endpoint/"]
COPY ["Mc2.CrudTest.QueryModel.Services/Mc2.CrudTest.QueryModel.Services.csproj", "Mc2.CrudTest.QueryModel.Services/"]
COPY ["Mc2.CrudTest.QueryModel.Date.EFCore/Mc2.CrudTest.QueryModel.Date.EFCore.csproj", "Mc2.CrudTest.QueryModel.Date.EFCore/"]
COPY ["Mc2.CrudTest.QueryModel.Models/Mc2.CrudTest.QueryModel.Models.csproj", "Mc2.CrudTest.QueryModel.Models/"]
COPY ["Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "Mc2.CrudTest.Domain/"]
COPY ["Mc2.CrudTest.Framework/Mc2.CrudTest.Framework.csproj", "Mc2.CrudTest.Framework/"]
COPY ["Mc2.CrudTest.Domain.Contracts/Mc2.CrudTest.Domain.Contracts.csproj", "Mc2.CrudTest.Domain.Contracts/"]
RUN dotnet restore "Mc2.CrudTest.QueryModel.Endpoint/Mc2.CrudTest.QueryModel.Endpoint.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.QueryModel.Endpoint"
RUN dotnet build "Mc2.CrudTest.QueryModel.Endpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.QueryModel.Endpoint.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.QueryModel.Endpoint.dll"]