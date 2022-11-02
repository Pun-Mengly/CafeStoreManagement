
using CafeStoreManagement.Features;
using CafeStoreManagement.Features.ItemDetail.Response;

public interface IBusinessLogic
{
    #region Items
        public Task<List<ItemCommand>> PostItem(List<ItemCommand> postItems);
        public Task<List<ItemResponse>> GetItems();
        public Task<ItemCommand> PutItem(ItemCommand putItem);
        public Task<Guid> DeleteItem(Guid id,bool isDeleted);
    #endregion

    #region ItemDetail
        public Task<List<ItemDetailCommand>> PostItemDetail(List<ItemDetailCommand> postItemDetails);
        public Task<List<ItemDetailResponse>> GetItemDetail();
        public Task<Guid> DeleteItemDetail(Guid id, bool isDeleted);
    
    #endregion  
    public void InitailizationData();

}
