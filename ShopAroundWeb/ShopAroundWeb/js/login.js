$(function () {

    "use strict";

    $(".navigateRegister").click(function (e) {
        $(location).attr('href', "/Register");
        //e.preventDefault();
    });

    $(".btnLogin").click(function (e) {
		$(this).hide();
		e.preventDefault();

        var email = $(".email").val();
        var password = $(".password").val();

        var docRef = db.collection("shops").doc(email);

        docRef.get().then(function (doc) {
			if (doc.exists && doc.data().password == password) {
				console.log("Login Successful", doc.id);
				$.sendServer(doc.id);
            } else {
                // doc.data() will be undefined in this case
                console.log("Invalid Email or Password");
                $(this).show();
            }
        }).catch(function (error) {
            console.log("Error getting document:", error);
            $(this).show();
        });   
       
	});

	$.sendServer = function (userID) {
		$.ajax({
			/// <summary>
			///  Perform an asynchronous HTTP (Ajax) request
			/// </summary>
			type: "POST",
			url: 'Login.aspx/SignIn',
			data: "{'userID': '" + userID + "'}",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {
				/// <summary>
				/// when success
				/// </summary>
				console.log(response.d);
				$(location).attr('href', "/Dashboard");
			},
			failure: function (msg) {
				/// <summary>
				/// when there is an error
				/// </summary>
				console.log(msg.d);
			}
		});
	}

});