﻿using ParkBee.Application.Interface;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Repositories
{
    public class GarageRepository : IGarageRepository
    {
        private readonly IApplicationContext _context;

        public GarageRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task InsertGarageAsync(Garage garage)
        {
            await _context.Set<Garage>().AddAsync(garage);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<Garage> GetGaregeByIdAsync(Guid garageId)
        => await _context.Set<Garage>().FindAsync(garageId);
    }
}
