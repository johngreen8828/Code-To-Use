using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    interface IMusicTrack
    {
       string Artist { get; set; }
         string Title { get; set; }
         int Length { get; set; }
    }
}
