$(function () {

    "use strict";

    var selectedCity;

    $(".navigateLogin").click(function (e) {
        $(location).attr('href', "/Login");
        e.preventDefault();
    });

    $("select.city").change(function () {
        selectedCity = $(this).children("option:selected").val();
    });

    $(".btnRegister").click(function (e) {
		$(this).hide();
		e.preventDefault();

        var id = $(".email").val();

        db.collection("shops").doc(id).set({
            name: $(".shopName").val(),
            password: $(".password").val(),
            email: $(".email").val(),
            phone: $(".phone").val(),
            city: selectedCity
        }).then(function () {
            $(location).attr('href', "/Login");
        }).catch(function (error) {
            console.error("Error adding document: ", error);
            $(this).show();
        });
       
    });

});