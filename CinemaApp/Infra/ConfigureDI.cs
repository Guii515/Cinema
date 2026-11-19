using AutoMapper;
using CinemaApp.Cadastros;
using CinemaApp.Models;
using CinemaDomain;
using CinemaRepository.Base;
using CinemaRepository.Context;
using CinemaService.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;

namespace CinemaApp.Infra
{
    public static class ConfigureDI
    {
        public static ServiceCollection Services;
        public static IServiceProvider ServiceProvider;
        public static void Configure()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Services = new ServiceCollection();            
            
            #region Banco de Dados Injeção de Dependência            
            var strCon = File.ReadAllText("Config/ConfigDB.txt");
            Services.AddDbContext<MyDBContext>(options => options.UseNpgsql(strCon));
            #endregion

            #region Repositórios Injeção de Dependência
            Services.AddScoped<IBaseRepository<Genero>, BaseRepository<Genero>>();
            Services.AddScoped<IBaseRepository<Filme>, BaseRepository<Filme>>();
            Services.AddScoped<IBaseRepository<Sala>, BaseRepository<Sala>>();
            Services.AddScoped<IBaseRepository<Sessao>, BaseRepository<Sessao>>();
            Services.AddScoped<IBaseRepository<Ingresso>, BaseRepository<Ingresso>>();
            Services.AddScoped<IBaseRepository<IngressoItem>, BaseRepository<IngressoItem>>();
            #endregion

            #region Serviços Injeção de Dependência
            Services.AddScoped<IBaseService<Genero>, BaseService<Genero>>();
            Services.AddScoped<IBaseService<Filme>, BaseService<Filme>>();
            Services.AddScoped<IBaseService<Sala>, BaseService<Sala>>();
            Services.AddScoped<IBaseService<Sessao>, BaseService<Sessao>>();
            Services.AddScoped<IBaseService<Ingresso>, BaseService<Ingresso>>();
            Services.AddScoped<IBaseService<IngressoItem>, BaseService<IngressoItem>>();
            #endregion

            #region AutoMapper Injeção de Dependência
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Filme, FilmeViewModel>()
                    .ForMember(d => d.NomeGenero, o => o.MapFrom(s => s.Genero.Nome));

                cfg.CreateMap<Sessao, SessaoViewModel>()
                    .ForMember(d => d.NomeFilme, o => o.MapFrom(s => s.Filme.Nome))
                    .ForMember(d => d.NumeroSala, o => o.MapFrom(s => s.Sala.Numero));

                cfg.CreateMap<Ingresso, IngressoViewModel>()
                    .ForMember(d => d.NomeFilme, o => o.MapFrom(s => s.Sessao.Filme.Nome))
                    .ForMember(d => d.DataSessao, o => o.MapFrom(s => s.Sessao.Data))
                    .ForMember(d => d.Quantidade, o => o.MapFrom(s => s.IngressoItens.Count));
            }, NullLoggerFactory.Instance);

            Services.AddSingleton(mapperConfig.CreateMapper());
            #endregion

            #region Formulários Injeção de Dependência
            Services.AddTransient<CadastroGenero>();
            Services.AddTransient<CadastroFilme>();
            Services.AddTransient<CadastroSala>();
            Services.AddTransient<CadastroSessao>();
            Services.AddTransient<CadastroIngresso>();
            #endregion

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
