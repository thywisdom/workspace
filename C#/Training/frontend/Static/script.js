    //Asynchronous methos (Promises)

    let success = Number(prompt("Enter 0 or 1"))
    const message = "The Asynchronous Methos has been invoked and returned the above results!" 

    function getUsers()
    {
        return new Promise((resolve, reject) =>
        {
            setTimeout(() => {
                if(success){
                resolve( 
                    [
                        {username: "Suman",email:"sumanezhumalai@gmail.com"},
                        {username:  "Neednt",email:"witnesstowisdom@gmail.com"},
                        {username: "Tess", email : "testcasefreedom@gmail.com"} 
                    ]
                )}
                else
                {
                    reject("Failed to retrieve")
                }
            }, 2000);
        })
    }

    getUsers()
    .then((users) => console.log(users))
    .catch((error) => console.log(error))
    .finally(() => console.log(message))





    // Synchronous method
  
  /* function getUsers()
    {
        return[
        {username: "Suman",email:"sumanezhumalai@gmail.com"},
        {username:  "Neednt",email:"witnesstowisdom@gmail.com"},
        {username: "Tess", emial : "testcasefreedom@gmail.com"}
        ]
    }

    function findUser(username)
    {
        const users = getUsers()
        const usr = users.find((user) => user.username == username)
        return usr
    }

    let name = prompt("Enter name: ") 
    console.log(findUser(name)) */






    //Simple Arrow function

//  let question = "Do you Agree?"
//  confirm(question)? alert("You Agreed!") : alert("You Cancelled the Execution!")


    //Simple Function

/* let name = prompt("Enter name : ")
 let age = prompt("Enter Age : ")

 function showMessage(name,age)
 {
    if(age.trim() == "" ) {
        age == 0
        alert(" Age has set zero")
    }

    // age = age || "empty"

    let msg = "Welcome to React World, " + name +  "!" + "Your age is " + age
    alert(msg)
 }

 showMessage(name,age) */
