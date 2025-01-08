window.ShowToaster = function (type, message) {
    if (type === 'success') {
        toastr.success(message)
    }
    if (type === 'error') {
        toastr.error(message)
    }
    if (type === 'warning') {
        toastr.warning(message)
    }
}

window.showSwal = function (type, message) {
    if (type === 'success') {
        Swal.fire({
            position: "top-end",
            title: "Good Job!",
            text: message,
            icon: "success",
            draggable: true
        });
    }
    if (type === 'error') {
        Swal.fire({
            position: "top-end",
            icon: "error",
            title: "Oops...",
            text: message,
            draggable: true
        });
    }
    
}