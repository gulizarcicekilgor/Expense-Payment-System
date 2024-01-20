namespace WebApi.Models
{
    public class EftModel
    {
        public class EftTransactionRequest
        {
            public int AccountId { get; set; }
            public decimal Amount { get; set; }
            public string Description { get; set; }
            public string ReceiverAccount { get; set; }
            public string ReceiverIban { get; set; }
            public string ReceiverName { get; set; }
        }

        public class EftTransactionResponse
        {
            public int AccountId { get; set; }
            public string ReferenceNumber { get; set; }
            public DateTime TransactionDate { get; set; }
            public decimal Amount { get; set; }
            public string Description { get; set; }

            public string ReceiverAccount { get; set; }
            public string ReceiverIban { get; set; }
            public string ReceiverName { get; set; }
        }

    }
}