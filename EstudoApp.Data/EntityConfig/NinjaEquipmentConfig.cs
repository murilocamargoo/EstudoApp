using System.Data.Entity.ModelConfiguration;
using EstudoApp.Domain.Entities;

namespace EstudoApp.Data.EntityConfig
{
    public class NinjaEquipmentConfig : EntityTypeConfiguration<NinjaEquipment>
    {
        public NinjaEquipmentConfig()
        {
            HasKey(ne => ne.Id);

            HasRequired(n => n.Ninja)
                .WithMany(n => n.NinjaEquipments)
                .HasForeignKey(n => n.NinjaId);
        }
    }
}
