
function showModal(id, wtarget, wsource, etarget, pron, esource, tips, level) {

    $('#fcidModal').text(id);
    $('#wtarget').val(wtarget);
    $('#wsource').val(wsource);
    $('#etarget').val(etarget);
    $('#pron').val(pron);
    $('#esource').val(esource);
    $('#tips').val(tips);
    $('#level').val(level);

    document.getElementById('editModal').style.display = 'block';
    return false;
}


function closeModal() {
    document.getElementById('editModal').style.display = 'none';
    return false; // Prevent default action of the event
}


function saveChanges() {

    var id = $('#fcidModal').text();
    var wtarget = $('#wtarget').val();
    var wsource = $('#wsource').val();
    var etarget = $('#etarget').val();
    var pron = $('#pron').val();
    var esource = $('#esource').val();
    var tips = $('#tips').val();
    var level = $('#level').val();

    // Chamar editFlashcard com os valores coletados
    editFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level);
}


function editFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level) {
    $.ajax({
        type: "POST",
        url: "UserFlashcardsDisplay.aspx/UpdateFlashcard",
        data: JSON.stringify({
            id: id,
            wtarget: wtarget,
            wsource: wsource,
            etarget: etarget,
            pron: pron,
            esource: esource,
            tips: tips,
            level: level
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Success: " + response.d);
        },
        error: function (xhr, status, error) {
            console.error("Error updating flashcard: " + xhr.responseText);
        }
    });
}





function deleteFlashcard(flashcardId) {
    $.ajax({
        type: "POST",
        url: "UserFlashcardsDisplay.aspx/DeleteFlashcard",
        data: JSON.stringify({ flashcardId: flashcardId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Success: " + response.d);
        },
        error: function (xhr, status, error) {
            console.error("Error deleting flashcard: " + xhr.responseText);
            if (xhr.status === 401) {
                alert("Unauthorized access. Please log in.");
            }
        }
    });
}

