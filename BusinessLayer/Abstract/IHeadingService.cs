﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        Heading GetByID(int id); 
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        void HeadingAdd(Heading heading);
    }
}
