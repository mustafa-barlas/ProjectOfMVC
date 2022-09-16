﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string r);
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        Content GetByID(int id);
        List<Content> GetListByHeadingID(int id);
        void ContentAdd(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
