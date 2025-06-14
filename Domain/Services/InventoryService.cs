using MongoDB.Entities;
using WareHouseProject.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WareHouseProject.Domain.Services
{
    public class InventoryService
    {
        public async Task<List<VatTu>> GetAllAsync()
        {
            return await DB.Find<VatTu>()
                           .Match(v => v.MaKho == "kho115")
                           .ExecuteAsync();
        }

        public async Task AddAsync(VatTu vatTu)
        {
            vatTu.MaKho = "kho115";
            await vatTu.SaveAsync();
        }

        public async Task<bool> ExportAsync(string maVatTu, int soLuongXuat)
        {
            var vatTu = await DB.Find<VatTu>()
                                .Match(v => v.MaVatTu == maVatTu && v.MaKho == "kho115")
                                .ExecuteSingleAsync();

            if (vatTu == null || vatTu.SoLuong < soLuongXuat)
                return false;

            vatTu.SoLuong -= soLuongXuat;
            await vatTu.SaveAsync();
            return true;
        }
    }
}
