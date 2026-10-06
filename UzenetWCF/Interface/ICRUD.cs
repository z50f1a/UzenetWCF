using System;
using System.Collections.Generic;
using UzenetWCF.Models;

namespace UzenetWCF.Interface
{
    internal interface ICRUD
    {
        string Create(Tablazat tablazat);

        List<Tablazat> Read();

        string Update(Tablazat tablazat);

        string Delete(int id);
    }
}
