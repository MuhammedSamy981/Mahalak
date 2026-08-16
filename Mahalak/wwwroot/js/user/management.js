
/*
$(document).ready(function () {

 $.get('/user/getPaginatedAdminManagementTable/',function(result)
{
$("paginatedAdminManagementTable").html(result);
}); 

});*/ 


$(document).ready(function () {
const content='<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';
$("#paginatedAdminManagementTable").html(content);
$("#paginatedUserManagementTable").html(content);
$("#paginatedShopManagementTable").html(content);
$("#paginatedProductManagementTable").html(content);
$("#ratingTable").html(content);


$.get('/scategory/management',function(result)
{
$("#scategoryManagement").html(result);
});      


$.get('/scountry/management',function(result)
{
$("#scountryManagement").html(result);
});      


$.get('/scity/management',function(result)
{
$("#scityManagement").html(result);
});      


$.get('/sarea/management',function(result)
{
$("#sareaManagement").html(result);
});      


$.get('/pcategory/management',function(result)
{
$("#pcategoryManagement").html(result);
});      


$.get('/pcondition/management',function(result)
{
$("#pconditionManagement").html(result);
});      


$.get('/user/getPaginatedAdminManagementTable/',function(result)
{
$("#paginatedAdminManagementTable").html(result);
}); 


$.get('/user/getPaginatedUserManagementTable/',function(result)
{
$("#paginatedUserManagementTable").html(result);
}); 


$.get('/shop/getPaginatedShopManagementTable',function(result)
{
$("#paginatedShopManagementTable").html(result);
}); 


$.get('/product/getPaginatedProductManagementTable',function(result)
{
$("#paginatedProductManagementTable").html(result);
}); 

 $.get('/rating/index',function(result)
{
$("#ratingTable").html(result);
}); 

}); 


/*


$(document).ready(function () {
    var urlSegments = window.location.pathname.split('/');
    var idIndex = urlSegments.length - 1; 
    var tableIndex = urlSegments.length - 2;
    var idValue = window.isFinite(urlSegments[idIndex])==true 
    && urlSegments[tableIndex]=="shops"? urlSegments[idIndex]:1;
 $.get('/shop/getPaginatedShopsTableForAdmin/'+idValue,function(result)
{
    alert(idValue+"/"+urlSegments[idIndex]+"/"+urlSegments[tableIndex]);
$("#shopsTable").html(result);
});

    $("#ShopSearchForm").submit(function (e) {   
 
        e.preventDefault(); 
       $.get('/shop/getPaginatedShopsTableForAdmin/'+idValue+"?name="+$('#shopNameInput').val(), function (result) 
{alert(idValue+"/"+urlSegments[idIndex]+"/"+urlSegments[tableIndex]);
$("#shopsTable").html(result);
}); 
    });

});


$(document).ready(function () {
    var urlSegments = window.location.pathname.split('/');
    var idIndex = urlSegments.length - 1; 
    var tableIndex = urlSegments.length - 2;
    var idValue = window.isFinite(urlSegments[idIndex])==true 
    && urlSegments[tableIndex]=="products"? urlSegments[idIndex]:1;

 $.get('/product/getPaginatedProductsTableForAdmin/',function(result)
{
$("#productsTable").html(result);
});      

    $("#ProductSearchForm").submit(function (e) {   
 
        e.preventDefault(); 
       $.get('/product/getPaginatedProductsTableForAdmin/'+idValue+"?name="+$('#productNameInput').val(), function (result) 
{alert(idValue+"/"+urlSegments[idIndex]+"/"+urlSegments[tableIndex]);
$("#productsTable").html(result);
}); 
    });
});
*/
