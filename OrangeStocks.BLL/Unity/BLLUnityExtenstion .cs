using Unity;
using Unity.Extension;
using OrangeStocks.DLL.Interfaces;
using OrangeStocks.DLL.Services;
using OrangeStokcs.DLL.EDMX;
using OrangeStocks.BLL.Managers;
using OrangeStocks.Core.Entity;
using OrangeStocks.BLL.Interfaces;

namespace OrangeStocks.BLL.Unity {

    public class BLLUnityExtenstion : UnityContainerExtension {

        protected override void Initialize() {

            Container
                //DB Service Class Mappings
                .RegisterType<IOrangeStocksDBService<TransactionType>, OrangeStocksDBService<TransactionType>>()
                .RegisterType<IOrangeStocksDBService<Transaction>, OrangeStocksDBService<Transaction>>()
                .RegisterType<IOrangeStocksDBService<TransactionDetail>, OrangeStocksDBService<TransactionDetail>>()
                .RegisterType<IOrangeStocksDBService<User>, OrangeStocksDBService<User>>()
                .RegisterType<IOrangeStocksDBService<Vendor>, OrangeStocksDBService<Vendor>>()
                .RegisterType<IOrangeStocksDBService<StockItem>, OrangeStocksDBService<StockItem>>()
                .RegisterType<IOrangeStocksDBService<StockItemCategory>, OrangeStocksDBService<StockItemCategory>>()
                .RegisterType<IOrangeStocksDBService<Role>, OrangeStocksDBService<Role>>()
                .RegisterType<IOrangeStocksDBService<Customer>, OrangeStocksDBService<Customer>>()
                //CRUD Service Class Mappings
                .RegisterType<IOrangeStocksCRUDService<CustomerModel>, OrangeStocksCRUDService<CustomerModel, Customer>>()
                .RegisterType<IOrangeStocksCRUDService<VendorModel>, OrangeStocksCRUDService<VendorModel, Vendor>>()
                .RegisterType<IOrangeStocksCRUDService<StockItemCategoryModel>, OrangeStocksCRUDService<StockItemCategoryModel, StockItemCategory>>()
                .RegisterType<IOrangeStocksCRUDService<StockItemModel>, OrangeStocksCRUDService<StockItemModel, StockItem>>()
                .RegisterType<IOrangeStocksCRUDService<TransactionTypeModel>, OrangeStocksCRUDService<TransactionTypeModel, TransactionType>>()
                .RegisterType<IOrangeStocksCRUDService<TransactionModel>, OrangeStocksCRUDService<TransactionModel, Transaction>>()
                .RegisterType<IOrangeStocksCRUDService<TransactionDetailModel>, OrangeStocksCRUDService<TransactionDetailModel, TransactionDetail>>()
                .RegisterType<IOrangeStocksCRUDService<UserModel>, OrangeStocksCRUDService<UserModel, User>>()
                .RegisterType<IOrangeStocksCRUDService<RoleModel>, OrangeStocksCRUDService<RoleModel, Role>>();

        }

    }
}