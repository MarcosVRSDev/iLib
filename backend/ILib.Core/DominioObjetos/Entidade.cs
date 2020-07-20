using System;

namespace ILib.Core
{
    public abstract class Entidade : IEquatable<Entidade>
    {
        public int Id { get; set; }

        public bool Equals(Entidade other)
        {
            return Id == other.Id;
        }
    }

}
