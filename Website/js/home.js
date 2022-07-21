$(document).ready(function(){
  loadMovies();
    $("#create").hide();
    $("#edit").hide();
    $("#CreateDvd").on('click', function(){
      event.preventDefault();
    })
    $("#SearchButton").on('click', function(){
      event.preventDefault();
    })
    $("#create-button").on('click', function(){
      event.preventDefault();
    })
    $("#editButton").on('click', function(){
      event.preventDefault();
      $("#nav-menu").hide();
      $("#tableOfMovies").hide();
      $("#create").hide();
      $("edit").show();
      editDvd()
    })
});

function loadMovies(){
    $.ajax({
      type: 'GET',
      url: 'https://localhost:44317/dvds',
      success: function(itemArray) {
        $.each(itemArray, function (index, movie){
          var title = movie.title;
          var releaseYear = movie.releaseYear;
          var director = movie.director;
          var rating = movie.rating;
          var id = movie.dvdId;


          var row = '<tr>';
          row += '<th scope="row"> <a href="" id="title-of-movie">' + title + '</a> </th>';
          row += '<td>'+ releaseYear + '</td>';
          row += '<td>' + director + '</td>';
          row += '<td>' + rating + '</td>';
          row += '<td><a id="edit-button" href="#" onclick="editDvd(' + id + ')">Edit</a> | <a href="#" onclick="deleteDvd(' + id + ')">Delete</a></td>';
          row += '</tr>';

          $('#table-body').append(row);

        })
      },
      error: function(){
        console.log("error");
      }
    });
}

function searchForDvds(){
    var category = $('#category-prompted').find(':selected').val();
    var searchTerm = $('#searchbar').val();
    $('#table-body').empty();
    $.ajax({
        type:'GET',
        url: 'https://localhost:44317/dvds/' + category + '/' + searchTerm,
        success: function(itemArray){
            $.each(itemArray, function(index, dvd){
                var id = dvd.dvdId;
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes;

                var row = '<tr>';
                row += '<th scope="row"> <a href="" id="title-of-movie">' + title + '</a> </th>';
                row += '<td>'+ releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                 row += '<td> <a id="editMe" onclick="editDvd('+id+')" href="#"> Edit</a> | <a id="deleteMe" onclick="deleteDvd('+id+')" href="#" data-toggle="modal" data-target="#myModal"> Delete</a></td>';
                row += '</tr>';
                $('#table-body').append(row);
            })
        },
        error: function(){
            $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
    })
};
$("#create-cancel-button").on('click', function(){
    $("#nav-menu").show();
    $("#tableOfMovies").show();
    $("#create").hide();
})

$("#edit-cancel-button").on('click', function(){
    $("#nav-menu").show();
    $("#tableOfMovies").show();
    $("#edit").hide();
})

$("#CreateDvd").on('click', function(){
  $("#nav-menu").hide();
  $("#tableOfMovies").hide();
  $("#create").show();
})

function onclickCreateDvd(){
    var haveValidationErrors = checkAndDisplayValidationErrors($('#create-dvds').find('input'));
    if(haveValidationErrors){
        return false;
    }
    $.ajax({
        url: 'https://localhost:44317/dvd',
        type: 'POST',
        data: JSON.stringify(
            {
                "title": $('#title-prompted').val(),
                "releaseYear": parseInt($('#release-date-prompted').val()),
                "director": $('#movie-director-prompted').val(),
                "rating": $('#ratings-prompted').find(':selected').val(),
                "notes": $('#notes-prompted').val(),
            }
        ),
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
        success:function(){
            $("#create").hide();
            $("#nav-menu").show();
            $('#table-body').empty();
            $("#tableOfMovies").show();
            console.log("success");
            loadMovies();
        },
        error:function(){
            $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text(message));
        }
    })
}

function checkAndDisplayValidationErrors(input){
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function(){
        if(!this.validity.valid){
            var errorField = $('label[for=' + this.dvdId +']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message) {
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
};

function deleteDvd(id){
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44317/dvd/' + id,
        success: function(){
            $('#table-body').empty();
            loadMovies();
        }
    })
}

function editDvd(dvdId){
    $("#nav-menu").hide();
    $("#tableOfMovies").hide();
    $("#edit").show();
    $('#save-button').click(function(event){
        var haveValidationErrors = checkAndDisplayValidationErrors($('#edit-dvds').find('input'));
        if(haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'PUT',
            url: 'https://localhost:44317/dvd'+ $('#editDvdId').val(),
            data: JSON.stringify({
                "title": $('#edit-title-prompted').val(),
                "releaseYear": $('#edit-realese-date-prompted').val(),
                "director": $('#edit-movie-director-prompted').val(),
                "rating": $('#edit-ratings-prompted').val(),
                "notes": $('#edit-notes-prompted').val()
            }),
            headers: {
                'Accept': '*/*',
                'Content-Type':'application/json'
            },
            success: function(){
                // $('#errorMessage').empty();
                $("#edit").hide();
                $("#nav-menu").show();
                $('#table-body').empty();
                $("#tableOfMovies").show();
                console.log("success");
                loadMovies();
                // console.log(dvdId);
            },
            'error': function(error) {
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text(error));
                console.log(error);
            }
        })
    })
};
