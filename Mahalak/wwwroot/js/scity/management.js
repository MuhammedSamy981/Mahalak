function loadScityDropdownList()
{
             $.get('/scity/index',function(result)
       {
      $('#ddlScities').empty();
       $('#ddlScities').append(new Option("- أختر المدينة -","0"));
       $.each(result.scities, function(key,value)
       {
        $('#ddlScities').append(new Option(value.text,value.value));
       });
       });
}
