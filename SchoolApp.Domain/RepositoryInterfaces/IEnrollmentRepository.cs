using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.RepositoryInterfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment>GetByIdAsync(int id);
        Task<IEnumerable<Enrollment>> GetAll();
        Task AddAsync(Enrollment enrollment);
        Task UpdateAsync(Enrollment enrollment);

        Task DeleteAsync(int id);
       
    }
}
