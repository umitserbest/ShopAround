$(function () {

	"use strict";

	var category;
	var combileImage;
	var coverImage;
	var secondImage;
	var thirdImage;
	var fourthImage;

	/* Run at startup */
	$(".combineImageNotification").hide();
	$(".coverImageNotification").hide();
	$(".secondImageNotification").hide();
	$(".thirdImageNotification").hide();
	$(".fourthImageNotification").hide();

	$("#category").change(function () {
		category = $(this).children("option:selected").val();
		console.log(category);
	});
	
	$("#combineImage").on("change", function () {
		uploadImage($(this)).then(function (name) {
			combileImage = name;
			$(".combineImageNotification").show();
		});		
	});

	$("#coverImage").on("change", function () {
		uploadImage($(this)).then(function (name) {
			coverImage = name;
			$(".coverImageNotification").show();
		});	
	});

	$("#secondImage").on("change", function () {
		uploadImage($(this)).then(function (name) {
			secondImage = name;
			$(".secondImageNotification").show();
		});
	});

	$("#thirdImage").on("change", function () {
		uploadImage($(this)).then(function (name) {
			thirdImage = name;
			$(".thirdImageNotification").show();
		});
	});

	$("#fourthImage").on("change", function () {
		uploadImage($(this)).then(function (name) {
			fourthImage = name;
			$(".fourthImageNotification").show();
		});
	});

	const uploadImage = async (doc) => {
		return new Promise(resolve => {
			const ref = storage.ref();
			const file = doc[0].files[0];
			const name = (+new Date()) + '_' + file.name;
			const metadata = {
				contentType: file.type
			};
			const task = ref.child(name).put(file, metadata);
			task
				.then(snapshot => snapshot.ref.getDownloadURL())
				.then((url) => {
					resolve(name);
				})
				.catch(console.error);
		});
	}

	$(".btnSave").click(function (e) {
		e.preventDefault();		

		if (combineImage != null && coverImage != null && secondImage != null && thirdImage != null && fourthImage != null) {

			db.collection("shops").doc(userID).collection("products").add({
				code: $("#productCode").val(),
				name: $("#productName").val(),
				category: category,
				combileImage: combileImage,
				coverImage: coverImage,
				secondImage: secondImage,
				thirdImage: thirdImage,
				fourthImage: fourthImage,
				brand: $("#brand").val(),
				color: $("#color").val(),
				size: $("#size").val(),
				material: $("#material").val(),
				details: $("#details").val()
			}).then(function () {
				console.log("Added");
				$(".btnSaved").click();
			}).catch(function (error) {
				console.error("Error adding document: ", error);
			});
		}
		else {
			console.log("Upload the images");
		}
	});

	$(".btnSaved").click(function (e) {

	});

});