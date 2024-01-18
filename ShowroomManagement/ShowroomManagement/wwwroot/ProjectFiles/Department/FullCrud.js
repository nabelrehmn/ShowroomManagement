
$(document).ready(function () {
    LoadData()
});

// ------------- DEPARMENT DATA FATCH FROM API ------------- //
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
                        <a href="#" class="btn btn-info p-2"><i class="fas fa-edit"></i></a>
                        <a href="#" class="btn btn-danger p-2"><i class="fas fa-trash-alt"></i></a>
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
            "name": Name,
            "description": Description
        }

        $.ajax({
            url: APIURLS.Department_AddDepartments,
            type: "Post",
            data: JSON.stringify(DepartmentObj),
            contentType: 'application/json',
            dataType: 'json',
            success: function (Response) {
                return Response;
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



