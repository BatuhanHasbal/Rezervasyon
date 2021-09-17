using FluentValidation;
using Rezervasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rezervasyon.FluentValidation
{
    public class RandevuValidation : AbstractValidator<Randevu>
    {
        public RandevuValidation()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Adınızı ve Soyadınızı Giriniz");
            RuleFor(x => x.PolicyNo).NotEmpty().WithMessage("Poliçe Numarasınızı Giriniz");
            RuleFor(x => x.TcNo).NotEmpty().WithMessage("TC Kimlik Numaranızı Giriniz");
            RuleFor(x => x.TcNo).Length(11).WithMessage("TC Kimlik Numaranız 11 karakterli olmak zorundadır");
            RuleFor(x => x.TcNo).Custom((tc, context) =>
            {
                if(!TcDogrulaV2(tc)) context.AddFailure("TC Kimlik Numaranızı Doğru Giriniz");
            });
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numaranızı Giriniz");
            RuleFor(x => x.City).NotEmpty().WithMessage("İl Bilgisi Giriniz");
            RuleFor(x => x.District).NotEmpty().WithMessage("İlçe Bilgisi Giriniz");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Seçiniz");

        }

        public static bool TcDogrulaV2(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }
    }

}