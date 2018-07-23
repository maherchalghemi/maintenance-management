var StockInconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var StockInController = {
    init: function () {
        StockInController.loadData();
        StockInController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            StockInController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            StockInController.resetForm();
            $.ajax({
                url: '/StockIn/LoadData',
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
               
                var m = $('#selMag').val() ;
                $.ajax({
                    url: '/StockIn/GetEmp',
                    type: 'GET',
                    data: { mag: m },
                    dataType: 'json',
                    success: function (response) {
                        var html = "<option value=''> </option>";
                        var data = response.droplist;
                        var template = $('#selEmp').html();
                        $.each(data, function (i, item) {
                            html += "<option value='" + item.Designation + "'>" + item.Designation + "</option>";
                        });
                        $('#selEmp').html(html);
                    }
                });

            });

            $.ajax({
                url: '/StockIn/LoadData',
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
                        var template = $('#selPiece').html();
                        $.each(data, function (i, item) {


                            html += "<option value=" + item.Designation + ">" + item.Designation + "</option>";

                        });
                        $('#selPiece').html(html);


                    }
                }
            });
            $.ajax({
                url: '/StockIn/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist2;
                        var html = "<option value=''> </option>";
                        var template = $('#selFour').html();
                        $.each(data, function (i, item) {


                            html += "<option value=" + item.Nom + ">" + item.Nom + "</option>";

                        });
                        $('#selFour').html(html);


                    }
                }
            });

            $.ajax({
                url: '/StockIn/LoadData',
                type: 'GET',
                data: {

                    page: 1,
                    pageSize: 10
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        debugger;
                        var data = response.droplist3;
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

                StockInController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            StockInController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                StockInController.deleteStockIn(id);
            });
        });

    },
    deleteStockIn: function (id) {
        $.ajax({
            url: '/StockIn/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('StockIn supprimée', 'hhhhhhh');
                    StockInController.loadData(true);

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
            url: '/StockIn/LoadData',
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
                url: '/StockIn/GetEmp',
                type: 'GET',
                data: { mag: m },
                dataType: 'json',
                success: function (response) {
                    var html = "<option value=''> </option>";
                    var data = response.droplist;
                    var template = $('#selEmp').html();
                    $.each(data, function (i, item) {
                        html += "<option>" + item.Designation + "</option>";
                    });
                    $('#selEmp').html(html);
                }
            });

        });

        $.ajax({
            url: '/StockIn/LoadData',
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
                    var template = $('#selFour').html();
                    $.each(data, function (i, item) {


                        html += "<option >" + item.Nom + "</option>";

                    });
                    $('#selFour').html(html);


                }
            }
        });

        $.ajax({
            url: '/StockIn/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist2;
                    var html = "<option value=''> </option>";
                    var template = $('#selPiece').html();
                    $.each(data, function (i, item) {


                        html += "<option >" + item.Designation + "</option>";

                    });
                    $('#selPiece').html(html);


                }
            }
        });

        $.ajax({
            url: '/StockIn/LoadData',
            type: 'GET',
            data: {

                page: 1,
                pageSize: 10
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    debugger;
                    var data = response.droplist3;
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
            url: '/StockIn/GetDetail',
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
                    $('#txtprix').val(data.prix);
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
        var px = $('#txtprix').val();
        var id = parseInt($('#hidID').val());
        var mag = $('#selMag').val();
        var four = $('#selFour').val();
        var pie = $('#selPiece').val();
        var stockIn = {
            Date: dt,
            observation: obs,
            magasin: mag,
            fournisseur: four,
            piece: pie,
            qte: qt,
            prix: px,
            Id: id
        }
        $.ajax({
            url: '/StockIn/SaveData',
            data: {
                strStockIn: JSON.stringify(stockIn)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('StockIn ajoutée', 'Ajout StockIn');

                    $('#modalAddUpdate').modal('hide');
                    StockInController.loadData(true);


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
        $('txtprix').val('0.00');

    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/StockIn/LoadData',
            type: 'GET',
            data: {

                page: StockInconfig.pageIndex,
                pageSize: StockInconfig.pageSize
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
                            fournisseur: item.fournisseur,
                            Ref: item.Ref,
                            observation: item.observation,
                            magasin: item.magasin

                        });

                    });
                    $('#tblData').html(html);
                    StockInController.paging(response.total, function () {
                        StockInController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / StockInconfig.pageSize);

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
                StockInconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
StockInController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    StockInController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce StockIn est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette StockIn?",
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
                    StockInController.deleteStockIn(id);
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