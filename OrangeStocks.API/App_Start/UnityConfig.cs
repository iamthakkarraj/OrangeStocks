using System.Web.Http;
using Unity;
using Unity.WebApi;
using OrangeStocks.BLL.Unity;
using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using OrangeStocks.BLL.Managers;

namespace OrangeStocks.API {
    public static class UnityConfig {
        public static void RegisterComponents() {
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(
                new UnityContainer()
                    .RegisterType<ICRUDServiceFactory<TransactionTypeModel>,
                        CRUDServiceFactory<TransactionTypeModel>>()
                    .RegisterType<ICRUDServiceFactory<TransactionModel>,
                        CRUDServiceFactory<TransactionModel>>()
                    .RegisterType<ICRUDServiceFactory<TransactionDetailModel>,
                        CRUDServiceFactory<TransactionDetailModel>>() 
                    .RegisterType<ICRUDServiceFactory<CustomerModel>,
                        CRUDServiceFactory<CustomerModel>>()
                    .RegisterType<ICRUDServiceFactory<VendorModel>,
                        CRUDServiceFactory<VendorModel>>()
                    .RegisterType<ICRUDServiceFactory<StockItemModel>,
                        CRUDServiceFactory<StockItemModel>>()
                    .RegisterType<ICRUDServiceFactory<StockItemCategoryModel>,
                        CRUDServiceFactory<StockItemCategoryModel>>()
                    .RegisterType<ICRUDServiceFactory<UserModel>,
                        CRUDServiceFactory<UserModel>>()
                    .AddNewExtension<BLLUnityExtenstion>()
            );            
        }
    }
}