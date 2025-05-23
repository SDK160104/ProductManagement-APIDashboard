using APIDashBoard.Domain;

namespace ProductManagement_APIDashboard.Models
{
    public class GetAllDataResponse
    {
        public ActionResponse ActionResponse { get; set; }
        public GetAllData<List<ProductModel>> Response { get; set; }
    }

    public class GetAllData<T>
    {
        public T Data { get; set; }
    }

}
