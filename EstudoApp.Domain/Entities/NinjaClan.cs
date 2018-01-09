using System;
using System.Collections.Generic;
using EstudoApp.Domain.Interfaces;

namespace EstudoApp.Domain.Entities
{
    public class NinjaClan : IModificationHistory, IEntity
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public DateTime FoundationDate { get; set; }
        public IList<Ninja> Ninjas { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
