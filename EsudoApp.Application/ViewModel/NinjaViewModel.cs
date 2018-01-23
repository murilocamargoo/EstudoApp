using System;
using System.Collections.Generic;
using EstudoApp.Domain.Entities;
using EstudoApp.Domain.Interfaces;

namespace EsudoApp.Application.ViewModel
{
    public class NinjaViewModel : IModificationHistory, IEntity
    {
        public int Id { get; set; }
        public string NinjaName { get; set; }
        public int? NinjaClanId { get; set; }
        public NinjaClan NinjaClan { get; set; }
        public IList<NinjaEquipment> NinjaEquipments { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}