using MyPostcodeApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPostcodeService, PostcodeServices>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
