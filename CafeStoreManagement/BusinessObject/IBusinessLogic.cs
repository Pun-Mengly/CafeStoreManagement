
using CafeStoreManagement.Features;
using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Models;
using System.Drawing;

public interface IBusinessLogic
{
    #region Items
        public Task<List<ItemCommand>> PostItem(List<ItemCommand> postItems);
        public Task<List<ItemResponse>> GetItems();
        public Task<ItemCommand> PutItem(ItemCommand putItem);
        public Task<Guid> DeleteItem(Guid id,bool isDeleted);

        public Task<List<SizeModel>> GetAllSizes();
        public Task<List<CategoryModel>> GetAllCategories();
        public Task<List<ItemModel>> GetAllItems();
    #endregion

    #region ItemDetail
        public Task<List<ItemDetailCommand>> PostItemDetail(List<ItemDetailCommand> postItemDetails);
        public Task<List<ItemDetailResponse>> GetItemDetail();
        public Task<ItemDetailCommand> UpdateItemDetail(ItemDetailCommand itemDetailCommand);
        public Task<Guid> DeleteItemDetail(Guid id, bool isDeleted);
    
    #endregion  Initailization
    public void InitailizationData();

    #region User Management
    //Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);

    //Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
    #endregion


}
