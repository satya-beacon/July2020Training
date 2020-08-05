namespace BlogPostDemo.BusinessLogic
{
    public interface ICustomerDomain
    {
        void TransferAccountBalance(int fromAccount, int toAccount, decimal amount);
    }
}
