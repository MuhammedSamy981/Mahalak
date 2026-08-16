
   /* $(document).ready(function () {
const content='<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';

$("#ratingTable").html(content);
});*/

            function acceptClientComment(id)
{
    alert("acceptClientComment"); 
   if (confirm('هل أنت متأكد من أنك تريد قبول هذا التعليق ؟')){
$.post('/rating/acceptClientComment/'+id, function (result) 
{alert("afteracceptClientComment"); 
$("#ratingTable").html(result);

});
}

}

        function removeClientComment(id)
{
    alert("removeClientComment"); 
   if (confirm('هل أنت متأكد من أنك تريد حذف هذا التعليق ؟')){
$.post('/rating/removeClientComment/'+id, function (result) 
{alert("afterremoveClientComment"); 
$("#ratingTable").html(result);
});
}
}
