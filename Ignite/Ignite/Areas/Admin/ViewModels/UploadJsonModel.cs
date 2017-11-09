using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class UploadJsonModel
    {
        [FileType("json")]
        [FileSize(0,10000000)]
        public HttpPostedFileBase Json { get; set; }
    }

    public class FileTypeAttribute : ValidationAttribute
    {
        private readonly List<string> allowedTypes;

        public FileTypeAttribute(string types)
        {
            this.allowedTypes = types
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }

        public override bool IsValid(object value)
        {
            if (value == null)  return true;

            var fileExtension = System.IO.Path
                .GetExtension((value as HttpPostedFileBase).FileName)
                .Substring(1);

            bool isValid = this.allowedTypes.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);

            return isValid;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Invalid File Type ! The supported file types are: {0}", string.Join(", ", this.allowedTypes));
        }
    }

    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;
        private readonly int minSize;

        public FileSizeAttribute(int minSize, int maxSize)
        {
            this.maxSize = maxSize;
            this.minSize = minSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            return (value as HttpPostedFileBase).ContentLength <= this.maxSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The maximum allowed file size is: {0}", this.maxSize);
        }
    }
}