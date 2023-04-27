using CommanderMinApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence
{
    public class CommanderMinApiDbContext : DbContext
    {
        public CommanderMinApiDbContext(DbContextOptions<CommanderMinApiDbContext> options) : base(options)
        {
            
        }

        public DbSet<CommandLineEntity> CommandLines { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommanderMinApiDbContext).Assembly);

            //seed data, added through migrations
            var angularCliGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var efGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var gitGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            modelBuilder.Entity<PlatformEntity>().HasData(new PlatformEntity
            {
                PlatformName = "Angular CLI",
                PlatformId = angularCliGuid
            });
            modelBuilder.Entity<PlatformEntity>().HasData(new PlatformEntity
            {
                PlatformName = "Entity Framework",
                PlatformId = efGuid
            });
            modelBuilder.Entity<PlatformEntity>().HasData(new PlatformEntity
            {
                PlatformName = "Git commands",
                PlatformId = gitGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                PlatformName = "Angular CLI",
                HowTo = "Generate new module",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = angularCliGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                PlatformName = "Angular CLI",
                HowTo = "Generate new component",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = angularCliGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                PlatformName = "Angular CLI",
                HowTo = "Generate new Service",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = angularCliGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                PlatformName = "Entity Framework",
                HowTo = "Add new migratation",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = efGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                PlatformName = "Entity Framework",
                HowTo = "Update database",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = efGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                PlatformName = "Entity Framework",
                HowTo = "Update packages",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = efGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                PlatformName = "Git commands",
                HowTo = "Push code",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = gitGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                PlatformName = "Git commands",
                HowTo = "Change branch",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = gitGuid
            });

            modelBuilder.Entity<CommandLineEntity>().HasData(new CommandLineEntity
            {
                CommandLineId = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                PlatformName = "Git commands",
                HowTo = "Add new repository",
                CommandLine = "This is the command",
                Comment = "This is a comment",
                PlatformId = gitGuid
            });
        }
    }
}