
$(document).ready(function () {
    LoadData()
});

// ------------- DEPARMENT DATA FATCH WITH API ------------- //
function LoadData() {
    $.ajax({
        url: APIURLS.Department_GetDepartments,
        type: 'Get',
        data: null,
        success: function (response) {
            var data = JSON.parse(response)
            for (let item of data.Response) {
                $('#example1 tbody').append(`
                <tr>
                    <td>${item.Name}</td>
                    <td>${item.Description}</td>
                    <td>
                        <a id="btnedit" class="btn btn-info p-2" data-toggle="modal" data-target="#modal-edit">
                            <i class="fas fa-edit"></i>
                        </a>
                        <input type="hidden" value="${item.Id}">
                        <a id="btndelete" class="btn btn-danger p-2">
                            <i class="fas fa-trash-alt""></i>
                        </a>
                    </td>
                </tr>
                `);
            }

            $("#example1").DataTable({
                "responsive": true, "lengthChange": false, "autoWidth": false,
                "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
            }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
            $('#example2').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": false,
                "ordering": true,
                "info": true,
                "autoWidth": false,
                "responsive": true,
            });
        }
    });
}

// ------------- ALL WORK FOR CREATE OR ADD DEPARTMENT ------------- //

$('#btnsubmit').on('click', function () {
    if (!validatecontrols()) {
        var Name = $('#txtname').val();
        var Description = $('#txtdescription').val();

        var DepartmentObj = {
            name: Name,
            description: Description
        }

        $.ajax({
            url: APIURLS.Department_AddDepartments,
            type: "Post",
            data: JSON.stringify(DepartmentObj),
            contentType: 'application/json',
            success: function (Response) {
                if (Response.ErrorMessage != null || Response.ErrorMessage != '') {
                    Swal.fire({
                        title: "Action Succesfull!",
                        text: "Department has been created!",
                        icon: "success",
                        confirmButtonText: "OK",
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.reload();
                        }
                    });
                }
            }
        });
    }
});

// ----- VALIDATION WORK ON ONE FEILD NAME ----- //
function validatecontrols() {
    var isEmpty = false;
    var Name = $('#txtname').val();
    if (Name == '' || Name == null) {
        isEmpty = true;
        $('#errormsg').text(`This is a required field!`);
        $('#txtname').addClass('border-danger');
    }
}

// ----- REMOVE VALIDATION WORK ON ONE FEILD NAME ----- //
$('#txtname').on('change', function () {
    var Name = $('#txtname').val();
    if (Name == '' || Name == null) {
        $('#errormsg').text(`This is a required field!`);
        $('#txtname').addClass('border-danger');
    }
    else {
        $('#errormsg').empty();
        $('#txtname').removeClass('border-danger');
    }
});

// ----- DELETE DEPARTMENT FROM API ----- //

$('body').on('click','#btndelete', function () {
    var ID = $(this).prev().val();

    var DepartmentObj = {
        id : ID
    }
 
    Swal.fire({
        title: "ALERT!",
        text: "Do you want to delete this Department!",
        icon: "warning",
        confirmButtonText: "Yes, delete it!",
        showCancelButton: true,
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: APIURLS.Department_DeleteDepartments,
                type: 'Get',
                data: DepartmentObj,
                success: function (response) {
                    if (response.ErrorMessage != null || response.ErrorMessage != '') {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Department has been deleted.",
                            icon: "success",
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.reload();
                            }
                        });
                    }
                }
            });
        }
    });
});

// ----- UPDATE DEPARTMENT FROM API ----- //

$('body').on('click','#btnedit', function () {

    var ID = $(this).next().val();
    console.log(ID);

    var DepartmentObj = {
        id : ID
    }

    $.ajax({
        url: APIURLS.Department_GetDepartmentById,
        type: "Get",
        data: DepartmentObj,
        success: function (Response) {
            var data = JSON.parse(Response)
            data = data.Response;
            if (ID == data.Id) {
                $('#txtnameedit').append().val(data.Name);
                $('#txtdescriptionedit').append().val(data.Description);
            }
        }
    });

    $('#btnupdate').on('click', function () {
        if (!validatecontolsedit()) {
            
            var Name = $('#txtnameedit').val();
            var Description = $('#txtdescriptionedit').val();

            var DepartmentObjs = {
                id: ID,
                name: Name,
                description: Description
            }

            $.ajax({
                url: APIURLS.Department_UpdateDepartments,
                type: "Post",
                data: JSON.stringify(DepartmentObjs),
                contentType: 'application/json',
                success: function (response) {
                    if (response.ErrorMessage != null || response.ErrorMessage != '') {
                        Swal.fire({
                            title: "Updated!",
                            text: "Department has been updated.",
                            icon: "success",
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.reload();
                            }
                        });
                    }
                }
            });
        }
    });

});

function validatecontolsedit() {
    var isEmpty = false;
    var Name = $('#txtnameedit').val();
    if (Name == '' || Name == null) {
        isEmpty = true;
        $('#errormsgedit').text(`This is a required field!`);
        $('#txtnameedit').addClass('border-danger');
    }
}

$('#txtnameedit').on('change', function () {
    var Name = $('#txtnameedit').val();
    if (Name == '' || Name == null) {
        isEmpty = true;
        $('#errormsgedit').text(`This is a required field!`);
        $('#txtnameedit').addClass("border-danger");
    }
    else {
        isEmpty = false;
        $('#errormsgedit').empty();
        $('#txtnameedit').removeClass('border-danger');
    }
});

