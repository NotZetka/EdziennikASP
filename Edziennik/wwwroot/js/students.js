var studentsTable;

$(document).ready(function () {
    loadStudentsTable();
});

function loadStudentsTable() {
    studentsTable = $('#students').DataTable({
        "ajax": {
            "url":"/Teacher/Home/GetStudents"
        },
        "columns": [
            { "data":"firstName", "width":"35%" },
            { "data":"secondName", "width":"35%" },
            { "data": "classname", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `                            
                            <a href="/Teacher/Home/Student?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-fill"></i> Select </a>
                        `
                },
                "width": "10%"
            },
        ]
    });
}