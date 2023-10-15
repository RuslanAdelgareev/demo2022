using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SportApp.Models
{
    public partial class SportTradeEntities
    {
        private static SportTradeEntities _context;
        public static SportTradeEntities GetContext()
        {
            if (_context == null)
            {
                _context = new SportTradeEntities();
            }
            return _context;
        }
    }
}
