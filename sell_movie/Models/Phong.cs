﻿using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class Phong
    {
        public Phong()
        {
            Ghes = new HashSet<Ghe>();
            Lichchieuphims = new HashSet<Lichchieuphim>();
            Trangthaighes = new HashSet<Trangthaighe>();
        }

        public string MaPhong { get; set; } = null!;
        public string TenPhong { get; set; } = null!;
        public int SoChoNgoi { get; set; }
        public int SoHang { get; set; }
        public int Socot { get; set; }

        public virtual ICollection<Ghe> Ghes { get; set; }
        public virtual ICollection<Lichchieuphim> Lichchieuphims { get; set; }
        public virtual ICollection<Trangthaighe> Trangthaighes { get; set; }
    }
}
