using GMAO.App.Interface;
using GMAO.App.Service;
using GMAO.Domain.Interfaces.Repository;
using GMAO.Domain.Interfaces.Service;
using GMAO.Domain.Service;
using GMAO.Infra.data.Repositories;
using GMAO.Infra.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Ioc
{
    public class IoC
    {
        private static IUnityContainer _Container;

        public IoC(IUnityContainer Container)
        {
            _Container = Container;
        }
        public void ResgitreType()
        {
            _Container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            _Container.RegisterType<IArticleRepository, ArticleRepository>();
            _Container.RegisterType<IAtelierRepository, AtelierRepository>();
            _Container.RegisterType<IRangementRepository, RangementRepository>();
            _Container.RegisterType<ICategorieOutillageRepository, CategorieOutillageRepository>();
            _Container.RegisterType<ICarr_EquipRepository, Carr_EquipRepository>();
            _Container.RegisterType<ICatt_EquipRepository, Catt_EquipRepository>();
            _Container.RegisterType<ICategoryRepository, CategoryRepository>();
            _Container.RegisterType<ICategorieClientRepository, CategorieClientRepository>();
            _Container.RegisterType<ICategorieEquipementRepository, CategorieEquipementRepository>();
            _Container.RegisterType<ICategoriePieceRechangeRepository, CategoriePieceRechangeRepository>();
            _Container.RegisterType<ICategorieFournisseurRepository, CategorieFournisseurRepository>();
            _Container.RegisterType<IClientRepository, ClientRepository>();
            _Container.RegisterType<ICompanyRepository, CompanyRepository>();
            _Container.RegisterType<ICompteurRepository, CompteurRepository>();
            _Container.RegisterType<IComposantRepository, ComposantRepository>();
            _Container.RegisterType<IConsigne_maintenanceRepository, Consigne_maintenanceRepository>();
            _Container.RegisterType<IConsMaintEquipementRepository, ConsMaintEquipementRepository>();
            _Container.RegisterType<IConsPieceRechangeRepository, ConsPieceRechangeRepository>();
            _Container.RegisterType<IDec_PanneRepository, Dec_PanneRepository>();
            _Container.RegisterType<IDepartementRepository, DepartementRepository>();
            _Container.RegisterType<IDocumentRepository, DocumentRepository>();
            _Container.RegisterType<IDeviseRepository, DeviseRepository>();
            _Container.RegisterType<IEmplacementRepository, EmplacementRepository>();
            _Container.RegisterType<IEquipementRepository, EquipementRepository>();
            _Container.RegisterType<IFonctionalityRepository, FonctionalityRepository>();
            _Container.RegisterType<IFournisseurRepository, FournisseurRepository>();
            _Container.RegisterType<IGroupUserRepository, GroupUserRepository>();
            _Container.RegisterType<IListeconsMaintEquipementRepository, ListeconsMaintEquipementRepository>();
            _Container.RegisterType<IMagasinRepository, MagasinRepository>();
            _Container.RegisterType<IModuleRepository, ModuleRepository>();
            _Container.RegisterType<IOrdre_de_travailRepository, Ordre_de_travailRepository>();
            _Container.RegisterType<IOTEmployeRepository, OTEmployeRepository>();
            _Container.RegisterType<IOTfournisseursRepository, OTfournisseursRepository>();
            _Container.RegisterType<IOTOutillageRepository, OTOutillageRepository>();
            _Container.RegisterType<IOTPieceRechangeRepository, OTPieceRechangeRepository>();
            _Container.RegisterType<IOutillageRepository, OutillageRepository>();
            _Container.RegisterType<IPersonnelRepository, PersonnelRepository>();
            _Container.RegisterType<IPhotoPanneRepository, PhotoPanneRepository>();
            _Container.RegisterType<IPieceRechangeRepository, PieceRechangeRepository>();
            _Container.RegisterType<IPoste_de_chargeRepository, Poste_de_chargeRepository>();
            _Container.RegisterType<IRightRepository, RightRepository>();
            _Container.RegisterType<ISiteRepository, SiteRepository>();
            _Container.RegisterType<IStockInRepository, StockInRepository>();
            _Container.RegisterType<IStockOutRepository, StockOutRepository>();
            _Container.RegisterType<ITestSchedulerRepository, TestSchedulerRepository>();
            _Container.RegisterType<IUserRepository, UserRepository>();





            _Container.RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>));
            _Container.RegisterType<IArticleService, ArticleService>();
            _Container.RegisterType<IAtelierService, AtelierService>();
            _Container.RegisterType<IRangementService, RangementService>();
            _Container.RegisterType<ICategorieOutillageService, CategorieOutillageService>();
            _Container.RegisterType<ICarr_EquipService, Carr_EquipService>();
            _Container.RegisterType<ICatt_EquipService, Catt_EquipService>();
            _Container.RegisterType<ICategoryService, CategoryService>();
            _Container.RegisterType<ICategorieClientService, CategorieClientService>();
            _Container.RegisterType<ICategorieEquipementService, CategorieEquipementService>();
            _Container.RegisterType<ICategoriePieceRechangeService, CategoriePieceRechangeService>();
            _Container.RegisterType<ICategorieFournisseurService, CategorieFournisseurService>();
            _Container.RegisterType<IClientService, ClientService>();
            _Container.RegisterType<ICompanyService, CompanyService>();
            _Container.RegisterType<ICompteurService, CompteurService>();
            _Container.RegisterType<IComposantService, ComposantService>();
            _Container.RegisterType<IConsigne_maintenanceService, Consigne_maintenanceService>();
            _Container.RegisterType<IConsMaintEquipementService, ConsMaintEquipementService>();
            _Container.RegisterType<IConsPieceRechangeService, ConsPieceRechangeService>();
            _Container.RegisterType<IDec_PanneService, Dec_PanneService>();
            _Container.RegisterType<IDepartementService, DepartementService>();
            _Container.RegisterType<IDocumentService, DocumentService>();
            _Container.RegisterType<IDeviseService, DeviseService>();
            _Container.RegisterType<IEmplacementService, EmplacementService>();
            _Container.RegisterType<IEquipementService, EquipementService>();
            _Container.RegisterType<IFonctionalityService, FonctionalityService>();
            _Container.RegisterType<IFournisseurService, FournisseurService>();
            _Container.RegisterType<IGroupUserService, GroupUserService>();
            _Container.RegisterType<IListeconsMaintEquipementService, ListeconsMaintEquipementService>();
            _Container.RegisterType<IMagasinService, MagasinService>();
            _Container.RegisterType<IModuleService, ModuleService>();
            _Container.RegisterType<IOrdre_de_travailService, Ordre_de_travailService>();
            _Container.RegisterType<IOTEmployeService, OTEmployeService>();
            _Container.RegisterType<IOTfournisseursService, OTfournisseursService>();
            _Container.RegisterType<IOTOutillageService, OTOutillageService>();
            _Container.RegisterType<IOTPieceRechangeService, OTPieceRechangeService>();
            _Container.RegisterType<IOutillageService, OutillageService>();
            _Container.RegisterType<IPersonnelService, PersonnelService>();
            _Container.RegisterType<IPhotoPanneService, PhotoPanneService>();
            _Container.RegisterType<IPieceRechangeService, PieceRechangeService>();
            _Container.RegisterType<IPoste_de_chargeService, Poste_de_chargeService>();
            _Container.RegisterType<IRightService, RightService>();
            _Container.RegisterType<ISiteService, SiteService>();
            _Container.RegisterType<IStockInService, StockInService>();
            _Container.RegisterType<IStockOutService, StockOutService>();
            _Container.RegisterType<ITestSchedulerService, TestSchedulerService>();
            _Container.RegisterType<IUserService, UserService>();





            _Container.RegisterType<IAppArticleService, ArticleAppService>();
            _Container.RegisterType<IAppAtelierService, AtelierAppService>();
            _Container.RegisterType<IAppRangementService, RangementAppService>();
            _Container.RegisterType<IAppCategorieOutillageService, CategorieOutillageAppService>();
            _Container.RegisterType<IAppCarr_EquipService, Carr_EquipAppService>();
            _Container.RegisterType<IAppCatt_EquipService, Catt_EquipAppService>();
            _Container.RegisterType<IAppCategoryService, CategoryAppService>();
            _Container.RegisterType<IAppCategorieClientService, CategorieClientAppService>();
            _Container.RegisterType<IAppCategorieEquipementService, CategorieEquipementAppService>();
            _Container.RegisterType<IAppCategoriePieceRechangeService, CategoriePieceRechangeAppService>();
            _Container.RegisterType<IAppCategorieFournisseurService, CategorieFournisseurAppService>();
            _Container.RegisterType<IAppClientService, ClientAppService>();
            _Container.RegisterType<IAppCompanyService, CompanyAppService>();
            _Container.RegisterType<IAppCompteurService, CompteurAppService>();
            _Container.RegisterType<IAppComposantService, ComposantAppService>();
            _Container.RegisterType<IAppConsigne_maintenanceService, Consigne_maintenanceAppService>();
            _Container.RegisterType<IAppConsMaintEquipementService, ConsMaintEquipementAppService>();
            _Container.RegisterType<IAppConsPieceRechangeService, ConsPieceRechangeAppService>();
            _Container.RegisterType<IAppDec_PanneService, Dec_PanneAppService>();
            _Container.RegisterType<IAppDepartementService, DepartementAppService>();
            _Container.RegisterType<IAppDocumentService, DocumentAppService>();
            _Container.RegisterType<IAppDeviseService, DeviseAppService>();
            _Container.RegisterType<IAppEmplacementService, EmplacementAppService>();
            _Container.RegisterType<IAppEquipementService, EquipementAppService>();
            _Container.RegisterType<IAppFonctionalityService, FonctionalityAppService>();
            _Container.RegisterType<IAppFournisseurService, FournisseurAppService>();
            _Container.RegisterType<IAppGroupUserService, GroupUserAppService>();
            _Container.RegisterType<IAppListeconsMaintEquipementService, ListeconsMaintEquipementAppService>();
            _Container.RegisterType<IAppMagasinService, MagasinAppService>();
            _Container.RegisterType<IAppModuleService, ModuleAppService>();
            _Container.RegisterType<IAppOrdre_de_travailService, Ordre_de_travailAppService>();
            _Container.RegisterType<IAppOTEmployeService, OTEmployeAppService>();
            _Container.RegisterType<IAppOTfournisseursService, OTfournisseursAppService>();
            _Container.RegisterType<IAppOTOutillageService, OTOutillageAppService>();
            _Container.RegisterType<IAppOTPieceRechangeService, OTPieceRechangeAppService>();
            _Container.RegisterType<IAppOutillageService, OutillageAppService>();
            _Container.RegisterType<IAppPersonnelService, PersonnelAppService>();
            _Container.RegisterType<IAppPhotoPanneService, PhotoPanneAppService>();
            _Container.RegisterType<IAppPieceRechangeService, PieceRechangeAppService>();
            _Container.RegisterType<IAppPoste_de_chargeService, Poste_de_chargeAppService>();
            _Container.RegisterType<IAppRightService, RightAppService>();
            _Container.RegisterType<IAppSiteService, SiteAppService>();
            _Container.RegisterType<IAppStockOutService, StockOutAppService>();
            _Container.RegisterType<IAppStockInService, StockInAppService>();
            _Container.RegisterType<IAppTestSchedulerService, TestSchedulerAppService>();
            _Container.RegisterType<IAppUserService, UserAppService>();









        }





    }
}

