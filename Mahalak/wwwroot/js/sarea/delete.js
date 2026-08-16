$(document).ready(function () {

loadSareaDropdownList();      

    $("#deleteSareaForm").submit(function (e) {   
 
        e.preventDefault(); 
                        var id = $('#ddlSareas').find(":selected").val();
                if (id != "0" && id != null && id != undefined) {
       
       $.post('/sarea/delete/'+id, function (result) {
        if(result.success){
        alert("تم الحذف بنجاح");
      loadSareaDropdownList();}
      else{
                        alert("فشل الحذف");}
                    });}
    });

});