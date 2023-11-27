using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class Ghe
    {
        internal int Hang;
        internal int Cot;

        public Ghe()
        {
            Ctdatves = new HashSet<Ctdatve>();
        }

        public string MaGhe { get; set; } = null!;
        public string TenGhe { get; set; } = null!;
        public byte TrangThai { get; set; }
        public string MaPhong { get; set; } = null!;

        public virtual Phong MaPhongNavigation { get; set; } = null!;
        public virtual ICollection<Ctdatve> Ctdatves { get; set; }
      
    }
}
