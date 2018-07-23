var Deviseconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var DeviseController = {
    init: function () {
        DeviseController.loadData();
        DeviseController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            DeviseController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            DeviseController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtcodeDevise").value == "") {
                     $('#lblmsg').html("Four vide");
                     document.getElementById("txtcodeDevise").focus();
                     document.getElementById("txtcodeDevise").style.borderColor = "red";
                      }
			if (document.getElementById("txtDesignation").value == "") {
                     $('#lblmsg1').html("Four vide");
                     document.getElementById("txtDesignation").focus();
                     document.getElementById("txtDesignation").style.borderColor = "red";
                      }

            else {

			    DeviseController.saveData();
			    location.reload();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            DeviseController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                DeviseController.deleteDevise(id);
            });
        });

    },
    deleteDevise: function (id) {
        $.ajax({
            url: '/Devise/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Devise supprimé', 'Suppression');
                    DeviseController.loadData(true);

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
            url: '/Devise/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcodeDevise').val(data.codeDevise);
                    $('#txtDesignation').val(data.Designation);
                    $('#txtdecimale').val(data.decimale);
                    $('#txtnb').val(data.nb);
                    

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
        var code = $('#txtcodeDevise').val();
        var des = $('#txtDesignation').val();
        var dc = $('#txtdecimale').val();
		var n = $('#txtnb').val();
        
        var id = parseInt($('#hidID').val());
        var devise = {
            codeDevise: code,
            Designation: des,
            decimale: dc,
			nb: n,
            
            Id: id
            
        }
        $.ajax({
            url: '/Devise/SaveData',
            data: {
                strDevise: JSON.stringify(devise)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Devise ajoutée', 'hhhhhhh');

                    $('#modalAddUpdate').modal('hide');
                    DeviseController.loadData(true);


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
        $('#txtcodeDevise').val('');
        $('#txtDesignation').val('');
        $('#txtnb').val('0');
		 $('#txtdecimale').val('0');
        
        
    },

    loadData: function (changePageSize) {

        $.ajax({
            url: '/Devise/LoadData',
            type: 'GET',
            data: {

                page: Deviseconfig.pageIndex,
                pageSize: Deviseconfig.pageSize
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
                            codeDevise: item.codeDevise,
                            Designation: item.Designation,
                            nb: item.nb,
							decimale: item.decimale
                        });

                    });
                    $('#tblData').html(html);
                    DeviseController.paging(response.total, function () {
                        DeviseController.Data();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Deviseconfig.pageSize);

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
                Deviseconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
DeviseController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    DeviseController.loadDetail(id);
}

function close() {
    debugger;

    location.reload();
}

function fncDelelte(thisme) {


    var id = $(thisme).data('id');

    bootbox.dialog({
        message: "La suppression de ce Devise est irréversible.",
        title: "Supprimer ce Devise ?",
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
                    DeviseController.deleteDevise(id);
                }
            }
        }
    });




}