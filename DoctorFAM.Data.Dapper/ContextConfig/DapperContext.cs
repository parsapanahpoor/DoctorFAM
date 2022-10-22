using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DoctorFAM.Data.Dapper.ContextConfig
{
    public abstract class DapperContext : IDisposable
    {
        private readonly IConfiguration configuration;
        protected DbConnection _context;
        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _context = new SqlConnection(configuration.GetConnectionString("DoctorFAMConnectionString"));
        }

        public async Task<DbConnection> GetDbConnectionAsync()
        {
            if (_context.State == ConnectionState.Closed)
            {
                await _context.OpenAsync();
            }
            return _context;
        }
        public DbConnection GetDbConnection()
        {
            if (_context.State == ConnectionState.Closed)
            {
                _context.Open();
            }
            return _context;
        }

        public void Dispose()
        {
            if (_context.State == ConnectionState.Open)
            {
                _context.Close();
                _context.Dispose();
            }
        }
    }
}
