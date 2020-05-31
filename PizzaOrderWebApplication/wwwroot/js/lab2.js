const uri = 'api/Customers';
let customers = [];
function getCustomers() {
    fetch(uri).then(response => {
        if (response.ok)
            return response.json();
        else throw new Error("Unable to get customers");
    })
        .then(data => _displayCustomers(data))
        .catch(error => alert(error));
};
function addCustomer() {
    const addNameTextbox = document.getElementById('add-name');
    const addEmailTextbox = document.getElementById('add-email');
    const addPhoneTextbox = document.getElementById('add-phone');
    const addAddressTextbox = document.getElementById('add-address');
    const customer = {
        name: addNameTextbox.value.trim(),
        email: addEmailTextbox.value.trim(),
        phoneNumber: addPhoneTextbox.value.trim(),
        address: addAddressTextbox.value.trim()
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
        .then(response => {
            if (response.ok)
                return response.json();
            else throw new Error("Unable to add customer");
        })
        .then(() => {
            getCustomers();
            addNameTextbox.value = '';
            addEmailTextbox.value = '';
            addPhoneTextbox.value = '';
            addAddressTextbox.value = '';
        })
        .catch(error => alert(error));
};
function deleteCustomers(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCustomers())
        .catch(error => alert('Unable to delete customer.' + error));
};
function displayEditForm(id) {
    const customer = customers.find(customer => customer.id === id);
    document.getElementById('edit-id').value = customer.id;
    document.getElementById('edit-name').value = customer.name;
    document.getElementById('edit-email').value = customer.email;
    document.getElementById('edit-phone').value = customer.phoneNumber;
    document.getElementById('edit-address').value = customer.address;
    document.getElementById('editCustomer').style.display = 'block';
    //}
};
function updateCustomer() {
    const customerId = document.getElementById('edit-id').value;
    const customer = {
        Id: parseInt(customerId, 10),
        Name: document.getElementById('edit-name').value.trim(),
        Email: document.getElementById('edit-email').value.trim(),
        phoneNumber: document.getElementById('edit-phone').value.trim(),
        Address: document.getElementById('edit-address').value.trim()
    };
    fetch(`${uri}/${customerId}`
        , {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(customer)
        }).then(response => {
            if (!response.ok)
                throw new Error("Unable to update customers");
        })

        .then(() => getCustomers())
        .catch(error => alert(error));
    closeInput();
    return false;
};
function closeInput() {
    document.getElementById('editCustomer').style.display = 'none';
};
function _displayCustomers(data) {
    const tBody = document.getElementById('customers');
    tBody.innerHTML = '';

    const button = document.createElement('button');
    data.forEach(customer => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${customer.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCustomers(${customer.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textName = document.createTextNode(customer.name);
        td1.appendChild(textName);

        let td2 = tr.insertCell(1);
        let textEmail = document.createTextNode(customer.email);
        td2.appendChild(textEmail);

        let td3 = tr.insertCell(2);
        let textphoneNumber = document.createTextNode(customer.phoneNumber);
        td3.appendChild(textphoneNumber);


        let td4 = tr.insertCell(3);
        let textAddress = document.createTextNode(customer.address);
        td4.appendChild(textAddress);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);
        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });
    customers = data;
};
/*
const uri = 'api/Customers';
let customers = [];
function getCustomers() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCustomers(data))

        .catch(error => console.error('Unabletogetcustomers.', error));
};
function addCustomer() {
    const addNameTextbox = document.getElementById('add-name');
    const addEmailTextbox = document.getElementById('add-email');
    const addPhoneTextbox = document.getElementById('add-phone');
    const addAddressTextbox = document.getElementById('add-address');
    const customer = {
        Name: addNameTextbox.value.trim(),
        Email: addEmailTextbox.value.trim(),
        phoneNumber: addPhoneTextbox.value.trim(),
        Address: addAddressTextbox.value.trim()
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
        .then(response => response.json())
        .then(() => {
            getCustomers();
            addNameTextbox.value = '';
            addEmailTextbox.value = '';
            addPhoneTextbox.value = '';
            addAddressTextbox.value = '';
        })
        .catch(error => console.error('Unabletoaddcustomer.', error));
};
function deleteCustomers(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCustomers())
        .catch(error => console.error('Unabletodeletecustomer.', error));
};
function displayEditForm(id) {
    const customer = customers.find(customer => customer.Id === id);
    document.getElementById('edit-id').value = customer.Id;
    document.getElementById('edit-name').value = customer.Name;
    document.getElementById('edit-email').value = customer.Email;
    document.getElementById('edit-phone').value = customer.phoneNumber;
    document.getElementById('edit-address').value = customer.Address;
    document.getElementById('editForm').style.display = 'block';
};
function updateCustomery() {
    const customerId = document.getElementById('edit-id').value;
    const customer = {
        Id: parseInt(categoryId, 10),
        Name: document.getElementById('edit-name').value.trim(),
        Email: document.getElementById('edit-email').value.trim(),
        phoneNumber: document.getElementById('edit-phone').value.trim(),
        Address: document.getElementById('edit-address').value.trim()
    };
    fetch(`${uri}/${customerId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })

        .then(() => getCustomers())
        .catch(error => console.error('Unabletoupdatecustomer.', error));
    closeInput();
    return false;
};
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
};
function _displayCustomers(data) {
    const tBody = document.getElementById('customers');
    tBody.innerHTML = '';

    const button = document.createElement('button');
    data.forEach(customer => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', displayEditForm(`${customer.Id}`));
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', deleteCategory(`${customer.Id}`));
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textName = document.createTextNode(customer.Name);
        td1.appendChild(textName);

        let td2 = tr.insertCell(1);
        let textEmail = document.createTextNode(customer.Email);
        td2.appendChild(textEmail);

        let td3 = tr.insertCell(2);
        let textphoneNumber = document.createTextNode(customer.phoneNumber);
        td3.appendChild(textphoneNumber);


        let td4 = tr.insertCell(3);
        let textAddress = document.createTextNode(customer.Address);
        td4.appendChild(textAddress);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);
        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });
    customers = data;
};
*/