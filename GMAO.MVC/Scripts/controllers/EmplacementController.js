var Emplacementconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var EmplacementController = {
    init: function () {
        EmplacementController.loadData();
        EmplacementController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            EmplacementController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            EmplacementController.resetForm();
            $.ajax({
                url: '/Emplacement/LoadData',
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
                        var html = "<option value=''> -- Choisir Magasin --</option>";
                        var template = $('#selMag').html();
                        $.each(data, function (i, item) {


                            html += "<option value=" + item.libelle + ">" + item.libelle + "</option>";

                        });
                        $('#selMag').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtCode_Emplacement").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCode_Emplacement").focus();
                document.getElementById("txtCode_Emplacement").style.borderColor = "red";
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }
            else {

                EmplacementController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            EmplacementController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                EmplacementController.deleteEmplacement(id);
            });
        });

    },
    deleteEmplacement: function (id) {
        $.ajax({
            url: '/Emplacement/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Emplacement supprimée', 'hhhhhhh');
                    EmplacementController.loadData(true);

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
            url: '/Emplacement/LoadData',
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
                    var html = "<option value=''> </option>";
                    var template = $('#selMag').html();
                    $.each(data, function (i, item) {


                        html += "<option >" + item.libelle + "</option>";

                    });
                    $('#selMag').html(html);


                }
            }
        });

        $.ajax({
            url: '/Emplacement/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCode_Emplacement').val(data.Code_Emplacement);
                    $('#txtDesignation').val(data.Designation);
                    // $("#selMag").val(data.magasin);

                    var text1 = val(data.magasin);

                    $("#selMag option[text=" + text1 + "]").attr("selected", "selected");

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
        var code = $('#txtCode_Emplacement').val();
        var des = $('#txtDesignation').val();

        var id = parseInt($('#hidID').val());
        var mag = $('#selMag').val();
        var emplacement = {
            Code_Emplacement: code,
            Designation: des,
            magasin : mag,
            Id: id
        }
        $.ajax({
            url: '/Emplacement/SaveData',
            data: {
                strEmplacement: JSON.stringify(emplacement)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Emplacement ajoutée', 'Ajout Emplacement');

                    $('#modalAddUpdate').modal('hide');
                    EmplacementController.loadData(true);


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
        $('#txtCode_Emplacement').val('');
        $('txtDesignation').val('');

    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Emplacement/LoadData',
            type: 'GET',
            data: {

                page: Emplacementconfig.pageIndex,
                pageSize: Emplacementconfig.pageSize
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
                            Code_Emplacement: item.Code_Emplacement,
                            Designation: item.Designation,
                            magasin: item.magasin

                        });

                    });
                    $('#tblData').html(html);
                    EmplacementController.paging(response.total, function () {
                        EmplacementController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Emplacementconfig.pageSize);

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
                Emplacementconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
EmplacementController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    EmplacementController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce emplacement est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette emplacement?",
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
                    EmplacementController.deleteEmplacement(id);
                }
            }
        }
    });
}