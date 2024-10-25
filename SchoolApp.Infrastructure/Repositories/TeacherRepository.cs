using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoryInterfaces;
using SchoolApp.Infrastructure.Persistence;

namespace SchoolApp.Infrastructure.Repositories
{
    public class TeacherRepository: ITeacherRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await GetByIdAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<IEnumerable<Teacher>> SearchByNameAsync(string firstName, string lastName)
        {
            return await _context.Teachers
               .Where(t => t.FirstName.Contains(firstName) || t.LastName.Contains(lastName))
               .ToListAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
