using Microsoft.EntityFrameworkCore;
using School_Bus_Api.Data;
using School_Bus_Api.Dtos.BusDtos;
using School_Bus_Api.Model;
using System.Collections.Generic;

namespace School_Bus_Api.Repos.Bus_Repo
{
    public class BusRepo : IBusRepo
    {
        private readonly AppDbContext _context;
        public BusRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<BusShowDataDto> GetAllBuses()
        {
            List<BusShowDataDto> bus = _context.buses.Select(b => new BusShowDataDto
            {
                Id = b.Id,
                BusCode = b.BusCode,
                Place = b.Place,
            }).ToList();

            return bus;
        }

        public BusDto GetBusById(int id)
        {
            var bus = _context.buses.Find(id);
            if (bus == null)
            {
                return null;
            }
            BusDto b = new BusDto
            {
                BusCode = bus.BusCode,
                Place = bus.Place
            };
            return b;
        }

        public void AddBus(BusDto busDto)
        {
            var bus = new BusModel
            {
                BusCode = busDto.BusCode,
                Place = busDto.Place
            };
            _context.buses.Add(bus);
            _context.SaveChanges();
        }

        public BusDto UpdateBus(int id, BusDto busDto)
        {
            var existingBus = _context.buses.Find(id);
            if (existingBus == null) 
                return null;


            existingBus.BusCode = busDto.BusCode;
            existingBus.Place = busDto.Place;
            _context.buses.Update(existingBus);
            _context.SaveChanges();
            return busDto;
        }

        public bool DeleteBus(int id)
        {
            var bus = _context.buses.Find(id);
            if (bus == null)
                return false;

            _context.buses.Remove(bus);
            _context.SaveChanges();
            return true;
        }
    }
}
