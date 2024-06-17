
//function deleteFlashcard(flashcardId) {
//    document.getElementById('<%= hfFlashcardId.ClientID %>').value = flashcardId;
//    document.getElementById('<%= btnDeleteHidden.ClientID %>').click();
//}


function showModal(id) {
    var paragraph = document.getElementById('fcid');
    paragraph.innerText = id;

    document.getElementById('editModal').style.display = 'block';
}


function closeModal() {
    document.getElementById('editModal').style.display = 'none';
    return false; // Prevent default action of the event
}


//function saveChanges() {

//    var flashcardId = document.getElementById('fcid').innerText;

//    // AJAX request
//    $.ajax({
//        type: "POST",
//        url: "UserFlashcardsDisplay.aspx/UpdateFlashcard",
//        data: JSON.stringify({ flashcardId: flashcardId }),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function () {
//            // Optional: Handle success response
//            console.log('Flashcard updated successfully');
//            closeModal();
//            // You can optionally reload or update the UI here
//        },
//        error: function (xhr, status, error) {
//            // Optional: Handle error response
//            console.error('Error updating flashcard:', error);
//            // Display an error message or handle errors as needed
//        }
//    });
//}


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