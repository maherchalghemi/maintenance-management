var PieceRechangeconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var PieceRechangeController = {
    init: function () {
        PieceRechangeController.loadData();
        PieceRechangeController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            PieceRechangeController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            PieceRechangeController.resetForm();
            $.ajax({
                url: '/PieceRechange/LoadData',
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
                        var html = "<option value=''> -- Choisir Catégorie --</option>";
                        var template = $('#selCat').html();
                        $.each(data, function (i, item) {


                            html += "<option value=" + item.Designation + ">" + item.Designation + "</option>";

                        });
                        $('#selCat').html(html);


                    }
                }
            });


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtCodePiece").value == "") {
                $('#lblmsg').html("Entrer un code");
                document.getElementById("txtCodePiece").focus();
                document.getElementById("txtCodePiece").style.borderColor = "red";
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Entrer une Désignation");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }
            else {

                PieceRechangeController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            PieceRechangeController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                PieceRechangeController.deletePieceRechange(id);
            });
        });

    },
    deletePieceRechange: function (id) {
        $.ajax({
            url: '/PieceRechange/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('PieceRechange supprimée', 'hhhhhhh');
                    PieceRechangeController.loadData(true);

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
            url: '/PieceRechange/LoadData',
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
                    var template = $('#selCat').html();
                    $.each(data, function (i, item) {


                        html += "<option >" + item.Designation + "</option>";

                    });
                    $('#selCat').html(html);


                }
            }
        });

        $.ajax({
            url: '/PieceRechange/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtCodePiece').val(data.CodePiece);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtCodeBarre').val(data.CodeBarre);
                    $('#txtCodeBarreFab').val(data.CodeBarreFab);
                    $('#txtDescription').val(data.Description);
                    $('#txtQteReappro').val(data.QteReappro);
                    $('#txtstock_scurit').val(data.stock_scurit);
                    $('#txtPrixHT').val(data.PrixHT);
                    $('#txtcode_Fournisseur').val(data.txtcode_Fournisseur);



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
        var code = $('#txtCodePiece').val();
        var des = $('#txtDesignation').val();

        var id = parseInt($('#hidID').val());
        var cat = $('#selCat').val();
        var eta = $('#selEtat').val();
        var cb = $('#txtCodeBarre').val();
        var cbf = $('#txtCodeBarreFab').val();
        var desc = $('#txtDescription').val();
        var uni = $('#selUnite').val();
        var four = $('#txtcode_Fournisseur').val();
        var qte = parseInt($('#txtQteReappro').val());
        var ss = parseFloat($('#txtstock_scurit').val());
        var prix = parseFloat($('#txtPrixHT').val());

        var pieceRechange = {
            CodePiece: code,
            Designation: des,
            Etat_Pice: eta,
            CodeBarre: cb,
            CodeBarreFab: cbf,
            CodeCatgorie: cat,
            Description: desc,
            unité: uni,
            code_Fournisseur: four,
            QteReappro: qte,
            stock_scurit: ss,
            PrixHT: prix,

            Id: id
        }
        $.ajax({
            url: '/PieceRechange/SaveData',
            data: {
                strPieceRechange: JSON.stringify(pieceRechange)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('PieceRechange ajoutée', 'Ajout PieceRechange');

                    $('#modalAddUpdate').modal('hide');
                    PieceRechangeController.loadData(true);


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

        $('txtDesignation').val('');
        $('#txtCodePiece').val('');

        $('#txtCodeBarre').val('');
        $('#txtCodeBarreFab').val('');
        $('#txtDescription').val('');
        $('#txtcode_Fournisseur').val('');
        $('#txtQteReappro').val('0');
        $('#txtstock_scurit').val('0.0000');
        $('#txtPrixHT').val('0.00');

    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/PieceRechange/LoadData',
            type: 'GET',
            data: {

                page: PieceRechangeconfig.pageIndex,
                pageSize: PieceRechangeconfig.pageSize
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

                            Designation: item.Designation,
                            CodePiece: item.CodePiece,
                            Etat_Pice: item.Etat_Pice,
                            CodeBarre: item.CodeBarre,
                            CodeBarreFab: item.CodeBarreFab,
                            CodeCatgorie: item.CodeCatgorie,
                            Description: item.Description,
                            code_Fournisseur: item.code_Fournisseur,
                            unité: item.unité,
                            QteReappro: item.QteReappro,
                            stock_scurit: item.stock_scurit,
                            PrixHT: item.PrixHT


                        });

                    });
                    $('#tblData').html(html);
                    PieceRechangeController.paging(response.total, function () {
                        PieceRechangeController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / PieceRechangeconfig.pageSize);

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
                PieceRechangeconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
PieceRechangeController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    PieceRechangeController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce PieceRechange est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette PieceRechange?",
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
                    PieceRechangeController.deletePieceRechange(id);
                }
            }
        }
    });
}