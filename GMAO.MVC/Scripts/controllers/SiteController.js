var Siteconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var SiteController = {
    init: function () {
        SiteController.loadData();
        SiteController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            SiteController.loadDetail(id);


        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            SiteController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            if (document.getElementById("txtcode_site").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtcode_site").focus();
                document.getElementById("txtcode_site").style.borderColor = "red";
                toastr.error('ERREUR');
            }
			
			if (document.getElementById("txtName").value == "") {
                $('#lblmsg1').html("Four vide");
                document.getElementById("txtName").focus();
                document.getElementById("txtName").style.borderColor = "red";
                toastr.error('ERREUR');
            }


            else {

                SiteController.saveData();

            }
        });
        $('#btnReset').on('click', function () {
            debugger;
            $('#txtNameS').val('');
            $('#ddlStatusS').val('');
            SiteController.loadData(true);
        });





        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                SiteController.deleteSite(id);
            });
        });

    },
    deleteSite: function (id) {
        $.ajax({
            url: '/Site/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.info('Site supprimé', 'Suppression');
                    SiteController.loadData(true);

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
            url: '/Site/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.Id);
                    $('#txtcode_site').val(data.code_site);
                    $('#txtName').val(data.Name);
                    $('#txtadresse_site').val(data.adresse_site);
                    $('#txtno_tel').val(data.no_tel);
                    $('#txtno_fax').val(data.no_fax);
                    $('#txtemail').val(data.email);
                    $('#txtVille').val(data.Ville);
					$('#txtpays').val(data.pays);
					$('#txtCode_postale').val(data.Code_postale);

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
        var code = $('#txtcode_site').val();
        var name = $('#txtName').val();
        var adr = $('#txtadresse_site').val();
        var tel = $('#txtno_tel').val();
        var fax = $('#txtno_fax').val();
        var mail = $('#txtemail').val();
        var ville = $('#txtVille').val();
        var pay = $('#txtpays').val();
		var cp = $('#txtCode_postale').val();
		var id = parseInt($('#hidID').val());
		

        var site = {
            code_site: code,
            Name: name,
            adresse_site: adr,
            no_tel: tel,
            Id: id,
            no_fax: fax,
            email: mail,
            Ville: ville,
			pays: pay,
			Code_postale: cp
			
        }
        $.ajax({
            url: '/Site/SaveData',
            data: {
                strSite: JSON.stringify(site)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Site ajouté', 'hhhhhhh');

                    $('#modalAddUpdate').modal('hide');
                    SiteController.loadData(true);


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
        $('#txtcode_site').val('');
        $('#txtName').val('');
        $('#txtadresse_site').val('');
        $('#txtno_tel').val('');
        $('#txtno_fax').val('');
        $('#txtemail').val('');
        $('#txtVille').val('');
		$('#txtpays').val('');
		$('#txtCode_postale').val('');
		
		
    },
    /*formatJSONDate: function (jsonDate) {
        var newDate = dateFormat(jsonDate, "mm/dd/yyyy");
        return newDate;
    },*/
    loadData: function (changePageSize) {

        $.ajax({
            url: '/Site/LoadData',
            type: 'GET',
            data: {

                page: Siteconfig.pageIndex,
                pageSize: Siteconfig.pageSize
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
                            code_site: item.code_site,
                            Name: item.Name,
                            adresse_site: item.adresse_site,
                            no_tel: item.no_tel,
                            no_fax: item.no_fax,
                            email: item.email,
							pays: item.pays,
							Code_postale: item.Code_postale,
                            Ville: item.Ville
							
							
                        });
                        // SiteController.formatJSONDate(Date(item.Date_reception))
                    });
                    $('#tblData').html(html);
                    SiteController.paging(response.total, function () {
                        SiteController.loadData();
                    }, changePageSize);

                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / Siteconfig.pageSize);

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
                Siteconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
SiteController.init();

function fncEdit(thisme) {
    debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    SiteController.loadDetail(id);
}




function fncDelelte(thisme) {
    
    
    var id = $(thisme).data('id');
   
    bootbox.dialog({
        message: "La suppression de ce site est irréversible",
        title: "Êtes-vous sûr de vouloir supprimer ce Site?",
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
                    SiteController.deleteSite(id);
                }
            }
        }
    });




}