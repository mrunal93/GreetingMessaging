
function InsertEmployee() {
    var data = {
        "First_Name": $('.FirstName-input').val(),
        "Last_Name": $('.LastName-input').val(),
        "Email": $('.Email-input').val(),
    }
    console.log("data", JSON.stringify(data));
    $.ajax(
        {
            type: 'POST',
            url: 'http://localhost:3000/Employee',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function () {
                alert('Employee added successfully');
            },
            error: function () {
                console.log("error");
            }

        })
}
function localStorage(id) {
    console.log(id)
    var data = {
        "First_Name": $('.FirstName-Edit').val(),
        "Last_Name": $('.LastName-Edit').val(),
        "Email": $('.Email-Edit').val(),
    }
    console.log("data",id);
    $.ajax(
        {
            type: 'PUT',
            url: 'http://localhost:3000/Employee/' + id,
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                alert('Employee Edited successfully');
                location.reload();
            },
            error: function () {
                console.log("error");
            }

        })
}
function DeleteEmployee(id) {
    
    console.log("data", id);
    $.ajax(
        {
            type: 'DELETE',
            url: 'http://localhost:3000/Employee/' +id,
            success: function () {
                alert('Employee Deleted successfully');
                location.reload();
            },
            error: function () {
                console.log("error");
            }

        })
}

$.ajax(
        {
            type: 'GET',
            url: 'http://localhost:3000/Employee',
            contentType: 'application/json',
            success: function (data) {
                $.each(data, function (key, value) {
                    var First_Name = value.First_Name;
                    var Last_Name = value.Last_Name;
                    var Email = value.Email;
                    $('<tr><td>' + First_Name + '<td>' + Last_Name + '<td>' + Email +
                        '<td><form action="/html/EditPage.html" ><button id=' + value.id + ' onClick="localStorage(id)"  class="Edit-Button"><img src="/images/Edit.png" style="width:20px; height:20px;"/> ' +
                        '<td><form ><button id='+value.id+' onClick="DeleteEmployee(id)"  class="Delete-Button"><img src="/images/icons8-remove-64.png" style="width:20px;height:20px;"/>')
                        .appendTo("#allEmployeeTable");
                   
                })
                console.log(data);
            },
            error: function () {
                console.log("error");
            }

        })

