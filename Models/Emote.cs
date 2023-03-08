using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emo.Models
{
    public class Emote
    {
        public String id { get; set; }
        public String code { get; set; }
        public String url { get; set; }
        public String imageType { get; set; }
        public bool animated { get; set; }
    }

    public enum ImageType {
        gif,
        png,
        jpg,
        jpeg
    }
}
