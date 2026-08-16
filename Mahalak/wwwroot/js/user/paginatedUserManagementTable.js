
    $(document).ready(function () {


loadUserManagementTable();
}); 

function loadUserManagementTable(){
     $("#userManagementTable").html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
 $.get('/user/getUserManagementTable',function(result)
{
$("#userManagementTable").html(result);
}); 
}

function loadPaginatedUserManagementTable(){
$.get('/user/getPaginatedUserManagementTable/',function(result)
{
$("#paginatedUserManagementTable").html(result);
}); 

}
