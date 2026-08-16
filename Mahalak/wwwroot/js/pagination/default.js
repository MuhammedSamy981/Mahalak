/*    $(document).ready(function () {

let controllerName= $('#@Model.ControllerName').text();
 let actionName= $('#@Model.ActionName').text();
  loadData(controllerName,actionName);
  });*/
     

/*document.getElementById("previousPageBtn").addEventListener("click", function() {
  //event.preventDefault(); 
       if (currentPage != 1 && currentPage != 0)
    {
      currentPage -= 1;
    }

            if(currentPage>totalPages)
  {
       currentPage = 1;

  }


  alert($("#@(Model.ControllerName+Model.ActionName)"+currentPage).text()+"fffffff");
  loadData();


});*/


function showPreviousPage(controllerName,actionName,totalPages,contentId)
{
    //event.preventDefault();
    let currentPage=Number($('#'+controllerName+actionName+'currentPage').val());
       if (currentPage != 1 && currentPage != 0)
    {
      currentPage -= 1;
    }

            if(currentPage>totalPages)
  {
       currentPage = 1;
  }

  loadData(controllerName,actionName,contentId,currentPage);

}

function showPageNumber(controllerName,actionName,contentId,id)
{

 let currentPage=Number($('#'+controllerName+actionName+'currentPage').val());
  currentPage=id;
  loadData(controllerName,actionName,contentId,currentPage);

}


function showNextPage(controllerName,actionName,totalPages,contentId)
{
    //event.preventDefault(); // Optional, only needed if the button is inside a <form> and type="submit"
  let currentPage=Number($('#'+controllerName+actionName+'currentPage').val());
        if (currentPage < totalPages && currentPage != 0)
    {
      currentPage += 1;
      
    }
    
  if(currentPage>totalPages)
  {
    currentPage=totalPages;  
  }

  loadData(controllerName,actionName,contentId,currentPage);

}


/*document.getElementById("nextPageBtn").addEventListener("click", function() {
  //event.preventDefault(); // Optional, only needed if the button is inside a <form> and type="submit"
        if (currentPage < totalPages && currentPage != 0)
    {
      currentPage += 1;
    }
         if(currentPage>totalPages)
  {
    currentPage=totalPages;
  }


  alert($("#@(Model.ControllerName+Model.ActionName)"+currentPage).text()+"fffffff");
  loadData();

});
*/

function loadData(controllerName,actionName,contentId,currentPage)
{
    // alert("loading");

$('#'+controllerName+actionName+'currentPage').val(currentPage);

let oldPage = document.querySelector(".active."+controllerName+"."+actionName);
let oldPageValue=oldPage!=null?oldPage.textContent.trim():"";
//if(oldPage!=null)
//{
  //alert("ele"+oldPage.textContent.trim());
  //}

//  if(currentPage==oldPageValue)
//{ 
 //  alert("eq");
//}

  if(currentPage!=oldPageValue)
{
   $('#'+contentId).html('<div class=" text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>');
   $.get('/'+controllerName+'/'+actionName+'/'+currentPage,function(result)
{
  // alert(oldPageValue);
   if(oldPageValue!="" && oldPageValue!=null)
   {
   $("#"+controllerName+actionName+oldPageValue).removeClass("active "+controllerName+" "+actionName);
   }
  $("#"+controllerName+actionName+currentPage).addClass("active "+controllerName+" "+actionName);
$('#'+contentId).html(result);
});

}

}
