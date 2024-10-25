using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(int id); 
        Task<IEnumerable<Course>> GetAllAsync();
        Task AddAsync(Course course); 
        Task UpdateAsync(Course course); 
        Task DeleteAsync(int id);
        Task<IEnumerable<Course>> SearchByNameAsync(string CourseName);
    }
}
