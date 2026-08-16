function loadSareaDropdownList()
{
             $.get('/sarea/index',function(result)
       {
      $('#ddlSareas').empty();
       $('#ddlSareas').append(new Option("- أختر المنطقة -","0"));
       $.each(result.sareas, function(key,value)
       {
        $('#ddlSareas').append(new Option(value.text,value.value));
       });
       });
}