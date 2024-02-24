using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
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
        private readonly Context _context;
        public EfPointDal(Context context = null)
        {
            _context = context ?? new Context();
        }

        public Point GetByXY(double? Latitude, double? Longitude)
        {
            return _context.Points.FirstOrDefault(p => p.Latitude == Latitude && p.Longitude == Longitude);
        }

        public Point GetByXYAndName( double? Latitude, double? Longitude, string PointName)
        {
            return _context.Points.FirstOrDefault(p => p.PointName == PointName && p.Latitude == Latitude && p.Longitude == Longitude);
        }

        public Point GetByXYAndNumber(string PointNumber, double? Latitude, double? Longitude)
        {
            return _context.Points.FirstOrDefault(p => p.PointNumber == PointNumber && p.Latitude == Latitude && p.Longitude == Longitude);
        }

        public Point GetByNumberAndNameAndXY(string PointNumber, string PointName, double? Latitude, double? Longitude)
        {
            return _context.Points.FirstOrDefault(p => p.PointName == PointName && p.PointNumber == PointNumber && p.Latitude == Latitude && p.Longitude == Longitude);
        }
        public Point GetByName(string PointName)
        {
            return _context.Points.FirstOrDefault(p => p.PointName == PointName);
        }

        public Point GetByNumber(string PointNumber)
        {
            return _context.Points.FirstOrDefault(p => p.PointNumber == PointNumber);
        }


        public Point GetByNumberAndName(string PointName, string PointNumber)
        {
            return _context.Points.FirstOrDefault(p => p.PointName == PointName && p.PointNumber == PointNumber);
        }
    }
}
