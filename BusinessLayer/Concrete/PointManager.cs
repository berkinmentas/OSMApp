using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PointManager : IPointService
    {
        private readonly IPointDal _PointDal;

        public PointManager(Context context)
        {
            _PointDal = (IPointDal?)(context ?? throw new ArgumentNullException(nameof(context)));

        }

        public PointManager(IPointDal pointDal)
        {
            _PointDal = pointDal ?? throw new ArgumentNullException(nameof(pointDal));
        }
      
        public List<Point> GetList()
        {
            return _PointDal.GetList();
        }

        public void TAdd(Point t)
        {
            _PointDal.Insert(t);
        }

        public void TDelete(Point t)
        {
            _PointDal.Delete(t);
        }

        public Point TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Point TGetByName(string PointName)
        {
           return  _PointDal.GetByName(PointName);
        }

        public Point TGetByNumber(string PointNumber)
        {
            return _PointDal.GetByNumber(PointNumber);
        }

        public void TUpdate(Point t)
        {
            _PointDal.Update(t);
        }

        public Point TGetByNumberAndName(string PointNumber, string PointName)
        {
            return _PointDal.GetByNumberAndName(PointNumber, PointName);
        }

        public Point TGetByXYAndName(double? Latitude, double? Longitude, string PointName)
        {
            return _PointDal.GetByXYAndName(Latitude, Longitude, PointName);
        }

        public Point TGetByXYAndNumber(string PointNumber, double? Longitude, double? Latitude)
        {
            return _PointDal.GetByXYAndNumber(PointNumber, Longitude, Latitude);
        }

        public Point TGetByXY(double? Latitude, double? Longitude)
        {
            return _PointDal.GetByXY(Latitude, Longitude);
        }

        public Point TGetByNumberAndNameAndXY(string PointNumber, string PointName, double? Latitude, double? Longitude)
        {
            return _PointDal.GetByNumberAndNameAndXY(PointNumber, PointName, Latitude, Longitude);
        }
    }
}
