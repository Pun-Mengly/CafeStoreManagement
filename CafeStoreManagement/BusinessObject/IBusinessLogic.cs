
using CafeStoreManagement.Features;
using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Models;
using CafeStoreWeb.Data;
using System.Drawing;

//Strategy Pattern
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

    #region Outlet
    public Task<OutletModel> CreateOutlet(OutletModel model);
    public Task<List<OutletModel>> GetAllOutlets();
    #endregion

    public void InitailizationData();
    public void GenerateReceiptReport();
    public Task<double> GetItemPricing(Guid itemId, Guid sizeId, Guid OutletId,int qty);
    public Task<IEnumerable<SizeModel>> GetItemSize(Guid itemId);
    public Task<IEnumerable<OutletModel>> GetItemOutlet(Guid outletId);

    #region User Management
    //Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);

    //Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
    #endregion

    public Task<ItemModel> postItemV2(ItemModel model);


    public Task PostOrderModel(List<ReceiptModel> item);
    public Task<IEnumerable<ReceiptModel>> GetReceipts(Guid outletId,DateTime startDate,DateTime endDate,Guid receiptId);


}
