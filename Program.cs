using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Tokens;
using SocialAPI;
using SocialAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NoteDbContext>();

// TODO: Replace with asymmetric key
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtOptions =>
    {
        jwtOptions.Authority = "C#-Notes-App";
        // Only required for development - should be removed in prod
        // FIXME
        jwtOptions.RequireHttpsMetadata = false;
        jwtOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtConst.Issuer,
            ValidAudience = JwtConst.Audience,
            IssuerSigningKey = JwtConst.PublicKey,
            // IssuerSigningKey = new SymmetricSecurityKey(
            //     new byte[256]
            //     )
        };
    });
builder.Services.AddAuthorization();
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
app.UseAuthentication();
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
