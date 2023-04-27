using EVMS.Entities;
using EVMS.Mappers;
using EVMS.Models;
using EVMS.utilities;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eStoreController  : Controller
    {
       StoreMapper mapper;
        public eStoreController()
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
            var voucher_list = dbContext.Voucher.Where(v => v.status == true).ToList();
            List<VoucherListViewModel> result = mapper.MapEntitiesToListViewModel(voucher_list);
            return result;
        }

        #endregion

        #region Buy Voucher
        [HttpPost]
        [Route("buyvoucher")]
        public IActionResult BuyVoucher(UserVoucherViewModel model)
        {
            try
            {
                var dbContext = new DatabaseContext();
                UserVoucher uv = new UserVoucher();
                var result = 0;
                uv.user_id = model.user_id;
                uv.voucher_id = model.voucher_id;
                uv.buy_type = model.buy_type;
                uv.gifttouser_id = model.gifttouser_id;
                uv.qty = model.qty;
                dbContext.Add(uv);
                result = dbContext.SaveChanges();
                if (result == 1)
                {
                    return Json(new { message = Constants.SAVE_SUCCESS_MESSAGE });
                }
                else
                {
                    return Json(new { message = Constants.Unsuccess_MESSAGE });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
            
        }
        #endregion

        #region Verify Promo Code and Checkout
        [HttpGet]
        [Route("verifycode")]
        public JsonResult VerifyPromoCodeAndCheckout(string codes, int phone, int goods_id)
        {
            try
            {
                var dbContext = new DatabaseContext();
                var voucher = dbContext.UserVoucher.Where(v => v.Voucher.code.Equals(codes) && v.User.phone_number.Equals(phone) && v.Voucher.status.Equals(true)).FirstOrDefault();
                if (voucher != null)
                {
                    var total = Checkout(voucher.id, goods_id);
                    return Json(new { dataresult = total });
                }
                else
                {
                    return Json(new { message = Constants.EXPERY_MESSAGE });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }

        int Checkout(int voucherid, int good_id)
        {
            var dbContext = new DatabaseContext();
            Voucher voucher = new Voucher();
            voucher = dbContext.Voucher.Find(voucherid);
            Goods goods = new Goods();
            goods = dbContext.Goods.Find(good_id);
            var total = 0;
            if (voucher != null && goods != null)
            {
                total = goods.price - voucher.amount;
            }
            return total;
        }
        #endregion

        #region Buy Goods
        [HttpPost]
        [Route("buygoods")]
        public IActionResult BuyGoods(UserGoodsViewModel model)
        {
            try
            {
                var dbContext = new DatabaseContext();
                UserGoods goods = new UserGoods();
                goods.user_voucher_id = model.user_voucher_id;
                goods.goods_id = model.goods_id;
                goods.promo_price = model.promo_price;
                goods.payment_method = model.payment_method;
                dbContext.UserGoods.Add(goods);
                var result = dbContext.SaveChanges();
                if (result == 1)
                {
                    return Json(new { message = Constants.SAVE_SUCCESS_MESSAGE });
                }
                else
                {
                    return Json(new { message = Constants.Unsuccess_MESSAGE });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }
        #endregion
    }
}
