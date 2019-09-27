﻿using System.Collections.Generic;
using FluentValidation.Attributes;
using spaCommerce.Areas.Admin.Validators.Customers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace spaCommerce.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer attribute model
    /// </summary>
    [Validator(typeof(CustomerAttributeValidator))]
    public partial class CustomerAttributeModel : BaseNopEntityModel, ILocalizedModel<CustomerAttributeLocalizedModel>
    {
        #region Ctor

        public CustomerAttributeModel()
        {
            Locales = new List<CustomerAttributeLocalizedModel>();
            CustomerAttributeValueSearchModel = new CustomerAttributeValueSearchModel();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.AttributeControlType")]
        public string AttributeControlTypeName { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<CustomerAttributeLocalizedModel> Locales { get; set; }

        public CustomerAttributeValueSearchModel CustomerAttributeValueSearchModel { get; set; }

        #endregion
    }

    public partial class CustomerAttributeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.Name")]
        public string Name { get; set; }
    }
}