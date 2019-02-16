$(function () {

    "use strict";

	feather.replace();

	//console.log("userID: " + userID);

	var docRef = db.collection("shops").doc(userID);

	docRef.get().then(function (doc) {
		if (doc.exists) {
			$(".userName").text(doc.data().name);
		} else {
			// doc.data() will be undefined in this case
			console.log("Error");
		}
	}).catch(function (error) {
		console.log("Error getting document:", error);
		$(this).show();
		});   

	$(".signOut").click(function (e) {
		$.ajax({
			/// <summary>
			///  Perform an asynchronous HTTP (Ajax) request
			/// </summary>
			type: "POST",
			url: 'Dashboard.aspx/SignOut',
			data: "{}",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {
				/// <summary>
				/// when success
				/// </summary>
				console.log(response.d);
				$(location).attr('href', "/Login");
			},
			failure: function (msg) {
				/// <summary>
				/// when there is an error
				/// </summary>
				console.log(msg.d);
			}
		});
	});

});