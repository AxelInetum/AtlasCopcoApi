﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAtlasCopco.Interfaces.Truck
{
    public class UpdateTruckdto
    {
       public int id { get; set; }
       public string nombre { get; set; }
       public string marca { get; set; }
       public string modelo { get; set; }
       public string matricula { get; set; }

    }
}
