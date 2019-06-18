// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function dynamicImage() {
    let path = document.querySelector(".image_url_source").value.trim();

    let img = document.querySelector(".image_to_display");

    var image = new Image();

    image.onload = () => { img.src = path; }
    image.onerror = () => { img.src = "/img/img00.jpg"; }
    image.src = path;

}

