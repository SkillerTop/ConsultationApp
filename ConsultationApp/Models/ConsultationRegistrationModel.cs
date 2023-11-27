using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultationApp.Models
{
    public class ConsultationRegistrationModel
    {
        [Required(ErrorMessage = "Ім'я є обов'язковим полем.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим полем.")]
        [EmailAddress(ErrorMessage = "Введіть коректний email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Бажана дата консультації є обов'язковим полем.")]
        [FutureDate(ErrorMessage = "Бажана дата консультації повинна бути в майбутньому та не попадати на вихідні дні.")]
        public DateTime PreferredDate { get; set; }

        [Required(ErrorMessage = "Вибір продукту є обов'язковим полем.")]
        public string SelectedProduct { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date > DateTime.Now && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
