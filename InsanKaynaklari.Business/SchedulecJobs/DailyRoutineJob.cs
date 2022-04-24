using InsanKaynaklari.Business.Mailing;
using InsanKaynaklari.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.SchedulecJobs
{
    public class DailyRoutineJob : IJob
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMailService _mailService;

        public DailyRoutineJob(DatabaseContext databaseContext,
                               IMailService mailService)
        {
            _databaseContext = databaseContext;
            _mailService = mailService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            DateTime now = DateTime.Now.ConvertToYearMonthDayFormat();

            #region Vardiya bilgilerini çekme ve mail olarak gönderme
            var checkShifts = _databaseContext.Shifts.Include(s => s.Personel).ThenInclude(p => p.PersonelDetail)
                                                               .Where(sh => sh.StartOfShift >= now.AddDays(1) &&
                                                                     sh.EndOfShift < now.AddDays(2)
               ).ToList();

            for (int index = 0; index < checkShifts.Count; index++)
            {
                _mailService.SendEmail(new MailTemplate(
                    from: "info@ik.com",
                    subject: $"IK Vardiya Bilgilendirme - {checkShifts[index].StartOfShift:d} Tarihli vardiya bilgileriniz",
                    to: checkShifts[index].Personel.Email,
                    body: @$"IK Personeli vardiya bilgilendirme detayi asagidaki gibidir:
Personel bilgileri   : {checkShifts[index].Personel.PersonelDetail.Title} {checkShifts[index].Personel.PersonelDetail.FirstName} {checkShifts[index].Personel.PersonelDetail.LastName}
Departmani           : {checkShifts[index].Personel.PersonelDetail.Department}
Vardiya başlangıç    : {checkShifts[index].StartOfShift}
Vardiya bitiş        : {checkShifts[index].EndOfShift}
Vardiya gün sayısı   : {checkShifts[index].EndOfShift.CalculateDifference(checkShifts[index].StartOfShift).Days}

"
                    ));
            }
            #endregion

            #region izin bilgilerini çekme ve mail olarak gönderme
            var checkLeaves = _databaseContext.Leaves
                    .Include(l => l.Personel)
                        .ThenInclude(p => p.PersonelDetail)
                    .Include(l => l.LeaveType)
                    .Where(l =>
                        l.StartLeaveDate >= now.AddDays(1) &&
                        l.StartLeaveDate < now.AddDays(2)).ToList();

            checkLeaves.ForEach(cl =>
            {
                cl.EndLeaveDate = cl.EndLeaveDate.AddDays(1);

                _mailService.SendEmail(new MailTemplate(
                    from: "info@ik.com",
                    subject: $"IK Izin Bilgilendirme - {cl.StartLeaveDate:d} Tarihli izin bilgileriniz",
                    to: cl.Personel.Email,
                    body: @$"IK Personeli izin bilgilendirme detayi asagidaki gibidir:
Personel bilgileri   : {cl.Personel.PersonelDetail.Title} {cl.Personel.PersonelDetail.FirstName} {cl.Personel.PersonelDetail.LastName}
Departmani           : {cl.Personel.PersonelDetail.Department}
Izin turu            : {cl.LeaveType.TypeName}
Izin tarihi          : {cl.StartLeaveDate:d}
Izin bitis tarihi    : {cl.EndLeaveDate:d}
Toplam izin suresi   : {cl.EndLeaveDate.CalculateDifference(cl.StartLeaveDate).Days}

Iyi tatiller - Keyfinize bakin, selametle gidin gelin, cok calisin az gezin para lazim :D
"
                    )
                );
            });
            #endregion

            return Task.CompletedTask;
        }
    }
}