var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add DbContext for EmployeesDB
builder.Services.AddDbContext<EmployeesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesDatabase"), 
        b => b.MigrationsAssembly("Infrastructure"))); 

// Add DbContext for ProjectsDB
builder.Services.AddDbContext<ProjectsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectsDatabase"), 
        b => b.MigrationsAssembly("Infrastructure"))); 

// Add Repositories
// إضافة خدمات MediatR
builder.Services.AddScoped<ITownRepository, TownRepository>(); // تسجيل الـ Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// Add Mediator
//builder.Services.AddMediatR(typeof(Program).Assembly); // استخدام الطريقة الصحيحة
//builder.Services.AddMediatR(typeof(GetAllTownsHandler).Assembly);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

// Configure the HTTP request pipeline.
var app = builder.Build(); // تأكد من أنك قد أضفت هذا السطر قبل استخدام 'app'

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // إذا كنت تستخدم API controllers

// إعادة توجيه الصفحة الرئيسية إلى Swagger
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.Run();
