$(document).ready(function () {
 
  
    $("#addRatingForm").submit(function (e) {   
 
        e.preventDefault(); 

        var submitButton = document.getElementById("submitBtn");
      submitButton.disabled = true;

    var urlSegments = window.location.pathname.split('/');
    var idIndex = urlSegments.length - 1; 
    var idValue = urlSegments[idIndex];

       $.post('/rating/create?shopId='+idValue, $(this).serialize(), function (result) {
        //alert("gggggg");
        if(result.success){
        loadRatingSection();
      }
                        
                    });
    });

});