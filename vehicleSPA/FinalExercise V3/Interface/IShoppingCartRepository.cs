using FinalExercise_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalExercise_V3.Interface
{
    interface IShoppingCartRepository
    {
        IEnumerable<TblOrder> GetAll();
        TblOrder Get(int id);
        TblOrder Add(TblOrder item);
        bool Update(TblOrder item);
        bool Delete(int id);
    }
}