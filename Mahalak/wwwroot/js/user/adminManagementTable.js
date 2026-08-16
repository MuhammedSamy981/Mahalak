
    //alert("uyuyuemailOrPhoneNumberValue"); 
    $("#AdminSearchForm").submit(function (e) {   

        e.preventDefault();

    var adminEmailOrAdminPhoneNumber=$('#emailOrPhoneNumberForAdminInput').val();
    //alert("uyuyu"+adminEmailOrAdminPhoneNumber); 
        var url = adminEmailOrAdminPhoneNumber!=undefined && adminEmailOrAdminPhoneNumber!=""? 
    '/user/getAdminManagementTable?emailOrPhoneNumber='+adminEmailOrAdminPhoneNumber
    :'/user/getAdminManagementTable';
    
$.get('/user/getPaginatedAdminManagementTable?adminEmailOrAdminPhoneNumber='+adminEmailOrAdminPhoneNumber, function (result) 
{
$("#paginatedAdminManagementTable").html(result);


});
    });



    function blockAdmin(id)
{
    //alert("block"); 
   if (confirm('هل أنت متأكد من أنك تريد حظر هذا الحساب ؟')){
let currentPage = document.querySelector(".active.user.getAdminManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/blockUser/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterblock"); 
        if(result.success){
        alert("تمت العملية بنجاح");
        loadAdminManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }

});
}

}

    function unBlockAdmin(id)
{
    //alert("unBlockUser"); 
   if (confirm('هل أنت متأكد من أنك تريد فك حظر هذا الحساب ؟')){
let currentPage = document.querySelector(".active.user.getAdminManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/unBlockUser/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterunblock"); 

        if(result.success){
        alert("تمت العملية بنجاح");
        loadAdminManagementTable();
      }
      else{
                        alert("فشلت العملية");
                        }
});
}

}

    function changeToUser(id)
{
    //alert("changeToUser"); 
   if (confirm('هل أنت متأكد من أنك تريد تحويل هذا الحساب لمستخدم عادى'))
   {
let currentPage = document.querySelector(".active.user.getAdminManagementTable");
let currentPageTextContent=currentPage!=null?currentPage.textContent.trim():"1";
let currentPageNumber=Number(currentPageTextContent);

$.post('/user/changeToUser/'+id+'?currentTablePage='+currentPageNumber, function (result) 
{//alert("afterchangeToUser"); 
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

    function deleteAdmin(id,role)
{
    //alert("deleteAdmin"); 
   if (confirm('هل أنت متأكد من أنك تريد حذف هذا الحساب ؟')){
$.post('/user/delete/'+id+'?role='+role, function (result) 
{//alert("afterdeleteAdmin"); 
$("#paginatedAdminManagementTable").html(result);
});
}

}
