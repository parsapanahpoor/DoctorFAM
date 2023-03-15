let playBtn = document.querySelector(".radio-stop-play");
let nextBtn = document.querySelector(".radio-next");
let previousBtn = document.querySelector(".radio-previous");
let audio = document.querySelector(".radio-audio audio");
let radioEqulizer = document.querySelector(".radio-equalizer");
let listItemMusicPopUp = document.querySelector(".radio-music-list-popup");
let listItemsMusic = document.querySelectorAll(".radio-music-list-item");
let radioFolder = document.querySelector(".radio-folder i");
let isPlay = false;
let musicCounter = 0;
let audioArray;

function playMusic() {
    if (isPlay === false) {
        audio.play();
        isPlay = true;
        radioEqulizer.classList.add("active-equlizer");
    } else {
        audio.pause();
        isPlay = false;
        radioEqulizer.classList.remove("active-equlizer");
    }
}

function nextMusic() {
    if (musicCounter >= audioArray.length - 1) {
        musicCounter = -1;
    }
    isPlay = false;
    musicCounter++;
    audio.src = audioArray[musicCounter].musicSrc;
    playMusic();
}

function previousMusic() {
    if (musicCounter <= 0) {
        musicCounter = audioArray.length;
    }
    isPlay = false;
    musicCounter--;
    audio.src = audioArray[musicCounter].musicSrc;
    playMusic();
}

async function loadMusic() {
    await fetch("https://doctorfam.com/api/v1/RadioFAMAPI/get-LatestPodcasts-ForShowInLanding")
        .then(res => res.json())
        .then(data => {
            audioArray = data.data
            audioArray.forEach(function (item, index) {
                let musicName = audioArray[index].musicName;
                let musicSrc = audioArray[index].musicSrc;
                audio.src = musicSrc
                let musicTemplate = `
                <div class="radio-music-list-item" onclick="playListMusic(event)">
                    <span class="radio-music-list-name">${musicName}</span>
                    <div class="radio-musix-list-audio" data-audio-src="${musicSrc}" data-id="${index}"></div>
                </div>
                `;
                listItemMusicPopUp.insertAdjacentHTML("afterbegin", musicTemplate);
            })
        })
        .catch(err => console.error(err))

}

function playListMusic(event) {
    let audioSrc = event.currentTarget.lastElementChild.dataset.audioSrc;
    let audioId = event.currentTarget.lastElementChild.dataset.id;
    audio.src = audioSrc;
    isPlay = false;
    musicCounter = audioId;
    playMusic();
}

function showDropDown() {
    listItemMusicPopUp.classList.toggle("active-popup");
}

playBtn.addEventListener("click", playMusic);
nextBtn.addEventListener("click", nextMusic);
previousBtn.addEventListener("click", previousMusic);
radioFolder.addEventListener("click", showDropDown);
window.addEventListener("load", loadMusic);