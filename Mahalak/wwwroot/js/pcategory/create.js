$(document).ready(function () {
  loadScategoryDropdownList();

      $("#createPcategoryForm").submit(function (e) {   
        e.preventDefault(); 
       $.post('/pcategory/create', $(this).serialize(), function (result) {
        if(result.success){
        alert("تم الأضافة بنجاح");
        loadPcategoryDropdownList();
         loadScategoryDropdownList();
      }
      else{
                        alert("فشل الأضافة");
                        }
                    });
    });


function loadScategoryDropdownList()
{
    $.get('/scategory/index',function(result)
       {
      $('#ddlScategoriesForPcategory').empty();
       $('#ddlScategoriesForPcategory').append(new Option("- أختر نوع المحل -","0"));
       $.each(result.scategories, function(key,value)
       {
        $('#ddlScategoriesForPcategory').append(new Option(value.text,value.value));
       });
       
       });
}

});

