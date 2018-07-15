using Business_Layer.Interfaces;
using Data_Access_Layer;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business_Layer.Services
{
    public class AirportService : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AirportService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }
        #region General
        public T GetById<T>(int id) where T : class
        {
            return _unitOfWork.GetRepository<T>().Get(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _unitOfWork.GetRepository<T>().GetAll();
        }

        public void Post<T>(T item) where T : class
        {
            _unitOfWork.GetRepository<T>().Create(item);
        }

        public void Update<T>(int id, T item) where T : class
        {
            _unitOfWork.GetRepository<T>().Update(id, item);
        }

        public void Delete<T>(int number) where T : class
        {
            _unitOfWork.GetRepository<T>().Delete(number);
        }
        #endregion


        public IEnumerable<Flight> GetFlightByRoute(string departureFrom, string destination)
        {
            return GetAll<Flight>().Where(f =>
            (f.DepartureFrom == departureFrom && f.Destination == destination));
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
        
}

