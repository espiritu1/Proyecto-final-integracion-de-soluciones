var peliculasUri = '/api/peliculas/';
var directorsUri = '/api/directors/';

function ajaxHelper(uri, method, data) {
    
    $('#error').html('');
    return $.ajax({
        type: method,
        url: uri,
        dataType: 'json',
        contentType: 'application/json',
        data: data ? JSON.stringify(data) : null
    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('#error').html(errorThrown);
    });
}

function getDirectors() {
    ajaxHelper(directorsUri, 'GET').done(function (data) {
        ImprimeDirectores(data);
    });
}

function getAllPeliculas() {
    ajaxHelper(peliculasUri, 'GET').done(function (data) {
        ImprimeLista(data);
    });
}

function ImprimeDirectores(jsondata) {
    var directors = $('#DirectorId');

    
    $(directors).empty();
    $.each(jsondata, function (i, obj) {
        $(directors).append($('<option value="' + obj.Id + '">' + obj.Nombre + '</option>'));
    });
}

function ImprimeLista(jsondata) {
    var peliculas = $('#peliculas');
    var plantilla = $('#peliculas li:first').clone();

    
    $(peliculas).empty();
    $.each(jsondata, function (i, obj) {
        var pelicula = plantilla.clone();
        $(pelicula).find('.DirectorNombre').text(obj.DirectorNombre);
        $(pelicula).find('.Titulo').text(obj.Titulo);
        $(pelicula).find('#peliculaId').text(obj.Id);
        $(pelicula).find('a').click(function () {
            ajaxHelper(peliculasUri + obj.Id, 'GET').done(function (data) {
                ImprimeDetalle(data);
            });
        });
        $(pelicula).appendTo(peliculas);
    });
}

function ImprimeDetalle(obj) {
    var tabladetalle = $('.table-detalles');

    $(tabladetalle).find('.DirectorNombre').text(obj.DirectorNombre);
    $(tabladetalle).find('.Titulo').text(obj.Titulo);
    $(tabladetalle).find('.Anio').text(obj.Anio);
    $(tabladetalle).find('.Genero').text(obj.Genero);
    $(tabladetalle).find('.Precio').text(obj.Precio);
}

function addPelicula() {
    var pelicula = {
        DirectorId: $('#DirectorId').val(),
        Genero: $('#inputGenero').val(),
        Precio: $('#inputPrecio').val(),
        Titulo: $('#inputTitulo').val(),
        Anio: $('#inputoAnio').val()
    };

    ajaxHelper(peliculasUri, 'POST', pelicula).done(function (item) {
        getAllPeliculas();
    });
    return false;
}

/*function eliminar()
{
    $("#borrar").on("click", function () {
        alert('estyo en onclic');
    });
   
}*/

// Fetch the initial data.
getAllPeliculas();
getDirectors();
//eliminar();
