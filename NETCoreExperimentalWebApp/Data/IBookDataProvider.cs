﻿using NETCoreExperimentalWebApp.Models;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Data
{
    public interface IBookDataProvider
    {
        IEnumerable<BookModel> GetAll();
        BookModel Get(int? id);
        BookModel Create(BookModel book);
        bool Delete(int? id);
        bool Update(int id, BookModel book);

    }

}
