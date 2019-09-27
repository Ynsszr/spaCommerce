﻿using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using spaCommerce.Areas.Admin.Validators.Forums;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace spaCommerce.Areas.Admin.Models.Forums
{
    /// <summary>
    /// Represents a forum list model
    /// </summary>
    [Validator(typeof(ForumValidator))]
    public partial class ForumModel : BaseNopEntityModel
    {
        #region Ctor

        public ForumModel()
        {
            ForumGroups = new List<ForumGroupModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId")]
        public int ForumGroupId { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        public List<ForumGroupModel> ForumGroups { get; set; }

        #endregion
    }
}