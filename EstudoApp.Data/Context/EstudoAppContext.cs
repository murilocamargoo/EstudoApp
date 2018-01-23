using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using EstudoApp.Data.EntityConfig;
using EstudoApp.Domain.Entities;
using EstudoApp.Domain.Interfaces;

namespace EstudoApp.Data.Context
{
    public class EstudoAppContext : DbContext
    {
        public EstudoAppContext() : base("EstudoApp")
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }

        public IDbSet<NinjaClan> NinjaClans { get; set; }
        public IDbSet<Ninja> Ninjas { get; set; }
        public IDbSet<NinjaEquipment> NinjaEquipments { get; set; }
            

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo as convenções  de cascade que são standard
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));

            modelBuilder.Types()
                .Configure(c => c.Ignore("IsDirty"));

            modelBuilder.Configurations.Add(new NinjaConfig());
            modelBuilder.Configurations.Add(new NinjaClanConfig());
            modelBuilder.Configurations.Add(new NinjaEquipmentConfig());
        }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as IModificationHistory))
            {
                if (history != null)
                {
                    history.DateModified = DateTime.Now;
                    if (history.DateCreated == DateTime.MinValue)
                        history.DateCreated = DateTime.Now;
                }
            }

            int result = base.SaveChanges();

            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModificationHistory).Select(e => e.Entity as IModificationHistory))
            {
                if (history != null) history.IsDirty = false;
            }

            return result;
        }
    }
}
