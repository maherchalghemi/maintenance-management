var Compteurconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var CompteurController = {
    init: function () {
        CompteurController.loadData();
        CompteurController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            CompteurController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            CompteurController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtcodeCompt").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtcodeCompt").focus();
                document.getElementById("txtcodeCompt").style.borderColor = "red";
            }


            else {

                CompteurController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            CompteurController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                CompteurController.deleteCompteur(id);
            });
        });

    },
    deleteCompteur: function (id) {
        $.ajax({
            url: '/Compteur/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Compteur supprimé', 'Suppression');
                    CompteurController.loadData(true);

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
            url: '/Compteur/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcodeCompt').val(data.codeCompt);
                    $('#txtunite').val(data.unite);
                    $('#txtvaleur_compteur_max').val(data.valeur_compteur_max);



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
    saveData: function () {
        var code = $('#txtcodeCompt').val();
        var un = $('#txtunite').val();
        var vcm = $('#txtvaleur_compteur_max').val();

        var id = parseInt($('#hidID').val());
        var compteur = {
            codeCompt: code,
            unite: un,
            valeur_compteur_max: vcm,

            Id: id

        }
        $.ajax({
            url: '/Compteur/SaveData',
            data: {
                strCompteur: JSON.stringify(compteur)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Compteur ajouté', 'Ajout Succé');

                    $('#modalAddUpdate').modal('hide');
                    CompteurController.loadData(true);


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
        $('#txtcodeCompt').val('');
        $('#txtunite').val('');
        $('#txtvaleur_compteur_max').val('0');


    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Compteur/LoadData',
            type: 'GET',
            data: {

                page: Compteurconfig.pageIndex,
                pageSize: Compteurconfig.pageSize
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
                            codeCompt: item.codeCompt,
                            unite: item.unite,
                            valeur_compteur_max: item.valeur_compteur_max
                        });

                    });
                    $('#tblData').html(html);
                    CompteurController.paging(response.total, function () {
                        CompteurController.Data();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Compteurconfig.pageSize);

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
                Compteurconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
CompteurController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    CompteurController.loadDetail(id);
}


function fncDelelte(thisme) {


    var id = $(thisme).data('id');

    bootbox.dialog({
        message: "La suppression de ce compteur est irréversible.",
        title: "Supprimer ce compteur ?",
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
                    CompteurController.deleteCompteur(id);
                }
            }
        }
    });




}