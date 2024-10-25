using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.RepositoryInterfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher?> GetByIdAsync(int id);  
        Task<IEnumerable<Teacher>> GetAllAsync();  
        Task AddAsync(Teacher teacher);  
        Task UpdateAsync(Teacher teacher);  
        Task DeleteAsync(int id);
        Task<IEnumerable<Teacher>> SearchByNameAsync(string firstName, string lastName);
    }
}
