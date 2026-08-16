
$(document).ready(function () {

loadShopManagementTable();

}); 
function loadShopManagementTable(){
 $("#shopManagementTable").html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
 $.get('/shop/getShopManagementTable',function(result)
{
$("#shopManagementTable").html(result);
}); 
}
