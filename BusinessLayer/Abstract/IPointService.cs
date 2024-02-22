using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPointService : IGenericService<Point>
    {
        Point TGetByName(string PointName);
        Point TGetByNumber(string PointNumber);
        Point TGetByXY(double? Latitude, double? Longitude);
        Point TGetByNumberAndName(string PointNumber, string PointName);

        Point TGetByXYAndName(double? Latitude, double? Longitude, string PointName);

        Point TGetByXYAndNumber(string PointNumber, double? Longitude, double? Latitude);
        Point TGetByNumberAndNameAndXY(string PointNumber, string PointName, double? Latitude, double? Longitude);
    }
}
