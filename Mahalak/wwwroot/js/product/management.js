$(document).ready(function () { 
const content='<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';
$("#paginatedProductManagementTable").html(content);

 $.get('/product/getPaginatedProductManagementTable',function(result)
{
$("#paginatedProductManagementTable").html(result);
});      

});