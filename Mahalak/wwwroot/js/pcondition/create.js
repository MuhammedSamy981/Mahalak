$(document).ready(function () {
      $("#createPconditionForm").submit(function (e) {   
        e.preventDefault(); 
       $.post('/pcondition/create', $(this).serialize(), function (result) {
        if(result.success){
        alert("تم الأضافة بنجاح");
        loadPconditionDropdownList();
      }
      else{
                        alert("فشل الأضافة");
                        }
                    });
    });


});