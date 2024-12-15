using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.models;

namespace BanCaCanh.mappers
{
    public static class AddressMapper
    {
        public static AddressDto ToAddressDto(this Address addressModel)
        {
            return new AddressDto
            {
                Id = addressModel.Id,
                Fullname = addressModel.Fullname,
                City = addressModel.City,
                District = addressModel.District,
                Street = addressModel.Street,
                PhoneNumber = addressModel.PhoneNumber,
            };
        }
        public static Address ToCreateAddressDto(this CreateAddressDto addressDto, string appUserId)
        {
            return new Address
            {
                Fullname = addressDto.Fullname,
                City = addressDto.City,
                District = addressDto.District,
                Street = addressDto.Street,
                PhoneNumber = addressDto.PhoneNumber,
                AppUserId = appUserId,
            };
        }
    }
}