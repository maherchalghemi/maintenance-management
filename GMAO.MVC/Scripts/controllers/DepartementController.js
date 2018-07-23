var Departementconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var DepartementController = {
    init: function () {
        DepartementController.loadData();
        DepartementController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            DepartementController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            DepartementController.resetForm();
            $.ajax({
                url: '/Departement/LoadData',
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
                        var html = "<option> -- Choisir Site --</option>";
                        var template = $('#selSite').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Name + "</option>";

                        });
                        $('#selSite').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtNumDepartement").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtNumDepartement").focus();
                document.getElementById("txtNumDepartement").style.borderColor = "red";
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }
            if ((document.getElementById("txtNumDepartement").value != "") && (document.getElementById("txtDesignation").value != "")) {

                DepartementController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            DepartementController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                DepartementController.deleteDepartement(id);
            });
        });

    },
    deleteDepartement: function (id) {
        $.ajax({
            url: '/Departement/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Departement supprimée', 'hhhhhhh');
                    DepartementController.loadData(true);

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
            url: '/Departement/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtNumDepartement').val(data.NumDepartement);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtDescription').val(data.Description);





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
            url: '/Departement/LoadData',
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
                    var html = "<option> -- Choisir Site --</option>";
                    var template = $('#selSite').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Name + "</option>";

                    });
                    $('#selSite').html(html);


                }
            }
        });
    },
    saveData: function () {


        var code = $('#txtNumDepartement').val();
        var des = $('#txtDesignation').val();
        var desc = $('#txtDescription').val();
        var id = parseInt($('#hidID').val());

        var departement = {
            NumDepartement: code,
            Designation: des,
            Description: desc,
            Id: id
        }
        $.ajax({
            url: '/Departement/SaveData',
            data: {
                strDepartement: JSON.stringify(departement)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Departement ajoutée', 'Ajout Departement');

                    $('#modalAddUpdate').modal('hide');
                    DepartementController.loadData(true);


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
        $('#txtNumDepartement').val('');
        $('txtDesignation').val('');
        $('txtDescription').val('');


    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Departement/LoadData',
            type: 'GET',
            data: {

                page: Departementconfig.pageIndex,
                pageSize: Departementconfig.pageSize
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
                            NumDepartement: item.NumDepartement,
                            Designation: item.Designation,
                            Description: item.Description


                        });

                    });
                    $('#tblData').html(html);
                    DepartementController.paging(response.total, function () {
                        DepartementController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Departementconfig.pageSize);

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
                Departementconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
DepartementController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    DepartementController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce Departement est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette Departement?",
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
                    DepartementController.deleteDepartement(id);
                }
            }
        }
    });
}