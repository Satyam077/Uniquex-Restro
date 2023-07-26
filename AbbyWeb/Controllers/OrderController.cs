using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;     
        public OrderController(IUnitOfWork unitOfWork) { 

            _unitOfWork = unitOfWork;          
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(string? status=null)
        {
            var OrderHeaderList = _unitOfWork.OrderHeader.GetAll(includeproperties:"ApplicationUser");
            if (status == "cancelled")
            {
                OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.statusCancelled || u.Status == SD.statusRejected);
            }
            else
            {
                if (status == "completed")
                {
                    OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.statusCompleted);
                }
                else
                {
                    if (status == "ready")
                    {
                        OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.statusReady);
                    }
                    else
                    {
                        OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.statusSubmitted || u.Status == SD.statusInProcess);
                    }
                }
            }
            return Json(new { data = OrderHeaderList });
        }      
    }
}
