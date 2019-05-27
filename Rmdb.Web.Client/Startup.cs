using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rmdb.Web.Client.Data.Contracts;
using Rmdb.Web.Client.Data.SessionStorage;
using Rmdb.Web.Client.ViewModels.Actors;
using Rmdb.Web.Client.ViewModels.Movies;

namespace Rmdb.Web.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ActorMapperProfile>();
                cfg.AddProfile<MovieMapperProfile>();
            });

            // added for demo purposes
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
            });

            services.AddHttpContextAccessor();
            services.AddTransient<IMovieService, MovieSessionStore>();
            services.AddTransient<IActorService, ActorSessionStore>();

            services.AddMvc(options =>
            {
                // add global authorization filter
                var policy = new AuthorizationPolicyBuilder()
                          .RequireAuthenticatedUser()
                          .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "RMDBCookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("RMDBCookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:44359/";
                    options.RequireHttpsMetadata = true;

                    // Use the hybrid grant, but ensure access tokens aren't exposed
                    // via the front channel
                    options.ResponseType = "code id_token";
                    options.ClientId = "rmdbwebclient";
                    // client secret required for token endpoint access
                    options.ClientSecret = "2E51842C-56EF-481A-938C-A0C4BF648215";
                    // always get claims from the userinfo endpoint (to avoid URL length restrictions)
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;
                });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseAuthentication();

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            // for demo purposes
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
