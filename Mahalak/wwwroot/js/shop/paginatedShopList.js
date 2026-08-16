
    $(document).ready(function () {
 $("#shopList").html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
 $.get('/shop/getShopList',function(result)
{
$("#shopList").html(result);
}); 
}); 
