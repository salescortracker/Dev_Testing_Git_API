using BusinessLayer.Common;
using BusinessLayer.DTOs;


namespace BusinessLayer.Interfaces
{
    public interface IAttendanceStatusService
    {
        Task<ApiResponse<IEnumerable<AttendanceStatusDto>>> GetAllAsync(int userId);


        Task<ApiResponse<AttendanceStatusDto?>> GetByIdAsync(int id);


        Task<ApiResponse<AttendanceStatusDto>> CreateAsync(AttendanceStatusDto dto);


        Task<ApiResponse<AttendanceStatusDto>> UpdateAsync(AttendanceStatusDto dto);


        Task<ApiResponse<bool>> DeleteAsync(int id);

    }
}
