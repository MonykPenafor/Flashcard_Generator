
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


function editFlashcard(flashcardId) {
    $.ajax({
        type: "POST",
        url: "UserFlashcardsDisplay.aspx/UpdateFlashcard",
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





function closeModal() {
    document.getElementById('editModal').style.display = 'none';
    return false; // Prevent default action of the event
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

