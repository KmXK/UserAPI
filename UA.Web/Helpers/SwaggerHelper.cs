using Microsoft.OpenApi.Models;

namespace UA.Web.Helpers;

public static class SwaggerHelper
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        var authorizationTokenType = "Bearer";

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "User API", Version = "v1" });
            c.AddSecurityDefinition(authorizationTokenType, new OpenApiSecurityScheme
            {
                Description = """
                              JWT Authorization header using the Bearer scheme. </br>
                                                    Enter your token with Bearer word.
                                                    Example: 'Bearer tgj7d3fhk'
                              """,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = authorizationTokenType
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = authorizationTokenType
                        },
                        Scheme = "oauth2",
                        Name = authorizationTokenType,
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }
}