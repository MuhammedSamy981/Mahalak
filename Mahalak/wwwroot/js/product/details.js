$(document).ready(function () {
localStorage.setItem("displayedProductId", JSON.stringify({ id: $('#productId').val() , currentUser:$('#admin').val()}));
});