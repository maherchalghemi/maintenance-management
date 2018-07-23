var ConsigneMaintenanceconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var ConsigneMaintenanceController = {
    init: function () {
        ConsigneMaintenanceController.loadData();
        ConsigneMaintenanceController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            ConsigneMaintenanceController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            ConsigneMaintenanceController.resetForm();
            $.ajax({
                url: '/ConsigneMaintenance/LoadData',
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
                        var html = "<option> -- Choisir Document --</option>";
                        var template = $('#selDoc').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.libelle + "</option>";

                        });
                        $('#selDoc').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtCode_Consigne").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCode_Consigne").focus();
                document.getElementById("txtCode_Consigne").style.borderColor = "red";
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }
            else {

                ConsigneMaintenanceController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            ConsigneMaintenanceController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                ConsigneMaintenanceController.deleteConsigneMaintenance(id);
            });
        });

    },
    deleteConsigneMaintenance: function (id) {
        $.ajax({
            url: '/ConsigneMaintenance/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Consigne supprimée', 'hhhhhhh');
                    ConsigneMaintenanceController.loadData(true);

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
            url: '/ConsigneMaintenance/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCode_Consigne').val(data.Code_Consigne);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtDescription').val(data.Description);
                    $('#txtDuré_cons_jr').val(data.Duré_cons_jr);
                    $('#txtDuré_cons_h').val(data.Duré_cons_h);
                    $('#txtNb_interv_suggéré').val(data.Nb_interv_suggéré);


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
            url: '/ConsigneMaintenance/LoadData',
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
                    var html = "<option> -- Choisir Document --</option>";
                    var template = $('#selDoc').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.libelle + "</option>";

                    });
                    $('#selDoc').html(html);


                }
            }
        });
    },
    saveData: function () {
        var code = $('#txtCode_Consigne').val();
        var des = $('#txtDesignation').val();
        var desc = $('#txtDescription').val();
        var dcj = parseInt($('#txtDuré_cons_jr').val());
        var dch = $('#txtDuré_cons_h').val();
        var nis = parseInt($('#txtNb_interv_suggéré').val());
        var id = parseInt($('#hidID').val());

        var consigne = {
            Code_Consigne: code,
            Designation: des,
            Description: desc,
            Duré_cons_jr: dcj,
            Duré_cons_h: dch,
            Nb_interv_suggéré: nis,
            Id: id
        }
        $.ajax({
            url: '/ConsigneMaintenance/SaveData',
            data: {
                strConsigne: JSON.stringify(consigne)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Consigne ajoutée', 'Ajout Consigne Maintenance');

                    $('#modalAddUpdate').modal('hide');
                    ConsigneMaintenanceController.loadData(true);


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
        $('#txtCode_Consigne').val('');
        $('txtDesignation').val('');
        $('txtDescription').val('');
        $('txtDuré_cons_h').val('');
        $('#txtDuré_cons_jr').val('0');
        $('#txtNb_interv_suggéré').val('0');

    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/ConsigneMaintenance/LoadData',
            type: 'GET',
            data: {

                page: ConsigneMaintenanceconfig.pageIndex,
                pageSize: ConsigneMaintenanceconfig.pageSize
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
                            Code_Consigne: item.Code_Consigne,
                            Designation: item.Designation,
                            Description: item.Description,
                            Duré_cons_h: item.Duré_cons_h,
                            Duré_cons_jr: item.Duré_cons_jr,
                            Nb_interv_suggéré: item.Nb_interv_suggéré

                        });

                    });
                    $('#tblData').html(html);
                    ConsigneMaintenanceController.paging(response.total, function () {
                        ConsigneMaintenanceController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / ConsigneMaintenanceconfig.pageSize);

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
                ConsigneMaintenanceconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
ConsigneMaintenanceController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    ConsigneMaintenanceController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de cette consigne est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette consigne?",
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
                    ConsigneMaintenanceController.deleteConsigneMaintenance(id);
                }
            }
        }
    });
}