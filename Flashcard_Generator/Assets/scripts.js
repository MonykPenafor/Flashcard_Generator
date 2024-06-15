console.log("heyyyyyyy");

function showToastAndRedirect(message, redirectUrl) {
    alert(message);
    window.location.href = redirectUrl;
}



function showModal(id) {
    var paragraph = document.getElementById('fcid');
    paragraph.innerText = id;

    document.getElementById('editModal').style.display = 'block';
}

function closeModal() {
    document.getElementById('editModal').style.display = 'none';
}

function saveChanges() {
    // Implement save logic here
    closeModal();
}
