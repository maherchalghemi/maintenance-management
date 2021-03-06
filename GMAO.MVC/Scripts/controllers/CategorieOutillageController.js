﻿var CategorieOutillageconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var CategorieOutillageController = {
    init: function () {
        CategorieOutillageController.loadData();
        CategorieOutillageController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            CategorieOutillageController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            CategorieOutillageController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtcode").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtcode").focus();
                document.getElementById("txtcode").style.borderColor = "red";
                toastr.error('ERREUR');
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }


            if ((document.getElementById("txtcode").value != "") && (document.getElementById("txtDesignation").value != "")) {

                CategorieOutillageController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            CategorieOutillageController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                CategorieOutillageController.deleteCategorieOutillage(id);
            });
        });

    },
    deleteCategorieOutillage: function (id) {
        $.ajax({
            url: '/CategorieOutillage/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Catégorie supprimée', 'Suppression');
                    CategorieOutillageController.loadData(true);

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
            url: '/CategorieOutillage/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcode').val(data.code);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtObservation').val(data.Observation);



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
        var cd = $('#txtcode').val();
        var des = $('#txtDesignation').val();
        var obs = $('#txtObservation').val();

        var id = parseInt($('#hidID').val());
        var categorieOutillage = {
            code: cd,
            Designation: des,
            Observation: obs,
            Id: id

        }
        $.ajax({
            url: '/CategorieOutillage/SaveData',
            data: {
                strCategorieOutillage: JSON.stringify(categorieOutillage)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Catégorie Enregistrée', 'Enregistrement Effectuée');

                    $('#modalAddUpdate').modal('hide');
                    CategorieOutillageController.loadData(true);


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
        $('#txtcode').val('');
        $('#txtDesignation').val('');
        $('#txtObservation').val('');



    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/CategorieOutillage/LoadData',
            type: 'GET',
            data: {

                page: CategorieOutillageconfig.pageIndex,
                pageSize: CategorieOutillageconfig.pageSize
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
                            code: item.code,
                            Designation: item.Designation,
                            Observation: item.Observation,


                        });


                    });
                    $('#tblData').html(html);
                    CategorieOutillageController.paging(response.total, function () {
                        CategorieOutillageController.Data();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / CategorieOutillageconfig.pageSize);

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
                CategorieOutillageconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
CategorieOutillageController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    CategorieOutillageController.loadDetail(id);
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
                    CategorieOutillageController.deleteCategorieOutillage(id);
                }
            }
        }
    });




}