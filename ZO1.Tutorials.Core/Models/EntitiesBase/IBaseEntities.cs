using ZO1.Tutorials.Core.Models.Enums;

namespace ZO1.Tutorials.Core.Models.EntitiesBase
{
    public interface IBaseEntities
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}