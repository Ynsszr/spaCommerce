﻿using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace spaCommerce.Models.Boards
{
    public partial  class ForumGroupModel : BaseNopModel
    {
        public ForumGroupModel()
        {
            this.Forums = new List<ForumRowModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }

        public IList<ForumRowModel> Forums { get; set; }
    }
}