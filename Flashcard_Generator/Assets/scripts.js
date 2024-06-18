
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


function deleteFlashcard() {
    var btn = document.getElementsByClassName('btnfcidDelete');
    if (btn.length > 0) {  // Check if there are any elements with the class 'btnfcid'
        btn[0].click();   // Click the first one found
    }
}

function editFlashcard() {
    var btn = document.getElementsByClassName('btnfcidEdit');
    if (btn.length > 0) {  // Check if there are any elements with the class 'btnfcid'
        btn[0].click();   // Click the first one found
    }
}
