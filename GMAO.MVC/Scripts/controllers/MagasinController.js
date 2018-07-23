var Magasinconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var MagasinController = {
    init: function () {
        MagasinController.loadData();
        MagasinController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');
            
            var id = $(this).data('id');
            MagasinController.loadDetail(id);
            
            // MagasinController.resetForm();
        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            MagasinController.resetForm();
            $.ajax({
                url: '/Magasin/LoadData',
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
                        var html = "<option> -- Choose --</option>";
                        var template = $('#selEmp').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selEmp').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {

          
            if (document.getElementById("txtCode_magasin").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtCode_magasin").focus();
                document.getElementById("txtCode_magasin").style.borderColor = "red";
            }

            if (document.getElementById("txtlibelle").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtlibelle").focus();
                document.getElementById("txtlibelle").style.borderColor = "red";
            }
            else {

                MagasinController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            MagasinController.loadData(true);
        });



        

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                MagasinController.deleteMagasin(id);
            });
        });

    },
    deleteMagasin: function (id) {
        $.ajax({
            url: '/Magasin/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Magasin supprimer', 'hhhhhhh');
                    MagasinController.loadData(true);

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
            url: '/Magasin/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCode_magasin').val(data.Code_magasin);
                    $('#txtlibelle').val(data.libelle);
                    $('#txttel').val(data.tel);
                    $('#txtobsrvation').val(data.obsrvation);
                    $('#txtAdresse').val(data.Adresse);
                    
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
            url: '/Magasin/LoadData',
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
                    var html = "<option> -- Choose --</option>";
                    var template = $('#selEmp').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.Designation + "</option>";

                    });
                    $('#selEmp').html(html);


                }
            }
        });
    },
    saveData: function () {
        var code = $('#txtCode_magasin').val();
        var lib = $('#txtlibelle').val();
        var tele = $('#txttel').val();
        var obs = $('#txtobsrvation').val();
        var id = parseInt($('#hidID').val());
        var Adr = $('#txtAdresse').val();
        var magasin = {
            Code_magasin: code,
            libelle: lib,
            tel: tele,
            obsrvation: obs,
            Id: id,
            Adresse: Adr
        }
        $.ajax({
            url: '/Magasin/SaveData',
            data: {
                strMagasin: JSON.stringify(magasin)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Fournisseur ajouté', 'hhhhhhh');

                    $('#modalAddUpdate').modal('hide');
                    MagasinController.loadData(true);


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
        $('#txtCode_magasin').val('');
        $('txtlibelle').val('');
        $('txttel').val('');
        $('txtobsrvation').val('');
        $('txtAdresse').val('');
    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Magasin/LoadData',
            type: 'GET',
            data: {

                page: Magasinconfig.pageIndex,
                pageSize: Magasinconfig.pageSize
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
                            Code_magasin: item.Code_magasin,
                            libelle: item.libelle,
                            tel: item.tel,
                            obsrvation: item.obsrvation,
                            Adresse: item.Adresse
                        });

                    });
                    $('#tblData').html(html);
                    MagasinController.paging(response.total, function () {
                        MagasinController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Magasinconfig.pageSize);

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
                Magasinconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
MagasinController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");
   
    MagasinController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');
    


    bootbox.dialog({
        message: "Êtes-vous sûr de vouloir Clôturer cette Déclaration?",
        title: "Clôturer",
        buttons: {
            success: {
                label: "Non",
                className: "btn-default",
                callback: function () {
                    bootbox.hideAll();
                    toastr.warning('Supprission Annulée');
                }
            },

            main: {
                label: "Oui",
                className: "btn-primary",
                callback: function () {
                    MagasinController.deleteMagasin(id);
                }
            }
        }
    });
}