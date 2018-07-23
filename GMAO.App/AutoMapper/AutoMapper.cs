using AutoMapper;
using GMAO.App.Entities;
using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.AutoMapper
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ArticleProfile());
                cfg.AddProfile(new AtelierProfile());
                cfg.AddProfile(new RangementProfile());
                cfg.AddProfile(new CategorieOutillageProfile());
                cfg.AddProfile(new Carr_EquipProfile());
                cfg.AddProfile(new Catt_EquipProfile());
                cfg.AddProfile(new ClientProfile());
                cfg.AddProfile(new CompanyProfile());
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new CategorieFournisseurProfile());
                cfg.AddProfile(new CategorieEquipementProfile());
                cfg.AddProfile(new CategoriePieceRechangeProfile());
                cfg.AddProfile(new CategorieClientProfile());
                cfg.AddProfile(new CompteurProfile());
                cfg.AddProfile(new ComposantProfile());
                cfg.AddProfile(new Consigne_maintenanceProfile());
                cfg.AddProfile(new ConsMaintEquipementProfile());
                cfg.AddProfile(new ConsPieceRechangeProfile());
                cfg.AddProfile(new Dec_PanneProfile());
                cfg.AddProfile(new DepartementProfile());
                cfg.AddProfile(new DeviseProfile());
                cfg.AddProfile(new DocumentProfile());
                cfg.AddProfile(new EmplacementProfile());
                cfg.AddProfile(new EquipementProfile());
                cfg.AddProfile(new FonctionalityProfile());
                cfg.AddProfile(new FournisseurProfile());
                cfg.AddProfile(new GroupUserProfile());
                cfg.AddProfile(new ListeconsMaintEquipementProfile());
                cfg.AddProfile(new MagasinProfile());
                cfg.AddProfile(new ModuleProfile());
                cfg.AddProfile(new Ordre_de_travailProfile());
                cfg.AddProfile(new OTEmployeProfile());
                cfg.AddProfile(new OTfournisseursProfile());
                cfg.AddProfile(new OTOutillageProfile());
                cfg.AddProfile(new OTPieceRechangeProfile());
                cfg.AddProfile(new OutillageProfile());
                cfg.AddProfile(new PersonnelProfile());
                cfg.AddProfile(new PhotoPanneProfile());
                cfg.AddProfile(new PieceRechangeProfile());
                cfg.AddProfile(new Poste_de_chargeProfile());
                cfg.AddProfile(new RightProfile());
                cfg.AddProfile(new SiteProfile());
                cfg.AddProfile(new StockInProfile());
                cfg.AddProfile(new StockOutProfile());
                cfg.AddProfile(new TestSchedulerProfile());
                cfg.AddProfile(new UserProfile());

            });
        }
    }

    public class ArticleProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Article, Article_DTO>();
            Mapper.CreateMap<Article_DTO, Article>();


        }
    }

    public class AtelierProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Atelier, Atelier_DTO>();
            Mapper.CreateMap<Atelier_DTO, Atelier>();


        }
    }

    public class RangementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Rangement, Rangement_DTO>();
            Mapper.CreateMap<Rangement_DTO, Rangement>();


        }
    }

    public class CategorieOutillageProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategorieOutillage, CategorieOutillage_DTO>();
            Mapper.CreateMap<CategorieOutillage_DTO, CategorieOutillage>();


        }
    }
	
	
    public class Carr_EquipProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Carr_Equip, Carr_Equip_DTO>();
            Mapper.CreateMap<Carr_Equip_DTO, Carr_Equip>();


        }
    }


    public class Catt_EquipProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Catt_Equip, Catt_Equip_DTO>();
            Mapper.CreateMap<Catt_Equip_DTO, Catt_Equip>();


        }
    }

    public class CategoryProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Category, Category_DTO>();
            Mapper.CreateMap<Category_DTO, Category>();


        }
    }


    public class CategorieFournisseurProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategorieFournisseur, CategorieFournisseur_DTO>();
            Mapper.CreateMap<CategorieFournisseur_DTO, CategorieFournisseur>();


        }
    }


    public class CategorieEquipementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategorieEquipement, CategorieEquipement_DTO>();
            Mapper.CreateMap<CategorieEquipement_DTO, CategorieEquipement>();


        }
    }



    public class CategoriePieceRechangeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategoriePieceRechange, CategoriePieceRechange_DTO>();
            Mapper.CreateMap<CategoriePieceRechange_DTO, CategoriePieceRechange>();


        }
    }

    public class CategorieClientProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategorieClient, CategorieClient_DTO>();
            Mapper.CreateMap<CategorieClient_DTO, CategorieClient>();


        }
    }

    public class ClientProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Client, Client_DTO>();
            Mapper.CreateMap<Client_DTO, Client>();


        }
    }


    public class CompanyProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Company, Company_DTO>();
            Mapper.CreateMap<Company_DTO, Company>();


        }
    }


    public class CompteurProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Compteur, Compteur_DTO>();
            Mapper.CreateMap<Compteur_DTO, Compteur>();


        }
    }

    public class ComposantProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Composant, Composant_DTO>();
            Mapper.CreateMap<Composant_DTO, Composant>();


        }
    }

    public class Consigne_maintenanceProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Consigne_maintenance, Consigne_maintenance_DTO>();
            Mapper.CreateMap<Consigne_maintenance_DTO, Consigne_maintenance>();


        }
    }

    public class ConsMaintEquipementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ConsMaintEquipement, ConsMaintEquipement_DTO>();
            Mapper.CreateMap<ConsMaintEquipement_DTO, ConsMaintEquipement>();


        }
    }


    public class ConsPieceRechangeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ConsPieceRechange, ConsPieceRechange_DTO>();
            Mapper.CreateMap<ConsPieceRechange_DTO, ConsPieceRechange>();


        }
    }

    public class Dec_PanneProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Dec_Panne, Dec_Panne_DTO>();
            Mapper.CreateMap<Dec_Panne_DTO, Dec_Panne>();


        }
    }

    public class DepartementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Departement, Departement_DTO>();
            Mapper.CreateMap<Departement_DTO, Departement>();


        }
    }
    public class DeviseProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Devise, Devise_DTO>();
            Mapper.CreateMap<Devise_DTO, Devise>();


        }
    }

    public class DocumentProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Document, Document_DTO>();
            Mapper.CreateMap<Document_DTO, Document>();


        }
    }

    public class EmplacementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Emplacement, Emplacement_DTO>();
            Mapper.CreateMap<Emplacement_DTO, Emplacement>();


        }
    }

    public class EquipementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Equipement, Equipement_DTO>();
            Mapper.CreateMap<Equipement_DTO, Equipement>();


        }
    }


    public class FonctionalityProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Fonctionality, Fonctionality_DTO>();
            Mapper.CreateMap<Fonctionality_DTO, Fonctionality>();


        }
    }

    public class FournisseurProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Fournisseur, Fournisseur_DTO>();
            Mapper.CreateMap<Fournisseur_DTO, Fournisseur>();


        }
    }

    public class GroupUserProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<GroupUser, GroupUser_DTO>();
            Mapper.CreateMap<GroupUser_DTO, GroupUser>();


        }
    }

    public class ListeconsMaintEquipementProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ListeconsMaintEquipement, ListeconsMaintEquipement_DTO>();
            Mapper.CreateMap<ListeconsMaintEquipement_DTO, ListeconsMaintEquipement>();


        }
    }

    public class MagasinProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Magasin, Magasin_DTO>();
            Mapper.CreateMap<Magasin_DTO, Magasin>();


        }
    }


    public class ModuleProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Module, Module_DTO>();
            Mapper.CreateMap<Module_DTO, Module>();


        }
    }


    public class Ordre_de_travailProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Ordre_de_travail, Ordre_de_travail_DTO>();
            Mapper.CreateMap<Ordre_de_travail_DTO, Ordre_de_travail>();


        }
    }

    public class OTEmployeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<OTEmploye, OTEmploye_DTO>();
            Mapper.CreateMap<OTEmploye_DTO, OTEmploye>();


        }
    }

    public class OTfournisseursProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<OTfournisseurs, OTfournisseurs_DTO>();
            Mapper.CreateMap<OTfournisseurs_DTO, OTfournisseurs>();


        }
    }

    public class OTOutillageProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<OTOutillage, OTOutillage_DTO>();
            Mapper.CreateMap<OTOutillage_DTO, OTOutillage>();


        }
    }

    public class OTPieceRechangeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<OTPieceRechange, OTPieceRechange_DTO>();
            Mapper.CreateMap<OTPieceRechange_DTO, OTPieceRechange>();


        }
    }

    public class OutillageProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Outillage, Outillage_DTO>();
            Mapper.CreateMap<Outillage_DTO, Outillage>();


        }
    }

    public class PersonnelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Personnel, Personnel_DTO>();
            Mapper.CreateMap<Personnel_DTO, Personnel>();


        }
    }

    public class PhotoPanneProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PhotoPanne, PhotoPanne_DTO>();
            Mapper.CreateMap<PhotoPanne_DTO, PhotoPanne>();


        }
    }


    public class PieceRechangeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PieceRechange, PieceRechange_DTO>();
            Mapper.CreateMap<PieceRechange_DTO, PieceRechange>();


        }
    }


    public class Poste_de_chargeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Poste_de_charge, Poste_de_charge_DTO>();
            Mapper.CreateMap<Poste_de_charge_DTO, Poste_de_charge>();


        }
    }


    public class RightProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Right, Right_DTO>();
            Mapper.CreateMap<Right_DTO, Right>();


        }
    }



    public class SiteProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Site, Site_DTO>();
            Mapper.CreateMap<Site_DTO, Site>();


        }
    }

    public class StockOutProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<StockOut, StockOut_DTO>();
            Mapper.CreateMap<StockOut_DTO, StockOut>();


        }
    }

    public class StockInProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<StockIn, StockIn_DTO>();
            Mapper.CreateMap<StockIn_DTO, StockIn>();


        }
    }

    public class TestSchedulerProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TestScheduler, TestScheduler_DTO>();
            Mapper.CreateMap<TestScheduler_DTO, TestScheduler>();


        }
    }



    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, User_DTO>();
            Mapper.CreateMap<User_DTO, User>();


        }
    }
}
