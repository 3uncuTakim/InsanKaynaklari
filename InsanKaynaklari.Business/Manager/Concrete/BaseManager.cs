using InsanKaynaklari.Business.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.Manager.Concrete
{
    public class BaseManager<T> : IGeneralService<T> where T :class  
    {
    }
}
