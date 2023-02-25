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
let audioArray = [
    {
        musicName: " 1",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 2",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 3",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 4",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 5",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 6",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 7",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 8",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
    {
        musicName: " 9",
        musicSrc: "/Content/Radio/music/FirstRadioProgram.m4a",
    },
];

playBtn.addEventListener("click", playMusic);
nextBtn.addEventListener("click", nextMusic);
previousBtn.addEventListener("click", previousMusic);
radioFolder.addEventListener("click", showDropDown);
window.addEventListener("load", loadMusic);

audio.src = audioArray[musicCounter].musicSrc;

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

function loadMusic() {
    for (let i = 4; i > -1; i--) {
        let musicName = audioArray[i].musicName;
        let musicSrc = audioArray[i].musicSrc;
        let musicTemplate = `
      <div class="radio-music-list-item" onclick="playListMusic(event)">
        <div class="radio-music-list-name">
            <span>${musicName}</span>
        </div>
        <div class="radio-musix-list-audio" data-audio-src="${musicSrc}" data-id="${i}"></div>
      </div>
    `;
        listItemMusicPopUp.insertAdjacentHTML("afterbegin", musicTemplate);
    }
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

