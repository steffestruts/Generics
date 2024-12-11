using MainApp.Data;
using MainApp.Models;

namespace MainApp.Services;

public class ProductService(DataContext<Product> context)
{
    private readonly DataContext<Product> _context = context;

    public ResponseResult<Product> SaveProduct(Product product)
    {
        try
        {
            if (!_context.Items().Any(x => x.Title == product.Title))
            {
                product.Id = _context.Items().Any() ? _context.Items().Last().Id + 1 : 1;
                _context.Save(product);
                return new ResponseResult<Product>
                {
                    Success = true
                };
            }
            else
            {
                return new ResponseResult<Product>
                {
                    Success = false,
                    Message = "A product with the same name already exists"
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseResult<Product>
            {
                Success = false,
                Message = $"{ex.Message}"
            };
        }
    }
    public ResponseResult<IEnumerable<Product>> GetAllProducts()
    {
        try
        {
            return new ResponseResult<IEnumerable<Product>>
            {
                Success = true,
                Result = _context.Items()
            };
        }
        catch (Exception ex)
        {
            return new ResponseResult<IEnumerable<Product>>
            {
                Success = false,
                Message = $"{ex.Message}"
            };
        }
    }
}
