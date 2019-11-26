# Artsdatabanken/IdentityServer4
[Forked from skoruba/IdentityServer4.Admin](https://github.com/skoruba/IdentityServer4.Admin)

Dockerised version of IdentityServer4 and IdentityServer4.Admin

## How to run locally with docker
### Edit the connection strings to point to your local db in the two Dockerfiles
- sts/Skoruba.IdentityServer4.STS.Identity/Dockerfile
- src/Skoruba.IdentityServer4.Admin/Dockerfile

Example
```<language>
...
ENV ConnectionStrings__ConfigurationDbConnection "Server=10.0.0.25;Database=IdentityServer4;User ID=myUser; password=mySecurePassword;MultipleActiveResultSets=true"
ENV ConnectionStrings__PersistedGrantDbConnection "Server=10.0.0.25;Database=IdentityServer4;User ID=myUser; password=mySecurePassword;MultipleActiveResultSets=true"
ENV ConnectionStrings__IdentityDbConnection "Server=10.0.0.25;Database=IdentityServer4;User ID=myUser; password=mySecurePassword;MultipleActiveResultSets=true"
ENV Serilog__WriteTo__0__Args__connectionString "Server=10.0.0.25;Database=IdentityServer4;User ID=myUser; password=mySecurePassword;MultipleActiveResultSets=true"
...
```

### Create db
Open Package Manager Console (Default project: src\Identity.Admin) and run these commands
```<language>
Update-Database -context AdminIdentityDbContext
Update-Database -context AdminLogDbContext
Update-Database -context IdentityServerConfigurationDbContext
Update-Database -context IdentityServerPersistedGrantDbContext
```

### Seed db with default test-data
Temporary uncomment line 24 in Skoruba.IdentityServer4.Admin/Program.cs and start the project, or start the project with commandline argument "/seed"
```<language>
// await DbMigrationHelpers.EnsureSeedData<IdentityServerConfigurationDbContext, AdminIdentityDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext, UserIdentity, UserIdentityRole>(host);
```

See [skoruba/IdentityServer4.Admin](https://github.com/skoruba/IdentityServer4.Admin) for more information
