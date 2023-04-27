using EVMS.utilities;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : Controller
    {
        [HttpGet]
        [Route("getpaymentmethod/")]
        public JsonResult GetPaymentMethod()
        {
            List<BuyType> list = new List<BuyType>();
            return Json(list);
        }
    }
}
