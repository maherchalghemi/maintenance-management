var Clientconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var ClientController = {
    init: function () {
        ClientController.loadData();
        ClientController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            ClientController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            ClientController.resetForm();
            $.ajax({
                url: '/Client/LoadData',
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
                url: '/Client/LoadData',
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
            if (document.getElementById("txtCodeInterne").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCodeInterne").focus();
                document.getElementById("txtCodeInterne").style.borderColor = "red";
                toastr.error('ERREUR');
            }

            if (document.getElementById("txtNomContact").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtNomContact").focus();
                document.getElementById("txtNomContact").style.borderColor = "red";
            }


            if ((document.getElementById("txtCodeInterne").value != "") && (document.getElementById("txtNomContact").value != "")) {

                ClientController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            ClientController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                ClientController.deleteClient(id);
            });
        });

    },
    deleteClient: function (id) {
        $.ajax({
            url: '/Client/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Catégorie supprimée', 'Suppression');
                    ClientController.loadData(true);

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
            url: '/Client/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCodeInterne').val(data.CodeInterne);
                    $('#txtNomContact').val(data.NomContact);
                    $('#txtobservation').val(data.observation);
                    $('#txtBanque').val(data.Banque);
                    $('#txtnb_bl').val(data.nb_bl);
                    $('#txtNCompte').val(data.NCompte);
                    $('#txtMatriculeFiscal').val(data.MatriculeFiscal);
                    $('#txtEmail').val(data.Email);
                    $('#txtEmailF').val(data.EmailF);
                    $('#txtTel').val(data.Tel);
                    $('#txtTelF').val(data.TelF);
                    $('#txtDomiciliation').val(data.Domiciliation);
                    $('#txtAdresse1').val(data.Adresse1);
                    $('#txtAdresse2').val(data.Adresse2);
                    $('#txtnbFacture').val(data.nbFacture);
                    $('#txtdelaiLiv').val(data.delaiLiv);
                    $('#txtescompte').val(data.escompte);
                    $('#txtFax').val(data.Fax);
                    $('#txtFaxF').val(data.FaxF);
                    $('#txtIBAN').val(data.IBAN);
                    $('#txtRefFour').val(data.RefFour);
                    $('#txtsiret').val(data.siret);
                    $('#txtcodeDouane').val(data.codeDouane);
                    $('#txtcodeTVA').val(data.codeTVA);
                    $('#txtSWIFT').val(data.SWIFT);
                    $('#txtVILLE').val(data.VILLE);
                    $('#txtVILLEF').val(data.VILLEF);
                    $('#txtCCP').val(data.CCP);
                    $('#txtCCPF').val(data.CCPF);




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
            url: '/Client/LoadData',
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
            url: '/Client/LoadData',
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
        var id = parseInt($('#hidID').val());
        var bq = $('#txtBanque').val();
        var obs = $('#txtobservation').val();
        var nbbl = parseInt($('#txtnb_bl').val());
        var nc = $('#txtNCompte').val();
        var mf = $('#txtMatriculeFiscal').val();
        var code = $('#txtCodeInterne').val();
        var nom = $('#txtNomContact').val();
        var email = $('#txtEmail').val();
        var emailf = $('#txtEmailF').val();
        var tel = $('#txtTel').val();
        var telf = $('#txtTelF').val();
        var dmc = $('#txtDomiciliation').val();
        var adru = $('#txtAdresse1').val();
        var adrf = $('#txtAdresse2').val();
        var nbf = parseInt($('#txtnbFacture').val());
        var dliv = parseInt($('#txtdelaiLiv').val());
        var esp = parseFloat($('#txtescompte').val());
        var fax = $('#txtFax').val();
        var faxu = $('#txtFaxF').val();
        var iban = $('#txtIBAN').val();
        var ref = $('#txtRefFour').val();
        var srt = $('#txtsiret').val();
        var cdn = $('#txtcodeDouane').val();
        var tva = $('#txtcodeTVA').val();
        var sft = $('#txtSWIFT').val();
        var ville = $('#txtVILLE').val();
        var villef = $('#txtVILLEF').val();
        var ccp = $('#txtCCP').val();
        var ccpf = $('#txtCCPF').val();



        var client = {
            Banque: bq,
            observation: obs,
            nb_bl: nbbl,
            NCompte: nc,
            MatriculeFiscal: mf,
            CodeInterne: code,
            NomContact: nom,
            Email: email,
            EmailF: emailf,
            Tel: tel,
            TelF: telf,
            Domiciliation: dmc,
            Adresse1: adru,
            Adresse2: adrf,
            nbFacture: nbf,
            delaiLiv: dliv,
            escompte: esp,
            Fax: fax,
            FaxF: faxu,
            IBAN: iban,
            RefFour: ref,
            siret: srt,
            codeDouane: cdn,
            codeTVA: tva,
            SWIFT: sft,
            VILLE: ville,
            VILLEF: villef,
            CCP: ccp,
            CCPF: ccpf,
            Id: id

        }
        $.ajax({
            url: '/Client/SaveData',
            data: {
                strClient: JSON.stringify(client)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Client Enregistré', 'Enregistrement Effectuée');

                    $('#modalAddUpdate').modal('hide');
                    ClientController.loadData(true);


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
        $('#txtCodeInterne').val('');
        $('#txtNomContact').val('');
        $('#txtobservation').val('');
        $('#txtBanque').val('');
        $('#txtnb_bl').val('0');
        $('#txtNCompte').val('');
        $('#txtMatriculeFiscal').val('');
        $('#txtEmail').val('');
        $('#txtEmailF').val('');
        $('#txtTel').val('');
        $('#txtTelF').val('');
        $('#txtDomiciliation').val('');
        $('#txtAdresse1').val('');
        $('#txtAdresse2').val('');
        $('#txtnbFacture').val('0');
        $('#txtdelaiLiv').val('0');
        $('#txtescompte').val('0.00');
        $('#txtFax').val('');
        $('#txtFaxF').val('');
        $('#txtIBAN').val('');
        $('#txtRefFour').val('');
        $('#txtsiret').val('');
        $('#txtcodeDouane').val('');
        $('#txtcodeTVA').val('');
        $('#txtSWIFT').val('');
        $('#txtVILLE').val('');
        $('#txtVILLEF').val('');
        $('#txtCCP').val('');
        $('#txtCCPF').val('');



    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Client/LoadData',
            type: 'GET',
            data: {

                page: Clientconfig.pageIndex,
                pageSize: Clientconfig.pageSize
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
                            CodeInterne: item.CodeInterne,
                            NomContact: item.NomContact,
                            Adresse1: item.Adresse1,
                            CCP: item.CCP,
                            VILLE: item.VILLE,
                            Tel: item.Tel,
                            Fax: item.Fax,
                            Email: item.Email

                        });


                    });
                    $('#tblData').html(html);
                    ClientController.paging(response.total, function () {
                        ClientController.LoadData();
                    }, changePageSize);
                    

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Clientconfig.pageSize);

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
                Clientconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
ClientController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    ClientController.loadDetail(id);
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
                    ClientController.deleteClient(id);
                }
            }
        }
    });




}