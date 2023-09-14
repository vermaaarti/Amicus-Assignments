const button = document.querySelector("#generate-jokes");

button.addEventListener("click", generateNewJokes);

function generateNewJokes(e) {
    const newXHRRequest = new XMLHttpRequest();
    const numberOfJokes = document.querySelector("#number-of-jokes").value;

    newXHRRequest.open(
        "GET",
        `http://api.icndb.com/jokes/random/${numberOfJokes}`,
        true
        // the numbers of jokes is appended to the url after a forward slash to specify the numbers of jokes to fetch from the server
      );

      newXHRRequest.onload = function () {

        if (this.status === 200) {
            const myJokes = JSON.parse(this.responseText);
          
            let output = "";
          
            if (myJokes.type === "success") {
              myJokes.value.forEach(function (joke) {
                output += `<li>${joke.joke}</li>`;
              });
            } else {
              output += `<li>Sorry! Couldn't get jokes</li>`;
            }
          
            document.querySelector("#jokes").innerHTML = output;
          }

      };

      newXHRRequest.send();

      e.preventDefault();

  }