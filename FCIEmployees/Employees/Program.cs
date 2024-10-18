

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add DbContext for EmployeesDbContext
builder.Services.AddDbContext<EmployeesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesDatabase"), 
        b => b.MigrationsAssembly("Infrastructure"))); 



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // إضافة Unit of Work

builder.Services.AddScoped<ITownRepository, TownRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// Add Mediator

//----------------------------------------------------------
builder.Services.AddMediatR(typeof(GetAllTownsHandler).Assembly);//Start Point --> all handlers in the assembly
//----------------------------------------------------------

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
// Register MediatR with all handlers in the assembly
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var mediator = builder.Services.BuildServiceProvider().GetService<IMediator>();
if (mediator == null)
{
    Console.WriteLine("Mediator is not registered.");
}

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
