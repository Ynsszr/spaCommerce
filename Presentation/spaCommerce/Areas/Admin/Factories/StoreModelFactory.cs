﻿using System;
using System.Linq;
using Nop.Core.Domain.Stores;
using Nop.Services.Localization;
using Nop.Services.Stores;
using spaCommerce.Areas.Admin.Infrastructure.Mapper.Extensions;
using spaCommerce.Areas.Admin.Models.Stores;
using Nop.Web.Framework.Extensions;
using Nop.Web.Framework.Factories;

namespace spaCommerce.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the store model factory implementation
    /// </summary>
    public partial class StoreModelFactory : IStoreModelFactory
    {
        #region Fields

        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IStoreService _storeService;

        #endregion

        #region Ctor

        public StoreModelFactory(IBaseAdminModelFactory baseAdminModelFactory,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IStoreService storeService)
        {
            this._baseAdminModelFactory = baseAdminModelFactory;
            this._localizationService = localizationService;
            this._localizedModelFactory = localizedModelFactory;
            this._storeService = storeService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare store search model
        /// </summary>
        /// <param name="searchModel">Store search model</param>
        /// <returns>Store search model</returns>
        public virtual StoreSearchModel PrepareStoreSearchModel(StoreSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged store list model
        /// </summary>
        /// <param name="searchModel">Store search model</param>
        /// <returns>Store list model</returns>
        public virtual StoreListModel PrepareStoreListModel(StoreSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get stores
            var stores = _storeService.GetAllStores(loadCacheableCopy: false);

            //prepare list model
            var model = new StoreListModel
            {
                //fill in model values from the entity
                Data = stores.PaginationByRequestModel(searchModel).Select(store => store.ToModel<StoreModel>()),
                Total = stores.Count
            };

            return model;
        }

        /// <summary>
        /// Prepare store model
        /// </summary>
        /// <param name="model">Store model</param>
        /// <param name="store">Store</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Store model</returns>
        public virtual StoreModel PrepareStoreModel(StoreModel model, Store store, bool excludeProperties = false)
        {
            Action<StoreLocalizedModel, int> localizedModelConfiguration = null;

            if (store != null)
            {
                //fill in model values from the entity
                model = model ?? store.ToModel<StoreModel>();

                //define localized model configuration action
                localizedModelConfiguration = (locale, languageId) =>
                {
                    locale.Name = _localizationService.GetLocalized(store, entity => entity.Name, languageId, false, false);
                };
            }

            //prepare available languages
            _baseAdminModelFactory.PrepareLanguages(model.AvailableLanguages, defaultItemText: _localizationService.GetResource("Admin.Configuration.Stores.Fields.DefaultLanguage.DefaultItemText"));

            //prepare localized models
            if (!excludeProperties)
                model.Locales = _localizedModelFactory.PrepareLocalizedModels(localizedModelConfiguration);

            return model;
        }

        #endregion
    }
}