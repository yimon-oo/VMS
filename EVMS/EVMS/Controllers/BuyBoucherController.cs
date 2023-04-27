using EVMS.Entities;
using EVMS.Mappers;
using EVMS.Models;
using EVMS.utilities;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyBoucherController  : Controller
    {
       StoreMapper mapper;
        public BuyBoucherController()
        {
            mapper = new StoreMapper();
        }

        #region Get All Active Voucher List

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<VoucherListViewModel> vmlist = GetAllData();
                return Json(new { dataresult = vmlist });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }            
        }

        public List<VoucherListViewModel> GetAllData()
        {
            var dbContext = new DatabaseContext();
            var voucher_list = dbContext.Voucher.Where(v => v.status == true && v.expiry_date >= DateTime.Now).ToList();
            List<VoucherListViewModel> result = mapper.MapEntitiesToListViewModel(voucher_list);
            return result;
        }

        #endregion

        #region Buy Voucher
        [HttpPost]
        public IActionResult BuyVoucher(UserVoucherViewModel model)
        {
            var dbContext = new DatabaseContext();
            UserVoucher uv=new UserVoucher();
            var result = 0;
            uv.voucher_id = model.voucher_id;
            uv.buy_type = model.buy_type;
            uv.gifttouser_id = model.gifttouser_id;
            uv.qty = model.qty;
            dbContext.Add(uv);            
            result = dbContext.SaveChanges();
            if(result == 1)
            {
                return Json(new {message=Constants.SAVE_SUCCESS_MESSAGE});
            }
            else
            {
                return Json(new { message = Constants.Unsuccess_MESSAGE });
            }
        }
        #endregion

    }
}
