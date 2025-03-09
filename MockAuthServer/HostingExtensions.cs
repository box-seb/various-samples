using Microsoft.IdentityModel.Tokens;
using MockNexusAuthServer.keys;
using Serilog;

namespace MockNexusAuthServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        //builder.Services.AddRazorPages();

        builder.Services.AddIdentityServer(options =>
            {
                options.IssuerUri = "https://auth-server-name.test/";

                options.Endpoints.EnableTokenEndpoint = true;
                options.Endpoints.EnableDiscoveryEndpoint = true;

                options.Endpoints.EnableAuthorizeEndpoint = false;
                options.Endpoints.EnableBackchannelAuthenticationEndpoint = false;
                options.Endpoints.EnableCheckSessionEndpoint = false;
                options.Endpoints.EnableDeviceAuthorizationEndpoint = false;
                options.Endpoints.EnableEndSessionEndpoint = false;
                options.Endpoints.EnableIntrospectionEndpoint = false;
                options.Endpoints.EnableJwtRequestUri = false;
                options.Endpoints.EnableTokenRevocationEndpoint = false;
                options.Endpoints.EnableUserInfoEndpoint = false;
                options.KeyManagement.Enabled = false;
            })
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            .AddSigningCredential(SigningKeyProvider.GetSigningKey(), SecurityAlgorithms.RsaSha256);

        return builder.Build();
    }



    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        //app.UseStaticFiles();
        //app.UseRouting();
            
        app.UseIdentityServer();

        // uncomment if you want to add a UI
        //app.UseAuthorization();
        //app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
