// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function myF(input) {
    let path = input.value.trim();

    //if (path != "" && imageExists(path))  console.log("OK");
    let img = document.querySelector("#image_display");



    checkImage(path,
        function () { console.log("good"); img.src = path },
        function () { console.log("bad"); img.src = "/img/img00.jpg"});
}

function imageExists(image_url) {

    var http = new XMLHttpRequest();

    http.open('HEAD', image_url, false);
    http.send();

    return http.status != 404;

}

function checkImage(imageSrc, good, bad) {
    var img = new Image();
    img.onload = good;
    img.onerror = bad;
    img.src = imageSrc;
}
