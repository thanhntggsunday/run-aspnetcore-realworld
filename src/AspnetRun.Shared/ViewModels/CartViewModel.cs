using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class CartViewModel : TransactionalInformation
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public decimal GrandTotal
        {
            get
            {
                decimal grandTotal = 0;
                foreach (var item in Items)
                {
                    grandTotal += item.Data.TotalPrice;
                }

                return grandTotal;
            }
        }
    }
}
