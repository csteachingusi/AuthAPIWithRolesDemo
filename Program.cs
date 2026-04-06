using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AuthAPIWithRolesDemo.Data;
using AuthAPIWithRolesDemo.Model;

var builder = WebApplication.CreateBuilder(args);

// Configure database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


// Configure Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("8643b28c55ae86e55222d2568135210769823a5ed23446b0916f5ce50aeb4fc63a97acc0880e584f8e02bfa800d38178f5871ef941ed1b03d51157c84f6b8f93f40c0945656168b953dc353a036548d0c5ca91b93c855c5721a5a482890fa1cd9566a6d26085335e4bcf9812608182a4d38258e67ae579e41fc045b0b72b204d911f1a8105b1b62cca185d263ebdf0b262ff2c7b07ade721129093b358f022f93a7534aac80266f5b7551720fd52632dff8d68186670685b3523eabd216de021f6f68afde355d6d695ad6877c33c838bd734f0dfa036a229fd9ccaf25ad5e630f6a918f89b28246c9465900d19481362b2ed928a4e295d71d48a736740214f94")),
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true
    };
});




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User", "Manager" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();  // Enable authentication
app.UseAuthorization();   // Enable authorization

app.MapControllers();

app.Run();
