     $(document).ready(function () {  

const content='<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';
$("#paginatedShopList").html(content);

document.getElementById("linkCancelSearch").style.display = "none";

 $.get('/shop/getPaginatedShopList',function(result)
{
$("#paginatedShopList").html(result);
});  

    $("#ddlCategories").change(function (e) {   

        e.preventDefault(); 
        $("#paginatedShopList").html(content);
                     $.get('/shop/getPaginatedShopList',$(this).serialize(),function(result)
{
$("#paginatedShopList").html(result);
document.getElementById("linkCancelSearch").style.display = "block";
});

    });

        $("#ddlCities").change(function (e) {

        e.preventDefault();  
        $("#paginatedShopList").html(content);
        document.getElementById("linkCancelSearch").style.display = "block";
        
            var cityValue = $('#ddlCities').find(":selected").val();
                if (cityValue != "0" && cityValue != null && cityValue != undefined) {
                            
       $.get('/shop/getAreasByCityId/'+cityValue,function(result)
       {
        //alert("response.data");
      $('#ddlAreas').empty();
       $('#ddlAreas').append(new Option("- أختر المنطقة -","0"));
       $.each(result.areas, function(key,value)
       {
        $('#ddlAreas').append(new Option(value.text,value.value));
       });
        
       });

$.get('/shop/getPaginatedShopList',$(this).serialize(),function(result)
{
$("#paginatedShopList").html(result);
});

}
  });

        $("#ddlAreas").change(function (e) {   
        e.preventDefault();
        $("#paginatedShopList").html(content);
  $.get('/shop/getPaginatedShopList',$(this).serialize(),function(result)
{
$("#paginatedShopList").html(result);
});
                    
    });

}); 
    


    