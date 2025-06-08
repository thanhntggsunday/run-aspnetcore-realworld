using AspnetRun.Shared;

namespace NetMvc.Cms.Common.ViewModel.Common
{
    public class ApiResult<T> : TransactionalInformation
    {
        public ApiResult()
        {
            ResultObj = default!; // Initialize ResultObj to its default value to satisfy the non-nullable requirement.
        }

        public ApiResult(T data)
        {
            ResultObj = data;
        }

        public T ResultObj { get; set; }
    }
}