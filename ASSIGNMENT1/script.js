const btn = document.querySelector('.btn');
const body = document.querySelector('body');
const moon = document.querySelector('.moon');
const sun = document.querySelector('.sun');
const phaseTitle = document.querySelector('.phase-title');
const phaseDescription = document.querySelector('.phase-description');
const leftCurtain = document.querySelector('.left-curtain');
const rightCurtain = document.querySelector('.right-curtain');
const girlArm = document.querySelector('.girl .arm');
const tvImage = document.getElementById('tv-image');
const tvImages = [
    "https://picsum.photos/800/400?random=1",
    "https://picsum.photos/800/400?random=2",
    "https://picsum.photos/800/400?random=3",
    "https://picsum.photos/800/400?random=4",
    "https://picsum.photos/800/400?random=5"
];

function changeTvImage() {
    const randomIndex = Math.floor(Math.random() * tvImages.length);
    tvImage.src = tvImages[randomIndex] + "&t=" + Date.now(); 
}
setInterval(() => {
    if (!body.classList.contains("on")) {
        changeTvImage();
    }
}, 3000);

const phases = [
    {
        name: "Midnight",
        bg: "#000014", 
        type: "moon",
        textColor: "#f5f5ff", 
        text: "Not perfect, yet eternal,\nThe moon grows like a lotus —\nUnfolding in silver petals,\nBreathing softly, silently,\nWith every passing time.\n\n✨ Intro Paragraph\n\nHi, I am Dipanwita. 🌸\nI see the world not just in shapes and shadows,\nBut in rhythms and quiet stories.\nLike the moon, I believe beauty is not about perfection,\nBut about growing, blooming, and breathing with life’s moments.\nI carry this spirit into all I do —\nA balance of calm reflection and bright curiosity,\nAlways reaching for light while rooted in depth."
    },
    {
        name: "Pre-Dawn",
        bg: "linear-gradient(to top, #0a0a1f, #334466)", 
        type: "moon",
        textColor: "#e0ecff", 
        text: "In the stillness before light,\nDreams linger on the edge of night —\nA whisper of beginnings,\nA promise just out of sight.\n\n✨ My Hobbies\nI am Dipanwita, and in these quiet hours I find joy in chess, in weaving thoughts into poems, and in shaping stories from silence. These passions teach me patience, creativity, and strategy — guiding lights that stay with me as dawn approaches."
    },
    {
        name: "Dawn",
        bg: "linear-gradient(to top, #1b2a4a, #87ceeb)", 
        type: "sun",
        textColor: "#fffdf5", 
        text: "From shadows I rise,\nLike the sky breaking free —\nFailures fall behind,\nStrength awakens in me.\n\n✨ My Resilience\nDawn reminds me of my own journey — from setbacks in projects to my rise into college life. Each fall became a stepping stone, each sunrise a second chance. Like the light, I learned to return stronger, brighter, and more determined."
    },
    {
        name: "Morning",
        bg: "#ffe66d", 
        type: "sun",
        textColor: "#2b2b2b",
        text: "Morning sings with fire,\nIdeas bloom, dreams aspire —\nHands that build and shape,\nHearts that never tire.\n\n✨ My Projects\nMorning mirrors my passion for creation. From IoT to AI, from sensors to web platforms — I’ve built, tested, and learned. Each project reflects my drive to merge logic with imagination, to craft solutions that breathe with purpose."
    },
    {
        name: "Late Morning",
        bg: "linear-gradient(to top, #b0eaff, #ffffff)", 
        type: "sun",
        textColor: "#444c4f", 
        text: "A path that widens,\nSteps that steady and grow —\nFrom roots of learning,\nTo branches that reach the sky’s glow.\n\n✨ My Transition\nThis is the phase of growth, where I moved from a junior to a senior in college. I found leadership in teamwork, confidence in knowledge, and clarity in vision. Late morning is not an ending, but the unfolding of a greater journey."
    },
    {
        name: "Noon",
        bg: "#0c89a8", 
        type: "sun",
        textColor: "#fff3cc", 
        text: "At the peak of day,\nDreams stand tall and bright —\nThe heart of effort,\nBeats with steady light.\n\n✨ My Next 5 Years\nI see myself walking a focused path — sticking with GyanSys, growing as a software engineer, and working hard toward becoming a software lead. Noon is my reminder: with discipline and persistence, every summit is within reach."
    },
    {
        name: "Early Afternoon",
        bg: "linear-gradient(to top, #fff2cc, #29a3be)", 
        type: "sun",
        textColor: "#2c2c2c", 
        text: "Gentle rays descend,\nShadows stretch and bend —\nPatience walks beside me,\nOn dreams that never end.\n\n✨ My Career Drive\nHere, I picture myself refining skills, embracing challenges, and working with teams that inspire me. Early afternoon is steady growth — not a rush, but a rhythm of learning, contributing, and climbing step by step."
    },
    {
        name: "Afternoon",
        bg: "linear-gradient(to top, #ffdca8, #9ed9f5)", 
        type: "sun",
        textColor: "#2a3a45", 
        text: "The day winds slow,\nBut the fire still flows —\nEndurance, quiet strength,\nA story life knows.\n\n✨ My Focus\nAfternoon reminds me to pace myself. While my goals shine ahead, I know success is not a sprint but a marathon. This phase is where I commit to balancing ambition with humility, and effort with reflection."
    },
    {
        name: "Late Afternoon",
        bg: "linear-gradient(to top, #ffb766, #104a6e)", 
        type: "sun",
        textColor: "#fff6e0", 
        text: "Golden skies unfold,\nStories painted bold —\nHope burns brighter,\nAs tomorrow is told.\n\n✨ My Aspiration\nIn the golden hour of late afternoon, I envision my leadership role — guiding teams, sharing knowledge, and building with purpose. This is where my dream of leading projects takes shape, glowing with confidence and courage."
    },
    {
        name: "Sunset",
        bg: "linear-gradient(to top, #ff9e6f, #243040)", 
        type: "sun",
        textColor: "#fff3f0", 
        text: "The horizon burns,\nAs day to night turns —\nEndings whisper softly,\nYet every ending learns.\n\n✨ My Reflection\nSunset is my reminder that every phase — every success and every failure — is a lesson. I carry these lessons with me, letting them set gently like the sun, while preparing for the light that tomorrow will bring."
    },
    {
        name: "Twilight",
        bg: "linear-gradient(to top, #1c1c3c, #112244)", 
        type: "moon",
        textColor: "#cde6ff", 
        text: "Stars awaken shy,\nSilver dreams across the sky —\nQuiet paths of wonder,\nWhere thoughts learn to fly.\n\n✨ My Curiosity\nIn twilight, I let my mind wander — into research, into new technologies, into unexplored ideas. It’s the space between reality and imagination, where I love to explore and grow."
    },
    {
        name: "Night",
        bg: "#02020f", 
        type: "moon",
        textColor: "#f2f2f2", 
        text: "Silent skies embrace,\nA silver guardian’s face —\nCalm within the dark,\nDreams find their place.\n\n✨ My Promise\nNight is when I pause — to breathe, to write, to dream. It reminds me that rest is as vital as effort. I promise myself to rise again, stronger each time, carrying the quiet strength of the moon within me."
    }
];


