$(document).ready(function () {
const content='<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';
           $("#ratingList").html(content);
          $("#addRating").html(content);
 
    var urlSegments = window.location.pathname.split('/');
    var idIndex = urlSegments.length - 1; 
    var idValue = urlSegments[idIndex];
 $.get('/rating/getAllByShopId/'+idValue,function(result)
{
$("#ratingList").html(result);
});  

      
   $.get('/rating/create',function(result)
{
$("#addRating").html(result);
});

}); 
