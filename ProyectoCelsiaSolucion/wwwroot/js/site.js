// site.js

// Código para el modal de eliminación
var deleteModal = document.getElementById('deleteModal');
deleteModal.addEventListener('show.bs.modal', function (event) {
    var button = event.relatedTarget;
    var customerId = button.getAttribute('data-id');
    var customerName = button.getAttribute('data-name');

    var modalCustomerName = deleteModal.querySelector('#modalCustomerName');
    var modalCustomerId = deleteModal.querySelector('#modalCustomerId');

    modalCustomerName.textContent = customerName;
    modalCustomerId.value = customerId;
});

// Código para el modal de detalles
var detailModal = document.getElementById('detailModal');
detailModal.addEventListener('show.bs.modal', function (event) {
    var button = event.relatedTarget;
    var customerId = button.getAttribute('data-id');

    fetch(`/Customer/Details/${customerId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('detailCustomerId').textContent = data.id;
            document.getElementById('detailCustomerNames').textContent = data.names;
            document.getElementById('detailCustomerDocument').textContent = data.document;
            document.getElementById('detailCustomerAddress').textContent = data.address;
            document.getElementById('detailCustomerPhone').textContent = data.phone;
            document.getElementById('detailCustomerEmail').textContent = data.email;
        });
});

// Código para el modal de eliminación de todos los clientes
var deleteAllModal = document.getElementById('deleteAllModal');
deleteAllModal.addEventListener('show.bs.modal', function (event) {
});