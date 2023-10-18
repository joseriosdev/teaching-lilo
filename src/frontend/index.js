const resultElement = document.getElementById('actual-result');
const getAllBtn = document.getElementById('get-all-btn');
const form = document.querySelector('.main-form');

const baseURL = 'https://localhost:7285/';


const getAllVideogamesAsync = async (event) => {
    console.log('Event', event);
    event.preventDefault();
    const result = await fetch(`${baseURL}Videogames/`);
    console.log('result', result);
    const data = await result.json();
    console.log('data', data);
    var output = '';
    data.forEach(videogame => {
        output += `
        <li>ID: ${videogame.id}</li>
        <li>VG NAME: ${videogame.name}</li>
        `;
    });
    resultElement.innerHTML = output;
}

function alertMessage(message, bgClassNameColor) {
    this.messageDisplayer.classList.add(bgClassNameColor);
    this.messageDisplayer.innerHTML = message;

    setTimeout(() => {
      this.messageDisplayer.classList.remove(bgClassNameColor);
      this.messageDisplayer.innerHTML = '';
    }, 4000)
}



getAllBtn.addEventListener('click', getAllVideogamesAsync);

form.addEventListener('submit', async function(e) {
    e.preventDefault();

    const videogameToCreate = document.getElementById('vg-name-input').value;
    document.getElementById('vg-name-input').value = '';
    
    const result = await fetch(`${baseURL}Videogames/?name=${videogameToCreate}`, {
        method: 'POST'
    });
    const data = await result.json();
    console.log(data);
});


