using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class OrderItemViewModel : TransactionalInformation
    {

       public OrderItemDto Data { get; set; } = new OrderItemDto();
        public OrderItemViewModel()
        {
        }
        public OrderItemViewModel(OrderItemDto data)
        {
            Data = data;
        }
        public int Id
        {
            get => Data.Id;
            set => Data.Id = value;
        }
       
    }
}
