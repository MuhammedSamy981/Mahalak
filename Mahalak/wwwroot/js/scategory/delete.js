$(document).ready(function () {

loadScategoryDropdownList();      

    $("#deleteScategoryForm").submit(function (e) {   
 
        e.preventDefault(); 
        var id = $('#ddlScategories').find(":selected").val();
                if (id != "0" && id != null && id != undefined) {
       $.post('/scategory/delete/'+id, function (result) {
        if(result.success){
        alert("تم الحذف بنجاح");
      loadScategoryDropdownList();}
      else{
                        alert("فشل الحذف");}
                    });}
    });




});