using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPointDal : GenericRepository<Point>, IPointDal
    {
        IPointDal _PointDal;
        public Point GetByName(string PointName)
        {
            return _PointDal.GetByName(PointName);
        }

        public Point GetByNumber(string PointNumber)
        {
            throw new NotImplementedException();
        }

        public Point GetByNumberAndName(string PointNumber, string PointName)
        {
            throw new NotImplementedException();
        }

        public Point GetByNumberAndNameAndXY(string PointNumber, string PointName, double? Latitude, double? Longitude)
        {
            throw new NotImplementedException();
        }

        public Point GetByXY(double? Latitude, double? Longitude)
        {
            throw new NotImplementedException();
        }

        public Point GetByXYAndName(double? Latitude, double? Longitude, string PointName)
        {
            throw new NotImplementedException();
        }

        public Point GetByXYAndNumber(string PointNumber, double? Longitude, double? Latitude)
        {
            throw new NotImplementedException();
        }
    }
}
