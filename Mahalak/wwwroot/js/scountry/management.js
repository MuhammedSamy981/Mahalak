function loadScountryDropdownList()
{
             $.get('/scountry/index',function(result)
       {
      $('#ddlScountries').empty();
       $('#ddlScountries').append(new Option("- أختر الدولة -","0"));
       $.each(result.scountries, function(key,value)
       {
        $('#ddlScountries').append(new Option(value.text,value.value));
       });
       });
}