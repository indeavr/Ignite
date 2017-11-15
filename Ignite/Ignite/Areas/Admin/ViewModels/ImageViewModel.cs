using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ignite.Areas.Admin.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        [DefaultValue("default.jpg")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The image contains no content")]
        public byte[] Content { get; set; }

        public int Order { get; set; }
    }
}