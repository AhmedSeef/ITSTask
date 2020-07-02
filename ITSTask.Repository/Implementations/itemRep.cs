using ITSTask.DB;
using ITSTask.Model;
using ITSTask.Repository.Contracts;
using ITSTask.Repository.Implementations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSTask.Repository.Implementations
{
    public class itemRep : Repository<Item>, iItemRep
    {
        private DataContext _context;
        public itemRep(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
