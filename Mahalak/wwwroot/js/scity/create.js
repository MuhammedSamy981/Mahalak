$(document).ready(function () {
  loadScountryDropdownList();

      $("#createScityForm").submit(function (e) {   
        e.preventDefault(); 
       $.post('/scity/create', $(this).serialize(), function (result) {
        if(result.success){
        alert("تم الأضافة بنجاح");
        loadScityDropdownList();
          loadScountryDropdownList();
      }
      else{
                        alert("فشل الأضافة");
                        }
                    });
    });


function loadScountryDropdownList()
{
    $.get('/scountry/index',function(result)
       {
      $('#ddlScountriesForScity').empty();
       $('#ddlScountriesForScity').append(new Option("- أختر الدولة -","0"));
       $.each(result.scountries, function(key,value)
       {
        $('#ddlScountriesForScity').append(new Option(value.text,value.value));
       });
       
       });
}

});