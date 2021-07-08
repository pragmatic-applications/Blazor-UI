
// S Get Width and Height
// window.innerWidth is prefered because it excludes the scrollbar and other unwanted browser chrome size data.
//export function getDimensions()
//{
//    return {
//        width: window.innerWidth,
//        height: window.innerHeight,

//        outerWidth: window.outerWidth,
//        outerHeight: window.outerHeight,

//        clientWidth: document.documentElement.clientWidth,
//        clientHeight: document.documentElement.clientHeight
//    };
//};

export function getDimensions()
{
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

export function getNewDimension() {
    return {
        width: document.getElementById("window_inner_width").innerHTML,
        height: document.getElementById("window_inner_height").innerHTML
    };
};
// E Get Width and Height

// S window.onresize
window.onresize = resizer;
export function resizer()
{
    document.getElementById("window_inner_width").innerHTML = window.innerWidth;
    document.getElementById("window_inner_height").innerHTML = window.innerHeight;

    document.getElementById("inner_width").innerHTML = document.getElementById("window_inner_width").innerHTML;
    document.getElementById("inner_height").innerHTML = document.getElementById("window_inner_height").innerHTML;
}
export function resize()
{
    return window.onresize;
}
// E window.onresize

// S addEventListener
export function onWindowSizeHandle()
{
    document.querySelector('.width').innerText = window.innerWidth;
    document.querySelector('.height').innerText = window.innerHeight;
}
export function onWindowSize()
{
    return window.addEventListener('resize', onWindowSizeHandle);
}
// E addEventListener
