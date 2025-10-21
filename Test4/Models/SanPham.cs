using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test4.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }


        public long LoaiSanPhamId { get; set; }

        public LoaiSanPham Loai_San_Pham { get; set; }

    }
}
