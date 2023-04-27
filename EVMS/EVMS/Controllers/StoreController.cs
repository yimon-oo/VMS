using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController  : Controller
    {
        private DatabaseContext dbContext;
        public StoreController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult VoucherList()
        {
            var voucher_list = dbContext.Voucher.ToList();
            List<VoucherListViewModel> result = MapEntitiesToListViewModel(voucher_list);
            return Json(result);
        }

        public List<VoucherListViewModel> MapEntitiesToListViewModel(List<Voucher> voucherList)
        {
            List<VoucherListViewModel> dataList=new List<VoucherListViewModel>();
            foreach(var vou in voucherList){
            VoucherListViewModel vm = new VoucherListViewModel();
            vm.Title = vou.Title;
            vm.Description = vou.Description;
            vm.Expiry_Date = vou.Expiry_Date;
            vm.Image = vou.Image;
            vm.Amount = vou.Amount;
            vm.Payment_Method = vou.Payment_Method;
            vm.Quantity = vou.Quantity;
            vm.Buy_Type = vou.Buy_Type;
            //vm.status = true;
            dataList.Add(vm);
            }            
            return dataList;
        }

        [HttpGet("VoucherDetail")]
        public IActionResult VoucherDetail(int id)
        {
            var voucher=dbContext.Voucher.Get(id);
            return Json(voucher);
        }

        [HttpGet("verifycode")]
        public IActionResult VerifyPromoCode(string codes, int phone)
        {            
            var voucher=dbContext.Voucher.Get(codes, true);
            if(voucher!=null){
                return Json(voucher);
            }
            else{
                return Json("Your voucher is expired!");
            }
        }
    }
}
