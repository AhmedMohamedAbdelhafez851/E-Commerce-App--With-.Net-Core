using System;
using System.Collections.Generic;

namespace Labs.Models
{
    public partial class TbSlider
    {
        public int SliderId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; } = null!;        
        public int CurrentState { get; set;   }

        public DateTime CreateDate { get; set; }    
        
        public string ?CreateBy { get; set; }    
        public DateTime UpdateDate { get; set;  }
        public string?  UpdateBy { get; set; }


    }
}
