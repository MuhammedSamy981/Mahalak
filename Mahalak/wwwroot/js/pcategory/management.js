function loadPcategoryDropdownList()
{
             $.get('/pcategory/index',function(result)
       {
      $('#ddlPcategories').empty();
       $('#ddlPcategories').append(new Option("- أختر نوع المنتج -","0"));
       $.each(result.pcategories, function(key,value)
       {
        $('#ddlPcategories').append(new Option(value.text,value.value));
       });
       });
}