using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    public class DontSavedException : Exception
    {
        public override string Message => "Kayıt Oluşturulamadı";
    }
}
