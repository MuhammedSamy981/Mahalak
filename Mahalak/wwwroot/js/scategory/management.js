function loadScategoryDropdownList()
{
             $.get('/scategory/index',function(result)
       {
      $('#ddlScategories').empty();
       $('#ddlScategories').append(new Option("- أختر نوع المحل -","0"));
       $.each(result.scategories, function(key,value)
       {
        $('#ddlScategories').append(new Option(value.text,value.value));
       });
       });
}
