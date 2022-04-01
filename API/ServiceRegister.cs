using API.Infra.Context;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API;

public static class ServiceRegister
{
    public static void RegisterDatabase(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();
    }

    public static void DependecyInjection(this IServiceCollection services)
    {
        // [ ] - TODO iNJETAR COLEÇÃO DE SERVIÇOS DE PACOTES
        // [ ] - TODO INJETAR REPOSITORIO DE PACOTES

        // [ ] - TODO iNJETAR COLEÇÃO DE SERVIÇOS DE dETALHES
        // [ ] - TODO INJETAR REPOSITORIO DE DETALHES
    }
    
    public static void ConfigureCORS(this IServiceCollection services)
    {
        // [ ] - TODO ADICIONAR POLITICASDE CORS NA APLICAÇÃO
    }

    public static void RegisterAuthentication(this IServiceCollection services)
    {
        // dotnet add package Microsoft.AspNetCore.Authentiction.JwtBearer
        // dotnet add package Microsoft.AspNetCore.Authentiction
 
        // [ ] - TODO UTILIZAR VARIAVEIS DE AMBIENTE
        var secret = "MY_BIGGEST_SECRET";
        var key = Encoding.ASCII.GetBytes(secret);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
    }   
    public static void RegisterAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
        });
    }

}