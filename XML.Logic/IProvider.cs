﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML.Logic
{
    public interface IProvider
    {
        IEnumerable<URL> Load();
    }
}
