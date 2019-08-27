function onloadEventHandler()
{
    var studentList = getStudentList();
}

function getStudentList()
{
    $.ajax(
        {
            url: 'https://localhost:44343/api/students'
        })
        .done(function (data, textStatus, xhr)
        {
            //alert(data);
            // console.log(data); 
            // alert(data[0].name + " ve " + data[1].name);

            fillStudentTable(data);
            return data;
        });
}

function fillStudentTable(data)
{
    var tBody = document.getElementById("studentTableBody");

    for (i = 0; i < data.length; i++)
    {
        var tableRow = document.createElement('tr');
        tableRow.innerHTML =
            "<td>" + data[i].id + "</td>" +
            "<td>" + data[i].name + "</td>" +
            "<td>" + data[i].surname + "</td>" +
            "<td>" + data[i].schoolId + "</td>" +
            "<td>" + "<button id='" + data[i].id + "' class='btn btn-danger' onclick='deleteButtonClickHandler(this)'>" + "S" + "\u0130" + "L " + "</button>" + "</td>";

        tBody.appendChild(tableRow);
    }
}

function deleteButtonClickHandler(button) 
{
    // Emin misiniz diye sorulsun!
    
    var studentId = button.id;
    postDeleteRequest(studentId)
}

function postDeleteRequest(studentId) 
{
    $.ajax(
    {
        type: 'DELETE',
        url: 'https://localhost:44343/api/students',
        dataType: 'json',
        contentType: 'application/json',
        data:
            JSON.stringify(
                {
                    "studentId": studentId
                }),
        success: function (data) 
        {
            alert("success");
        },
        error: function (jqXHR, textStatus, errorThrown) 
        {
            alert("error");
        }
    });
}