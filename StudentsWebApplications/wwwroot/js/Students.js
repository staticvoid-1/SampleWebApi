function onloadEventHandler() {


    var studentList = getStudentList();



}

function getStudentList() {
    $.ajax({
        url: 'http://localhost:62885/api/student'
    }).done(function (data, textStatus, xhr) {
        //alert(data);
        //console.log(data);

        //alert(data[0].name + " ve " + data[1].name);
        console.log(Object.values(data));

        fillStudentTable(data);
        return data;
    });

}

function fillStudentTable(data) {

    var tBody = document.getElementById("studentTableBody");

    for (i = 0; i < data.length; i++) {
        var tableRow = document.createElement('tr');
        tableRow.innerHTML =
            "<td>" + data[i].name + "</td>" +
            "<td>" + data[i].surname + "</td>" +
            "<td>" + data[i].schoolId + "</td>";

        tBody.appendChild(tableRow);

    }
}