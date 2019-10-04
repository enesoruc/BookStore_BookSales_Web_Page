using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class AllException : Exception
    {
        public string KayıtBasarili { get { return "Kayıt Başarılı Bir Şekilde Oluşturuldu"; } }
        public string KayıtBasarisiz { get { return "Kayıt İşlemi Başarısız Oldu Bilgileri Kontrol Edip Tekrar Deneyiniz"; } }
        public string HataOlustu { get { return "İşlem Gerçekleştirilirken Bir Hata Oluştu"; } }
    }
}
