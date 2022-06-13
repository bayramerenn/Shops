using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Application.Commons
{
    public static class Messages
    {
        // CurrentAccount
        public static string NotFoundCurrentAccount = "Kullanıcı kayıt edilirken bir hata meydana geldi";
        public static string NotFoundCurrentAccountList = "Kullanıcı tablosu boş olduğu için kayıtlar getirelemedi";
        public static string SuccessCurrentAccount = "Kullanıcı başarıyla oluşturulmuştur.";
        public static string NotFoundGetCurrentAccountList(Guid id) => $"Bu {id} ait bir kullanıcı bulunamadı.";

        // Invoice
        public static string NotFoundInvoice = "Fatura kayıt edilirken bir hata meydana geldi";
        public static string SuccessInvoice = "Fatura başarıyla oluşturulmuştur.";
        public static string NotFoundInvoiceList = "Fatura tablosu boş olduğu için kayıtlar getirelemedi";
        public static string NotFoundInvoiceGetCustomer(Guid id) => $"Bu {id} ait bir müşteri bulunamadı.";
        public static string NotFoundGetIdInvoice(Guid id) => $"Bu {id} ait bir fatura bulunamadı.";

        // CurrentAccountType
        public static string NotFoundCurrentAccountTypeList = "Kullanıcı type tablosu boş olduğu için kayıtlar getirelemedi";

        // Discount
        public static string NotFoundDiscountList = "İndirim tablosu boş olduğu için kayıtlar getirelemedi";


    }
}
