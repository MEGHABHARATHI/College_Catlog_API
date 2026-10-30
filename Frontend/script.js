$(document).ready(function () {

    // GET ALL COLLEGES
    $("#getColleges").click(function () {

        $.ajax({
            url: "http://localhost:5084/api/College/GetAllColleges",
            method: "GET"
        })
        .done(function (response) {

            console.log(response);

            $("#collegeList").empty();

            response.forEach(function (college) {

                $("#collegeList").append(
                    "<tr>" +
                    "<td>" + college.id + "</td>" +
                    "<td>" + college.name + "</td>" +
                    "<td>" + college.location + "</td>" +
                    "<td>" + college.university + "</td>" +
                    "<td>" +
                    "<button class='delete-btn' data-id='" +
                    college.id +
                    "'>Delete</button>" +
                    "</td>" +
                    "</tr>"
                );

            });

        })
        .fail(function (error) {

            console.log(error);

            alert("Failed to get colleges.");

        });

    });


    // POST - ADD COLLEGE
    $("#collegeForm").submit(function (event) {

        event.preventDefault();

        var college = {

            name: $("#collegeName").val(),

            location: $("#collegeLocation").val(),

            university: $("#collegeUniversity").val()

        };

        $.ajax({

            url: "http://localhost:5084/api/College",

            method: "POST",

            contentType: "application/json",

            data: JSON.stringify(college)

        })
        .done(function (response) {

            console.log(response);

            alert("College added successfully.");

            $("#collegeForm")[0].reset();

            $("#getColleges").click();

        })
        .fail(function (error) {

            console.log(error);

            alert("Failed to add college.");

        });

    });


    // DELETE COLLEGE
    $(document).on("click", ".delete-btn", function () {

        var id = $(this).data("id");

        $.ajax({

            url: "http://localhost:5084/api/College/" + id,

            method: "DELETE"

        })
        .done(function (response) {

            console.log(response);

            alert("College deleted successfully.");

            $("#getColleges").click();

        })
        .fail(function (error) {

            console.log(error);

            alert("Failed to delete college.");

        });

    });

});