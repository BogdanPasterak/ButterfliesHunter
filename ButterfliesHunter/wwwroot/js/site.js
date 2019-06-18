// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function dynamicImage() {
    try {
        let path = document.querySelector(".image_url_source").value.trim();

        let image = document.querySelector(".image_to_display");

        image.onerror = () => { image.src = "/img/img00.jpg"; }
        image.src = path;

    } catch (e) {
        console.log("Problem with load image", e)
    }

}

// example image from URL
//http://sandspointpreserveconservancy.org/wp-content/uploads/2018/12/Leopard-Lacewing.jpg
//https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEKASHSnnVdqzSM8KsQOsCHjL2Hb_zAeeRdm5SYyEJBVhWGMSr
