function loadPconditionDropdownList()
{
             $.get('/pcondition/index',function(result)
       {
      $('#ddlPconditions').empty();
       $('#ddlPconditions').append(new Option("- أختر حالة المنتج -","0"));
       $.each(result.pconditions, function(key,value)
       {
        $('#ddlPconditions').append(new Option(value.text,value.value));
       });
       });
}