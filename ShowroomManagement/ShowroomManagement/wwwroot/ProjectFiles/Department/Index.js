

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

