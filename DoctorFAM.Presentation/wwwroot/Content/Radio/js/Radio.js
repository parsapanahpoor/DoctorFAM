let playBtn = document.querySelector(".radio-stop-play");
let nextBtn = document.querySelector(".radio-next");
let previousBtn = document.querySelector(".radio-previous");
let audio = document.querySelector(".radio-audio audio");
// let radioName = document.querySelector(".radio-name span");
let radioEqulizer = document.querySelector(".radio-equalizer");
let isPlay = false;
let musicCounter = 0;
let audioArray = [
    {
        // name: "F1  87.5",
        musicSrc: "/Content/Radio/music/experience.mp3",
    },
    {
        // name: "F3  27.8",
        musicSrc: "/Content/Radio/music/experience1.wav",
    },
    {
        // name: "F5 67.6",
        musicSrc: "/Content/Radio/music/experience2.mp3",
    },
];

playBtn.addEventListener("click", playMusic);
nextBtn.addEventListener("click", nextMusic);
previousBtn.addEventListener("click", previousMusic);

audio.src = audioArray[musicCounter].musicSrc;
// radioName.innerHTML = audioArray[counter].name;

function playMusic() {
    if (isPlay === false) {
        audio.play();
        isPlay = true;
        radioEqulizer.classList.add("active-equlizer")
    } else {
        audio.pause();
        isPlay = false;
        radioEqulizer.classList.remove("active-equlizer")
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
    // radioName.innerHTML = audioArray[counter].name;
}

function previousMusic() {
    if (musicCounter <= 0) {
        musicCounter = audioArray.length;
    }
    isPlay = false;
    musicCounter--;
    audio.src = audioArray[musicCounter].musicSrc;
    playMusic();
    // radioName.innerHTML = audioArray[counter].name;
}

