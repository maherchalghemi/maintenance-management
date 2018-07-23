var Equipementconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var EquipementController = {
    init: function () {
        EquipementController.loadData();
        EquipementController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            EquipementController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            EquipementController.resetForm();
            $.ajax({
                url: '/Equipement/LoadData',
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
                        var html = "<option> -- Choisir Poste --</option>";
                        var template = $('#selPos').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selPos').html(html);


                    }
                }
            });

            $.ajax({
                url: '/Equipement/LoadData',
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
                url: '/Equipement/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist2;
                        var html = "<option> -- Choisir Fournisseur --</option>";
                        var template = $('#selFour').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Nom + "</option>";

                        });
                        $('#selFour').html(html);


                    }
                }
            });

            $.ajax({
                url: '/Equipement/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist3;
                        var html = "<option> -- Choisir Client --</option>";
                        var template = $('#selCli').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.NomContact + "</option>";

                        });
                        $('#selCli').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtCodeEquipement").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCodeEquipement").focus();
                document.getElementById("txtCodeEquipement").style.borderColor = "red";
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }
            if ((document.getElementById("txtDesignation").value != "") && (document.getElementById("txtCodeEquipement").value != "")) {

                EquipementController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            EquipementController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                EquipementController.deleteEquipement(id);
            });
        });

    },
    deleteEquipement: function (id) {
        $.ajax({
            url: '/Equipement/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Equipement supprimée', 'hhhhhhh');
                    EquipementController.loadData(true);

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
        debugger;
        $.ajax({
            url: '/Equipement/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCodeEquipement').val(data.CodeEquipement);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtNumSerie').val(data.NumSerie);
                    $('#txtNumModel').val(data.NumModel);
                    $('#txtMarque').val(data.Marque);





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
            url: '/Equipement/LoadData',
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
                    var html = "<option> -- Choisir Poste --</option>";
                    var template = $('#selPos').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Designation + "</option>";

                    });
                    $('#selPos').html(html);


                }
            }
        });

        $.ajax({
            url: '/Equipement/LoadData',
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
            url: '/Equipement/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist2;
                    var html = "<option> -- Choisir Fournisseur --</option>";
                    var template = $('#selFour').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Nom + "</option>";

                    });
                    $('#selFour').html(html);


                }
            }
        });


        $.ajax({
            url: '/Equipement/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist3;
                    var html = "<option> -- Choisir Client --</option>";
                    var template = $('#selCli').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.NomContact + "</option>";

                    });
                    $('#selCli').html(html);


                }
            }
        });
    },
    saveData: function () {
        var code = $('#txtCodeEquipement').val();
        var des = $('#txtDesignation').val();
        var ns = $('#txtNumSerie').val();
        var nm = $('#txtNumModel').val();
        var mq = $('#txtMarque').val();

        var id = parseInt($('#hidID').val());

        var equipement = {
            CodeEquipement: code,
            Designation: des,
            NumSerie: ns,
            NumModel: nm,
            Marque: mq,
            Id: id

        }
        $.ajax({
            url: '/Equipement/SaveData',
            data: {
                strEquipement: JSON.stringify(equipement)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Equipement Enregistrer', 'Enregistrement Effectuée');

                    $('#modalAddUpdate').modal('hide');
                    EquipementController.loadData(true);


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
        $('#txtCodeEquipement').val('');
        $('txtDesignation').val('');
        $('txtNumSerie').val('');
        $('txtNumModel').val('');
        $('txtMarque').val('');


    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Equipement/LoadData',
            type: 'GET',
            data: {

                page: Equipementconfig.pageIndex,
                pageSize: Equipementconfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {

                        html += Mustache.render(template, {
                            Id: item.Id,
                            CodeEquipement: item.CodeEquipement,
                            Designation: item.Designation,
                            NumSerie: item.NumSerie,
                            NumModel: item.NumModel,
                            Marque: item.Marque

                        });

                    });
                    $('#tblData').html(html);
                    EquipementController.paging(response.total, function () {
                        EquipementController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Equipementconfig.pageSize);

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
                Equipementconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
EquipementController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    EquipementController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce Equipement est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette Equipement?",
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
                    EquipementController.deleteEquipement(id);
                }
            }
        }
    });
}