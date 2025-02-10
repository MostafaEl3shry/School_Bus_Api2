using School_Bus_Api.Dtos.BusDtos;
using School_Bus_Api.Model;

namespace School_Bus_Api.Repos.Bus_Repo
{
    public interface IBusRepo
    {
        List<BusShowDataDto> GetAllBuses();
        BusDto GetBusById(int id);
        void AddBus(BusDto busDto);
        BusDto UpdateBus(int id, BusDto busDto);
        bool DeleteBus(int id);
    }
}
