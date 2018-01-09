using System.Data.Entity.ModelConfiguration;
using EstudoApp.Domain.Entities;

namespace EstudoApp.Data.EntityConfig
{
    public class NinjaClanConfig :EntityTypeConfiguration<NinjaClan>
    {
        public NinjaClanConfig()
        {
            HasKey(nc => nc.Id);

            //Relação com o Id obrigatório
            //HasMany(n => n.Ninjas)
            //    .WithRequired(n => n.NinjaClan)
            //    .HasForeignKey(n => n.NinjaClanId);

            //HasMany(n => n.Ninjas)
            //    .WithOptional(n => n.NinjaClan)
            //    .HasForeignKey(n => n.NinjaClanId);
        }
    }
}
