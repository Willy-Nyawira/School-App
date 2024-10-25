using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoryInterfaces;
using SchoolApp.Infrastructure.Persistence;

namespace SchoolApp.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SchoolDbContext _context;

        public EnrollmentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Enrollment = await GetByIdAsync(id);
            if (Enrollment != null)
            {
                _context.Enrollments.Remove(Enrollment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await _context.Enrollments.FindAsync(id);
        }

        public async Task UpdateAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
