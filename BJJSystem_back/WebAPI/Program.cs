using Domain.Interfaces.Generics;
using Domain.Interfaces.IAcademia;
using Domain.Interfaces.IAluno;
using Domain.Interfaces.IAlunoTurma;
using Domain.Interfaces.ICompeticao;
using Domain.Interfaces.IFaixa;
using Domain.Interfaces.IMensalidade;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IParticipacaoCompeticao;
using Domain.Interfaces.IPodio;
using Domain.Interfaces.IProfessor;
using Domain.Interfaces.IProfessorTurma;
using Domain.Interfaces.IResultado;
using Domain.Interfaces.ITurma;
using Domain.Servicos;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContextBase>();



// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositorioGenerics<>));
builder.Services.AddSingleton<InterfaceAcademia, RepositorioAcademia>();
builder.Services.AddSingleton<InterfaceAluno, RepositorioAluno>();
builder.Services.AddSingleton<InterfaceAlunoTurma, RepositorioAlunoTurma>();
builder.Services.AddSingleton<InterfaceCompeticao, RepositorioCompeticao>();
builder.Services.AddSingleton<InterfaceFaixa, RepositorioFaixa>();
builder.Services.AddSingleton<InterfaceMensalidade, RepositorioMensalidade>();
builder.Services.AddSingleton<InterfaceParticipacaoCompeticao, RepositorioParticipacaoCompeticao>();
builder.Services.AddSingleton<InterfacePodio, RepositorioPodio>();
builder.Services.AddSingleton<InterfaceProfessor, RepositorioProfessor>();
builder.Services.AddSingleton<InterfaceResultado, RepositorioResultado>();
builder.Services.AddSingleton<InterfaceTurma, RepositorioTurma>();
builder.Services.AddSingleton<InterfaceProfessorTurma, RepositorioProfessorTurma>();


// SERVIÇO DOMINIO
builder.Services.AddSingleton<IAcademiaServico, AcademiaServico>();
builder.Services.AddSingleton<IAlunoServico, AlunoServico>();
builder.Services.AddSingleton<IAlunoTurmaServico, AlunoTurmaServico>();
builder.Services.AddSingleton<ICompeticaoServico, CompeticaoServico>();
builder.Services.AddSingleton<IFaixaServico, FaixaServico>();
builder.Services.AddSingleton<IMensalidadeServico, MensalidadeServico>();
builder.Services.AddSingleton<IParticipacaoCompeticaoServico, ParticipacaoCompeticaoServico>();
builder.Services.AddSingleton<IPodioServico, PodioServico>();
builder.Services.AddSingleton<IProfessorServico, ProfessorServico>();
builder.Services.AddSingleton<IResultadoServico, ResultadoServico>();
builder.Services.AddSingleton<ITurmaServico, TurmaServico>();
builder.Services.AddSingleton<ITurmaServico, TurmaServico>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Teste.Securiry.Bearer",
            ValidAudience = "Teste.Securiry.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("secret_key-12345678")
        };
        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//new
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
