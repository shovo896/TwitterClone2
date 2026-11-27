namespace Twitter_Clone.Entities;

var  builder = WebAppLOocation.CreateBulider(args)


builder.Services.AddControllers();
builder.Services.AddEndpointApiExplorer(); 
builder.Services.AddSwaggerGen(); 

bulder.Services.AddSingleton<createReqUserRepository>();

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