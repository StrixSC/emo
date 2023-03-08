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
        public String name { get; set; }
        public String url { get; set; }
        public ImageType imageType { get; set; }
        public bool animated { get; set; }
    }

    internal enum ImageType {
        gif,
        png,
        jpg,
        jpeg
    }
}
