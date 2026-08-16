$(document).ready(function () {

      $("#createScategoryForm").submit(function (e) {   
        e.preventDefault(); 
       $.post('/scategory/create', $(this).serialize(), function (result) {
        if(result.success){
        alert("تم الأضافة بنجاح");
        loadScategoryDropdownList();
      }
      else{
                        alert("فشل الأضافة");
                        }
                    });
    });


});