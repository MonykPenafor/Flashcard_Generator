
function showModal(id) {
    var paragraph = document.getElementById('fcid');
    paragraph.innerText = id;

    document.getElementById('editModal').style.display = 'block';
}


function closeModal() {
    document.getElementById('editModal').style.display = 'none';
    return false; // Prevent default action of the event
}

