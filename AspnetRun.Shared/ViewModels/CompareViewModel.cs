using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class CompareViewModel : TransactionalInformation
    {
        public CompareDto Data { get; set; } = new CompareDto();       
    }
}
