using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Repositories
{
    public class ShipmentRepository : IShipmentRepository 
    { 

        private readonly TrollMarketContext _dbContext;
        public ShipmentRepository(TrollMarketContext dbContext)
        {
            _dbContext = dbContext;
        }   
        public void Insert(Shipper shipper)
        {
            _dbContext.Shippers.Add(shipper);
            _dbContext.SaveChanges();
        }
        public void Update(Shipper shipper)
        {
            _dbContext.Shippers.Update(shipper);
            _dbContext.SaveChanges();
        }
        public List<Shipper> GetAllShippers()
        {
            return _dbContext.Shippers
                .ToList();
        }  
        
        public List<Shipper> GetAllActiveShippers()
        {
            return _dbContext.Shippers
                .Where(s => s.Service == true)
                .ToList();
        }
        public Shipper GetById(int id)
        {
            var shipper = _dbContext.Shippers.FirstOrDefault(x => x.Id == id);
            return shipper;
        }
        public int CountShipperOnOrder(int shipperId)
        {
            return _dbContext.Orders.
                Count(s => s.ShipperId == shipperId);
        }
        public void Delete(Shipper shipper)
        {
            _dbContext.Shippers.Remove(shipper);
            _dbContext.SaveChanges();
        }
    }
}
