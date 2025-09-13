using ProductService.Return_Data;

namespace ProductService.Common_Repository
{
    public interface CommonProductInterface<Tentity, TDTO>
    {
        Task<CommonReturn> AddProduct(TDTO dto);
        Task<CommonReturn> GetAllProduct();
    }
}
