using EVMS.Entities;
using EVMS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EVMS.Mappers
{
    public class VoucherMapper
    {
        public Voucher MapModeltoEntity(VoucherViewModel model)
        {
            Voucher voucher = new Voucher();
            voucher.title = model.title;
            voucher.code = model.code;
            voucher.description = model.description;
            voucher.expiry_date = DateTime.ParseExact(model.expiry_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            voucher.qr_image = model.image;
            voucher.amount = model.amount;
            voucher.quantity = model.quantity;
            voucher.maximum = model.maximum;
            voucher.status = true;
            return voucher;
        }

        public List<VoucherListViewModel> MapEntityToListViewModel(List<Voucher> list)
        {
            List<VoucherListViewModel> vmList = new List<VoucherListViewModel>();
            foreach (var data in list)
            {
                VoucherListViewModel vm=new VoucherListViewModel();
                vm.title = data.title;
                vm.code = data.code;
                vm.description = data.description;
                vm.expiry_date= string.Format("{0:dd-MM-yyyy}", data.expiry_date);
                vm.amount = data.amount;
                vm.quantity = data.quantity;
                vm.maximum = data.maximum;
                if (data.status)
                {
                    vm.status = "Active";
                }
                else
                {
                    vm.status = "InActive";
                }
                vmList.Add(vm);
            }
            return vmList;
        }
    }
}
