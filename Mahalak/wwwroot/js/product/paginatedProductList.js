
    $(document).ready(function () {

         $("#productList").html('<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
//alert("fodifoido");
 $.get('/product/getProductList',function(result)
{
    //alert("ptpjkj");
$("#productList").html(result);
}); 


}); 