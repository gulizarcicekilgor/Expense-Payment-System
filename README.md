for database : dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0

for Migration : dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0

WebApi> dotnet ef migrations add InitialCreate 
WebApi> dotnet ef database update

Token-Authentication
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.0


AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0
dotnet add package AutoMapper --version 7.0.1
