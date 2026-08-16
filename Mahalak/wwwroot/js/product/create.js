
    $("#images").on("change", function(e) {
        e.preventDefault(); 
var images=e.target.files;

        $.each(images, function(i,value)
       {
        $("#product_images").append('<div style="width: 18rem;"><img src="'+URL.createObjectURL(value)+'" class="adding-product-image"></div>');
       });
  });

// When the content is loaded, this event is executed
  document.addEventListener("DOMContentLoaded", function () {
     // Get a reference to the form , submit button and spinner loading 
    var form = document.getElementById("myForm");
    var submitButton = document.getElementById("submitBtn");
    var spinnerLoading = document.getElementById("spinnerLoading");

    // Add a submit event listener to the form
    form.addEventListener("submit", function () {
      if ($("#myForm").valid()) {
        spinnerLoading.hidden = false;
        submitButton.disabled = true;
        alert("برجاء الأنتظار حتى بتم أضافة المنتج");
      }
    });

  });