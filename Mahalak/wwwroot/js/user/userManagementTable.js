

    $("#UserSearchForm").submit(function (e) {   

        e.preventDefault();

    var userEmailOrUserPhoneNumber=$('#emailOrPhoneNumberForUserInput').val();
    //alert("uyuyu"+userEmailOrUserPhoneNumber); 
    
$.get('/user/getPaginatedUserManagementTable?userEmailOrUserPhoneNumber='+userEmailOrUserPhoneNumber, function (result) 
{
$("#paginatedUserManagementTable").html(result);

});
    });


    function blockUser(id)
{
    //alert("block"); 
   if (confirm('هل أنت متأكد من أنك تريد حظر هذا الحساب ؟')){
let currentPage = document.querySelector(".active.user.getUserManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/blockUser/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterblock"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadUserManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }

});
}

}

    function unBlockUser(id)
{
    //alert("unBlockUser"); 
   if (confirm('هل أنت متأكد من أنك تريد فك حظر هذا الحساب ؟')){
let currentPage = document.querySelector(".active.user.getUserManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/unBlockUser/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterunblock"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadUserManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }

});
}

}

    function changeToAdmin(id)
{
    //alert("changeToAdmin"); 
   if (confirm('هل أنت متأكد من أنك تحويل جعل هذا الحساب لمشرف ؟')){
let currentPage = document.querySelector(".active.user.getUserManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/changeToAdmin/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterchangeToAdmin"); 
        if(result.success){
        alert("تمت العملية بنجاح");
                loadPaginatedAdminManagementTable();
        loadPaginatedUserManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }

});
}

}


    function deleteUser(id,role)
{
    //alert("deleteUser"); 
   if (confirm('هل أنت متأكد من أنك تريد حذف هذا الحساب ؟')){
$.post('/user/delete/'+id+'?role='+role, function (result) 
{//alert("afterdeleteUser"); 
$("#paginatedUserManagementTable").html(result);
});
}

}


document.getElementById("changeCountShopsLimit").addEventListener("click", function(event) {
  event.preventDefault(); // Optional, only needed if the button is inside a <form> and type="submit"
    //alert("changeCountShopsLimit"); 
let currentPage = document.querySelector(".active.user.getUserManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

var addingShopsCount = $('#addingShopsCount').find(":selected").val();
var addingShopsPeriod = $('#addingShopsPeriod').find(":selected").val();

$.post('/user/changeCountShopsLimit/?addingShopsCount='+addingShopsCount+'&addingShopsPeriod='+addingShopsPeriod+'&currentTablePage='+currentPageNumber, function (result) 
{//alert("afterchangeCountShopsLimit"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadUserManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }
});

});


    function removeAddingShops(id)
{
    //alert("removeAddingShops"); 
   if (confirm('هل أنت متأكد من أنك تريد إلفاء أضافة محلات لهذا المستخدم ؟')){
let currentPage = document.querySelector(".active.user.getUserManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/removeAddingShops/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterremoveAddingShops"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadUserManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }

});
}

}
