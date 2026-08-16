
    $(document).ready(function () {

loadProductManagementTable();

}); 

function loadProductManagementTable(){
         $("#productManagementTable").html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
 $.get('/product/getProductManagementTable',function(result)
{
    //alert("cvv");
$("#productManagementTable").html(result);
}); 
}
