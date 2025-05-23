namespace ProductManagement_APIDashboard.Models
{
        public class GetByIdResponse
        {
            public GetById? Response { get; set; }
            public ActionResponse ActionResponse { get; set; }

        }
        public class GetById
        {
            public int ProductId { get; set; }
            public string? ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            public int ProductNoOfStock { get; set; }
        }

    
}
