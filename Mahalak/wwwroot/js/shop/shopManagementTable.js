
    $("#ShopSearchForm").submit(function (e) {   
        e.preventDefault();
    var shopNameValue=$('#shopNameInput').val();
    //alert("uyuyu"+shopNameValue); 

$.get('/shop/getPaginatedShopManagementTable?shopName='+shopNameValue, function (result) 
{
      //alert("kkkkkkkk"+shopNameValue); 
$("#paginatedShopManagementTable").html(result);
});
    });


            function acceptShop(id)
{
    //alert("acceptShop"); 
   if (confirm('هل أنت متأكد من أنك تريد قبول هذا المحل ؟')){
let currentPage = document.querySelector(".active.shop.getShopManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/shop/acceptShop/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afteracceptShop"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadShopManagementTable();
        $.get('/product/getPaginatedProductManagementTable',function(result)
{
$("#paginatedProductManagementTable").html(result);
}); 
      }
      else{
                        alert("فشلت العملية");
                        }
});
}

}


        function refuseShop(id)
{
    //alert("refuseshop"); 
   if (confirm('هل أنت متأكد من أنك تريد رفض هذا المحل ؟')){
let currentPage = document.querySelector(".active.shop.getShopManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/shop/refuseShop/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterrefuseshop"); 
        if(result.success){
        //alert("تمت العملية بنجاح");
        loadShopManagementTable();
      }
      else{
                        //alert("فشلت العملية");
                        }
});
}

}

        function deleteShop(id)
{
    //alert("deleteshop"); 
   if (confirm('هل أنت متأكد من أنك تريد حذف هذا المحل ؟')){
$.post('/shop/delete/'+id, function (result) 
{//alert("afterdeleteshop"); 
$("#paginatedShopManagementTable").html(result);
});
}
}


document.getElementById("distinguishShop").addEventListener("click", function(event) {
  event.preventDefault(); // Optional, only needed if the button is inside a <form> and type="submit"
    //alert("distinguishShop"); 
let currentPage = document.querySelector(".active.shop.getShopManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

var distinctivePeriod = $('#distinctivePeriod').find(":selected").val();

$.post('/shop/distinguishShop/?distinctivePeriod='+distinctivePeriod+'&currentTablePage='+currentPageNumber, function (result) 
{//alert("afterdistinguishShop"); 
        if(result.success){
        //alert("تمت العملية بنجاح");
        loadShopManagementTable();
      }
      else{
                        //alert("فشلت العملية");
                        }
});

});




    function removeDistinctive(id)
{
    //alert("removeDistinctive"); 
   if (confirm('هل أنت متأكد من أنك تريد إلغاء تمييز هذا المحل ؟')){
let currentPage = document.querySelector(".active.shop.getShopManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/shop/removeDistinctive/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterremoveDistinctive"); 
        if(result.success){
        //alert("تمت العملية بنجاح");
        loadShopManagementTable();
      }
      else{
                        //alert("فشلت العملية");
                        }

});
}

}
