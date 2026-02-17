using Domain.Entities;
using Application.Services.Activities;
namespace Application.Services.Activities
{
    public interface IActivityService
    {
        Activity GetActivityById(int id);
        
        List<Activity> GetAllActivities();
    }
}