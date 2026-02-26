using Application.DTO.IncomePlanning;
using Domain.Entities;
using Application.Services.IncomePlanningServices;
using Application.Interfaces;

namespace Application.Services.IncomePlanningServices{
    public class IncomePlanningService : IIncomePlanningService{
        private readonly IIncomePlanning _incomePlanning;
        public IncomePlanningService(IIncomePlanning incomePlanning){
            _incomePlanning = incomePlanning;
        }
        public async Task <List<IncomePlanning>> GetIncomePlanningsAsync(){
            return await _incomePlanning.GetIncomePlanningsAsync();
           
        }
        public async Task AddIncomePlanning(CreateIncomePlanningDTO dto){
            await _incomePlanning.AddIncomePlanning(dto);
        }
    }
}