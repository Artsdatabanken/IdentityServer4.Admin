FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS="http://+:5000"
ENV ConnectionStrings__ConfigurationDbConnection "Server=[YOUR IP];Database=[YOUR DB];User ID=[YOUR USERNAME]; password=[YOUR PASSWORD];MultipleActiveResultSets=true"
ENV ConnectionStrings__PersistedGrantDbConnection "Server=[YOUR IP];Database=[YOUR DB];User ID=[YOUR USERNAME]; password=[YOUR PASSWORD];MultipleActiveResultSets=true"
ENV ConnectionStrings__IdentityDbConnection "Server=[YOUR IP];Database=[YOUR DB];User ID=[YOUR USERNAME]; password=[YOUR PASSWORD];MultipleActiveResultSets=true"
ENV Serilog__WriteTo__0__Args__connectionString "Server=[YOUR IP];Database=[YOUR DB];User ID=[YOUR USERNAME]; password=[YOUR PASSWORD];MultipleActiveResultSets=true"

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Skoruba.IdentityServer4.STS.Identity/Skoruba.IdentityServer4.STS.Identity.csproj", "src/Skoruba.IdentityServer4.STS.Identity/"]
COPY ["src/Skoruba.IdentityServer4.Admin.EntityFramework.Identity/Skoruba.IdentityServer4.Admin.EntityFramework.Identity.csproj", "src/Skoruba.IdentityServer4.Admin.EntityFramework.Identity/"]
COPY ["src/Skoruba.IdentityServer4.Admin.EntityFramework/Skoruba.IdentityServer4.Admin.EntityFramework.csproj", "src/Skoruba.IdentityServer4.Admin.EntityFramework/"]
COPY ["src/Skoruba.IdentityServer4.Admin.EntityFramework.Extensions/Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.csproj", "src/Skoruba.IdentityServer4.Admin.EntityFramework.Extensions/"]
COPY ["src/Skoruba.IdentityServer4.Admin.EntityFramework.Shared/Skoruba.IdentityServer4.Admin.EntityFramework.Shared.csproj", "src/Skoruba.IdentityServer4.Admin.EntityFramework.Shared/"]
RUN dotnet restore "src/Skoruba.IdentityServer4.STS.Identity/Skoruba.IdentityServer4.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Skoruba.IdentityServer4.STS.Identity"
RUN dotnet build "Skoruba.IdentityServer4.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Skoruba.IdentityServer4.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Skoruba.IdentityServer4.STS.Identity.dll"]