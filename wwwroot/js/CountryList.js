var dataTable;

$(document).ready(function () {
    LoadCountryList();
})

function LoadCountryList() {
     
    dataTable = $('#tbldata').DataTable({
        "ajax": {

            "url": "/Home/GetCountryList",

        },
        "columns": [
            { "data": "name", "width": "80%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="row">
                    <div class="text-center ">

                    <a class="btn btn-info" href="/Home/Upsert/${data}" asp-action="Upsert"> 
                    <i class = "fas fa-edit"></i> 
                    </a>

                    <a class="btn btn-danger"   onclick=Delete("/Home/Delete/${data}")>
                    <i class ="fas fa-trash-alt"></i>
                    </a>
                   </div>
                   </div>
                   `;
                }

            }
        ]

    })
}



function Delete(url) {
     
    swal({

        title: "Are you sure you want to delete?",
        text: "This information will Permanently deleted?!!",
        buttons: true,
        icon: "warning",
        dangerModel: true

    }).then((willdelete) => {
        if (willdelete) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.messages);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.messages)
                    }
                }
            })
        }
    })
}
