
function showModal(id, wtarget, wsource, etarget, pron, esource, tips, level) {


    var p = document.getElementById('fcidModal');
    p.innerText = id;

    document.getElementById('wtarget').value = wtarget;
    document.getElementById('wsource').value = wsource;
    document.getElementById('etarget').value = etarget;
    document.getElementById('pron').value = pron;
    document.getElementById('esource').value = esource;
    document.getElementById('tips').value = tips;
    document.getElementById('level').value = level;

    document.getElementById('editModal').style.display = 'block';
    return false;
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

