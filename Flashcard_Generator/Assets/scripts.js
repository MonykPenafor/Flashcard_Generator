
function showModal(id) {
    var p = document.getElementById('fcid');
    p.innerText = id;

    document.getElementById('editModal').style.display = 'block';
    return false;
}



function closeModal() {
    document.getElementById('editModal').style.display = 'none';
    return false; // Prevent default action of the event
}


function deleteFlashcard() {
    var btn = document.getElementById('btnfcid');
    btn.click;
}
