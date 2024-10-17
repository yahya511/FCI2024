namespace Infrastructure.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        ITownRepository Towns { get; }
        IProjectRepository Projects { get; }
        IEmployeeProjectRepository employeeProject { get; }
        Task<int> CommitAsync(); // لحفظ جميع التغييرات في جلسة واحدة
    }
}
