using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class Lichchieu
    {
        public Lichchieu()
        {
            Lichchieuphims = new HashSet<Lichchieuphim>();
            Trangthaighes = new HashSet<Trangthaighe>();
        }

        public string MaLichChieu { get; set; } = null!;
        public DateTime NgayChieu { get; set; }
        public TimeSpan GioChieu { get; set; }

        public virtual ICollection<Lichchieuphim> Lichchieuphims { get; set; }
        public virtual ICollection<Trangthaighe> Trangthaighes { get; set; }
    }
}
