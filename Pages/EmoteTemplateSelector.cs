using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emo.Models;

namespace Emo.Pages
{
    class EmoteTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StaticEmoteTemplate { get; set; }
        public DataTemplate AnimatedEmoteTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Emote)item).Animated ? AnimatedEmoteTemplate : StaticEmoteTemplate;
        }
    }
}
