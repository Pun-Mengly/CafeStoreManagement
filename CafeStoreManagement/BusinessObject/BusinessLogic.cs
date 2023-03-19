
using CafeStoreManagement.ConfigurationModels;
using CafeStoreManagement.Features;
using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Models;

public class BusinessLogic : IBusinessLogic
{
    //private readonly UserManager<ApplicationUser> _userManager;
    private readonly DataContext dataContext;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly string userId;
    private readonly IConfiguration _configuration;
    //private readonly IEmailService _emailService;



    public BusinessLogic(DataContext _dataContext, IHttpContextAccessor _httpContextAccessor
                         /*UserManager<ApplicationUser> userManager*/, IConfiguration configuration /*IEmailService emailService*/)
    {
        this.dataContext = _dataContext;
        this.httpContextAccessor = _httpContextAccessor;
        this.userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        //_userManager = userManager;
        _configuration = configuration;
        //_emailService = emailService;
    }
    public async Task<List<ItemCommand>> PostItem(List<ItemCommand> postItems)
    {
        try
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
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
                    IsDeleted = false,
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
            var results = await dataContext.ItemModels.Where(e => e.CreatedBy == userId).ToListAsync();
            var items = new List<ItemResponse>();
            int i = 1;
            foreach (var result in results)
            {
                var data = new ItemResponse()
                {
                    No = i++,
                    Id = result.Id,
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ItemCommand> PutItem(ItemCommand putItem)
    {
        try
        {
            var result = await dataContext.ItemModels.Where(e => e.Id == putItem.Id && e.CreatedBy == userId).FirstOrDefaultAsync();
            if (result is null)
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<Guid> DeleteItem(Guid id, bool isdeleted)
    {
        try
        {
            var result = await dataContext.ItemModels.Where(e => e.Id == id && e.CreatedBy==userId).FirstOrDefaultAsync();
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

    public async Task<List<ItemDetailCommand>> PostItemDetail(List<ItemDetailCommand> postItemDetails)
    {
        try
        {
            foreach (var itemDetail in postItemDetails)
            {
                var categories = await dataContext.CategoryModels.Where(e => e.CreatedBy == userId &&
                                                                e.Name == itemDetail.Category).FirstOrDefaultAsync();
                if (categories is null) throw new Exception("category is null");
                var items = await dataContext.ItemModels.Where(e => e.CreatedBy == userId &&
                                                                e.Name == itemDetail.ItemName).FirstOrDefaultAsync();
                if (items is null) throw new Exception("item is null");
                var sizes = await dataContext.SizeModels.Where(e => e.CreatedBy == userId &&
                                                                e.Name == itemDetail.Size).FirstOrDefaultAsync();
                if (sizes is null) throw new Exception("size is null");
                var data = new ItemDetailModel()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = userId,
                    Price = itemDetail.Price,
                    IsDeleted = false,
                    Description = itemDetail!.Decription,
                    CategortId = categories.Id,
                    ItemId = items.Id,
                    SizeId = sizes.Id
                };
                await dataContext.ItemDetailModels.AddAsync(data);
                await dataContext.SaveChangesAsync();
            }   
            return postItemDetails;
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void InitailizationData()
    {
        try
        {
            var groupId1 = Guid.NewGuid();
            var groupId2 = Guid.NewGuid();

            #region Size
            var sizeSmall = new SizeModel()
            {
                Id = Guid.NewGuid(),
                Code = "S",
                Name = "Small",
                Description = CoreString.description,
                IsDeleted = false,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
            };
            var sizeMeduim = new SizeModel()
            {
                Id = Guid.NewGuid(),
                Code = "M",
                Name = "Medium",
                Description = CoreString.description,
                IsDeleted = false,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
            };
            var sizeLarge = new SizeModel()
            {
                Id = Guid.NewGuid(),
                Code = "L",
                Name = "Large",
                Description = CoreString.description,
                IsDeleted = false,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
            };
            var sizes = new List<SizeModel> { sizeSmall, sizeMeduim, sizeLarge };
             dataContext.SizeModels.AddRange(sizes);
            #endregion

            #region Category
            var categories = new List<CategoryModel>
        {
            new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    MenuGroupId= groupId1,
                    Code = "SMT",
                    Name = "Smoothie",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "MIT",
                    MenuGroupId= groupId1,
                    Name = "Milk Tea",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    MenuGroupId= groupId1,
                    Code = "CAF",
                    Name = "Coffee",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    MenuGroupId= groupId2,
                    Code = "RIC",
                    Name = "Rice",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    MenuGroupId= groupId2,
                    Code = "SNK",
                    Name = "Snack",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                }
        };
            dataContext.CategoryModels.AddRange(categories);
            #endregion

            #region Tax
            var taxs = new List<TaxModel> {
            new TaxModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "PLT",
                    Name = "PLT",
                    Percentage = 10.00,
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new TaxModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "VAT",
                    Name = "VAT",
                    Percentage = 10.00,
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                }
        };
            dataContext.TaxModels.AddRange(taxs);
            #endregion

            #region Source
            var sources = new List<SourceModel>
        {
             new SourceModel()
                {
                    Id=Guid.NewGuid(),
                    Code="MBL",
                    Abv="MBL",
                    Name="Mobile App",
                    Description= CoreString.description,
                    IsDeleted=false,
                    CreatedBy= userId,
                    CreatedDate=DateTime.Now,
                },
                new SourceModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "FAT",
                    Abv = "FAT",
                    Name = "Food Aggregator",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new SourceModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "WAL",
                    Abv = "WAL",
                    Name = "Walk In",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                }
        };
             dataContext.SourceModels.AddRange(sources);
            #endregion

            #region Channel
            var channels = new List<ChannelModel>
        {
                new ChannelModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "DIN",
                    Abv = "DIN",
                    Name = "Dine In",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new ChannelModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "TAK",
                    Abv = "TAK",
                    Name = "Take Away",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                },
                new ChannelModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "DEL",
                    Abv = "DEL",
                    Name = "Delivery",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                }
        };
             dataContext.ChannelModels.AddRange(channels);
            #endregion

            #region MenuGroup
            var menuGroups = new List<MenuGroupModel>
        {
              new MenuGroupModel()
               {
                   Id = groupId1,
                   Code = "DRK",
                   Abv = "DRK",
                   Name = "Drink",
                   Description = CoreString.description,
                   IsDeleted = false,
                   CreatedBy =userId,
                   CreatedDate = DateTime.Now,
               },
               new MenuGroupModel()
               {
                   Id = groupId2,
                   Code = "FOD",
                   Abv = "FOD",
                   Name = "Food",
                   Description = CoreString.description,
                   IsDeleted = false,
                   CreatedBy = userId,
                   CreatedDate = DateTime.Now,
               }
        };
             dataContext.MenuGroups.AddRange(menuGroups);
            #endregion

        //    #region PaymentMethod
        //    var paymentMethod = new List<PaymentMethodModel>
        //{
        //      new PaymentMethodModel()
        //       {
        //           Id =Guid.NewGuid(),
        //           Code = "Cash",
        //           Name = "Cash",
        //           Description = CoreString.description,
        //           IsDeleted = false,
        //           CreatedBy =userId,
        //           CreatedDate = DateTime.Now,
        //       },
             
        //};
        //    dataContext.PaymentMethodModels.AddRange(paymentMethod);
        //    #endregion

        //    #region PromotionTypes
        //    var promotionTypes = new List<PromotionTypeModel>
        //{
        //      new PromotionTypeModel()
        //       {
        //           Id =Guid.NewGuid(),
        //           Code = "PMT-001",
        //           TypeName = "Discount",
        //           Description = CoreString.description,
        //           IsDeleted = false,
        //           CreatedBy =userId,
        //           CreatedDate = DateTime.Now,
        //       },
        //        new PromotionTypeModel()
        //       {
        //           Id =Guid.NewGuid(),
        //           Code = "PMT-002",
        //           TypeName = "Givaway",
        //           Description = CoreString.description,
        //           IsDeleted = false,
        //           CreatedBy =userId,
        //           CreatedDate = DateTime.Now,
        //       },
        //        new PromotionTypeModel()
        //       {
        //           Id =Guid.NewGuid(),
        //           Code = "PMT-003",
        //           TypeName = "PaymentMethod",
        //           Description = CoreString.description,
        //           IsDeleted = false,
        //           CreatedBy =userId,
        //           CreatedDate = DateTime.Now,
        //       },


        //};
        //    dataContext.PromotionTypeModels.AddRange(promotionTypes);


        //    #endregion

            #region Promotion


            #endregion

            dataContext.SaveChanges();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    
    }

    public async Task<List<ItemDetailResponse>> GetItemDetail()
    {
        var itemDetailResponses = new List<ItemDetailResponse>();
        var itemDetails =await dataContext.ItemDetailModels.Where(e=>e.IsDeleted==false &&e.CreatedBy==userId).ToListAsync();
        var items = await dataContext.ItemModels.ToListAsync();
        var sizes = await dataContext.SizeModels.ToListAsync();
        var categories = await dataContext.CategoryModels.ToListAsync();
        int i = 1;
        foreach (var itemDetail in itemDetails)
        {
            var item = items.Where(e => e.Id == itemDetail.ItemId && e.CreatedBy==itemDetail.CreatedBy).FirstOrDefault();
            var size = sizes.Where(e => e.Id == itemDetail.SizeId && e.CreatedBy == itemDetail.CreatedBy).FirstOrDefault();
            var category = categories.Where(e => e.Id == itemDetail.CategortId && e.CreatedBy == itemDetail.CreatedBy).FirstOrDefault();
            var itemDetailResponse = new ItemDetailResponse()
            {
                No=i++,
                Id=itemDetail.Id,
                itemCode= item!.Code,
                ItemName=item!.Name,
                Photo=item!.Photo,
                Price=itemDetail.Price,
                Decription=itemDetail.Description,
                CreatedDate=itemDetail.CreatedDate,
                Category=category!.Name,
                Size=size!.Name,
                IsDeleted=itemDetail.IsDeleted,
            };
            itemDetailResponses.Add(itemDetailResponse);
        }
        return itemDetailResponses;
    }

    public async Task<Guid> DeleteItemDetail(Guid id, bool isDeleted)
    {
        try
        {
            var data = await dataContext.ItemDetailModels.Where(e => e.Id == id).FirstOrDefaultAsync();
            data!.IsDeleted = isDeleted;
            dataContext.ItemDetailModels.Update(data);
            await dataContext.SaveChangesAsync();
            return id;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
            
    }

    public async Task<List<SizeModel>> GetAllSizes()
    {
        try
        {
            var result =await  dataContext.SizeModels.Where(e => e.IsDeleted == false && e.CreatedBy == userId).ToListAsync();
            return result;
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        try
        {
            var result = await dataContext.CategoryModels.Where(e => e.IsDeleted == false && e.CreatedBy == userId).ToListAsync();
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<ItemModel>> GetAllItems()
    {
        try
        {
            var result = await dataContext.ItemModels.Where(e => e.IsDeleted == false && e.CreatedBy == userId).ToListAsync();
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ItemDetailCommand> UpdateItemDetail(ItemDetailCommand itemDetail)
    {
        try
        {
            var items = await dataContext.ItemModels.ToListAsync();
            var sizes = await dataContext.SizeModels.ToListAsync();
            var categories = await dataContext.CategoryModels.ToListAsync();

            var item = items.Where(e => e.Name == itemDetail.ItemName && e.CreatedBy == userId).FirstOrDefault();
            var size = sizes.Where(e => e.Name == itemDetail.Size && e.CreatedBy == userId).FirstOrDefault();
            var category = categories.Where(e => e.Name == itemDetail.Category && e.CreatedBy == userId).FirstOrDefault();

            var result =await dataContext.ItemDetailModels.Where(e => e.Id == itemDetail.Id && e.CreatedBy==userId).FirstOrDefaultAsync();
            result!.ItemId = item == null ? result!.ItemId : item!.Id;
            result!.CategortId = category == null ? result!.CategortId : category!.Id;
            result!.SizeId = size == null ? result!.SizeId : size!.Id;
            result!.Price = itemDetail.Price == 0 ? result!.Price : itemDetail.Price;
            result!.Description = itemDetail.Decription == null ? result!.Description : itemDetail.Decription!;
            dataContext.ItemDetailModels.Update(result);
            await dataContext.SaveChangesAsync();
            return itemDetail;
            
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<OutletModel> CreateOutlet(OutletModel model)
    {
        try
        {
            OutletModel outlet = new OutletModel()
            {
                Id = Guid.NewGuid(),
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                Website = model.Website,
                PhoneNumber = model.PhoneNumber,
                Location = model.Location,
                IsDeleted = model.IsDeleted,
            };
            await dataContext.OutletModels.AddAsync(outlet);
            await dataContext.SaveChangesAsync();
            return model;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<OutletModel>> GetAllOutlets()
    {
        return await dataContext.OutletModels.Where(e=>e.CreatedBy==userId).ToListAsync();
    }

    public async Task<ItemModel> postItemV2(ItemModel model)
    {
        var guidItemId = Guid.NewGuid();
        var objItem = new ItemModel()
        {
            Id = guidItemId,
            Code = model.Code,
            CreatedBy = userId,
            CreatedDate = DateTime.Now,
            Name = model.Name,
            Description = model.Description,
            IsDeleted = false,
            Photo = model.Photo,
        };
        await dataContext.ItemModels.AddAsync(objItem);
        await dataContext.SaveChangesAsync();
        model.ItemDetails.ToList().ForEach( e =>
        {
            e.Id = Guid.NewGuid();
            e.ItemId= guidItemId;
            e.IsDeleted = false;
            e.SizeId = e.SizeId;
            e.OutletId = e.OutletId;
            e.Price = e.Price;
            e.CreatedDate = DateTime.Now;
            e.CreatedBy = userId;
            e.Description = e.Description;
            e.CategortId=e.CategortId;
            dataContext.ItemDetailModels.Add(e);
            dataContext.SaveChanges();
        });
        return model;
    }

    //public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
    //{
    //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
    //    if (!string.IsNullOrEmpty(token))
    //    {
    //        //await SendEmailConfirmationEmail(user, token);
    //    }
    //}

    //public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
    //{
    //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //    if (!string.IsNullOrEmpty(token))
    //    {
    //        await SendForgotPasswordEmail(user, token);
    //    }
    //}
    //private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
    //{
    //    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
    //    string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

    //    UserEmailOptions options = new UserEmailOptions
    //    {
    //        ToEmails = new List<string>() { user.Email },
    //        PlaceHolders = new List<KeyValuePair<string, string>>()
    //            {
    //                new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
    //                new KeyValuePair<string, string>("{{Link}}",
    //                    string.Format(appDomain + confirmationLink, user.Id, token))
    //            }
    //    };

    //    await _emailService.SendEmailForForgotPassword(options);
    //}
}