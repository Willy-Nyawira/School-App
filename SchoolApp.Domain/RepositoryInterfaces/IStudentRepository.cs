using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(int id); 
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student student);
        Task UpdateAsync(Student student); 
        Task DeleteAsync(int id);
        Task<IEnumerable<Student>> SearchByNameAsync(string firstName, string lastName);
    
    }
}
