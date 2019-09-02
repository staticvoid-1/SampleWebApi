function onloadEventHandler() {
    var studentList = getStudentList();
}

function getStudentList() {
    $.ajax(
        {
            url: 'https://localhost:44343/api/students'
        })
        .done(function (data, textStatus, xhr) {
            //alert(data);
            // console.log(data); 
            // alert(data[0].name + " ve " + data[1].name);

            fillStudentTable(data);
            return data;
        });
}

function addStudentRow(student, tBody) {
    var tableRow = document.createElement('tr');
    tableRow.innerHTML =
        "<td>" + student.id + "</td>" +
        "<td>" + student.name + "</td>" +
        "<td>" + student.surname + "</td>" +
        "<td>" + student.schoolId + "</td>" +
        "<td>" + "<button id='" + student.id + "Button" + "' class='btn btn-danger' onclick='deleteButtonClickHandler(this)'>" + "S" + "\u0130" + "L " + "</button>" + "</td>";
    tableRow.id = student.id + "Row";
    tBody.appendChild(tableRow);
}

function removeStudentRow(student)
{
    $("#studentTableBody").find("#" + student.id+"Row").remove();
    
}

function fillStudentTable(data) {
    var tBody = document.getElementById("studentTableBody");

    for (i = 0; i < data.length; i++) {
        addStudentRow(data[i], tBody);
    }
}



function deleteButtonClickHandler(button) {
 

    var studentId = button.id.substring(0, button.id.length-6);
    postDeleteRequest(studentId);
}

function postAddRequest() {
    var nameInput = document.getElementById('nameInput');
    var surnameInput = document.getElementById('surnameInput');
    var schoolIdInput = document.getElementById('schoolIdInput');
    $.ajax(
        {
            type: 'POST',
            url: 'https://localhost:44343/api/students',
            contentType: 'application/json',
            data:
                JSON.stringify(
                    {
                        "name": nameInput.value,
                        "surname": surnameInput.value,
                        "schoolId": schoolIdInput.value
                    }),
            success: function (student) {
                var tBody = document.getElementById("studentTableBody");
                addStudentRow(student, tBody);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error, status = " + textStatus + ", " + "error thrown: " + errorThrown);
            }
        });
}

function postDeleteRequest(studentId) {
    $.ajax(
        {
            type: 'DELETE',
            url: 'https://localhost:44343/api/students',
            contentType: 'application/json',
            data:
                JSON.stringify(
                    {
                        "studentId": studentId
                    }),
            success: function (student) {
               
                removeStudentRow(student);
            },
            error: function (jqXHR, textStatus, errorThrown) {

                console.log(jqXHR.statusText);
                console.log(textStatus);
                console.log(errorThrown);


            }
        });
}