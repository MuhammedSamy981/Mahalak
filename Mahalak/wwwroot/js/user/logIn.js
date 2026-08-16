
    document.addEventListener("DOMContentLoaded", function() {
        
  // Get a reference to the form and submit button
  var logInForm = document.getElementById("logInForm");
  var logInButton = document.getElementById("logInBtn");
  var logInSpinnerLoading = document.getElementById("logInSpinnerLoading");

  // Add a submit event listener to the form
  logInForm.addEventListener("submit", function() { 
    if($("#logInForm").valid()) {
    logInSpinnerLoading.hidden=false;
    logInButton.disabled = true;
  }
});

  // Get a reference to the form and submit button
  var externalLogInForm = document.getElementById("externalLogInForm");
  var externalLogInButton = document.getElementById("externalLogInBtn");
  var externalLogInSpinnerLoading = document.getElementById("externalLogInSpinnerLoading");

  externalLogInForm.addEventListener("submit", function() { 
      if($("#externalLogInForm").valid()) {
    externalLogInSpinnerLoading.hidden=false;
    externalLogInButton.disabled = true;
  }
});

});
