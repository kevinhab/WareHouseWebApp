using MongoDB.Entities;

namespace WareHouseProject.Domain.Models
{
    [Collection("Vật tư")]
    public class VatTu : Entity
    {
        public string MaVatTu { get; set; }
        public string Model { get; set; }
        public string TenVatTu { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string MaKho { get; set; }
        public bool CanExport(int soLuong)
        {
            return SoLuong >= soLuong;
        }
    }
}
