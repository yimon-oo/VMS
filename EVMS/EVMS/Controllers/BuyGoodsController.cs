using EVMS.Entities;
using EVMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyGoodsController : Controller
    {
        #region Buy Goods
        [HttpPost]
        public IActionResult BuyGoods(UserGoodsViewModel model)
        {
            var dbContext = new DatabaseContext();
            UserGoods goods = new UserGoods();
            goods.user_voucher_id = model.user_voucher_id;
            goods.goods_id = model.goods_id;
            goods.promo_price = model.promo_price;
            goods.payment_method = model.payment_method;
            dbContext.UserGoods.Add(goods);
            var result = dbContext.SaveChanges();
            return Json(result);
        }
        #endregion

        #region Verify Promo Code and Checkout
        [HttpGet("verifycode")]
        public JsonResult VerifyPromoCodeAndCheckout(string codes, int phone, int goods_id)
        {
            try
            {
                var dbContext = new DatabaseContext();
                var voucher = dbContext.UserVoucher.Where(v => v.Voucher.code.Equals(codes) && v.User.phone_number.Equals(phone) && v.Voucher.status.Equals(true)).FirstOrDefault();
                if (voucher != null)
                {
                    var total = Checkout(voucher.id, goods_id);
                    return Json(total);
                }
                else
                {
                    return Json("Your voucher is expired!");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
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

    }
}
