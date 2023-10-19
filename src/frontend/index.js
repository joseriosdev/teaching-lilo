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

function alertMessage(message, classesToAdd) {
    const messageDisplayer = document.getElementById('notifier');

    classesToAdd.forEach(cssClass => messageDisplayer.classList.add(cssClass));
    messageDisplayer.innerText = message;

    setTimeout(() => {
        classesToAdd.forEach(cssClass => messageDisplayer.classList.remove(cssClass));
        messageDisplayer.innerText = '';
    }, 4000)
}



getAllBtn.addEventListener('click', getAllVideogamesAsync);

form.addEventListener('submit', async function(e) {
    e.preventDefault();

    const videogameToCreate = document.getElementById('vg-name-input').value;
    document.getElementById('vg-name-input').value = '';
    
    const result = await fetch(
        `${baseURL}Videogames/?name=${videogameToCreate}`,
        { method: 'POST' }
    );
    const data = await result.json();
    alertMessage(
        `The Videogame ${data.name} was created with id ${data.id}`,
        ['alert','green-alert']
    );
});


