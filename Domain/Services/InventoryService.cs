using MongoDB.Driver;
using MongoDB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouseProject.Domain.Models;

namespace WareHouseProject.Domain.Services
{
    public class InventoryService
    {
        public string maKhoIntern { get; set; }
        public event Action OnMaKhoChanged;
        public void SetMaKho(string maKho)
        {
            maKhoIntern = maKho;
            OnMaKhoChanged?.Invoke();
        }
        public string GetMaKho()
        {
            return maKhoIntern;
        }

        public async Task<List<VatTu>> GetAllAsync()
        {
            return await DB.Find<VatTu>()
                           .Match(v => v.MaKho == maKhoIntern)
                           .ExecuteAsync();
        }

        public async Task AddAsync(VatTu vatTu)
        {
            vatTu.MaKho = maKhoIntern;
            await vatTu.SaveAsync();
        }

        public async Task<bool> ExportAsync(string maVatTu, int soLuongXuat)
        {
            var vatTu = await DB.Find<VatTu>()
                                .Match(v => v.MaVatTu == maVatTu && v.MaKho == maKhoIntern)
                                .ExecuteSingleAsync();

            if (vatTu == null || !vatTu.CanExport(soLuongXuat))
                return false;

            vatTu.SoLuong -= soLuongXuat;
            await vatTu.SaveAsync();
            return true;
        }
        public async Task<List<string>> GetDanhSachMaKhoAsync()
        {
            var danhSach = await DB.Find<VatTu>().ExecuteAsync();

            // Dùng LINQ để lấy danh sách MaKho duy nhất
            var dsMaKho = danhSach
                            .Where(v => !string.IsNullOrWhiteSpace(v.MaKho))
                            .Select(v => v.MaKho)
                            .Distinct()
                            .ToList();

            return dsMaKho;
        }
        public async Task<VatTu?> FindByMaVatTuAsync(string maVatTu)
        {
            return await DB.Find<VatTu>()
                           .Match(v => v.MaVatTu == maVatTu && v.MaKho == maKhoIntern)
                           .ExecuteSingleAsync();
        }

    }
}
