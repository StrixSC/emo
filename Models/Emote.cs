using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Emo.Models
{
    public class Emote
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string ImageType { get; set; }
        public string Url { get; set; }
        public bool Animated { get; set; }
    }

    public enum ImageType {
        gif,
        png,
        jpg,
        jpeg
    }
}
