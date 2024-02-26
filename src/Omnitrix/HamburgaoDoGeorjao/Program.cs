using HamburgaoDoGeorjao.DAO.Regras;
using RegrasDeNegocios.Regras;
using RegrasDeNegocios.Serviços;
using HamburgaoDoGeorjao.DAO.Dao;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var logger = new LoggerConfiguration()
    //.ReadFrom.
    //Configuration(builder.Configuration)
    //.CreateLogger();

//Log.Logger = logger;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("Master");

Console.WriteLine(connectionStrings);

//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Testes"));
//.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// Criação objetos acesso a dados
//builder.Services.AddScoped<IHamburguerDao, HamburguerRepository>();
//builder.Services.AddScoped<IClienteDao, ClienteRepository>();
//builder.Services.AddScoped<IPedidoDao, PedidoRepository>();

//Criação objetos de serviço
builder.Services.AddScoped<IHamburguerService, HamburguerService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddLogging(configure =>
{
    configure.AddConsole();
    //configure.AddSerilog();
});


var app = builder.Build();

app.Logger.LogInformation("Ola eu sou informação");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
