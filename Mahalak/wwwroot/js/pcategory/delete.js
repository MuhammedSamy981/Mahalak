$(document).ready(function () {

loadPcategoryDropdownList();      

    $("#deletePcategoryForm").submit(function (e) {   
 
        e.preventDefault(); 
        var id = $('#ddlPcategories').find(":selected").val();
                if (id != "0" && id != null && id != undefined) {
       
       $.post('/pcategory/delete/'+id, function (result) {
        if(result.success){
        alert("تم الحذف بنجاح");
      loadPcategoryDropdownList();}
      else{
                        alert("فشل الحذف");}
                    });
                    }
    });




});