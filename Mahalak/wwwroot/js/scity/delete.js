$(document).ready(function () {

loadScityDropdownList();      

    $("#deleteScityForm").submit(function (e) {   
 
        e.preventDefault(); 
                        var id = $('#ddlScities').find(":selected").val();
                if (id != "0" && id != null && id != undefined) {
       
       $.post('/scity/delete/'+id, function (result) {
        if(result.success){
        alert("تم الحذف بنجاح");
      loadScityDropdownList();}
      else{
                        alert("فشل الحذف");}
                    });
                    }
    });




});