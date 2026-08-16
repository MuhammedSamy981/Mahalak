
    document.addEventListener("DOMContentLoaded", function() {
  // Get a reference to the form and submit button
  var form = document.getElementById("myForm");
  var submitButton = document.getElementById("submitBtn");
  var spinnerLoading = document.getElementById("spinnerLoading");
  // Add a submit event listener to the form
  form.addEventListener("submit", function() { 
    if($("#myForm").valid()) {
    spinnerLoading.hidden=false;
    submitButton.disabled = true;
    
  alert("برجاء الأنتظار حتى بتم حفظ التعديلات");
  }
});

});


