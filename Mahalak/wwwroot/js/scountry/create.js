$(document).ready(function () {

      $("#createScountryForm").submit(function (e) {   
        e.preventDefault(); 
       $.post('/scountry/create', $(this).serialize(), function (result) {
        if(result.success){
        alert("تم الأضافة بنجاح");
        loadScountryDropdownList();
      }
      else{
                        alert("فشل الأضافة");
                        }
                    });
    });


});