using Twitter_Clone.TwitterClone.Application.services;
using TwitterClone.Application;

namespace Twitter_Clone.Entities;

var  builder = WebAppLOocation.CreateBulider(args)


builder.Services.AddControllers();
builder.Services.AddEndpointApiExplorer(); 
builder.Services.AddSwaggerGen(); 

builder.Services.AddSingleton<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService, UserServices.UserServices.UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger(); 
}

app.UserhttpsRedirection(); 
app.UseAuthorization(); 
app.MapControllers(); 
app.Run();