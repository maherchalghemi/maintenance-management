var Atelierconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var AtelierController = {
    init: function () {
        AtelierController.loadData();
        AtelierController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            AtelierController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            AtelierController.resetForm();
            $.ajax({
                url: '/Atelier/LoadData',
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
                        var html = "<option> -- Choisir Département --</option>";
                        var template = $('#selDep').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selDep').html(html);


                    }
                }
            });
			
			
			$.ajax({
                url: '/Atelier/LoadData',
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


            if (document.getElementById("txtcode_atelier").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtcode_atelier").focus();
                document.getElementById("txtcode_atelier").style.borderColor = "red";
            }

            if (document.getElementById("txtDesignation").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtDesignation").focus();
                document.getElementById("txtDesignation").style.borderColor = "red";
            }
            if ((document.getElementById("txtDesignation").value != "") && (document.getElementById("txtcode_atelier").value != "")){

                AtelierController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            AtelierController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                AtelierController.deleteAtelier(id);
            });
        });

    },
    deleteAtelier: function (id) {
        $.ajax({
            url: '/Atelier/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Atelier supprimée', 'hhhhhhh');
                    AtelierController.loadData(true);

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
            url: '/Atelier/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcode_atelier').val(data.code_atelier);
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
        $.ajax({
                url: '/Atelier/LoadData',
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
                        var html = "<option> -- Choisir Département --</option>";
                        var template = $('#selDep').html();
                        $.each(data, function (i, item) {


                            html += "<option>" + item.Designation + "</option>";

                        });
                        $('#selDep').html(html);


                    }
                }
            });
			
			
			$.ajax({
                url: '/Atelier/LoadData',
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
        var code = $('#txtcode_atelier').val();
        var des = $('#txtDesignation').val();

        var id = parseInt($('#hidID').val());

        var atelier = {
            Code_Atelier: code,
            Designation: des,
            Id: id
        }
        $.ajax({
            url: '/Atelier/SaveData',
            data: {
                strAtelier: JSON.stringify(atelier)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Atelier ajoutée', 'Ajout Atelier');

                    $('#modalAddUpdate').modal('hide');
                    AtelierController.loadData(true);


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
        $('#txtcode_atelier').val('');
        $('txtDesignation').val('');

    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Atelier/LoadData',
            type: 'GET',
            data: {

                page: Atelierconfig.pageIndex,
                pageSize: Atelierconfig.pageSize
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
                            code_atelier: item.code_atelier,
                            Designation: item.Designation

                        });

                    });
                    $('#tblData').html(html);
                    AtelierController.paging(response.total, function () {
                        AtelierController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Atelierconfig.pageSize);

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
                Atelierconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
AtelierController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    AtelierController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de ce Atelier est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer cette Atelier?",
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
                    AtelierController.deleteAtelier(id);
                }
            }
        }
    });
}