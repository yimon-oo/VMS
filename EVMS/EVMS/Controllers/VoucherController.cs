using EVMS.Entities;
using EVMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : BaseController
    {
        private DatabaseContext dbContext;
        public VoucherController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateVoucher(VoucherViewModel model)
        {
            if (Authorize(utilities.AuthorizeAction.CREATEORUPDATE))
            {
                try
                {
                    Voucher voucher = new Voucher();
                    if (model.id > 0)
                    {
                        voucher=dbContext.Voucher.Find(model.id);
                        voucher.id = model.id;
                        voucher = MapModeltoEntity(model);
                        dbContext.Voucher.Update(voucher);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        voucher = MapModeltoEntity(model);
                        dbContext.Voucher.Add(voucher);
                        dbContext.SaveChanges();
                    }
                    return Json("");//Json(result);
                }
                catch (Exception ex)
                {
                    return Json("");//Json(GetServerJsonResult<Catalog>());
                }
            }
            else
            {
                return Json("");//Json(GetAccessDeniedJsonResult<Catalog>());
            }
            //return Json("");
        }

        public Voucher MapModeltoEntity(VoucherViewModel model)
        {
            Voucher voucher = new Voucher();
            voucher.Title = model.Title;
            voucher.Description = model.Description;
            voucher.Expiry_Date = model.Expiry_Date;
            voucher.Image = model.Image;
            voucher.Amount = model.Amount;
            voucher.Payment_Method = model.Payment_Method;
            voucher.Quantity = model.Quantity;
            voucher.Buy_Type = model.Buy_Type;
            voucher.status = true;
            return voucher;
        }

        [HttpGet("changeStatus")]
        public IActionResult InActiveStatus(int id){
            Voucher voucher=new Voucher();
            voucher=dbContext.Voucher.Find(model.id);
            voucher.status=false;
            dbContext.Voucher.Update(voucher);
            dbContext.SaveChanges();
            return Json("Success ")
        }
    }
}
