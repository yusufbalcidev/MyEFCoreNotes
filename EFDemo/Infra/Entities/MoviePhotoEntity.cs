using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.Infra.Entities.Base;

namespace EFDemo.Infra.Entities
{
    public  class MoviePhotoEntity: BaseEntity
    {
        public string Url { get; set; }
        public Guid MovieId { get; set; }
        public MovieEntity Movie { get; set; }


    }
}
