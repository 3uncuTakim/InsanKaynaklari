using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.DataAccess.Repository.BaseRepository;
using InsanKaynaklari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Repository.Concrete
{
    public class PersonalDetailRepository : BaseRepository<PersonelDetail>
    {
        public PersonalDetailRepository(DatabaseContext context):base(context)
        {

        }
    }
}
