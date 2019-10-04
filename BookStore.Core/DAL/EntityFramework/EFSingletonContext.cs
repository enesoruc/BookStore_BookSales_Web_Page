using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DAL.EntityFramework
{
    public class EFSingletonContext<TContext>
        where TContext : DbContext, new()//Bunu sadece DbContext'ten kalıtım almış ve parametresiz ctor'u bulunanlar kullanabilir
    {
        private static TContext context;

        public static TContext Instance
        {
            get
            {
                if (context==null)
                {
                    context = new TContext();
                }
                return context;
            }
        }
    }
}
