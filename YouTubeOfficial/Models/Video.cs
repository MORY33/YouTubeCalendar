using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeOfficial.Models
{
    public class Video
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
