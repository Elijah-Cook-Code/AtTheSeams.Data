using AtTheSeams.Data.Connections;
using AtTheSeams.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AtTheSeams.Data.Services
{
    public class ClientLogic
    {
        private readonly ClientContext _context;

        public ClientLogic(ClientContext context)
        {
            _context = context;
        }

        public async Task<List<ClientInfo>> GetClientsAsync()
        {

            var clients = await _context.Clients.ToListAsync();

            Console.WriteLine($"Database Query: Retrieved {clients.Count} clients."); // ✅ Debug log
            return clients;
        }
        public async Task<List<ClientMeasurements>> GetAllMeasurementsAsync()
        {
            return await _context.Measurements.ToListAsync();
        }

        public async Task AddClientAsync(ClientInfo client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(ClientInfo client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(ClientInfo client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
        public async Task AddClientMeasurementAsync(ClientMeasurements measurement)
        {
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientMeasurementAsync(ClientMeasurements measurement)
        {
            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();
        }
    }
}


