using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteS7AngelGualotuna
{
    public interface DataBase
    {

        SQLiteAsyncConnection GetConnection();

    }
}
