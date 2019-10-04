using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    public class DontUpdatedException : Exception
    {
        public override string Message => "Güncelleme İşlemi Gerçekleştirilemedi";
    }
}
