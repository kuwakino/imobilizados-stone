using ImobilizadosStone.Domain.Entities;
using ImobilizadosStone.Domain.Repository;
using ImobilizadosStone.Resources;

namespace ImobilizadosStone.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(Settings settings) : base(settings, "Item")
        {
        }
    }
}