let phaseIndex = 0;
let phaseTime = 0;
const phaseDuration = 14000;

function animateCycle() {
    if (body.classList.contains('on')) {
        phaseTime += 50;
        if (phaseTime >= phaseDuration) {
            phaseIndex = (phaseIndex + 1) % phases.length;
            phaseTime = 0;
        }
        const progress = phaseTime / phaseDuration;

        // Update background
        body.style.background = phases[phaseIndex].bg;

        // Update phase text
        phaseTitle.textContent = phases[phaseIndex].name;
        phaseDescription.textContent = phases[phaseIndex].text;

        // Update text colors
        phaseTitle.style.color = phases[phaseIndex].textColor;
        phaseDescription.style.color = phases[phaseIndex].textColor;

        // Animate sun/moon
        const topPos = 10;
        const leftPos = -15 + progress * 115;
        if (phases[phaseIndex].type === 'moon') {
            moon.style.opacity = 1;
            moon.style.left = leftPos + 'vw';
            moon.style.top = topPos + 'vh';
            sun.style.opacity = 0;
        } else {
            sun.style.opacity = 1;
            sun.style.left = leftPos + 'vw';
            sun.style.top = topPos + 'vh';
            moon.style.opacity = 0;
        }
    } else {
        body.style.background = '#111';
        moon.style.opacity = 0;
        sun.style.opacity = 0;
        phaseTitle.textContent = "";
        phaseDescription.textContent = "";
    }
    requestAnimationFrame(animateCycle);
}

animateCycle();

btn.onclick = () => {
    body.classList.toggle('on');
    girlArm.style.animation = "none";
    void girlArm.offsetWidth;

    if (body.classList.contains('on')) {
        leftCurtain.classList.add('open-left');
        rightCurtain.classList.add('open-right');
        girlArm.style.animation = 'arm-move 1.5s forwards';
    } else {
        leftCurtain.classList.remove('open-left');
        rightCurtain.classList.remove('open-right');
        girlArm.style.animation = 'arm-move-reverse 1.5s forwards';
    }
};

const decorations = document.querySelector('.decorations');

function createFlower() {
    if (body.classList.contains('on')) {
        const flower = document.createElement('div');
        flower.classList.add('flower');
        flower.style.left = Math.random() * 100 + "vw";
        flower.style.animationDuration = (5 + Math.random() * 5) + "s";
        decorations.appendChild(flower);
        setTimeout(() => flower.remove(), 10000);
    }
}

setInterval(createFlower, 800);

function createCurtainLights(curtain, count) {
    const colors = ["#ff4d4d", "#4dff4d", "#4d4dff", "#ffff4d", "#ff99ff", "#80dfff", "#ffffff"];
    for (let i = 0; i < count; i++) {
        const light = document.createElement("div");
        light.classList.add("curtain-light");
        light.style.setProperty("--x", Math.random());
        light.style.setProperty("--y", Math.random());
        light.style.setProperty("--color", colors[Math.floor(Math.random() * colors.length)]);
        light.style.setProperty("--delay", (Math.random() * 2).toFixed(2));
        curtain.appendChild(light);
    }
}

createCurtainLights(document.querySelector(".left-curtain"), 120);
createCurtainLights(document.querySelector(".right-curtain"), 120);