using System.ComponentModel.DataAnnotations;

namespace IMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}