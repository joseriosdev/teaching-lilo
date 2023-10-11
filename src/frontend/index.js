const resultElement = document.getElementById('actual-result');
const getAllBtn = document.getElementById('get-all-btn');

const baseURL = 'https://localhost:7285/';
const videogameURI = 'Videogames/';



const getAllVidegamesAsync = async (event) => {
    console.log(event);
    event.preventDefault();
    const result = await fetch(baseURL+videogameURI);
    const data = await result.json();
    var output = '';
    data.forEach(videogame => {
        output += `
        <li>ID: ${videogame.id}</li>
        <li>VG NAME: ${videogame.name}</li>
        `;
    });
    resultElement.innerHTML = output;
}

getAllBtn.addEventListener('click', getAllVidegamesAsync);