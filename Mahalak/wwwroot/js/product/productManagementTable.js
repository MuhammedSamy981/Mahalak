$("#ProductSearchForm").submit(function (e) {   

        e.preventDefault();

    var productNameValue=$('#productNameInput').val();
    //alert("uyuyu"+productNameValue); 
    
$.get('/product/getPaginatedProductManagementTable?productName='+productNameValue, function (result) 
{
$("#paginatedProductManagementTable").html(result);
});

    });


        function acceptProduct(admin,id)
{
   let displayedProductId;
   let currentUser;
      var storedData = localStorage.getItem("displayedProductId");
    if (storedData) {
        var product = JSON.parse(storedData);
        displayedProductId=product.id;
        currentUser=product.currentUser;
        // alert("acceptProduct"+displayedProductId);
        // Optional: remove the data after use
        // localStorage.removeItem("userData");
    }
    //alert(displayedProductId+"/"+currentUser+"/");
 if(displayedProductId==id && currentUser==admin)
    {   
   if (confirm('هل أنت متأكد من أنك تريد قبول هذا المنتج ؟')){
let currentPage = document.querySelector(".active.product.getProductManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/product/acceptProduct/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afteracceptProduct"); 

        if(result.success){
        alert("تمت العملية بنجاح");
        loadProductManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }
});
}
}
else
{
    alert("يجب عليك رؤية المنتج أولا");
}


}



        function refuseProduct(admin,id)
{     let displayedProductId;
    let currentUser;
      var storedData = localStorage.getItem("displayedProductId");
    if (storedData) {
        var product = JSON.parse(storedData);
        displayedProductId=product.id;
        currentUser=product.currentUser;
         //alert("refuseProduct"+displayedProductId);
        // Optional: remove the data after use
        // localStorage.removeItem("userData");
    }
 if(displayedProductId==id && currentUser==admin){
   if (confirm('هل أنت متأكد من أنك تريد رفض هذا المنتج ؟')){
let currentPage = document.querySelector(".active.product.getProductManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/product/refuseProduct/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterrefuseProduct"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadProductManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }
});
}
}
else
{
    alert("يجب عليك رؤية المنتج أولا");
}
}


        function deleteProduct(id)
{
    //alert("deleteProduct"); 
   if (confirm('هل أنت متأكد من أنك تريد حذف هذا المنتج ؟')){
$.post('/product/delete/'+id, function (result) 
{//alert("afterdeleteProduct"); 
$("#paginatedProductManagementTable").html(result);
});
}

}