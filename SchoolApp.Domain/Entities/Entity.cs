namespace SchoolApp.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(int id)
        {
            Id = id;
        }
        public int Id { get; private init; }
        public static bool operator == (Entity? first, Entity? second)
        {
            return first is not null&& second is not null&& first.Equals(second);
        }
        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }
        public bool Equals(Entity? other)
        {
            if (other == null)
            {
                return false;
            }
            if(other.GetType() != GetType())
            {
                return false;
            }
            return other.Id==this.Id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false; 
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            if (obj is not Entity entity)
            {
                return false;
            }
            return entity.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode()*31;
        }

    }
}

