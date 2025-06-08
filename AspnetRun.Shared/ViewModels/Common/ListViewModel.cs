using AspnetRun.Shared;
using System.Collections.Generic;

namespace NetMvc.Cms.Common.ViewModel.Common
{
    public class ListViewModel<T>
    {
        public ListViewModel()
        {
            Transactional = new TransactionalInformation();
            Data = new List<T>(); // Initialize 'Data' to avoid CS8618 error  
        }

        public TransactionalInformation Transactional { get; set; }
        public IList<T> Data { get; set; }
    }
}