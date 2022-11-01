
using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using Microsoft.EntityFrameworkCore;

public class BusinessLogic : IBusinessLogic
{
    private readonly DataContext dataContext;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly string userId;

    public BusinessLogic(DataContext _dataContext, IHttpContextAccessor _httpContextAccessor)
    {
        this.dataContext = _dataContext;
        this.httpContextAccessor = _httpContextAccessor;
        this.userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    }
    

    public List<ItemDetailCommand> PostItemDetail(List<ItemDetailCommand> postItemDetails)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ItemCommand>> PostItem(List<ItemCommand> postItems)
    {
        try
        {
            var userId= httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            foreach (var postItem in postItems)
            {
                var item = new ItemModel()
                {
                    Id = Guid.NewGuid(),
                    Code = postItem.Code,
                    Name = postItem.Name,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userId,
                    Description = postItem.Description,
                    Photo = postItem.Photo,
                    IsDeleted=false
                    
                };
                await dataContext.ItemModels.AddAsync(item);
                await dataContext.SaveChangesAsync();
            }
            return postItems;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<ItemResponse>> GetItems()
    {
        try
        {
            var results = await dataContext.ItemModels.Where(e=>e.CreatedBy==userId).ToListAsync();
            var items = new List<ItemResponse>();
            foreach (var result in results)
            {
                var data = new ItemResponse()
                {
                    Id=result.Id,
                    Code = result.Code,
                    Name = result.Name,
                    Photo = result.Photo,
                    Description = result.Description,
                    CreatedDate = result.CreatedDate,
                    IsDeleted = result.IsDeleted,
                };
                items.Add(data);
            }
            return items;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }       
    }

    public async Task<ItemCommand> PutItem(ItemCommand putItem)
    {
        try
        {
            var result = await dataContext.ItemModels.Where(e =>e.Id == putItem.Id).FirstOrDefaultAsync();
            if(result is null)
            {
                throw new Exception("The Data is null");
            }
            else
            {
                result!.Name = putItem.Name;
                result!.Photo = putItem.Photo;
                result!.Code = result.Code;
                result!.Description = putItem.Description;
                result!.IsDeleted = putItem.IsDeleted;
                dataContext.ItemModels.Update(result);
                dataContext.SaveChanges();
            }
            return putItem;
            
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<Guid> DeleteItem(Guid id,bool isdeleted)
    {
        try
        {
            var result = await dataContext.ItemModels.Where(e=>e.Id ==id).FirstOrDefaultAsync();
            if (result is null)
            {
                throw new Exception("The Data is null");
            }
            else
            {
                result!.IsDeleted = isdeleted;
                dataContext.ItemModels.Update(result);
                dataContext.SaveChanges();
            }
            return id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
