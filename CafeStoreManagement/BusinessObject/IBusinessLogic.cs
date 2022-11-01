
using CafeStoreManagement.Features;

public interface IBusinessLogic
    {
        #region Items
        public Task<List<ItemCommand>> PostItem(List<ItemCommand> postItems);
        public Task<List<ItemResponse>> GetItems();
        public Task<ItemCommand> PutItem(ItemCommand putItem);
        public Task<Guid> DeleteItem(Guid id,bool isDeleted);
        #endregion
        public List<ItemDetailCommand> PostItemDetail(List<ItemDetailCommand> postItemDetails);
    }
