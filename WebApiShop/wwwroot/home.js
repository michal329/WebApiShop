
    const userName = document.querySelector("#userName")
    const firstName = document.querySelector("#firstName")
    const lastName = document.querySelector("#lastName")
    const password = document.querySelector("#password")



const signUp = async () => {
    try {
        const newUser = {
            userName: userName.value,
            firstName: firstName.value,
            lastName: lastName.value,
            password: password.value,
        }
      

        const responsePost = await fetch('https://localhost:44385/api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });

        if (responsePost.status == 400) {
            const responseText = await responsePost.text()
            if (responseText == "password")
                throw Error("your password is too easy")
            throw Error("try again please")
        }

        if (!responsePost.ok) {
            throw Error("Run into a problem")
        }

        const postData = await responsePost.json();
        alert('POST Data:' + JSON.stringify(postData));

    } catch (error) {
        alert(error)
    }
}


////////////////////////////////////////////////////////////////

const RuserName = document.querySelector("#RuserName")
const Rpassword = document.querySelector("#Rpassword")



    const signIn = async () => {

        try {
            const user = {
                userName: RuserName.value,
                password: Rpassword.value,
            }


            alert("send to server: " + JSON.stringify(user));

            const responsePost = await fetch('https://localhost:44385/api/Users/login', {

                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
            if (responsePost.status == 204) {
                alert("Email or password incorrect! please try again ")
                return
            }
            if (!responsePost.ok) {
                throw Error("error")
            }
           
                const result = await responsePost.json();
                window.location.href = "userDetails.html?id=" + result.id;
       
        }
        catch (error) {
            alert(error)
        }
}

    
    async function checkPasswordScore() {
        try {
            const password = document.querySelector("#password").value
            const progress = document.querySelector("#passwordScore")
            const response = await fetch('https://localhost:44385/api/Passwords/PasswordScore', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(password)
            });

            if (!response.ok) {
                throw Error("error")
            }
            const data = await response.json();
            progress.value = data * 25
        }
        catch (error) {
            alert(error)
        }
    }

   

            

