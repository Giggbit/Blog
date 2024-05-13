using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class MembershipRepository : IMembership
    {
        private readonly ApplicationContext _context;

        public MembershipRepository(ApplicationContext applicationContext) { 
            _context = applicationContext;
        }

        public async Task AddMembershipAsync(Membership membership) {
            _context.memberships.Add(membership);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMembershipAsync(Membership membership) {
            _context.memberships.Remove(membership);
            await _context.SaveChangesAsync();
        }

        public async Task DisableMembershipCodeAsync(string code) {
            var currentMembership = await _context.memberships.FirstOrDefaultAsync(e => e.Code.Equals(code));
            if(currentMembership != null) { 
                currentMembership.IsEnable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EnableCodeMembershipByCodeAsync(string code) {
            var currentMembership = await _context.memberships.FirstOrDefaultAsync(e => e.Code.Equals(code));
            if(currentMembership != null) { 
                return currentMembership.IsEnable;
            }
            return false;
        }

        public async Task<bool> ExistsMembershipByCodeAsync(string code) {
            return await _context.memberships.AnyAsync(e => e.Code.Equals(code));
        }

        public async Task<IEnumerable<Membership>> GetAllMembershipAsync() {
            return await _context.memberships.OrderByDescending(e => e.Id).ToListAsync();
        }

        public async Task<Membership> GetMembershipAsync(int id) {
            return await _context.memberships.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
