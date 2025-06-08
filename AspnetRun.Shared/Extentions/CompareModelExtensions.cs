using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Shared.Extentions
{
    public static class CompareModelExtensions
    {
        public static CompareDto ToCompareDto (this Compare model)
        {
            if (model == null) return null;

            return new CompareDto
            {
                Id = model.Id,
                UserName = model.UserName
                // ,Items = model.Items?.ToCartItemDtoList()
            };
        }

        public static CompareDto ToCompareEntity(this CompareDto dto)
        {
            if (dto == null) return null;

            return new CompareDto
            {
                Id = dto.Id,
                UserName = dto.UserName
                // ,Items = model.Items?.ToCartItemDtoList()
            };
        }
    }
}
