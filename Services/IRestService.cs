using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emo.Models;

namespace Emo.Services
{
    internal interface IRestService
    {
        Task<List<Emote>> FetchAllEmotesAsync();
    }
}
