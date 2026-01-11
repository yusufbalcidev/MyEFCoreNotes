using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.Infra.Entities.Base;

namespace EFDemo.Infra.Entities
{
    public class MovieEntity : BaseEntity
    {
        public string Name { get; set; }
        public int ViewCount { get; set; }

        public Guid GenreId { get; set; }
        public virtual GenreEntity Genre { get; set; }

        public Guid DirectorId { get; set; }
        public virtual DirectorEntity Director { get; set; }

        public virtual ICollection<ActorEntity> Actors { get; set; }
        public virtual ICollection<MoviePhotoEntity> Photos { get; set; }


    }
}