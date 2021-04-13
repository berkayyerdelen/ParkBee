﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Domain.GarageAggregate
{
    public interface IGarageRepository
    {
        Task InsertGarageAsync(Garage garage);
        Task<Garage> GetGaregeByIdAsync(Guid garageId);
    }
}
