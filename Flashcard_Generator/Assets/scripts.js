
function showToast(message) {
    const toast = document.getElementById("toast");
    toast.textContent = message;
    toast.className = "show";
    setTimeout(function () { toast.className = toast.className.replace("show", ""); }, 3000);
}


function copyToClipboard() {
    navigator.clipboard.writeText(textToCopy).then(function () {
        console.log('Text copied to clipboard');
        showToast('Text copied to clipboard!');
    }).catch(function (error) {
        console.error('Error copying text: ', error);
        showToast('Failed to copy text.');
    });
}


function showModal(id) {

    var row = $("#" + id);

    var wtarget = row.find(".tr-word-target").text();
    var wsource = row.find(".tr-word-source").text();
    var etarget = row.find(".tr-example-target").text();
    var pron = row.find(".tr-pronunciation").text();
    var esource = row.find(".tr-example-source").text();
    var tips = row.find(".tr-tips").text();
    var level = row.find(".tr-level").text();
    var isPublic = row.find(".tr-isPublic").text();
    var ispublic = (isPublic === 'False' || isPublic === 'false') ? 'false' : 'true';

    $("#fcidModal").text(id);
    $("#wtarget").val(wtarget);
    $("#wsource").val(wsource);
    $("#etarget").val(etarget);
    $("#pron").val(pron);
    $("#esource").val(esource);
    $("#tips").val(tips);
    $("#level").val(level);
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

            if (response.d === 'ok') {
                updateTableRow(id, wtarget, wsource, etarget, pron, esource, tips, level, isPublic);
                closeModal();
                showToast("Flashcard Updated!");
            }
            else {
                alert("Error updating flashcard: " + response.d);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:" + xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
    });
}


function updateTableRow(id, wtarget, wsource, etarget, pron, esource, tips, level, isPublic) {

    var row = $("#" + id);

    row.find(".tr-word-target").text(wtarget);
    row.find(".tr-word-source").text(wsource);
    row.find(".tr-example-target").text(etarget);
    row.find(".tr-pronunciation").text(pron);
    row.find(".tr-example-source").text(esource);
    row.find(".tr-tips").text(tips);
    row.find(".tr-level").text(level);
    row.find(".tr-isPublic").text(isPublic);
}


function deleteFlashcard(flashcardId) {
    if (confirm("Are you sure you want to delete the flashcard forever and ever?")) {
        $.ajax({
            type: "POST",
            url: "UserFlashcardsDisplay.aspx/DeleteFlashcard",
            data: JSON.stringify({ flashcardId: flashcardId }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                if (response.d === "ok")
                {
                    $("#" + flashcardId).fadeOut("fast", function () {
                        $(this).remove();
                        showToast('Flashcard deleted!');
                    });
                }
                else
                {
                    alert('Error deleting flashcard: ' + response.d);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error deleting flashcard: " + xhr.responseText);
                alert('Error deleting flashcard - ajax' + xhr.responseText);
            }
        });
    }
}


function deleteAllFlashcards(lsource, ltarget, category) {

    var username = $('#lblLoggedInUser').text();

    if (confirm("Are you sure you want to delete All the flashcards in this table forever and ever?")) {
        $.ajax({
            type: "POST",
            url: "UserFlashcardsDisplay.aspx/DeleteAllFlashcards",
            data: JSON.stringify({
                lsource: lsource,
                ltarget: ltarget,
                category: category,
                username: username
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                if (response.d === "ok") {
                    showToast('Flashcards deleted!');

                    setTimeout(function () {
                        window.location.href = 'FlashcardGroupsDisplayByUser.aspx';
                    }, 2000);
                }
                else
                {
                    alert('Error deleting flashcards: ' + response.d);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error deleting flashcard: " + xhr.responseText);
                alert('Error deleting flashcard - ajax' + xhr.responseText);
            }
        });
    }
}
