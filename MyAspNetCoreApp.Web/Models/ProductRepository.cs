using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products;

        // Read
        public List<Product> GetAll() => _products;

        // Create
        public void Add(Product newProduct) => _products.Add(newProduct);

        // Delete
        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id}) ye sahip ürün bulunmamaktadır");
            }

            _products.Remove(hasProduct);
        }

        // Update
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id}) ye sahip ürün bulunmamaktadır");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[index] = hasProduct;
        }
    }
}
