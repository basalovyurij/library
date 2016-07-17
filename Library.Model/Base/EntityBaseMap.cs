using System.Data.Entity.ModelConfiguration;

namespace Library.DB.Base
{
    public class EntityBaseMap<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        public EntityBaseMap()
        {
            ToTable(GetType().Name);

            HasKey(t => t.Id);

            Property(t => t.Id);
        }
    }
}
