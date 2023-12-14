using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface IShipmentRepository
    {
        public void Insert(Shipper shipper);
        public List<Shipper> GetAllShippers();
        public Shipper GetById(int id);
        public void Update(Shipper shipper);
        public List<Shipper> GetAllActiveShippers();
        public int CountShipperOnOrder(int shipperId);
        public void Delete(Shipper shipper);
    }
}
