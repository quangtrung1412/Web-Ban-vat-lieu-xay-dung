$("#navbarSupportedContent li").click(function () {
    $("#navbarSupportedContent li").removeClass('active');
    $(this).addClass('active');
});
$('#navbarLogin .dropdown .avatar').on('click', function () {
    $(".user-dropdown").show();
});

// var allOfThem = $('*');
// for (let i = 0; i < allOfThem.length; i++) {
//     // text += allOfThem[i] + "<br>";
//     if (allOfThem[i].className.length != 0) {
//         let text = "." + allOfThem[i].className;
//         console.log(text);
//     }
//     if (allOfThem[i].className != 'user-dropdown' || allOfThem[i].className != 'nav-link avatar' || allOfThem[i].className.length != 0) {
//         let text = "." + allOfThem[i].className;
//         console.log(text);
//         // $(text).on('click', function () {
//         //     $(".user-dropdown").hide();
//         // });
//     }
// }    
