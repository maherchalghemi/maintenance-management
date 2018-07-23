var Composantconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var ComposantController = {
    init: function () {
        ComposantController.loadData();
        ComposantController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            ComposantController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            ComposantController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtcodeComposant").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtcodeComposant").focus();
                document.getElementById("txtcodeComposant").style.borderColor = "red";
                toastr.error('ERREUR');
            }


            else {

                ComposantController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            ComposantController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                ComposantController.deleteComposant(id);
            });
        });

    },
    deleteComposant: function (id) {
        $.ajax({
            url: '/Composant/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Composant supprimer', 'hhhhhhh');
                    ComposantController.loadData(true);

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
            url: '/Composant/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcodeComposant').val(data.codeComposant);
                    $('#txtlibelle').val(data.libelle);
                    $('#txtNumLot').val(data.NumLot);
                    $('#txtcodeBarre').val(data.codeBarre);
                    $('#txtDate_reception').val(data.Date_reception);
                    $('#txtdelaiObtention').val(data.delaiObtention);
                    $('#txtNbrExemplaire').val(data.NbrExemplaire);

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
        var code = $('#txtcodeComposant').val();
        var lib = $('#txtlibelle').val();
        var nlot = parseInt($('#txtNumLot').val());
        var cb = $('#txtcodeBarre').val();
        var dr = $('#txtDate_reception').val();
        var delai = parseInt($('#txtdelaiObtention').val());
        var ne = parseInt($('#txtNbrExemplaire').val());
        var id = parseInt($('#hidID').val());
        var composant = {
            codeComposant: code,
            libelle: lib,
            NumLot: nlot,
            codeBarre: cb,
            Id: id,
            Date_reception: dr,
            delaiObtention: delai,
            NbrExemplaire: ne
        }
        $.ajax({
            url: '/Composant/SaveData',
            data: {
                strComposant: JSON.stringify(composant)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Composant ajouté', 'hhhhhhh');

                    $('#modalAddUpdate').modal('hide');
                    ComposantController.loadData(true);


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
        $('#txtcodeComposant').val('');
        $('#txtlibelle').val('');
        $('#txtNumLot').val('0');
        $('#txtcodeBarre').val('');
        $('#txtDate_reception').val('');
        $('#txtdelaiObtention').val('0');
        $('#txtNbrExemplaire').val('0');
    },
    /*formatJSONDate: function (jsonDate) {
        var newDate = dateFormat(jsonDate, "mm/dd/yyyy");
        return newDate;
    },*/
    loadData: function (changePageSize) {

        $.ajax({
            url: '/Composant/LoadData',
            type: 'GET',
            data: {

                page: Composantconfig.pageIndex,
                pageSize: Composantconfig.pageSize
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
                            codeComposant: item.codeComposant,
                            libelle: item.libelle,
                            NumLot: item.NumLot,
                            codeBarre: item.codeBarre,
                            Date_reception: item.Date_reception,
                            delaiObtention: item.delaiObtention,
                            NbrExemplaire: item.NbrExemplaire
                        });
                        // ComposantController.formatJSONDate(Date(item.Date_reception))
                    });
                    $('#tblData').html(html);
                    ComposantController.paging(response.total, function () {
                        ComposantController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Composantconfig.pageSize);

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
                Composantconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
ComposantController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    ComposantController.loadDetail(id);
}

/*
function formatJSONDate(jsonDate) {
    var newDate = dateFormat(jsonDate, "mm/dd/yyyy");
    return newDate;
}*/


function fncDelelte(thisme) {
    
    
    var id = $(thisme).data('id');
   
    bootbox.dialog({
        message: "Êtes-vous sûr de vouloir supprimer ce Composant?",
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
                    ComposantController.deleteComposant(id);
                }
            }
        }
    });




}