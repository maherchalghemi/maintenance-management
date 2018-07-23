namespace GMAO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        Nature = c.Int(nullable: false),
                        PrixRevient = c.Single(nullable: false),
                        IDFamille = c.Int(nullable: false),
                        CractTechnique = c.String(nullable: false, unicode: false),
                        IDSite = c.Int(nullable: false),
                        IDSociete = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                        Reference = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompteActif = c.Boolean(nullable: false),
                        loex = c.Boolean(nullable: false),
                        Banque = c.String(unicode: false),
                        nb_bl = c.Int(nullable: false),
                        NCompte = c.String(unicode: false),
                        civilite = c.String(unicode: false),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        DateModification = c.DateTime(nullable: false, precision: 0),
                        MatriculeFiscal = c.String(unicode: false),
                        CodeInterne = c.String(nullable: false, unicode: false),
                        NomContact = c.String(nullable: false, unicode: false),
                        Email = c.String(unicode: false),
                        EmailF = c.String(unicode: false),
                        Tel = c.String(unicode: false),
                        TelF = c.String(unicode: false),
                        Domiciliation = c.String(unicode: false),
                        Adresse1 = c.String(unicode: false),
                        Adresse2 = c.String(unicode: false),
                        nbFacture = c.Int(),
                        delaiLiv = c.Int(),
                        escompte = c.Single(),
                        Fax = c.String(unicode: false),
                        FaxF = c.String(unicode: false),
                        IBAN = c.String(unicode: false),
                        observation = c.String(unicode: false),
                        UR = c.String(unicode: false),
                        RefFour = c.String(unicode: false),
                        siret = c.String(unicode: false),
                        codeDouane = c.String(unicode: false),
                        codeTVA = c.String(unicode: false),
                        SWIFT = c.String(unicode: false),
                        VILLE = c.String(unicode: false),
                        VILLEF = c.String(unicode: false),
                        CCP = c.String(unicode: false),
                        CCPF = c.String(unicode: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Right",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupUser_Id = c.Int(nullable: false),
                        fonctionality_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fonctionality", t => t.fonctionality_Id, cascadeDelete: true)
                .ForeignKey("dbo.GroupUser", t => t.GroupUser_Id, cascadeDelete: true)
                .Index(t => t.GroupUser_Id)
                .Index(t => t.fonctionality_Id);
            
            CreateTable(
                "dbo.Fonctionality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, unicode: false),
                        Categorie = c.String(nullable: false, unicode: false),
                        IsMenu = c.Boolean(nullable: false),
                        Controler = c.String(nullable: false, unicode: false),
                        Action = c.String(nullable: false, unicode: false),
                        JavaAction = c.String(nullable: false, unicode: false),
                        Icon = c.String(nullable: false, unicode: false),
                        Module_Id = c.Int(nullable: false),
                        Group = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        GroupUser_Id = c.Int(nullable: false),
                        Personnel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupUser", t => t.GroupUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnel", t => t.Personnel_Id, cascadeDelete: true)
                .Index(t => t.GroupUser_Id)
                .Index(t => t.Personnel_Id);
            
            CreateTable(
                "dbo.Personnel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, unicode: false),
                        Prenom = c.String(nullable: false, unicode: false),
                        NomPrenom = c.String(unicode: false),
                        DateNaissance = c.DateTime(precision: 0),
                        Adresse = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        DateAjout = c.DateTime(precision: 0),
                        CIN = c.String(unicode: false),
                        CNSS = c.String(unicode: false),
                        Photo = c.String(unicode: false),
                        Sexe = c.String(unicode: false),
                        Integre = c.Boolean(),
                        DebutIntegration = c.DateTime(precision: 0),
                        FinIntegration = c.DateTime(precision: 0),
                        IDService = c.Int(),
                        Tel = c.String(unicode: false),
                        Matricule = c.String(nullable: false, unicode: false),
                        Diplomes = c.String(unicode: false),
                        AutresCompetances = c.String(unicode: false),
                        AptitudesPhysiques = c.String(unicode: false),
                        ExperienceProfessionelles = c.String(unicode: false),
                        Actif = c.Boolean(),
                        EstTitulaire = c.Boolean(),
                        DateTitularisation = c.DateTime(precision: 0),
                        Grade = c.String(unicode: false),
                        NomPre = c.String(unicode: false),
                        IDSite = c.Int(),
                        IDSociete = c.Int(),
                        CINDELIVRELE = c.DateTime(precision: 0),
                        CINDELIVREA = c.String(unicode: false),
                        LNAISSANCE = c.String(unicode: false),
                        TELDOM = c.String(unicode: false),
                        GSM = c.String(unicode: false),
                        DLIQUIDATION = c.DateTime(precision: 0),
                        RIP = c.String(unicode: false),
                        MAXCONGE = c.Single(),
                        IdCompany = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dec_Panne",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(nullable: false, unicode: false),
                        Heure_Dec_Panne = c.String(nullable: false, unicode: false),
                        Date_Dec_Panne = c.DateTime(nullable: false, precision: 0),
                        Heure_Arr_Panne = c.String(nullable: false, unicode: false),
                        Date_Arr_Panne = c.DateTime(nullable: false, precision: 0),
                        Symtome = c.String(nullable: false, unicode: false),
                        Action_Imediate = c.String(nullable: false, unicode: false),
                        Diagnostic = c.String(nullable: false, unicode: false),
                        Id_Personnel = c.Int(nullable: false),
                        Id_Equipement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipement", t => t.Id_Equipement, cascadeDelete: true)
                .ForeignKey("dbo.Personnel", t => t.Id_Personnel, cascadeDelete: true)
                .Index(t => t.Id_Personnel)
                .Index(t => t.Id_Equipement);
            
            CreateTable(
                "dbo.Equipement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeEquipement = c.String(nullable: false, unicode: false),
                        NumEquipement = c.String(unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        NumModel = c.String(unicode: false),
                        NumSerie = c.String(unicode: false),
                        Marque = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Code_poste = c.String(unicode: false),
                        Code_categorie = c.String(unicode: false),
                        codeclient = c.String(unicode: false),
                        EtatEquipement = c.String(unicode: false),
                        nb_eq = c.String(unicode: false),
                        Nature_Heure_Travail = c.String(unicode: false),
                        Photo = c.Binary(),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        Poste_de_charge_Id = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consigne_maintenance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        Cod_doc = c.String(unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        niveau = c.String(unicode: false),
                        photo = c.Binary(),
                        Nb_interv_suggéré = c.Int(),
                        Duré_cons_h = c.String(unicode: false),
                        Code_Consigne = c.String(nullable: false, unicode: false),
                        Duré_cons_jr = c.Int(),
                        Equipement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipement", t => t.Equipement_Id)
                .Index(t => t.Equipement_Id);
            
            CreateTable(
                "dbo.ListeconsMaintEquipement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, unicode: false),
                        libellé = c.String(nullable: false, unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        Cod_doc = c.String(nullable: false, unicode: false),
                        Date_creation = c.DateTime(nullable: false, precision: 0),
                        date_Modification = c.DateTime(nullable: false, precision: 0),
                        niveau = c.String(nullable: false, unicode: false),
                        Duree_Standard_JR = c.Int(nullable: false),
                        Duree_Standard_hhmm = c.String(nullable: false, unicode: false),
                        photo = c.Binary(nullable: false),
                        Nb_interv_suggéré = c.Int(nullable: false),
                        fréquence = c.Int(nullable: false),
                        NumEquipement = c.String(nullable: false, unicode: false),
                        date_fin = c.DateTime(nullable: false, precision: 0),
                        date_début = c.DateTime(nullable: false, precision: 0),
                        STime = c.String(nullable: false, unicode: false),
                        ETime = c.String(nullable: false, unicode: false),
                        alerte = c.Single(nullable: false),
                        Duré_cons_h = c.String(nullable: false, unicode: false),
                        Code_Consigne = c.String(nullable: false, unicode: false),
                        type = c.String(nullable: false, unicode: false),
                        CodeCompt = c.String(nullable: false, unicode: false),
                        periodicite = c.Int(nullable: false),
                        indice_gen = c.Int(nullable: false),
                        Duré_cons_jr = c.Int(nullable: false),
                        tYpe_planning = c.String(nullable: false, unicode: false),
                        Départ_Compt = c.Single(nullable: false),
                        Equipements_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipement", t => t.Equipements_Id, cascadeDelete: true)
                .Index(t => t.Equipements_Id);
            
            CreateTable(
                "dbo.ConsPieceRechange",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListConsM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListeconsMaintEquipement", t => t.ListConsM_Id, cascadeDelete: true)
                .Index(t => t.ListConsM_Id);
            
            CreateTable(
                "dbo.Ordre_de_travail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefDecPanne = c.Int(nullable: false),
                        TypePanne = c.String(nullable: false, unicode: false),
                        Code_OT = c.String(nullable: false, unicode: false),
                        DescriptionPanne = c.String(nullable: false, unicode: false),
                        Coût_tot_reel = c.Double(nullable: false),
                        Coût_pieces_de_rechanges_planifie = c.Double(nullable: false),
                        cout_Intervenant_planifie = c.Double(nullable: false),
                        Causepanne = c.String(nullable: false, unicode: false),
                        Priorite = c.String(nullable: false, unicode: false),
                        Cout_tot_Planifie = c.Double(nullable: false),
                        Duree_total_Reel = c.String(nullable: false, unicode: false),
                        Nom_inter = c.String(nullable: false, unicode: false),
                        dure_int_planifie = c.String(nullable: false, unicode: false),
                        cout_int_reel = c.Double(nullable: false),
                        duree_int_reel = c.String(nullable: false, unicode: false),
                        statut = c.String(nullable: false, unicode: false),
                        Declarant = c.String(nullable: false, unicode: false),
                        Moye_declaration = c.String(nullable: false, unicode: false),
                        Date_declaration = c.DateTime(nullable: false, precision: 0),
                        Heure_declaration = c.String(nullable: false, unicode: false),
                        Action_immediate = c.String(nullable: false, unicode: false),
                        degre_urgence = c.String(nullable: false, unicode: false),
                        Duree_total_planifie = c.String(nullable: false, unicode: false),
                        Nom_int_reel = c.String(nullable: false, unicode: false),
                        date_lancement_OT = c.DateTime(nullable: false, precision: 0),
                        Date_Debut_planifie = c.DateTime(nullable: false, precision: 0),
                        date_debut_prevu_ext = c.DateTime(nullable: false, precision: 0),
                        date_debut_reelle_ext = c.DateTime(nullable: false, precision: 0),
                        Coût_pieces_de_rechanges_reel = c.Double(nullable: false),
                        Date_mise_en_marche = c.DateTime(nullable: false, precision: 0),
                        Heure_mise_en_marche = c.String(nullable: false, unicode: false),
                        date_debut_OT = c.DateTime(nullable: false, precision: 0),
                        Date_fin_Ot = c.DateTime(nullable: false, precision: 0),
                        Cause_annulation = c.String(nullable: false, unicode: false),
                        Date_annulation = c.DateTime(nullable: false, precision: 0),
                        date_clôture = c.DateTime(nullable: false, precision: 0),
                        Rapport_Intervention = c.String(nullable: false, unicode: false),
                        Duree_ext_reel_jr = c.String(nullable: false, unicode: false),
                        Duree_ext_planifie_jr = c.String(nullable: false, unicode: false),
                        duree_tot_planif_jr = c.String(nullable: false, unicode: false),
                        duree_tot_reel_jr = c.String(nullable: false, unicode: false),
                        Type_ECO = c.String(nullable: false, unicode: false),
                        commentaire_EXT = c.String(nullable: false, unicode: false),
                        Heure_Debut_OT = c.String(nullable: false, unicode: false),
                        heuer_fin_ot = c.String(nullable: false, unicode: false),
                        Date_Fin_Estimee = c.DateTime(nullable: false, precision: 0),
                        MesureCompteurPN = c.String(nullable: false, unicode: false),
                        MesureCompteurREM = c.String(nullable: false, unicode: false),
                        DiagnosticPanne = c.String(nullable: false, unicode: false),
                        Ressource_Arrêtee = c.Boolean(nullable: false),
                        Date_arret = c.DateTime(nullable: false, precision: 0),
                        Heure_arrêt = c.String(nullable: false, unicode: false),
                        OT_Personnel_Id = c.Int(nullable: false),
                        Equipement_Id = c.Int(nullable: false),
                        Personnel_Id = c.Int(nullable: false),
                        cArr_Equip_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carr_Equip", t => t.cArr_Equip_Id, cascadeDelete: true)
                .ForeignKey("dbo.Equipement", t => t.Equipement_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnel", t => t.Personnel_Id, cascadeDelete: true)
                .Index(t => t.Equipement_Id)
                .Index(t => t.Personnel_Id)
                .Index(t => t.cArr_Equip_Id);
            
            CreateTable(
                "dbo.Carr_Equip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code_cause = c.String(nullable: false, unicode: false),
                        libelle = c.String(nullable: false, unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        taux_horaire = c.Double(),
                        panne = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OTEmploye",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code_OT = c.String(nullable: false, unicode: false),
                        Action = c.String(nullable: false, unicode: false),
                        Duree_planifie = c.String(nullable: false, unicode: false),
                        Date_debut_prevu = c.DateTime(nullable: false, precision: 0),
                        Duree_planifie_jr = c.String(nullable: false, unicode: false),
                        Cout_planifie = c.Double(nullable: false),
                        Dure_reelle = c.String(nullable: false, unicode: false),
                        Date_debut_reelle = c.DateTime(nullable: false, precision: 0),
                        Cout_MO = c.Double(nullable: false),
                        Cout_MO_P = c.Double(nullable: false),
                        Dure_reelle_jr = c.String(nullable: false, unicode: false),
                        Personnel_Id = c.Int(nullable: false),
                        OT_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ordre_de_travail", t => t.OT_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnel", t => t.Personnel_Id, cascadeDelete: true)
                .Index(t => t.Personnel_Id)
                .Index(t => t.OT_Id);
            
            CreateTable(
                "dbo.OTfournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date_debut_prevu_ext = c.DateTime(nullable: false, precision: 0),
                        Duree_ext_planifie_jr = c.String(nullable: false, unicode: false),
                        duree_Ext_planifie_h = c.String(nullable: false, unicode: false),
                        cout_Intervenant_planifie = c.Double(nullable: false),
                        cout_Intervenant_reel = c.Double(nullable: false),
                        date_debut_reelle_ext = c.DateTime(nullable: false, precision: 0),
                        Duree_ext_reel_jr = c.String(nullable: false, unicode: false),
                        duree_ext_reel_h = c.String(nullable: false, unicode: false),
                        Action = c.String(nullable: false, unicode: false),
                        Fournisseurs_Id = c.Int(nullable: false),
                        OT_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fournisseur", t => t.Fournisseurs_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ordre_de_travail", t => t.OT_Id, cascadeDelete: true)
                .Index(t => t.Fournisseurs_Id)
                .Index(t => t.OT_Id);
            
            CreateTable(
                "dbo.Fournisseur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code_Fournisseur = c.String(nullable: false, unicode: false),
                        Code_Devise = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                        code_postal = c.String(unicode: false),
                        Nom = c.String(nullable: false, unicode: false),
                        Ville = c.String(unicode: false),
                        Pays = c.String(unicode: false),
                        TEL = c.String(unicode: false),
                        FAX = c.String(unicode: false),
                        email = c.String(unicode: false),
                        Site_Web = c.String(unicode: false),
                        Compte_Courant_Bancaire = c.String(unicode: false),
                        matricule_fiscale = c.String(unicode: false),
                        Date_création = c.DateTime(precision: 0),
                        Date_Modification = c.DateTime(precision: 0),
                        GSM = c.String(unicode: false),
                        Domaine = c.String(unicode: false),
                        Date = c.DateTime(precision: 0),
                        civilité = c.String(unicode: false),
                        Banque = c.String(unicode: false),
                        Domiciliation_Bancaire = c.String(unicode: false),
                        IBAN = c.String(unicode: false),
                        code_douane = c.String(unicode: false),
                        Code_tva = c.String(unicode: false),
                        adresse_usine = c.String(unicode: false),
                        pays_usine = c.String(unicode: false),
                        ville_usine = c.String(unicode: false),
                        ccp_usine = c.String(unicode: false),
                        tel_usine = c.String(unicode: false),
                        fax_usine = c.String(unicode: false),
                        email_usine = c.String(unicode: false),
                        adresse_livraison = c.String(unicode: false),
                        adresse_facturation = c.String(unicode: false),
                        Ville_L = c.String(unicode: false),
                        Ville_F = c.String(unicode: false),
                        ccP_L = c.String(unicode: false),
                        ccp_F = c.String(unicode: false),
                        Pays_L = c.String(unicode: false),
                        Pays_F = c.String(unicode: false),
                        observation = c.String(unicode: false),
                        SWIFT = c.String(unicode: false),
                        téL_L = c.String(unicode: false),
                        téL_F = c.String(unicode: false),
                        FAX_l = c.String(unicode: false),
                        FAX_F = c.String(unicode: false),
                        EMAIL_L = c.String(unicode: false),
                        EMAIL_F = c.String(unicode: false),
                        Délai_confirmation_CDE = c.String(unicode: false),
                        Num_client = c.String(unicode: false),
                        Etat_Fournisseur = c.String(unicode: false),
                        TVA = c.Single(),
                        nb_facture = c.Int(),
                        nb_bl = c.Int(),
                        escompte = c.Int(),
                        Site_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Site", t => t.Site_Id)
                .Index(t => t.Site_Id);
            
            CreateTable(
                "dbo.Site",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        code_site = c.String(nullable: false, unicode: false),
                        adresse_site = c.String(unicode: false),
                        no_tel = c.String(unicode: false),
                        no_fax = c.String(unicode: false),
                        email = c.String(unicode: false),
                        Ville = c.String(unicode: false),
                        pays = c.String(unicode: false),
                        Code_postale = c.String(unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OTOutillage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codeoutil = c.String(nullable: false, unicode: false),
                        qte = c.Double(nullable: false),
                        designation = c.String(nullable: false, unicode: false),
                        codeABarre = c.String(nullable: false, unicode: false),
                        OT_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ordre_de_travail", t => t.OT_Id, cascadeDelete: true)
                .Index(t => t.OT_Id);
            
            CreateTable(
                "dbo.OTPieceRechange",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(nullable: false, unicode: false),
                        Code_OT = c.String(nullable: false, unicode: false),
                        Qantite_pla = c.Long(nullable: false),
                        PRix_unitaite_pla = c.Single(nullable: false),
                        Quantite_reelle = c.Long(nullable: false),
                        PRix_unitaite_reelle = c.Single(nullable: false),
                        SA_BS = c.String(nullable: false, unicode: false),
                        OT_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ordre_de_travail", t => t.OT_Id, cascadeDelete: true)
                .Index(t => t.OT_Id);
            
            CreateTable(
                "dbo.PhotoPanne",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        photo = c.Binary(nullable: false),
                        urlPhoto = c.String(nullable: false, unicode: false),
                        Equipement_Id = c.Int(nullable: false),
                        OT_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipement", t => t.Equipement_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ordre_de_travail", t => t.OT_Id, cascadeDelete: true)
                .Index(t => t.Equipement_Id)
                .Index(t => t.OT_Id);
            
            CreateTable(
                "dbo.TestScheduler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        start_date = c.DateTime(nullable: false, precision: 0),
                        end_date = c.DateTime(nullable: false, precision: 0),
                        text = c.String(nullable: false, unicode: false),
                        room_id = c.Int(nullable: false),
                        color = c.String(nullable: false, unicode: false),
                        event_length = c.Long(nullable: false),
                        rec_type = c.String(nullable: false, unicode: false),
                        event_pid = c.Int(nullable: false),
                        Equipement_Id = c.Int(nullable: false),
                        Personnel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipement", t => t.Equipement_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnel", t => t.Personnel_Id, cascadeDelete: true)
                .Index(t => t.Equipement_Id)
                .Index(t => t.Personnel_Id);
            
            CreateTable(
                "dbo.Atelier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle_atelier = c.String(unicode: false),
                        site = c.String(unicode: false),
                        code_atelier = c.String(nullable: false, unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        Departement_Id = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorieClient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorieEquipement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                        Observation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorieFournisseur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorieOutillage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                        Observation = c.String(unicode: false),
                        type = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoriePieceRechange",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                        Observation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Catt_Equip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code_cause = c.String(nullable: false, unicode: false),
                        libelle = c.String(nullable: false, unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        taux_horaire = c.Double(),
                        panne = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Composants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        codeComposant = c.String(unicode: false),
                        libelle = c.String(unicode: false),
                        NumLot = c.Int(),
                        codeBarre = c.String(unicode: false),
                        Date_reception = c.DateTime(precision: 0),
                        delaiObtention = c.Int(),
                        NbrExemplaire = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compteur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        codeCompt = c.String(nullable: false, unicode: false),
                        unite = c.String(unicode: false),
                        valeur_compteur_max = c.String(unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsMaintEquipement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fréquence = c.Int(nullable: false),
                        NumEquipement = c.String(nullable: false, unicode: false),
                        date_fin = c.DateTime(nullable: false, precision: 0),
                        date_début = c.DateTime(nullable: false, precision: 0),
                        alerte = c.Single(nullable: false),
                        Duré_cons_h = c.String(nullable: false, unicode: false),
                        Code_Consigne = c.String(nullable: false, unicode: false),
                        type = c.String(nullable: false, unicode: false),
                        CodeCompt = c.String(nullable: false, unicode: false),
                        periodicite = c.Int(nullable: false),
                        indice_gen = c.Int(nullable: false),
                        Duré_cons_jr = c.Int(nullable: false),
                        tYpe_planning = c.String(nullable: false, unicode: false),
                        Départ_Compt = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumDepartement = c.String(nullable: false, unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        Description = c.String(unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        codeDevise = c.String(nullable: false, unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        decimale = c.String(unicode: false),
                        nb = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        codeDocument = c.String(nullable: false, unicode: false),
                        typeDocument = c.String(unicode: false),
                        libelle = c.String(nullable: false, unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        Edition = c.String(unicode: false),
                        lien = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emplacement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code_Emplacement = c.String(nullable: false, unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        magasin = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Magasin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code_magasin = c.String(nullable: false, unicode: false),
                        libelle = c.String(nullable: false, unicode: false),
                        Adresse = c.String(unicode: false),
                        tel = c.String(unicode: false),
                        obsrvation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Outillage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        codeoutil = c.String(nullable: false, unicode: false),
                        code_barre = c.String(unicode: false),
                        designation = c.String(nullable: false, unicode: false),
                        date_achat = c.DateTime(precision: 0),
                        caractéristiques = c.String(unicode: false),
                        observation = c.String(unicode: false),
                        Date_création = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        Code_famille = c.String(unicode: false),
                        Nom = c.String(unicode: false),
                        Nb_exp = c.Long(),
                        etat_outillage = c.String(unicode: false),
                        LONGBLOB = c.Byte(),
                        IDAtelier = c.Int(),
                        prix_U = c.Single(),
                        Code_barre_Ext = c.String(unicode: false),
                        Code_Fournisseur = c.String(unicode: false),
                        nb_eq = c.Int(),
                        IDLieuRangement = c.String(unicode: false),
                        Nature_Heure_Travail = c.Int(),
                        N_série = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PieceRechange",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeBarreFab = c.String(unicode: false),
                        PrixHT = c.Single(nullable: false),
                        QteReappro = c.Long(nullable: false),
                        unité = c.String(unicode: false),
                        CodePiece = c.String(nullable: false, unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        CodeBarre = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        code_Fournisseur = c.String(unicode: false),
                        CodeCatgorie = c.String(unicode: false),
                        stock = c.Double(nullable: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        LONGBLOB = c.Byte(nullable: false),
                        stock_scurit = c.Double(nullable: false),
                        Etat_Pice = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Poste_de_charge",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dureeJr = c.Single(),
                        code_poste = c.String(nullable: false, unicode: false),
                        NbEquipe = c.String(unicode: false),
                        Designation = c.String(nullable: false, unicode: false),
                        Date_creation = c.DateTime(precision: 0),
                        date_Modification = c.DateTime(precision: 0),
                        Atelier = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rangement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, unicode: false),
                        code = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockIn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ref = c.String(unicode: false),
                        personnel = c.String(unicode: false),
                        Date = c.DateTime(precision: 0),
                        magasin = c.String(unicode: false),
                        piece = c.String(unicode: false),
                        emplacement = c.String(unicode: false),
                        fournisseur = c.String(unicode: false),
                        observation = c.String(unicode: false),
                        refExt = c.String(unicode: false),
                        qte = c.Double(),
                        prix = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockOut",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ref = c.String(unicode: false),
                        personnel = c.String(unicode: false),
                        Date = c.DateTime(precision: 0),
                        magasin = c.String(unicode: false),
                        piece = c.String(unicode: false),
                        observation = c.String(unicode: false),
                        refExt = c.String(unicode: false),
                        qte = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.User", "Personnel_Id", "dbo.Personnel");
            DropForeignKey("dbo.Dec_Panne", "Id_Personnel", "dbo.Personnel");
            DropForeignKey("dbo.Dec_Panne", "Id_Equipement", "dbo.Equipement");
            DropForeignKey("dbo.TestScheduler", "Personnel_Id", "dbo.Personnel");
            DropForeignKey("dbo.TestScheduler", "Equipement_Id", "dbo.Equipement");
            DropForeignKey("dbo.PhotoPanne", "OT_Id", "dbo.Ordre_de_travail");
            DropForeignKey("dbo.PhotoPanne", "Equipement_Id", "dbo.Equipement");
            DropForeignKey("dbo.Ordre_de_travail", "Personnel_Id", "dbo.Personnel");
            DropForeignKey("dbo.OTPieceRechange", "OT_Id", "dbo.Ordre_de_travail");
            DropForeignKey("dbo.OTOutillage", "OT_Id", "dbo.Ordre_de_travail");
            DropForeignKey("dbo.OTfournisseurs", "OT_Id", "dbo.Ordre_de_travail");
            DropForeignKey("dbo.OTfournisseurs", "Fournisseurs_Id", "dbo.Fournisseur");
            DropForeignKey("dbo.Fournisseur", "Site_Id", "dbo.Site");
            DropForeignKey("dbo.OTEmploye", "Personnel_Id", "dbo.Personnel");
            DropForeignKey("dbo.OTEmploye", "OT_Id", "dbo.Ordre_de_travail");
            DropForeignKey("dbo.Ordre_de_travail", "Equipement_Id", "dbo.Equipement");
            DropForeignKey("dbo.Ordre_de_travail", "cArr_Equip_Id", "dbo.Carr_Equip");
            DropForeignKey("dbo.ListeconsMaintEquipement", "Equipements_Id", "dbo.Equipement");
            DropForeignKey("dbo.ConsPieceRechange", "ListConsM_Id", "dbo.ListeconsMaintEquipement");
            DropForeignKey("dbo.Consigne_maintenance", "Equipement_Id", "dbo.Equipement");
            DropForeignKey("dbo.User", "GroupUser_Id", "dbo.GroupUser");
            DropForeignKey("dbo.Right", "GroupUser_Id", "dbo.GroupUser");
            DropForeignKey("dbo.Right", "fonctionality_Id", "dbo.Fonctionality");
            DropForeignKey("dbo.GroupUser", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Client", "Company_Id", "dbo.Company");
            DropIndex("dbo.TestScheduler", new[] { "Personnel_Id" });
            DropIndex("dbo.TestScheduler", new[] { "Equipement_Id" });
            DropIndex("dbo.PhotoPanne", new[] { "OT_Id" });
            DropIndex("dbo.PhotoPanne", new[] { "Equipement_Id" });
            DropIndex("dbo.OTPieceRechange", new[] { "OT_Id" });
            DropIndex("dbo.OTOutillage", new[] { "OT_Id" });
            DropIndex("dbo.Fournisseur", new[] { "Site_Id" });
            DropIndex("dbo.OTfournisseurs", new[] { "OT_Id" });
            DropIndex("dbo.OTfournisseurs", new[] { "Fournisseurs_Id" });
            DropIndex("dbo.OTEmploye", new[] { "OT_Id" });
            DropIndex("dbo.OTEmploye", new[] { "Personnel_Id" });
            DropIndex("dbo.Ordre_de_travail", new[] { "cArr_Equip_Id" });
            DropIndex("dbo.Ordre_de_travail", new[] { "Personnel_Id" });
            DropIndex("dbo.Ordre_de_travail", new[] { "Equipement_Id" });
            DropIndex("dbo.ConsPieceRechange", new[] { "ListConsM_Id" });
            DropIndex("dbo.ListeconsMaintEquipement", new[] { "Equipements_Id" });
            DropIndex("dbo.Consigne_maintenance", new[] { "Equipement_Id" });
            DropIndex("dbo.Dec_Panne", new[] { "Id_Equipement" });
            DropIndex("dbo.Dec_Panne", new[] { "Id_Personnel" });
            DropIndex("dbo.User", new[] { "Personnel_Id" });
            DropIndex("dbo.User", new[] { "GroupUser_Id" });
            DropIndex("dbo.Right", new[] { "fonctionality_Id" });
            DropIndex("dbo.Right", new[] { "GroupUser_Id" });
            DropIndex("dbo.GroupUser", new[] { "Company_Id" });
            DropIndex("dbo.Client", new[] { "Company_Id" });
            DropIndex("dbo.Article", new[] { "Company_Id" });
            DropTable("dbo.StockOut");
            DropTable("dbo.StockIn");
            DropTable("dbo.Rangement");
            DropTable("dbo.Poste_de_charge");
            DropTable("dbo.PieceRechange");
            DropTable("dbo.Outillage");
            DropTable("dbo.Module");
            DropTable("dbo.Magasin");
            DropTable("dbo.Emplacement");
            DropTable("dbo.Document");
            DropTable("dbo.Devise");
            DropTable("dbo.Departement");
            DropTable("dbo.ConsMaintEquipement");
            DropTable("dbo.Compteur");
            DropTable("dbo.Composants");
            DropTable("dbo.Catt_Equip");
            DropTable("dbo.Category");
            DropTable("dbo.CategoriePieceRechange");
            DropTable("dbo.CategorieOutillage");
            DropTable("dbo.CategorieFournisseur");
            DropTable("dbo.CategorieEquipement");
            DropTable("dbo.CategorieClient");
            DropTable("dbo.Atelier");
            DropTable("dbo.TestScheduler");
            DropTable("dbo.PhotoPanne");
            DropTable("dbo.OTPieceRechange");
            DropTable("dbo.OTOutillage");
            DropTable("dbo.Site");
            DropTable("dbo.Fournisseur");
            DropTable("dbo.OTfournisseurs");
            DropTable("dbo.OTEmploye");
            DropTable("dbo.Carr_Equip");
            DropTable("dbo.Ordre_de_travail");
            DropTable("dbo.ConsPieceRechange");
            DropTable("dbo.ListeconsMaintEquipement");
            DropTable("dbo.Consigne_maintenance");
            DropTable("dbo.Equipement");
            DropTable("dbo.Dec_Panne");
            DropTable("dbo.Personnel");
            DropTable("dbo.User");
            DropTable("dbo.Fonctionality");
            DropTable("dbo.Right");
            DropTable("dbo.GroupUser");
            DropTable("dbo.Client");
            DropTable("dbo.Company");
            DropTable("dbo.Article");
        }
    }
}
