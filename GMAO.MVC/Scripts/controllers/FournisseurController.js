var Fournisseurconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var FournisseurController = {
    init: function () {
        FournisseurController.loadData();
        FournisseurController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            FournisseurController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            FournisseurController.resetForm();
            $.ajax({
                url: '/Fournisseur/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist;
                        var html = "<option> -- Choisir Catégorie --</option>";
                        var template = $('#selCat').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selCat').html(html);


                    }
                }
            });


            $.ajax({
                url: '/Fournisseur/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist1;
                        var html = "<option> -- Choisir Devise --</option>";
                        var template = $('#selDev').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selDev').html(html);


                    }
                }
            });

        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtCode_Fournisseur").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCode_Fournisseur").focus();
                document.getElementById("txtCode_Fournisseur").style.borderColor = "red";
                toastr.error('ERREUR');
            }

            if (document.getElementById("txtNom").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtNom").focus();
                document.getElementById("txtNom").style.borderColor = "red";
            }


            if ((document.getElementById("txtCode_Fournisseur").value != "") && (document.getElementById("txtNom").value != "")) {

                FournisseurController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            FournisseurController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                FournisseurController.deleteFournisseur(id);
            });
        });

    },
    deleteFournisseur: function (id) {
        $.ajax({
            url: '/Fournisseur/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Fournisseur supprimée', 'Suppression');
                    FournisseurController.loadData(true);

                }
                else {
                    toastr.error('ERREUR');
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/Fournisseur/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCode_Fournisseur').val(data.Code_Fournisseur);
                    $('#txtNom').val(data.Nom);
                    $('#txtDélai_confirmation_CDE').val(data.Délai_confirmation_CDE);
                    $('#txtDomaine').val(data.Domaine);
                    $('#txtobservation').val(data.observation);
                    $('#txtadresse_usine').val(data.adresse_usine);
                    $('#txtpays_usine').val(data.pays_usine);
                    $('#txtville_usine').val(data.ville_usine);
                    $('#txtccp_usine').val(data.ccp_usine);
                    $('#txttel_usine').val(data.tel_usine);
                    $('#txtfax_usine').val(data.fax_usine);
                    $('#txtemail_usine').val(data.email_usine);
                    $('#txtadresse_facturation').val(data.adresse_facturation);
                    $('#txtPays_F').val(data.Pays_F);
                    $('#txtVille_F').val(data.Ville_F);
                    $('#txtccp_F').val(data.ccp_F);
                    $('#txttéL_F').val(data.txttéL_F);
                    $('#txtFAX_F').val(data.FAX_F);
                    $('#txtEMAIL_F').val(data.EMAIL_F);
                    $('#txtadresse_livraison').val(data.adresse_livraison);
                    $('#txtPays_L').val(data.Pays_L);
                    $('#txtVille_L').val(data.Ville_L);
                    $('#txtccP_L').val(data.ccP_L);
                    $('#txttéL_L').val(data.téL_L);
                    $('#txtFAX_l').val(data.FAX_l);
                    $('#txtEMAIL_L').val(data.EMAIL_L);
                    $('#txtBanque').val(data.Banque);
                    $('#txtDomiciliation_Bancaire').val(data.Domiciliation_Bancaire);
                    $('#txtCompte_Courant_Bancaire').val(data.Compte_Courant_Bancaire);
                    $('#txtIBAN').val(data.IBAN);
                    $('#txtcode_douane').val(data.code_douane);
                    $('#txtSWIFT').val(data.SWIFT);
                    $('#txtmatricule_fiscale').val(data.matricule_fiscale);
                    $('#txtescompte').val(data.escompte);
                    $('#txtnb_facture').val(data.nb_facture);
                    $('#txtCode_tva').val(data.Code_tva);
                    $('#txtnb_bl').val(data.nb_bl);




                }
                else {
                    bootbox.alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });

        $.ajax({
            url: '/Fournisseur/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist;
                    var html = "<option> -- Choisir Catégorie --</option>";
                    var template = $('#selCat').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Designation + "</option>";

                    });
                    $('#selCat').html(html);


                }
            }
        });


        $.ajax({
            url: '/Fournisseur/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist1;
                    var html = "<option> -- Choisir Devise --</option>";
                    var template = $('#selDev').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Designation + "</option>";

                    });
                    $('#selDev').html(html);


                }
            }
        });


    },
    saveData: function () {
        var code = $('#txtCode_Fournisseur').val();
        var nom = $('#txtNom').val();
        var cde = $('#txtDélai_confirmation_CDE').val();
        var domaine = $('#txtDomaine').val();
        var obs = $('#txtobservation').val();
        var au = $('#txtadresse_usine').val();
        var pu = $('#txtpays_usine').val();
        var vu = $('#txtville_usine').val();
        var ccpu = $('#txtccp_usine').val();
        var telu = $('#txttel_usine').val();
        var faxu = $('#txtfax_usine').val();
        var eu = $('#txtemail_usine').val();
        var af = $('#txtadresse_facturation').val();
        var pf = $('#txtPays_F').val();
        var vf = $('#txtVille_F').val();
        var ccpf = $('#txtccp_F').val();
        var telf = $('#txttéL_F').val();
        var faxf = $('#txtFAX_F').val();
        var ef = $('#txtEMAIL_F').val();
        var al = $('#txtadresse_livraison').val();
        var pl = $('#txtPays_L').val();
        var vl = $('#txtVille_L').val();
        var ccpl = $('#txtccP_L').val();
        var tell = $('#txttéL_L').val();
        var faxl = $('#txtFAX_l').val();
        var el = $('#txtEMAIL_L').val();
        var bq = $('#txtBanque').val();
        var dbq = $('#txtDomiciliation_Bancaire').val();
        var ccb = $('#txtCompte_Courant_Bancaire').val();
        var iban = $('#txtIBAN').val();
        var cdn = $('#txtcode_douane').val();
        var swift = $('#txtSWIFT').val();
        var mf = $('#txtmatricule_fiscale').val();
        var ctva = $('#txtCode_tva').val();


        var esp = parseInt($('#txtescompte').val());
        var nbf = parseInt($('#txtnb_facture').val());
        var nbbl = parseInt($('#txtnb_bl').val());
        var id = parseInt($('#hidID').val());
        var fournisseur = {
            Code_Fournisseur: code,
            Nom: nom,
            Délai_confirmation_CDE: cde,
            Domaine: domaine,
            observation: obs,
            adresse_usine: au,
            pays_usine: pu,
            ville_usine: vu,
            ccp_usine: ccpu,
            tel_usine: telu,
            fax_usine: faxu,
            email_usine: eu,
            adresse_facturation: af,
            Pays_F: pf,
            Ville_F: vf,
            ccp_F: ccpf,
            téL_F: telf,
            FAX_F: faxf,
            EMAIL_F: ef,
            adresse_livraison: al,
            Pays_L: pl,
            Ville_L: vl,
            ccP_L: ccpl,
            téL_L: tell,
            FAX_l: faxl,
            EMAIL_L: el,
            Banque: bq,
            Domiciliation_Bancaire: dbq,
            Compte_Courant_Bancaire: ccb,
            IBAN: iban,
            code_douane: cdn,
            SWIFT: swift,
            matricule_fiscale: mf,
            Code_tva: ctva,
            escompte: esp,
            nb_facture: nbf,
            nb_bl: nbbl,

            Id: id

        }
        $.ajax({
            url: '/Fournisseur/SaveData',
            data: {
                strFournisseur: JSON.stringify(fournisseur)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Fournisseur ajoutée', 'Enregistrement Effectuée');

                    $('#modalAddUpdate').modal('hide');
                    FournisseurController.loadData(true);


                }
                else {
                    bootbox.alert(response.message);

                }


            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    resetForm: function () {
        $('#hidID').val('0');
        $('#txtCode_Fournisseur').val('');
        $('#txtobservation').val('');
        $('#txtNom').val('');
        $('#txtDélai_confirmation_CDE').val('');
        $('#txtDomaine').val('');
        $('#txtadresse_usine').val('');
        $('#txtpays_usine').val('');
        $('#txtville_usine').val('');
        $('#txtccp_usine').val('');
        $('#txttel_usine').val('');
        $('#txtfax_usine').val('');
        $('#txtemail_usine').val('');
        $('#txtadresse_facturation').val('');
        $('#txtPays_F').val('');
        $('#txtVille_F').val('');
        $('#txtccp_F').val('');
        $('#txttéL_F').val('');
        $('#txtFAX_F').val('');
        $('#txtEMAIL_F').val('');
        $('#txtadresse_livraison').val('');
        $('#txtPays_L').val('');
        $('#txtVille_L').val('');
        $('#txtccP_L').val('');
        $('#txttéL_L').val('');
        $('#txtFAX_l').val('');
        $('#txtEMAIL_L').val('');
        $('#txtBanque').val('');
        $('#txtDomiciliation_Bancaire').val('');
        $('#txtCompte_Courant_Bancaire').val('');
        $('#txtIBAN').val('');
        $('#txtcode_douane').val('');
        $('#txtSWIFT').val('');
        $('#txtmatricule_fiscale').val('');
        $('#txtCode_tva').val('');
        $('#txtescompte').val('0');
        $('#txtnb_facture').val('0');
        $('#txtnb_bl').val('0');



    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Fournisseur/LoadData',
            type: 'GET',
            data: {

                page: Fournisseurconfig.pageIndex,
                pageSize: Fournisseurconfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            Id: item.Id,
                            Code_Fournisseur: item.Code_Fournisseur,
                            Nom: item.Nom,
                            Domaine: item.Domaine,
                            adresse_usine: item.adresse_usine,
                            pays_usine: item.pays_usine,
                            ville_usine: item.ville_usine,
                            ccp_usine: item.ccp_usine,
                            tel_usine: item.tel_usine,
                            fax_usine: item.fax_usine,
                            email_usine: item.email_usine,
                            Code_tva: item.Code_tva,
                            Compte_Courant_Bancaire: item.Compte_Courant_Bancaire


                        });


                    });
                    $('#tblData').html(html);
                    FournisseurController.paging(response.total, function () {
                        FournisseurController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Fournisseurconfig.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        // this is my script
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "<<",
            next: "Suivant",
            last: ">>",
            prev: "Précédent",
            visiblePages: 10,
            onPageClick: function (event, page) {
                Fournisseurconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
FournisseurController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    FournisseurController.loadDetail(id);
}


function fncDelelte(thisme) {


    var id = $(thisme).data('id');

    bootbox.dialog({
        message: "Êtes-vous sûr de vouloir supprimer cette catégorie?",
        title: "Suppression",
        buttons: {
            success: {
                label: "Annuler",
                className: "btn-default",
                callback: function () {
                    bootbox.hideAll();
                    toastr.warning('Supprission Annulée');
                }
            },

            main: {
                label: "Supprimer",
                className: "btn-primary",
                callback: function () {
                    FournisseurController.deleteFournisseur(id);
                }
            }
        }
    });




}