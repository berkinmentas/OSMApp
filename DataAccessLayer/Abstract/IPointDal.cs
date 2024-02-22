using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPointDal: IGenericDal<Point>
    {
        Point GetByName(string PointName);
        Point GetByNumber(string PointNumber);

        Point GetByXY(double? Latitude, double? Longitude);

        Point GetByNumberAndName(string PointNumber, string PointName);

        Point GetByXYAndName(double? Latitude, double? Longitude, string PointName);

        Point GetByXYAndNumber(string PointNumber, double? Longitude, double? Latitude);
        Point GetByNumberAndNameAndXY(string PointNumber, string PointName, double? Latitude, double? Longitude);


    }
}
