using EVMS.Entities;
using EVMS.Models;

namespace EVMS.Mappers
{
    public class StoreMapper
    {
        public List<VoucherListViewModel> MapEntitiesToListViewModel(List<Voucher> voucherList)
        {
            List<VoucherListViewModel> dataList = new List<VoucherListViewModel>();
            foreach (var vou in voucherList)
            {
                VoucherListViewModel vm = new VoucherListViewModel();
                vm.title = vou.title;
                vm.description = vou.description;
                vm.amount = vou.amount;
                dataList.Add(vm);
            }
            return dataList;
        }
    }
}
