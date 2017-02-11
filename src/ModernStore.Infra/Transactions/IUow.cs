namespace ModernStore.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
