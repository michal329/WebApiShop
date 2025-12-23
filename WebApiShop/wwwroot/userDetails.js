

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
    try {
        // Check password strength before submitting
        const response = await fetch('https://localhost:44385/api/Passwords/PasswordScore', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password.value)
        });
        
        if (response.ok) {
            const passwordScore = await response.json();
            if (passwordScore < 2) {
                alert(`Password too weak (score: ${passwordScore}/4). Please choose a stronger password.`);
                return;
            }
        }
    } catch (error) {
        console.error('Error checking password:', error);
    }

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
    if (responsePost.ok) {
        window.location.href = "home.html";
    } else {
        const text = await responsePost.text();
        alert("Error: " + text);
    }
}