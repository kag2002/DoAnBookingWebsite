using System.ComponentModel.DataAnnotations;

namespace BookingWebsite.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}