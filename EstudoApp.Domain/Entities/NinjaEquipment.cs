using System;
using EstudoApp.Domain.Interfaces;

namespace EstudoApp.Domain.Entities
{
    public class NinjaEquipment : IModificationHistory, IEntity
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; }
        public int? NinjaId { get; set; }
        public Ninja Ninja { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
