using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quipu.Core.DomainModel;
using System;

namespace Quipu.Core.DAL
{
    public class QContext : DbContext
    {
        public QContext(DbContextOptions<QContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskRevision> TaskRevisions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermissionOverride> UserPermissionOverrides { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMessage> TeamMessages { get; set; }
        public DbSet<TaskStatusCategory> TaskStatusCategories { get; set; }
        public DbSet<PriorityType> PriorityTypes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<DiscussionOwner> DiscussionOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            foreach(var entityType in model.Model.GetEntityTypes())
            {
                foreach(var property in entityType.GetProperties())
                {
                    if(property.ClrType.IsEnum)
                    {
                        var type = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                        var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                        property.SetValueConverter(converter);
                    }
                }
            }
        }
    }
}
