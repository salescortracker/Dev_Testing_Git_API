using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Implementations
{
    public interface IVisaTypeService
    {
        Task<List<VisaTypeDto>> GetVisaTypeList(int userId);

        Task<string> CreateVisaType(VisaTypeDto dto);

        Task<string> UpdateVisaType(VisaTypeDto dto);

        Task<string> DeleteVisaType(int id);
    }
}
