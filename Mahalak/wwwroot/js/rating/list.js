
        function deleteRating(id)
{
    //alert("deleteRating"); 
   if (confirm('هل أنت متأكد من أنك تريد حذف هذا التقييم ؟')){

            var submitButton = document.getElementById("submitBtn");
      submitButton.disabled = true;

$.post('/rating/delete/'+id, function (result) 
{//alert("afterdeleteRating"); 
 if(result.success){
        loadRatingSection();
      }
});
}

}
