using Domain.Entities;
using Application.Services.Activities;
using Application.Interfaces;

namespace Application.Services.Activities
{
    public class ActivityService : IActivityService
    {
        private readonly IActivity _activity;
        public ActivityService(IActivity activity)
        {
            _activity = activity;
        }
        public List<Activity> GetAllActivities()
        {
            List<Activity> _activities = _activity.GetAllActivities();
            
            return _activities;
        }

        public Activity GetActivityById(int id)
        {
            return _activity.GetActivityById(id);
        }

        
    }
}

public interface IActivity
{
    List<Activity> GetAllActivities();
    Activity GetActivityById(int id);
}