

const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");


alert(id)

async function loadUser() {
    const response = await fetch('https://localhost:44385/api/Users/' + id);
    if (response.ok) {
        const user = await response.json();
        hello.innerText = "שלום " + user.firstName; 
    } else {
        alert("לא נמצא משתמש");
    }
}
loadUser();

const userName = document.querySelector("#NuserName")
const firstName = document.querySelector("#NfirstName")
const lastName = document.querySelector("#NlastName")
const password = document.querySelector("#Npassword")

const update = async () => {

    const newDetails = {
        userName: userName.value,
        firstName: firstName.value,
        lastName: lastName.value,
        password: password.value,
    }



    const responsePost = await fetch('https://localhost:44385/api/Users/' + id, {

        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newDetails)

    });
    const postData = await responsePost.json();
    alert('POST Data:' + JSON.stringify(postData));
    if (responsePost.ok) {
        window.location.href = "home.html";
    }
}