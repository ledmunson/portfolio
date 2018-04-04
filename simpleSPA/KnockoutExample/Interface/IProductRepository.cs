using KnockoutExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutExample.Interface
{
    interface IProductRepository
    {
        IEnumerable<TblProductList> GetAll();
        TblProductList Get(int id);
        TblProductList Add(TblProductList item);
        bool Update(TblProductList item);
        bool Delete(int id);
    }
}