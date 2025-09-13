using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductService.DatabaseContext;
using ProductService.Return_Data;

namespace ProductService.Common_Repository
{
    public class CommonProductRepository<Tentity, TDTO> : CommonProductInterface<Tentity, TDTO>
        where Tentity : class
        where TDTO : class
    {

        private readonly MyDbContext context;
        private readonly IMapper mapper;
        private readonly DbSet<Tentity> entities;

        public CommonProductRepository(MyDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
            entities = context.Set<Tentity>();
        }
        public async Task<CommonReturn> AddProduct(TDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return new CommonReturn
                    {
                        errormessage = "Data Can not be empty",
                        result = false
                    };
                }
                var data = mapper.Map<Tentity>(dto);
                await entities.AddAsync(data);
                await context.SaveChangesAsync();
                return new CommonReturn
                {

                    Data = data,
                    result = true
                };
            }
            catch (Exception ex)
            {

                return new CommonReturn
                {
                    errormessage = ex.Message,
                    result = false
                };
            }
        }
        public async Task<CommonReturn> GetAllProduct()
        {
            try
            {
                var data = await entities.ToListAsync();
                var returndata = mapper.Map<List<TDTO>>(data);

                return new CommonReturn
                {
                    result = true,
                    Data = returndata
                };
            }
            catch (Exception ex)
            {
                return new CommonReturn
                {
                    errormessage = ex.Message,
                    result = false
                };
            }
        }

    }
}
