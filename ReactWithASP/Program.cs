using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

using System.Threading.Tasks;
namespace ReactWithASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//var builder = WebApplication.CreateBuilder(args);

//// Configure services
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//})
//.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
//.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
//{
//    options.ClientId = builder.Configuration["OpenId:ClientId"];
//    options.Authority = builder.Configuration["OpenId:Authority"]; // e.g., https://login.microsoftonline.com/{tenant-id}

//    options.ResponseType = "code";
//    options.SaveTokens = true;
//    //options.CallbackPath = "/signin-oidc";
//    //options.RedirectUri = builder.Configuration["OpenId:RedirectUri"]; // e.g., https://localhost:62060/signin-oidc
//    //options.PostLogoutRedirectUri = builder.Configuration["OpenId:PostLogoutRedirectUri"]; // e.g., https://localhost:62060/signout-callback
//    options.SignedOutRedirectUri = builder.Configuration["OpenId:PostLogoutRedirectUri"];
//    options.Events = new OpenIdConnectEvents
//    {
//        //OnRedirectToAuthorizationEndpoint = context =>
//        //{
//        //    context.ProtocolMessage.RedirectUri = builder.Configuration["OpenId:RedirectUri"];
//        //    return Task.CompletedTask;
//        //},
//        OnAuthenticationFailed = context =>
//        {
//            context.HandleResponse();
//            context.Response.Redirect(builder.Configuration["OpenId:PostLogoutRedirectUri"]);
//            return Task.CompletedTask;
//        },
//        OnTokenValidated = context =>
//        {
//            // Custom logic after token validation
//            return Task.CompletedTask;
//        }
//    };
//});

//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddRazorPages();
//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});

//var app = builder.Build();

//// Configure middleware
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();
//app.MapRazorPages();

//app.Run();

//namespace ReactWithASP
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
//using Microsoft.IdentityModel.Tokens;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Http;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
//using System.IdentityModel.Tokens.Jwt;
//using System;
//using ReactWithASP.Interface;
//using ReactWithASP.UIServices;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<IGateEntryServiceReader, GateEntryServiceReader>();
//// Add authentication services
////builder.Services.AddAuthentication(options =>
////{
////    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
////    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
////})
////.AddCookie(options =>
////{
////    options.SlidingExpiration = true;
////    options.ExpireTimeSpan = TimeSpan.FromHours(8);
////    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
////})
////.AddOpenIdConnect(options =>
////{
////    options.ClientId = builder.Configuration["Oidc:ClientId"];
////    options.ClientSecret = builder.Configuration["Oidc:ClientSecret"];
////    options.Authority = builder.Configuration["Oidc:MetadataAddress"];
////    options.ResponseType = OpenIdConnectResponseType.IdToken;
////    options.SaveTokens = true;

////    //options.RedirectUri = builder.Configuration["Oidc:RedirectUrl"];
////    options.SignedOutRedirectUri = builder.Configuration["Oidc:LogOutRedirectUrl"];
////    options.RequireHttpsMetadata = false; // Set to true in production

////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        NameClaimType = ClaimTypes.NameIdentifier
////    };

////    options.Events = new OpenIdConnectEvents
////    {
////        OnAuthenticationFailed = context =>
////        {
////            if (context.Exception.Message.Contains("IDX21323"))
////            {
////                context.HandleResponse();
////                context.Response.Redirect(builder.Configuration["Oidc:LogOutRedirectUrl"]);
////            }
////            return Task.CompletedTask;
////        },
////        OnTokenValidated = context =>
////        {
////            var idToken = context.SecurityToken as JwtSecurityToken;
////            if (idToken != null)
////            {
////                context.Principal.AddIdentity(new ClaimsIdentity(new[]
////                {
////                    new Claim("id_token", idToken.RawData)
////                }));
////            }

////            context.Principal.AddIdentity(new ClaimsIdentity(new[]
////            {
////                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "oidc")
////            }));

////            return Task.CompletedTask;
////        },
////        //OnRedirectToAuthorizationEndpoint = context =>
////        //{
////        //    if (context.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
////        //    {
////        //        if (!string.IsNullOrEmpty(context.ProtocolMessage.RedirectUri) && !context.ProtocolMessage.RedirectUri.StartsWith("https://"))
////        //        {
////        //            context.ProtocolMessage.RedirectUri = context.ProtocolMessage.RedirectUri.Replace("http://", "https://");
////        //        }

////        //        if (context.HttpContext.Request.Query.ContainsKey("ui_locales"))
////        //        {
////        //            context.ProtocolMessage.UiLocales = context.HttpContext.Request.Query["ui_locales"];
////        //        }

////        //        if (context.ProtocolMessage.State.Contains("="))
////        //        {
////        //            var stateQueryString = context.ProtocolMessage.State.Split('=');
////        //            var protectedState = stateQueryString[1];
////        //            var authenticationProperties = context.Options.StateDataFormat.Unprotect(protectedState);
////        //            if (authenticationProperties.Dictionary.TryGetValue("acr_values", out var acr_values))
////        //            {
////        //                context.ProtocolMessage.AcrValues = acr_values;
////        //            }
////        //        }
////        //    }

////        //    if (context.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
////        //    {
////        //        if (!string.IsNullOrEmpty(context.ProtocolMessage.PostLogoutRedirectUri) && context.ProtocolMessage.PostLogoutRedirectUri.StartsWith("https://"))
////        //        {
////        //            context.ProtocolMessage.PostLogoutRedirectUri = context.ProtocolMessage.PostLogoutRedirectUri.Replace("http://", "https://");
////        //        }

////        //        var idTokenHint = context.Principal?.FindFirst("id_token")?.Value;
////        //        if (idTokenHint != null)
////        //        {
////        //            context.ProtocolMessage.IdTokenHint = idTokenHint;
////        //        }
////        //    }

////        //    return Task.CompletedTask;
////        //}
////    };
////});

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();
//app.MapRazorPages();

//app.Run();

