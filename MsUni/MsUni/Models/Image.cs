using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsUni.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string UserId { get; set; }

        public string ImageType { get; set; }

        public byte[] ImageData { get; set; }
    }
}