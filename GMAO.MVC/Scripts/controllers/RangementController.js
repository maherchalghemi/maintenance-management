var Rangementconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var RangementController = {
    init: function () {
        RangementController.loadData();
        RangementController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            RangementController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            RangementController.resetForm();
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

                RangementController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            RangementController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                RangementController.deleteRangement(id);
            });
        });

    },
    deleteRangement: function (id) {
        $.ajax({
            url: '/Rangement/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Rangement supprimée', 'Suppression');
                    RangementController.loadData(true);

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
            url: '/Rangement/GetDetail',
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


        var id = parseInt($('#hidID').val());
        var rangement = {
            code: cd,
            Designation: des,

            Id: id

        }
        $.ajax({
            url: '/Rangement/SaveData',
            data: {
                strRangement: JSON.stringify(rangement)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Rangement Enregistré', 'Enregistrement Effectuée');

                    $('#modalAddUpdate').modal('hide');
                    RangementController.loadData(true);


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



    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Rangement/LoadData',
            type: 'GET',
            data: {

                page: Rangementconfig.pageIndex,
                pageSize: Rangementconfig.pageSize
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
                            Designation: item.Designation


                        });


                    });
                    $('#tblData').html(html);
                    RangementController.paging(response.total, function () {
                        RangementController.Data();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Rangementconfig.pageSize);

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
                Rangementconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
RangementController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    RangementController.loadDetail(id);
}


function fncDelelte(thisme) {


    var id = $(thisme).data('id');

    bootbox.dialog({
        message: "Êtes-vous sûr de vouloir supprimer ce Rangement?",
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
                    RangementController.deleteRangement(id);
                }
            }
        }
    });




}