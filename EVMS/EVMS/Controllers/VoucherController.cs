using EVMS.Entities;
using EVMS.Mappers;
using EVMS.Models;
using EVMS.utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : Controller
    {
        VoucherMapper mapper;
        public VoucherController()
        {
            mapper = new VoucherMapper();
        }

        #region Get Voucher List

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<VoucherListViewModel> vmlist = GetAllData();
                return Json(new { resultdata = vmlist });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }

        public List<VoucherListViewModel> GetAllData()
        {
            var dbContext = new DatabaseContext();
            List<Voucher> list = new List<Voucher>();
            list = dbContext.Voucher.ToList();            
            List<VoucherListViewModel> listvm = mapper.MapEntityToListViewModel(list);
            return listvm;
        }

        #endregion

        #region Create or Update Voucher
        [HttpPost]
        public IActionResult CreateVoucher(VoucherViewModel model)
        {
            try
            {
                Voucher voucher = new Voucher();
                var dbContext = new DatabaseContext();
                int result = 0;
                if (model.id > 0)
                {
                    voucher = dbContext.Voucher.Find(model.id);
                    voucher.id = model.id;
                    voucher = mapper.MapModeltoEntity(model);
                    dbContext.Voucher.Update(voucher);
                    result = dbContext.SaveChanges();
                }
                else
                {
                    voucher = mapper.MapModeltoEntity(model);
                    dbContext.Voucher.Add(voucher);
                    result = dbContext.SaveChanges();
                }
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

        #region Get voucher by Id for voucher update

        [HttpGet]
        [Route("GetById")]
        public JsonResult GetById(int id)
        {
            try{
                var dbContext = new DatabaseContext();
                Voucher voucher = dbContext.Voucher.Find(id);
                return Json(new { resultdata = voucher });
            }
            catch(Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }

        #endregion

        #region Inactive Voucher

        [HttpPost]
        [Route("changeStatus")]
        public JsonResult ChangeStatus(int id, bool status)
        {
            var dbContext = new DatabaseContext();
            Voucher voucher=new Voucher();
            voucher=dbContext.Voucher.Find(id);
            var result = 0;
            if (voucher != null)
            {
                voucher.status = status;
                dbContext.Voucher.Update(voucher);
                result = dbContext.SaveChanges();
            }
            
            if (result == 1)
            {
                return Json(new { message = Constants.SAVE_SUCCESS_MESSAGE });
            }
            else
            {
                return Json(new { message = Constants.Unsuccess_MESSAGE });
            }
        }
        
        #endregion

        #region Delete Voucher

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var dbContext = new DatabaseContext();
            Voucher voucher = new Voucher();
            voucher = dbContext.Voucher.Find(id);
            dbContext.Voucher.Remove(voucher);
            var result = dbContext.SaveChanges();
            if (result == 1)
            {
                return Json(new { message = Constants.DELETE_SUCCESS_MESSAGE });
            }
            else
            {
                return Json(new { message = Constants.Unsuccess_MESSAGE });
            }
        }

        #endregion
    }
}
