var PosteChargeconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var PosteChargeController = {
    init: function () {
        PosteChargeController.loadData();
        PosteChargeController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            PosteChargeController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            PosteChargeController.resetForm();
            $.ajax({
                url: '/PosteCharge/LoadData',
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
                        var html = "<option> -- Choisir Atelier --</option>";
                        var template = $('#selAtl').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selAtl').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtcode_poste").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtcode_poste").focus();
                document.getElementById("txtcode_poste").style.borderColor = "red";
            }

           
             if (document.getElementById("txtDesignation").value == "") {
                    $('#lblmsg1').html("Four vide");
                    document.getElementById("txtDesignation").focus();
                    document.getElementById("txtDesignation").style.borderColor = "red";
                }
            
            
            if ((document.getElementById("txtcode_poste").value != "") && (document.getElementById("txtDesignation").value != "")) {

                PosteChargeController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            PosteChargeController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                PosteChargeController.deletePosteCharge(id);
            });
        });

    },
    deletePosteCharge: function (id) {
        $.ajax({
            url: '/PosteCharge/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('PosteCharge supprimée', 'hhhhhhh');
                    PosteChargeController.loadData(true);

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
            url: '/PosteCharge/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcode_poste').val(data.code_poste);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtdureeJr').val(data.dureeJr);




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
            url: '/PosteCharge/LoadData',
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
                    var html = "<option> -- Choisir Atelier --</option>";
                    var template = $('#selAtl').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Designation + "</option>";

                    });
                    $('#selAtl').html(html);


                }
            }
        });
    },
    saveData: function () {


        var code = $('#txtcode_poste').val();
        var des = $('#txtDesignation').val();
        var dur = parseFloat($('#txtdureeJr').val());
        var id = parseInt($('#hidID').val());

        var poste = {
            code_poste: code,
            Designation: des,
            dureeJr: dur,
            Id: id
        }
        $.ajax({
            url: '/PosteCharge/SaveData',
            data: {
                strPoste: JSON.stringify(poste)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('PosteCharge ajoutée', 'Ajout PosteCharge');

                    $('#modalAddUpdate').modal('hide');
                    PosteChargeController.loadData(true);


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
        $('#txtcode_poste').val('');
        $('txtDesignation').val('');
        $('#txtdureeJr').val('0.00');
    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/PosteCharge/LoadData',
            type: 'GET',
            data: {

                page: PosteChargeconfig.pageIndex,
                pageSize: PosteChargeconfig.pageSize
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
                            code_poste: item.code_poste,
                            Designation: item.Designation,
                            dureeJr: item.dureeJr

                        });

                    });
                    $('#tblData').html(html);
                    PosteChargeController.paging(response.total, function () {
                        PosteChargeController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / PosteChargeconfig.pageSize);

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
                PosteChargeconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
PosteChargeController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    PosteChargeController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce PosteCharge est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette PosteCharge?",
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
                    PosteChargeController.deletePosteCharge(id);
                }
            }
        }
    });
}