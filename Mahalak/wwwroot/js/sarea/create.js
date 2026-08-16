$(document).ready(function () {
  loadScityDropdownList();

      $("#createSareaForm").submit(function (e) {   
        e.preventDefault(); 
       $.post('/sarea/create', $(this).serialize(), function (result) {
        if(result.success){
        alert("تم الأضافة بنجاح");
        loadSareaDropdownList();
        loadScityDropdownList();
      }
      else{
                        alert("فشل الأضافة");
                        }
                    });
    });


function loadScityDropdownList()
{
    $.get('/scity/index',function(result)
       {
      $('#ddlScitiesForSarea').empty();
       $('#ddlScitiesForSarea').append(new Option("- أختر المدينة -","0"));
       $.each(result.scities, function(key,value)
       {
        $('#ddlScitiesForSarea').append(new Option(value.text,value.value));
       });
       
       });
}

});