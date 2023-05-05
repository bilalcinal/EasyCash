
using EasyCash.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyCash.DataAccess.Concrete.Context;

    public class EasyCashDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
        //const string ConnetDeveloper = "Server=localhost;Port=3306;Database=News365Db;User=root;password=21085454;Charset=utf8;";
        const string ConnetDeveloper = "server=localhost ;port=3306;database=EasyCashDb;user=root;password=0987654321;Charset=utf8;";
        optionsBuilder.UseLazyLoadingProxies()
            .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
            .EnableSensitiveDataLogging()
            .ConfigureWarnings(warnings =>
            {
                warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
            });
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountsProcesses { get; set; }
        
    }
