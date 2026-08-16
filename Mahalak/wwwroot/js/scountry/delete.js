$(document).ready(function () {

loadScountryDropdownList();      

    $("#deleteScountryForm").submit(function (e) {   
 
        e.preventDefault(); 
                        var id = $('#ddlScountries').find(":selected").val();
                if (id != "0" && id != null && id != undefined) {
       
       $.post('/scountry/delete/'+id, function (result) {
        if(result.success){
        alert("تم الحذف بنجاح");
      loadScountryDropdownList();}
      else{
                        alert("فشل الحذف");}
                    });}
    });


});