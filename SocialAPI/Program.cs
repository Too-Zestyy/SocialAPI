using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SocialAPI;
using SocialAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NoteDbContext>();
// builder.Services.AddDbContext<NoteDBContext>(options => {});

// builder.Services.AddDbContextPool<NotesContext>(opt => 
//     opt.UseNpgsql(builder.Configuration.GetConnectionString("NotesContext")));

// builder.Services.AddNpgsqlDataSource(
//     "Server=localhost;Port=5432;Database=c_sharp_notes;User ID=c_sharp_notes;Password=cSharp;"
//     );

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

// Call EnsureCreated() to create the database and tables  
using (var scope = app.Services.CreateScope())  
{  
    var services = scope.ServiceProvider;  
    try  
    {  
        var dbContext = services.GetRequiredService<NoteDbContext>();  
        dbContext.Database.EnsureCreated(); // Creates database/tables if missing  
    }  
    catch (Exception ex)  
    {  
        var logger = services.GetRequiredService<ILogger<Program>>();  
        logger.LogError(ex, "An error occurred creating the database.");  
    }  
}  

app.Run();
