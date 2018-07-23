var Personnelconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var PersonnelController = {
    init: function () {
        PersonnelController.loadData();
        PersonnelController.registerEvent();

    },
    registerEvent: function () {

        $('#btn-edit').off('click').on('click', function () {
            debugger;
            $('#modalAddUpdate').modal('show');

            var id = $(this).data('id');
            PersonnelController.loadDetail(id);

           
        });

        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            PersonnelController.resetForm();
            $.ajax({
                url: '/Personnel/LoadData',
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


        });

        $('#btnSave').off('click').on('click', function () {


            if (document.getElementById("txtMatricule").value == "") {
                $('#lblmsg').html("Four vide");
                document.getElementById("txtMatricule").focus();
                document.getElementById("txtMatricule").style.borderColor = "red";
            }
            if (document.getElementById("txtNom").value == "") {
                $('#lblmsg1').html("nom vide");
                document.getElementById("txtNom").focus();
                document.getElementById("txtNom").style.borderColor = "red";

            }

            if (document.getElementById("txtPrenom").value == "") {
                $('#lblmsg2').html("nom vide");
                document.getElementById("txtPrenom").focus();
                document.getElementById("txtPrenom").style.borderColor = "red";

            }
            if ((document.getElementById("txtPrenom").value != "") && (document.getElementById("txtNom").value != "") && (document.getElementById("txtMatricule").value != ""))
                {

                PersonnelController.saveData();

        }
        });
$('#btnReset').on('click', function () {
    debugger;
    $('#txtNameS').val('');
    $('#ddlStatusS').val('');
    PersonnelController.loadData(true);
});







},
    deletePersonnel: function (id) {
        debugger;
    $.ajax({
        url: '/Personnel/Delete',
        data: {
            id: id
        },
        type: 'POST',
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                toastr.info('Personnel supprimé', 'hhhhhhh');
                PersonnelController.loadData(true);

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
        url: '/Personnel/GetDetail',
        data: {
            id: id
        },
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                var data = response.data;
                $('#hidID').val(data.Id);
                $('#txtMatricule').val(data.Matricule);
                $('#txtNom').val(data.Nom);
                $('#txtPrenom').val(data.Prenom);
                $('#txtDateNaissance').val(data.DateNaissance);
                $('#txtCIN').val(data.CIN);
                $('#txtDateAjout').val(data.DateAjout);
                $('#txtAdresse').val(data.Adresse);
                $('#txtTel').val(data.Tel);
                $('#txtGSM').val(data.GSM);
                $('#txtGrade').val(data.Grade);
					
									
                    

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
        url: '/Personnel/LoadData',
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
},
saveData: function () {
    var mat = $('#txtMatricule').val();
    var nom = $('#txtNom').val();
    var pre = $('#txtPrenom').val();
    var dn = $('#txtDateNaissance').val();
    var cin = $('#txtCIN').val();
    var dr = $('#txtDateAjout').val();
    var adr = $('#txtAdresse').val();
    var tel = $('#txtTel').val();
    var gsm = $('#txtGSM').val();
    var fnc = $('#txtGrade').val();
    var id = parseInt($('#hidID').val());
		
       
    var personnel = {
        Matricule: mat,
        Nom: nom,
        Prenom: pre,
        DateNaissance: dn,
        CIN: cin,
        DateAjout: dr,
        Adresse: adr,
        Tel: tel,
        GSM: gsm,
        Grade: fnc,
        Id: id
    }
    $.ajax({
        url: '/Personnel/SaveData',
        data: {
            strPersonnel: JSON.stringify(personnel)
        },
        type: 'POST',
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                toastr.success('Personnel Enregistrée', 'Enregistrement Effectuée');

                $('#modalAddUpdate').modal('hide');
                PersonnelController.loadData(true);


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
    $('#txtMatricule').val('');
    $('txtNom').val('');
    $('txtPrenom').val('');
    $('txtCIN').val('');
    $('txtAdresse').val('');
    $('txtTel').val('');
    $('txtGSM').val('');
    $('txtGrade').val('');
		
		
       
        
},

loadData: function (changePageSize) {

    $.ajax({
        url: '/Personnel/LoadData',
        type: 'GET',
        data: {

            page: Personnelconfig.pageIndex,
            pageSize: Personnelconfig.pageSize
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
                        Matricule: item.Matricule,
                        Nom: item.Nom,
                        Prenom: item.Prenom,
                        DateNaissance: item.DateNaissance,
                        CIN: item.CIN,
                        DateAjout: item.DateAjout,
                        Adresse: item.Adresse,
                        Tel: item.Tel,
                        GSM: item.GSM,
                        Grade: item.Grade
							
							
                            
                    });

                });
                $('#tblData').html(html);
                PersonnelController.paging(response.total, function () {
                    PersonnelController.loadData();
                }, changePageSize);

            }
        }
    })
},
paging: function (totalRow, callback, changePageSize) {
    var totalPage = Math.ceil(totalRow / Personnelconfig.pageSize);

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
            Personnelconfig.pageIndex = page;
            setTimeout(callback, 200);
        }
    });
}
}
PersonnelController.init();

function fncEdit(thisme) {
    //debugger;
    $('#modalAddUpdate').modal('show');
    var id = $(thisme).data("id");

    PersonnelController.loadDetail(id);
}


function fncDelelte(thisme) {
    var id = $(thisme).data('id');



    bootbox.dialog({
        message: "La suppression de cette poste est irréversible.",
        title: "Êtes-vous sûr de vouloir supprimer ce Personnel?",
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
                    PersonnelController.deletePersonnel(id);
                }
            }
        }
    });
}