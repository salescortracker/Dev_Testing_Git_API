using BusinessLayer.Common;
using BusinessLayer.DTOs;
namespace BusinessLayer.Interfaces
{
    public interface ICertificationTypeService
    {
        Task<ApiResponse<IEnumerable<CertificationTypeDto>>> GetAll(int userId);

        Task<ApiResponse<CertificationTypeDto?>> GetByIdAsync(int id);

        Task<ApiResponse<string>> CreateAsync(CreateUpdateCertificationTypeDto dto);

        Task<ApiResponse<string>> UpdateAsync(CreateUpdateCertificationTypeDto dto);

        Task<ApiResponse<string>> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<CertificationTypeDto>>> GetCmpregionAllAsync(
          int companyId, int regionId);

        Task<ApiResponse<(int inserted, int duplicates, int failed)>> BulkInsertAsync(
            IEnumerable<CreateUpdateCertificationTypeDto> items, int createdBy);
    }
}
