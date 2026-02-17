using Domain.Entities;

namespace Application.Interfaces
{
    public interface IActivityService
    {
        public List<Activity> GetAllActivities();
        public Activity GetActivityById(int id);
    }
}