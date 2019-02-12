$(function () {

    "use strict";

    $(".navigateRegister").click(function (e) {
        $(location).attr('href', "/Register");
        e.preventDefault();
    });

    $(".btnLogin").click(function (e) {
        $(this).hide();

        var email = $(".email").val();
        var password = $(".password").val();

        var docRef = db.collection("shops").doc(email);

        docRef.get().then(function (doc) {
            if (doc.exists && doc.data().password == password) {
                console.log("Login Successful");
            } else {
                // doc.data() will be undefined in this case
                console.log("Invalid Email or Password");
                $(this).show();
            }
        }).catch(function (error) {
            console.log("Error getting document:", error);
            $(this).show();
        });   

        e.preventDefault();
    });

});