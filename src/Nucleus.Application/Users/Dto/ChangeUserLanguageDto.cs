using System.ComponentModel.DataAnnotations;

namespace Nucleus.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}