using System.Data.Entity.ModelConfiguration;
using EstudoApp.Domain.Entities;

namespace EstudoApp.Data.EntityConfig
{
    public class NinjaConfig : EntityTypeConfiguration<Ninja>
    {
        public NinjaConfig()
        {
            HasKey(n => n.Id);

            //Para deixar a foreign key como nula
            Property(n => n.NinjaClanId).IsOptional();

            //Relação com o Id não obrigatório
            HasOptional(nc => nc.NinjaClan)
                .WithMany(nc => nc.Ninjas)
                .HasForeignKey(nc => nc.NinjaClanId);

            //Id obrigatório
            //HasRequired(nc => nc.NinjaClan)
            //    .WithMany(nc => nc.Ninjas)
            //    .HasForeignKey(nc => nc.NinjaClanId);
        }
    }
}
