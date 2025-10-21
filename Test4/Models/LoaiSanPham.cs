using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test4.Models
{
    [Table("LoaiSanPham")]
    [Index(nameof(MaLoai), IsUnique = true)]
    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]
        public string MaLoai { get; set; }

        [Display(Name = "Tên loại")]
        [StringLength(50)]
        public string TenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }

        public ICollection<SanPham> SanPhams { get; set; } = new HashSet<SanPham>();
    }
}
