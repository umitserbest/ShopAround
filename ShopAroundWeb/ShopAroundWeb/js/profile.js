$(function () {

	"use strict";

	var selectedCity;
	var password;

	var docRef = db.collection("shops").doc(userID);

	docRef.get().then(function (doc) {
		if (doc.exists) {
			$("#shopName").val(doc.data().name);
			$("#email").val(doc.data().email);
			$("#address").val(doc.data().address);
			$("#city").val(doc.data().city);
			$("#phone").val(doc.data().phone);
			$("#about").val(doc.data().about);

			password = doc.data().password;
			selectedCity = doc.data().city;
		} else {
			// doc.data() will be undefined in this case
			console.log("Error");
		}
	}).catch(function (error) {
		console.log("Error getting document:", error);
		$(this).show();
		});

	$("#city").change(function () {
		selectedCity = $(this).children("option:selected").val();
	});

	$(".btnSave").click(function (e) {		
		e.preventDefault();

		var newPassword = $("#password").val();

		if (newPassword != null && newPassword != "") {
			password = newPassword;
		}

		db.collection("shops").doc(userID).set({
			name: $("#shopName").val(),			
			email: $("#email").val(),
			password: password,
			address: $("#address").val(),
			city: selectedCity,
			phone: $("#phone").val(),
			about: $("#about").val()	
		}).then(function () {
			console.log("Updated");		
			$(".btnSaved").click();
		}).catch(function (error) {
			console.error("Error adding document: ", error);
		});
	});

	$(".btnSaved").click(function (e) {
		
	});

});