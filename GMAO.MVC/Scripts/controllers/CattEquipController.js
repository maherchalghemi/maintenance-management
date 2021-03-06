﻿var CattEquipconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var CattEquipController = {
    init: function () {
        CattEquipController.loadData();
        CattEquipController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            CattEquipController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            CattEquipController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtCode_cause").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCode_cause").focus();
                document.getElementById("txtCode_cause").style.borderColor = "red";
                toastr.error('ERREUR');
            }

            if (document.getElementById("txtlibelle").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtlibelle").focus();
                document.getElementById("txtlibelle").style.borderColor = "red";
            }


            else {

                CattEquipController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            CattEquipController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                CattEquipController.deleteCattEquip(id);
            });
        });

    },
    deleteCattEquip: function (id) {
        $.ajax({
            url: '/CattEquip/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Cause attente supprimée', 'hhhhhhh');
                    CattEquipController.loadData(true);

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
            url: '/CattEquip/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCode_cause').val(data.Code_cause);
                    $('#txtlibelle').val(data.libelle);
                    $('#txttaux_horaire').val(data.taux_horaire);
                    $('#txtpanne').prop('checked', data.panne);


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
        var code = $('#txtCode_cause').val();
        var lib = $('#txtlibelle').val();
        var thr = parseFloat($('#txttaux_horaire').val());
        var pn = $('#txtpanne').prop('checked');

        var id = parseInt($('#hidID').val());
        var cattEquip = {
            Code_cause: code,
            libelle: lib,
            taux_horaire: thr,
            panne: pn,
            Id: id

        }
        $.ajax({
            url: '/CattEquip/SaveData',
            data: {
                strCattEquip: JSON.stringify(cattEquip)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Cause ajoutée', 'hhhhhhh');

                    $('#modalAddUpdate').modal('hide');
                    CattEquipController.loadData(true);


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
        $('#txtCode_cause').val('');
        $('#txtlibelle').val('');
        $('#txttaux_horaire').val('0');
        $('#txtpanne').prop('checked', true);

    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/CattEquip/LoadData',
            type: 'GET',
            data: {

                page: CattEquipconfig.pageIndex,
                pageSize: CattEquipconfig.pageSize
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
                            Code_cause: item.Code_cause,
                            libelle: item.libelle,
                            taux_horaire: item.taux_horaire,
                            panne: item.panne == true ? "<span class=\"label label-success\">Oui</span>" : "<span class=\"label label-danger\">Non</span>"
                        });

                    });
                    $('#tblData').html(html);
                    CattEquipController.paging(response.total, function () {
                        CattEquipController.Data();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / CattEquipconfig.pageSize);

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
                CattEquipconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
CattEquipController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    CattEquipController.loadDetail(id);
}


function fncDelelte(thisme) {


    var id = $(thisme).data('id');

    bootbox.dialog({
        message: "Êtes-vous sûr de vouloir supprimer cette cause?",
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
                    CattEquipController.deleteCattEquip(id);
                }
            }
        }
    });




}