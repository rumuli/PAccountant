using Application.Interfaces;
using Infrastructure.Data;
using Application.Services.Activities;      
using Domain.Entities;
using Infrastructure.DependencyInjection;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : IActivity
    {
        private readonly ApplicationDbContext _dbContext;
        public ActivityRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public List<Activity> GetAllActivities()
        {
            List<Activity> _activities = _dbContext.Activities.ToList();

            return _activities;
        }

        public Activity GetActivityById(int id)
        {
            return _dbContext.Activities.FirstOrDefault(a => a.Id == id);
        }
   
    }
}