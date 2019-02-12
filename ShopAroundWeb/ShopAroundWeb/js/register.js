// Shorthand for $( document ).ready()
$(function () {
    //console.log("ready!");

    var selectedCity;

    $("select.city").change(function () {
        selectedCity = $(this).children("option:selected").val();
        //alert("You have selected the city - " + selectedCity);
    });

    $(".btnRegister").click(function (e) {
       
        //$(this).hide();
        console.log("clicked!");
        console.log($(".shopName").val());
        console.log($(".password").val());
        console.log($(".email").val());
        console.log($(".phone").val());
        console.log(selectedCity);

        db.collection("shop").add({
            name: $(".shopName").val(),
            password: $(".password").val(),
            email: $(".email").val(),
            phone: $(".phone").val(),
            city: selectedCity
        })
            .then(function (docRef) {
                console.log("Document written with ID: ", docRef.id);
            })
            .catch(function (error) {
                console.error("Error adding document: ", error);
            });

        e.preventDefault();
    });

});