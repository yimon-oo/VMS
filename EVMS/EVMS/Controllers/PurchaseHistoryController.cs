using EVMS.Entities;
using EVMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseHistoryController : Controller
    {
        #region Get Purchase History

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<PurchaseHistory> vmlist = GetAllData();
                return Json(vmlist);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public List<PurchaseHistory> GetAllData()
        {
            var user_id = Request.Query["user_id"].FirstOrDefault();
            var dbContext = new DatabaseContext();
            List<PurchaseHistory> list = new List<PurchaseHistory>();
            // purchase history per user
            if (user_id != null)
            {
                list = dbContext.PurchaseHistory.Where(x => x.id.Equals(user_id)).ToList();
            }
            // purchase history of all user
            else
            {
                list = dbContext.PurchaseHistory.ToList();
            }
            return list;
        }

        #endregion
    }
}
