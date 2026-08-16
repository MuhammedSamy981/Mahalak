$(document).ready(function () {

loadPconditionDropdownList();      

    $("#deletePconditionForm").submit(function (e) {   
 
        e.preventDefault(); 
        var id = $('#ddlPconditions').find(":selected").val();
                if (id != "0" && id != null && id != undefined) {
       $.post('/pcondition/delete/'+id, function (result) {
        if(result.success){
        alert("تم الحذف بنجاح");
      loadPconditionDropdownList();}
      else{
                        alert("فشل الحذف");}
                    });}
    });




});