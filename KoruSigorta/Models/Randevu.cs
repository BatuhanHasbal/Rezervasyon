using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezervasyon.Models
{
    public class Randevu
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Adınızı ve Soyadınızı Giriniz")]

        public string FullName { get; set; }
        [Required(ErrorMessage = "Poliçe Numaranızı Giriniz")]

        public int PolicyNo { get; set; }
        [Required(ErrorMessage = "TC Kimlik Numarınızı Giriniz")]

        public string TcNo { get; set; }
        [Required(ErrorMessage = "Telefon Numarasınızı Giriniz")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "İl Bilginizi Giriniz")]

        public string City { get; set; }
        [Required(ErrorMessage = "İlçe Bilginizi Giriniz")]

        public string District { get; set; }
        [Required(ErrorMessage = "Tarih Seçiniz")]

        public DateTime Date { get; set; }
        public bool Approval { get; set; }
    }
}