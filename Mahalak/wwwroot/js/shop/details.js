
$(document).ready(function () {
           $("#ratingSection").html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
        loadRatingSection();
}); 

function loadRatingSection()
{
    var urlSegments = window.location.pathname.split('/');
    var idIndex = urlSegments.length - 1; 
    var idValue = urlSegments[idIndex];
 $.get('/rating/getSection?shopId='+idValue+'&userName='+'@Model.User?.Email',function(result)
{
//alert("result");
$("#ratingSection").html(result);
});  

}