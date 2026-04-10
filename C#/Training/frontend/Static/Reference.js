// ==========================
// 1. INPUT / OUTPUT
// ==========================
let num = +prompt("Enter a number:", "");
console.log("Entered number:", num);

alert("Welcome to JS Basics");

let confirmCheck = confirm("Do you want to continue?");


// ==========================
// 2. VARIABLES & TYPES
// ==========================
let name = "Suman";
let age = 20;
let isStudent = true;
let emptyValue = null;
let notDefined;

console.log(typeof name, typeof age, typeof isStudent);


// ==========================
// 3. OPERATORS
// ==========================
let a = 10, b = 5;

console.log("Add:", a + b);
console.log("Compare:", a > b);
console.log("Logical:", a > 5 && b < 10);


// ==========================
// 4. CONDITIONAL STATEMENTS
// ==========================
if (confirmCheck) {
    if (num > 0) {
        alert("Positive");
    } else if (num < 0) {
        alert("Negative");
    } else {
        alert("Zero");
    }
} else {
    alert("Cancelled");
}


// ==========================
// 5. TERNARY OPERATOR
// ==========================
let login = prompt("Enter role (Employee / Director):");

let message = (login === "Employee") ? "Hello" :
              (login === "Director") ? "Greetings" :
              (login === "") ? "No Login" :
              "Invalid Login";

alert(message);


// ==========================
// 6. LOOPS
// ==========================

// While loop
while (num < 100 && num !== 0) {
    num = +prompt("Enter number > 100 (0 to stop):");
}

// Do-while
do {
    num = +prompt("Enter number > 50:");
} while (num <= 50 && num !== 0);

// For loop
for (let i = 1; i <= 5; i++) {
    console.log("For loop:", i);
}


// ==========================
// 7. FUNCTIONS
// ==========================
function greet(name) {
    return "Hello " + name;
}

console.log(greet("Suman"));

// Arrow function
const add = (x, y) => x + y;
console.log("Sum:", add(2, 3));


// ==========================
// 8. ARRAYS
// ==========================
let arr = [1, 2, 3];

arr.push(4);
arr.pop();

console.log("Array:", arr);


// ==========================
// 9. OBJECTS
// ==========================
let user = {
    name: "Suman",
    age: 20
};

console.log(user.name);

user.age = 21;


// ==========================
// 10. DOM MANIPULATION
// ==========================
let heading = document.getElementById("title");
heading.innerText = "JS Updated Successfully";


// ==========================
// 11. TYPE CONVERSION
// ==========================
let str = "123";
let convertedNum = Number(str);

let numberValue = 456;
let convertedStr = String(numberValue);

console.log(convertedNum, convertedStr);


// ==========================
// 12. FINAL VALIDATION EXAMPLE
// ==========================
let input;

do {
    input = +prompt("Enter number greater than 100:");
} while (input <= 100 && input !== 0);

alert("Done!");
