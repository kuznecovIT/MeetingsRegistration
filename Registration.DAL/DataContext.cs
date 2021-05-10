using System;
using System.Threading.Tasks;
using Meetings.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetings.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<MeetingEntity> Meetings { get; set; }
        
        public DbSet<VisitorEntity> Visitors { get; set; }
        
        public DbSet<ActivityEntity> Activities { get; set; }

        public DbSet<MeetingVisitorEntity> MeetingVisitors { get; set; }
        
        
        public DataContext(DbContextOptions<DataContext> options, IServiceProvider serviceProvider) : base(options)
        {

        }

        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}