using InsanKaynaklari.DataAccess.Repository.BaseRepository;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynaklari.DataAccess.Repository.Abstract;

namespace InsanKaynaklari.DataAccess.Repository.Concrete
{
    public class EventRepository:BaseRepository<Event>,IEventRepository
    {
        public EventRepository(DatabaseContext context):base(context)
        {

        }
    }
}
