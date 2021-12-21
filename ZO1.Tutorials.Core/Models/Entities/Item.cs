using ZO1.Tutorials.Core.Models.EntitiesBase;

namespace ZO1.Tutorials.Core.Models.Entities
{
    public class Item : BaseEntities
    {
        public string ItemName { get; set; }
        public string BorrowerName { get; set; }
        public string Lender { get; set; }
    }
}