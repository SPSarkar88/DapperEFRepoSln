
using Carter;
using DapperEFRepoProject.Modules.Contacts.Respository;
using DapperEFRepoProject.Modules.Contacts.Service;

namespace DapperEFRepoProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddControllers();
            builder.Services.AddScoped<IContactDapperRepository, ContactDapperRepository>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddCarter();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            //app.MapControllers();
            app.MapCarter();
            app.Run();
        }
    }
}
