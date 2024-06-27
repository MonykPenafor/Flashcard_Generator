﻿
function showModal(id, wtarget, wsource, etarget, pron, esource, tips, level, isPublic) {


    $("#fcidModal").text(id);
    $("#wtarget").val(wtarget);
    $("#wsource").val(wsource);
    $("#etarget").val(etarget);
    $("#pron").val(pron);
    $("#esource").val(esource);
    $("#tips").val(tips);
    $("#level").val(level);

    var ispublic = (isPublic === 'False') ? 'false' : 'true';
    $("#isPublic").val(ispublic);


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
    var isPublic = $('#isPublic').val();

    if (!wtarget || !wsource || !etarget || !pron || !esource || !tips) {
        alert("Por favor, preencha todos os campos.");
        return;
    }

    editFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level, isPublic);

}


function editFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level, isPublic) {
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
            level: level,
            isPublic: isPublic
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            updateTableRow(id, wtarget, wsource, etarget, pron, esource, tips, level);
            alert("Success: " + response.d);

            closeModal();
        },
        error: function (xhr, status, error) {
            console.error("Error updating flashcard: " + xhr.responseText);
        }
    });
}



function updateTableRow(id, wtarget, wsource, etarget, pron, esource, tips, level) {
    var rowId = 'Row' + id;
    var row = $("#" + rowId);

    row.find(".flashcad-table-row-cell").eq(0).html(wtarget + "<br />" + wsource);
    row.find(".flashcad-table-row-cell").eq(1).html(etarget + "<br />" + pron + "<br />" + esource);
    row.find(".flashcad-table-row-cell").eq(2).text(tips);
    row.find(".flashcad-table-row-cell").eq(3).text(level);


}


//function deleteFlashcard(flashcardId) {
//    $.ajax({
//        type: "POST",
//        url: "UserFlashcardsDisplay.aspx/DeleteFlashcard",
//        data: JSON.stringify({ flashcardId: flashcardId }),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            showToast('Flashcard deleted!')
//        },
//        error: function (xhr, status, error) {
//            console.error("Error deleting flashcard: " + xhr.responseText);
//            showToast('Error deleting flashcard');
//        }
//    });
//}

function copyToClipboard() {
    navigator.clipboard.writeText(textToCopy).then(function () {
        console.log('Text copied to clipboard');
        showToast('Text copied to clipboard!');
    }).catch(function (error) {
        console.error('Error copying text: ', error);
        showToast('Failed to copy text.');
    });
}

function showToast(message) {
    const toast = document.getElementById("toast");
    toast.textContent = message;
    toast.className = "show";
    setTimeout(function () { toast.className = toast.className.replace("show", ""); }, 3000);
}





function deleteFlashcard(flashcardId) {
    $.ajax({
        type: "POST",
        url: "UserFlashcardsDisplay.aspx/DeleteFlashcard",
        data: JSON.stringify({ flashcardId: flashcardId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d === "Success") {
                $.when($("#" + flashcardId).remove()).done(function () {
                    showToast('Flashcard deleted!');
                });
            } else {
                showToast('Error deleting flashcard');
            }
        },
        error: function (xhr, status, error) {
            console.error("Error deleting flashcard: " + xhr.responseText);
            showToast('Error deleting flashcard - ajax');
        }
    });
}