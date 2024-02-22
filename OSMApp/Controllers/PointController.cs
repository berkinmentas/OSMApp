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
            }else if (!string.IsNullOrEmpty(PointName)){
                var  pointGetByName = pointManager.TGetByName(PointName);
                return new Response { Data= pointGetByName, Message ="Name found", Success = true };
            }
            else if (!string.IsNullOrEmpty(PointNumber)){
                var pointGetByNumber = pointManager.TGetByNumber(PointNumber);
                return new Response { Data = pointGetByNumber, Message = "Number found", Success = true };
            }
            else if (Latitude.HasValue && Longitude.HasValue)
            {
                var pointGetByLatitude = pointManager.TGetByXY(Latitude, Longitude);
                return new Response { Data = pointGetByLatitude, Message = "Number found", Success = true };
            }
            else if( string.IsNullOrEmpty(PointNumber) && Latitude.HasValue && Longitude.HasValue)
            {
                var pointGetByNumberAndXY = pointManager.TGetByXYAndNumber(PointNumber, Latitude, Longitude);
                return new Response { Data = pointGetByNumberAndXY, Message = "Point found", Success = true };
            }else if(string.IsNullOrEmpty(PointName) && Latitude.HasValue && Longitude.HasValue)
            {
                var pointGetByNameAndXY = pointManager.TGetByXYAndName(Latitude, Longitude, PointName);
                return new Response { Data = pointGetByNameAndXY, Message = "Point found", Success = true };
            }else if(string.IsNullOrEmpty(PointNumber) && string.IsNullOrEmpty(PointName))
            {
                var pointGetByNumberAndName = pointManager.TGetByNumberAndName(PointNumber, PointName);
                return new Response { Data = pointGetByNumberAndName, Message = "Point found", Success = true };

            }else 
            {
                var pointGetByNumberAndNameAndXY = pointManager.TGetByNumberAndNameAndXY(PointNumber,PointName, Latitude, Longitude);
                return new Response { Data = pointGetByNumberAndNameAndXY, Message = "Point found", Success = true };

            }
            
        }
    }
}