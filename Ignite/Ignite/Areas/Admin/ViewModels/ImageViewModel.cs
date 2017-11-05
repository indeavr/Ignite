using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class ImageViewModel
    {
        public string Name { get; set; }

        public byte[] Content { get; set; }

        public int Order { get; set; }
    }
}