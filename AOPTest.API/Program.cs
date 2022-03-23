using AOPTest.API.Filters;
using AOPTest.API.Model;
using AOPTest.API.Services;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => {
    opt.Filters.Add(new DefaultResponseAttribute());
    opt.Filters.Add(new LogAttribute());
});

// builder.Services.AddMvc(opt =>
//     {
//         opt.Filters.Add(new ValidationFilter());
//     })
//     .AddFluentValidation(opt =>
//     {
//         opt.RegisterValidatorsFromAssemblyContaining<StartupBase>();
//     });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILogModel, LogModel>();
builder.Services.AddScoped<IStudentService, StudentService>();

// System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(mytype => mytype.GetInterface(typeof(IServiceHandlerAsync<>).Name) != null)
//             .ForEach(appCoreService => services.AddScoped(appCoreService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
