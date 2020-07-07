namespace SCM.BusinessRuleEngine.Web.DataAccess
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Unit of Work.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// SaveAsync method signature.
        /// </summary>
        /// <returns> Task. </returns>
        Task SaveAsync();

        /// <summary>
        ///  BeginTransactionAsync method signature.
        /// </summary>
        void BeginTransactionAsync();

        /// <summary>
        /// CommitTransaction method signature .
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// RollbackTransaction method signature.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Dispose method signature.
        /// </summary>
        void Dispose();

        GenericRepository<Models.PackingSlip> PackingSlipRepository { get; }
    }
}
