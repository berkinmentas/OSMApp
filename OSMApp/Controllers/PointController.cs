using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OSMApp.Models;
using System.Diagnostics;

namespace OSMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : Controller
    {
        PointManager pointManager = new PointManager(new EfPointDal());

        [HttpPost]
        public Response AddPoint([FromBody] Point point)
        {
            try
            {
                bool nameExists = !string.IsNullOrEmpty(point.PointName) && pointManager.TGetByName(point.PointName) != null;
                bool numberExists = point.PointName != null && pointManager.TGetByNumber(point.PointNumber) != null;
                bool coordinatesExists = point.Longitude != null && point.Latitude != null && pointManager.TGetByXY(point.Latitude, point.Longitude) != null;
                if (nameExists || numberExists || coordinatesExists)
                {
                    return new Response { Data = null, Message = "The provided point coordinates, name or number already exists", Success = false };
                }
                else
                {
                    var createPoint = new Point
                    {
                        PointName = point.PointName,
                        PointNumber = point.PointNumber,
                        Latitude = point.Latitude,
                        Longitude = point.Longitude,
                    };
                    pointManager.TAdd(createPoint);
                    return new Response { Data = createPoint, Message = "Point added successfully", Success = true };
                }
                
            }
            catch (Exception ex)
            {
                return new Response { Data = null, Message = ex.Message, Success = false };


            }
        }
       /* [HttpGet]
        public Response GetPoints()
        {
            var points = pointManager.GetList();
            return new Response { Data = points, Message = "Get points list successful.", Success = true };
        }*/
        [HttpGet]
        public Response QueryPoints([FromQuery] string? PointName, [FromQuery] string? PointNumber, [FromQuery] double? Latitude, [FromQuery] double? Longitude)
        {
            if(string.IsNullOrEmpty(PointName) && string.IsNullOrEmpty(PointNumber) && !Latitude.HasValue && !Longitude.HasValue)
            {
                var points = pointManager.GetList();
                return new Response { Data = points, Message = "Get points list successful.", Success = true };
            }else if (!string.IsNullOrEmpty(PointName) && string.IsNullOrEmpty(PointNumber) && !Latitude.HasValue && !Longitude.HasValue)
            {
                var  pointGetByName = pointManager.TGetByName(PointName);
                if(pointGetByName != null)
                {
                    return new Response { Data = pointGetByName, Message = "Name found", Success = true };
                }
                return new Response { Data= null, Message ="Name didn'n find.", Success = false };
            }
            else if (string.IsNullOrEmpty(PointName) && !string.IsNullOrEmpty(PointNumber) && !Latitude.HasValue && !Longitude.HasValue)
            {
                var pointGetByNumber = pointManager.TGetByNumber(PointNumber);
                if (pointGetByNumber != null)
                {
                    return new Response { Data = pointGetByNumber, Message = "Number found", Success = true };
                }
                return new Response { Data = null, Message = "Number didn't find.", Success = false };
            }
            else if (string.IsNullOrEmpty(PointName) && string.IsNullOrEmpty(PointNumber) && Latitude.HasValue && Longitude.HasValue)
            {
                var pointGetByLatitude = pointManager.TGetByXY(Latitude, Longitude);
                if (pointGetByLatitude != null)
                {
                    return new Response { Data = pointGetByLatitude, Message = "Coordinate found", Success = true };
                }
                return new Response { Data = null, Message = "Coordinate didn't find.", Success = false };

            }
            else if(string.IsNullOrEmpty(PointName) && !string.IsNullOrEmpty(PointNumber) && Latitude.HasValue && Longitude.HasValue)
            {
                var pointGetByNumberAndXY = pointManager.TGetByXYAndNumber(PointNumber, Latitude, Longitude);
                if (pointGetByNumberAndXY != null)
                {
                    return new Response { Data = pointGetByNumberAndXY, Message = "Coordinate founded by number and x-y", Success = true };
                }
                return new Response { Data = null, Message = "Coordinate didn't find.", Success = false };
            }else if(!string.IsNullOrEmpty(PointName) && string.IsNullOrEmpty(PointNumber) && Latitude.HasValue && Longitude.HasValue)
            {
                var pointGetByNameAndXY = pointManager.TGetByXYAndName(Latitude, Longitude, PointName);
                if (pointGetByNameAndXY != null)
                {
                    return new Response { Data = pointGetByNameAndXY, Message = "Coordinate founded by name and x-y", Success = true };
                }
                return new Response { Data = null, Message = "Coordinate didn't find.", Success = false };

            }
            else if (!string.IsNullOrEmpty(PointName) && !string.IsNullOrEmpty(PointNumber) && !Latitude.HasValue && !Longitude.HasValue)
            {
                var pointGetByNumberName = pointManager.TGetByNumberAndName(PointName, PointNumber);
                if (pointGetByNumberName != null)
                {
                    return new Response { Data = pointGetByNumberName, Message = "Name and Number found", Success = true };
                }
                else
                {
                    return new Response { Data = null, Message = "Name and Number didn't find", Success = false };
                }

            }
            else 
            {
                var pointGetByNumberAndNameAndXY = pointManager.TGetByNumberAndNameAndXY(PointNumber,PointName, Latitude, Longitude);
                if (pointGetByNumberAndNameAndXY != null)
                {
                    return new Response { Data = pointGetByNumberAndNameAndXY, Message = "Coordinate founded by name and number and x-y", Success = true };
                }
                return new Response { Data = null, Message = "Coordinate didn't find.", Success = false };

            }
            
        }
    }
}