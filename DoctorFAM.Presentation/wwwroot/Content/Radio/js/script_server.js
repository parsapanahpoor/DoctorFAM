let playBtn = document.querySelector(".radio-stop-play");
let nextBtn = document.querySelector(".radio-next");
let previousBtn = document.querySelector(".radio-previous");
let audio = document.querySelector(".radio-audio audio");
let radioEqulizer = document.querySelector(".radio-equalizer");
let musicList = document.querySelector(".music-list > .row");
let radioPlayIcon = document.querySelector(".radio-play-icon")
let isPlay = false;
let musicCounter = 0;
let audioArray;

function playMusic() {
    if (isPlay === false) {
        audio.play();
        isPlay = true;
        radioEqulizer.classList.add("active-equlizer");
        radioPlayIcon.classList.replace("bi-play-fill", "bi-pause-fill")
    } else {
        audio.pause();
        isPlay = false;
        radioEqulizer.classList.remove("active-equlizer");
        radioPlayIcon.classList.replace("bi-pause-fill", "bi-play-fill")
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
    await fetch("http://devhealthhouse.ir/api/v1/RadioFAMAPI/get-LatestPodcasts-ForShowInLanding")
        .then(res => res.json())
        .then(data => {
            audioArray = data.data
            console.log(audioArray);
            audioArray.forEach(function (item, index) {
                let musicName = audioArray[index].musicName;
                let musicSrc = audioArray[index].musicSrc;
                let musicDate = audioArray[index].createDate;
                let musicBackground = audioArray[index].musicImageSrc
                audio.src = musicSrc
                let musicTemplate = `
                <div class="col-12">
                    <li class="music-list-item" onclick="playListMusic(event)">
                        <img src="${musicImageSrc}" class="music-item-image" alt="radio image">
                        <span class="music-item-name">${musicName}</span>
                        <span class="music-item-date">${musicDate}</span>
                        <div class="music-item-audio" data-audio-src="${musicSrc}" data-id="${index}"></div>
                    </li>
                </div>
                `;
                musicList.insertAdjacentHTML("beforeend", musicTemplate)
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

playBtn.addEventListener("click", playMusic);
nextBtn.addEventListener("click", nextMusic);
previousBtn.addEventListener("click", previousMusic);
window.addEventListener("load", loadMusic);