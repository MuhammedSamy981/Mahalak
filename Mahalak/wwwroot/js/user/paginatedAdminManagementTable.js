
    $(document).ready(function () {

loadAdminManagementTable();

}); 

function loadAdminManagementTable(){
         $("#adminManagementTable").html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
 $.get('/user/getAdminManagementTable',function(result)
{
    //alert("HHHHHHHHHhhhhh");
$("#adminManagementTable").html(result);
}); 
}

function loadPaginatedAdminManagementTable(){
$.get('/user/getPaginatedAdminManagementTable/',function(result)
{
$("#paginatedAdminManagementTable").html(result);
}); 
}
