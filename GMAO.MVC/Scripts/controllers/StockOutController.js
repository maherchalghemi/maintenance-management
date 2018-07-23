var StockOutconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var StockOutController = {
    init: function () {
        StockOutController.loadData();
        StockOutController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            StockOutController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            StockOutController.resetForm();
            $.ajax({
                url: '/StockOut/LoadData',
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

            $('#selMag').on('change', function () {

                var m = $('#selMag').val();
                $.ajax({
                    url: '/StockOut/GetPiece',
                    type: 'GET',
                    data: { mag: m },
                    dataType: 'json',
                    success: function (response) {
                        var html = "<option value=''> </option>";
                        var data = response.droplist;
                        var template = $('#selPiece').html();
                        $.each(data, function (i, item) {
                            html += "<option value='" + item.piece + "'>" + item.piece + "</option>";
                        });
                        $('#selPiece').html(html);
                    }
                });

            });




            $.ajax({
                url: '/StockOut/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist1;
                        var html = "<option value=''> </option>";
                        var template = $('#selPers').html();
                        $.each(data, function (i, item) {


                            html += "<option value=" + item.NomPrenom + ">" + item.NomPrenom + "</option>";

                        });
                        $('#selPers').html(html);


                    }
                }
            });

        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtDate").value == "") {
                $('#lblmsg').html("Remlir la date de mouvement");
                document.getElementById("txtDate").focus();
                document.getElementById("txtDate").style.borderColor = "red";
            }


            if (document.getElementById("txtDate").value != "") {

                StockOutController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            StockOutController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                StockOutController.deleteStockOut(id);
            });
        });

    },
    deleteStockOut: function (id) {
        $.ajax({
            url: '/StockOut/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('StockOut supprimée', 'hhhhhhh');
                    StockOutController.loadData(true);

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
            url: '/StockOut/LoadData',
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

        $('#selMag').on('change', function () {

            var m = $('#selMag').val();
            $.ajax({
                url: '/StockOut/GetPiece',
                type: 'GET',
                data: { mag: m },
                dataType: 'json',
                success: function (response) {
                    var html = "<option value=''> </option>";
                    var data = response.droplist;
                    var template = $('#selPiece').html();
                    $.each(data, function (i, item) {
                        html += "<option>" + item.piece + "</option>";
                    });
                    $('#selPiece').html(html);
                }
            });

        });





        $.ajax({
            url: '/StockOut/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist1;
                    var html = "<option value=''> </option>";
                    var template = $('#selPers').html();
                    $.each(data, function (i, item) {


                        html += "<option>" + item.NomPrenom + "</option>";

                    });
                    $('#selPers').html(html);


                }
            }
        });

        $.ajax({
            url: '/StockOut/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtDate').val(data.Date);
                    $('#txtqte').val(data.qte);

                    $('#txtobservation').val(data.observation);



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
        var dt = $('#txtDate').val();
        var obs = $('#txtobservation').val();
        var qt = $('#txtqte').val();

        var id = parseInt($('#hidID').val());
        var mag = $('#selMag').val();

        var pie = $('#selPiece').val();
        var stockOut = {
            Date: dt,
            observation: obs,
            magasin: mag,

            piece: pie,
            qte: qt,

            Id: id
        }
        $.ajax({
            url: '/StockOut/SaveData',
            data: {
                strStockOut: JSON.stringify(stockOut)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('StockOut ajoutée', 'Ajout StockOut');

                    $('#modalAddUpdate').modal('hide');
                    StockOutController.loadData(true);


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
        $('#txtDate').val('');
        $('#txtobservation').val('');
        $('txtqte').val('0.00');


    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/StockOut/LoadData',
            type: 'GET',
            data: {

                page: StockOutconfig.pageIndex,
                pageSize: StockOutconfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        debugger;
                        html += Mustache.render(template, {
                            Id: item.Id,
                            Date: ConvertToDatetime(item.Date),
                            piece: item.piece,
                            personnel: item.personnel,

                            Ref: item.Ref,
                            observation: item.observation,
                            magasin: item.magasin

                        });

                    });
                    $('#tblData').html(html);
                    StockOutController.paging(response.total, function () {
                        StockOutController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / StockOutconfig.pageSize);

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
                StockOutconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
StockOutController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    StockOutController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce StockOut est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette StockOut?",
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
                    StockOutController.deleteStockOut(id);
                }
            }
        }
    });
}
function ConvertToDatetime(dateValue) {
    var regex = /-?\d+/; // Remove Date(...) (json)
    var match = regex.exec(dateValue);
    var date = new Date(parseInt(match[0]));
    return date.getDate() + '/' + (date.getMonth() + 1) + '/' + +date.getFullYear();
}