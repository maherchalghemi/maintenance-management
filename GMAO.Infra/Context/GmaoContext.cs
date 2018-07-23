using GMAO.Domain.Entities;
using GMAO.Infra.data.EntityConfig;
using GMAO.Infra.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.Context
{

    
    public partial class GmaoContext : DbContext
    {
       static GmaoContext()
        {
            Database.SetInitializer<GmaoContext>(null);
        }
        


        public GmaoContext()
            : base("Name=GmaoContext")
        {
           // Database.SetInitializer<GmaoContext>(new CreateDatabaseIfNotExists<GmaoContext>());
        }


        public DbSet<Client> clients { get; set; }
        public DbSet<Fournisseur> fournisseurs { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Atelier> ateliers { get; set; }
        public DbSet<Carr_Equip> carr_Equips { get; set; }
        public DbSet<Catt_Equip> catt_Equips { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<CategorieFournisseur> categorieFournisseurs { get; set; }
        public DbSet<CategorieClient> categorieClients { get; set; }
        public DbSet<CategorieEquipement> categorieEquipements { get; set; }
        public DbSet<CategoriePieceRechange> categoriePieceRechanges { get; set; }
        public DbSet<CategorieOutillage> categorieOutillages { get; set; }
        public DbSet<Rangement> rangements { get; set; }
        public DbSet<Company> companys { get; set; }
        public DbSet<Compteur> compteurs { get; set; }
        public DbSet<Composant> composant { get; set; }
        public DbSet<Consigne_maintenance> consigne_maintenances { get; set; }
        public DbSet<ConsMaintEquipement> consMaintEquipements { get; set; }
        public DbSet<ConsPieceRechange> consPieceRechanges { get; set; }
        public DbSet<Dec_Panne> dec_Pannes { get; set; }
        public DbSet<Departement> departements { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<Devise> devise { get; set; }
        public DbSet<Emplacement> equipements { get; set; }
        public DbSet<Equipement> emplacements { get; set; }
        public DbSet<Fonctionality> fonctionalitys { get; set; }
        public DbSet<GroupUser> groupUsers { get; set; }
        public DbSet<ListeconsMaintEquipement> listeconsMaintEquipements { get; set; }
        public DbSet<Magasin> magasins { get; set; }
        public DbSet<Module> modules { get; set; }
        public DbSet<Ordre_de_travail> ordre_de_travails { get; set; }
        public DbSet<OTEmploye> oTEmployes { get; set; }
        public DbSet<OTfournisseurs> oTfournisseurss { get; set; }
        public DbSet<OTOutillage> oTOutillages { get; set; }
        public DbSet<OTPieceRechange> oTPieceRechanges { get; set; }
        public DbSet<Outillage> outillages { get; set; }
        public DbSet<Personnel> personnels { get; set; }
        public DbSet<PhotoPanne> photoPannes { get; set; }
        public DbSet<PieceRechange> pieceRechanges { get; set; }
        public DbSet<Poste_de_charge> poste_de_charges { get; set; }
        public DbSet<Right> rights { get; set; }
        public DbSet<Site> sites { get; set; }
        public DbSet<StockIn> stockIns { get; set; }
        public DbSet<StockOut> stockOuts { get; set; }
        public DbSet<TestScheduler> testSchedulers { get; set; }
        public DbSet<User> users { get; set; }
       


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new FournisseurMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new AtelierMap());
            modelBuilder.Configurations.Add(new Carr_EquipMap());
            modelBuilder.Configurations.Add(new Catt_EquipMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CategorieEquipementMap());
            modelBuilder.Configurations.Add(new CategoriePieceRechangeMap());
            modelBuilder.Configurations.Add(new CategorieClientMap());
            modelBuilder.Configurations.Add(new CategorieOutillageMap());
            modelBuilder.Configurations.Add(new RangementMap());
            modelBuilder.Configurations.Add(new CategorieFournisseurMap());
            modelBuilder.Configurations.Add(new CompteurMap());
            modelBuilder.Configurations.Add(new Consigne_maintenanceMap());
            modelBuilder.Configurations.Add(new ConsMaintEquipementMap());
            modelBuilder.Configurations.Add(new ConsPieceRechangeMap());
            modelBuilder.Configurations.Add(new Dec_PanneMap());
            modelBuilder.Configurations.Add(new DepartementMap());
            modelBuilder.Configurations.Add(new DeviseMap());
            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new EmplacementMap());
            modelBuilder.Configurations.Add(new EquipementMap());
            modelBuilder.Configurations.Add(new FonctionalityMap());
            modelBuilder.Configurations.Add(new GroupUserMap());
            modelBuilder.Configurations.Add(new ListeconsMaintEquipementMap());
            modelBuilder.Configurations.Add(new MagasinMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new Ordre_de_travailMap());
            modelBuilder.Configurations.Add(new OTEmployeMap());
            modelBuilder.Configurations.Add(new OTfournisseursMap());
            modelBuilder.Configurations.Add(new OTOutillageMap());
            modelBuilder.Configurations.Add(new OTPieceRechangeMap());
            modelBuilder.Configurations.Add(new OutillageMap());
            modelBuilder.Configurations.Add(new PersonnelMap());
            modelBuilder.Configurations.Add(new PhotoPanneMap());
            modelBuilder.Configurations.Add(new PieceRechangeMap());
            modelBuilder.Configurations.Add(new Poste_de_chargeMap());
            modelBuilder.Configurations.Add(new RightMap());
            modelBuilder.Configurations.Add(new SiteMap());
            modelBuilder.Configurations.Add(new StockInMap());
            modelBuilder.Configurations.Add(new StockOutMap());
            modelBuilder.Configurations.Add(new TestSchedulerMap());
            modelBuilder.Configurations.Add(new UserMap());
 
            
          
        }

    }
}
