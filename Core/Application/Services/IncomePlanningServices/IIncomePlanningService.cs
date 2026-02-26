using Domain.Entities;
using Application.DTO.IncomePlanning;
namespace Application.Services.IncomePlanningServices{
    public interface IIncomePlanningService{
        Task <List<IncomePlanning>> GetIncomePlanningsAsync();
        Task AddIncomePlanning(CreateIncomePlanningDTO dto);
    }
}