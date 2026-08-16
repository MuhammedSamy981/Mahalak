
$(document).ready(function () {
const content='<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';
$("#paginatedShopManagementTable").html(content);

 $.get('/shop/getPaginatedShopManagementTable',function(result)
{
$("#paginatedShopManagementTable").html(result);
});      

});
