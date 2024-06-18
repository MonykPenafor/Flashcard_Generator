
function showModal(id) {
    var p = document.getElementById('fcidModal');
    p.innerText = id;

    document.getElementById('editModal').style.display = 'block';
    return false;
}



function closeModal() {
    document.getElementById('editModal').style.display = 'none';
    return false; // Prevent default action of the event
}


//function deleteFlashcard() {
//    var btn = document.getElementsByClassName('btnfcidDelete');
//    if (btn.length > 0) {  // Check if there are any elements with the class 'btnfcid'
//        btn[0].click();   // Click the first one found
//    }
//}

function editFlashcard() {
    var btn = document.getElementsByClassName('btnfcidEdit');
    if (btn.length > 0) {  // Check if there are any elements with the class 'btnfcid'
        btn[0].click();   // Click the first one found
    }
}



$(document).ready(function () {
    $('#' + btnClickMeId).click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "UserFlashcardsDisplay.aspx/GetServerTime",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#' + lblMessageId).text(response.d);
            },
            error: function (xhr, status, error) {
                console.error("Error: " + error);
            }
        });
    });
});



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