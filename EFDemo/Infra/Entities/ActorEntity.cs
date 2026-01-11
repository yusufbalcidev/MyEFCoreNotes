using System.Net.Mail;
using EFDemo.Infra.Entities.Base;

namespace EFDemo.Infra.Entities
{
    public class ActorEntity : PersonBaseEntity
    {
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
