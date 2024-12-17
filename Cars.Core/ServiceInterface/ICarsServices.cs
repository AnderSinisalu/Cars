using Cars.Core.Dto;
using Cars.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarsDto dto);
        Task<Car> Update(CarsDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> DetailsAsync(Guid id);
    }
}
