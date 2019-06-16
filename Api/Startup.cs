using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Api.Email;
using Api.Helpers;
using Aplication;
using Aplication.ICommand;
using Aplication.Interface;
using DataAcess;
using EFCommand;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<PostContext>();
            services.AddTransient<IGetCategory, EFGetCategory>();
            services.AddTransient<IGetPost, EFGetPostCommand>();
            services.AddTransient<IGetOnePostCommand, EFGetOnePost>();
            services.AddTransient<IGetOneCategory, EFGetOneCategory>();
            services.AddTransient<IAddCategoryCommand, EFAddCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EFEditCategory>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            services.AddTransient<IGetMenuCommand, EFGetMenu>();
            services.AddTransient<IGetOneMenuCommand, EFGetOneMenu>();
            services.AddTransient<IAddMenuCommand, EFAddMenu>();
            services.AddTransient<IEditMenuCommand, EFEditMenu>();
            services.AddTransient<IDeleteMenu, EFDeleteMenu>();
            services.AddTransient<IGetComment, EFGetComment>();
            services.AddTransient<IGetOneComment, EFGetOneComment>();
            services.AddTransient<IAddCommentCommand, EFAddCommentCommand>();
            services.AddTransient<IEditComment, EFEditComment>();
            services.AddTransient<IDeleteComment, EFDeleteComment>();
            services.AddTransient<IGetUserCommand, EFGetUserCommand>();
            services.AddTransient<IGetOneUser, EFGetOneUser>();
            services.AddTransient<IAddUser, EFAddUser>();
            services.AddTransient<IEditUser, EFEditUser>();
            services.AddTransient<IdeleteUser, EFDeleteUser>();
            services.AddTransient<IGEtTypeCommand, EFGEtType>();
            services.AddTransient<IGetOneType, EFGetOneType>();
            services.AddTransient<IAddType,EFAddType>();
            services.AddTransient<IEditType,EFEditType>();
            services.AddTransient<IDeleteType, EFDeleteType>();
            services.AddTransient<IGetAddPost, EFAddPost>();
            services.AddTransient<IDeletePicture, EFDeletePicture>();
            services.AddTransient<IDeletePost, EFDeletePost>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthCommand, EFAuthCommand>();
            services.AddTransient<IGetCateroryApi, EFGetCtegoryApi>();
            services.AddTransient<IEditPostCommand, EFEditPostCommand>();

            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encryption(key);
            services.AddSingleton(enc);


            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}")+1);
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });


            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Post Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
