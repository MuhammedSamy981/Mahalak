
$(document).ready(function () {

const content='<div class="text-center my-5"><div class="spinner-border m-5" role="status"><span class="visually-hidden">Loading...</span></div></div>';
$("#paginatedProductList").html(content);
 $.get('/product/getPaginatedProductList',function(result)
{
$("#paginatedProductList").html(result);
});          


    $("#productFiltersForm").submit(function (e) {   
 
        e.preventDefault(); 
        $("#paginatedProductList").html(content);
         $.get('/product/getPaginatedProductList', $(this).serialize(),function(result)
{
$("#paginatedProductList").html(result);
}); 

    });

});

//min price range start
  const minPriceRangeInput = document.getElementById('minPrice');
  const minPriceRangeOutput = document.getElementById('minPriceValue');


  minPriceRangeOutput.textContent = minPriceRangeInput.value;

  minPriceRangeInput.addEventListener('input', function() {
    minPriceRangeOutput.textContent = this.value;
  });
//min price range end

//max price range start
  const maxPriceRangeInput = document.getElementById('maxPrice');
  const maxPriceRangeOutput = document.getElementById('maxPriceValue');


  maxPriceRangeOutput.textContent = maxPriceRangeInput.value;

  maxPriceRangeInput.addEventListener('input', function() {
    maxPriceRangeOutput.textContent = this.value;
  });
//max price range end