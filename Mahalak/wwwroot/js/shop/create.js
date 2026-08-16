 /* $("body").on("change", "#ddlCategories", function () {
    document.forms["Form1"].submit();
  });

  $("body").on("change", "#ddlCities", function () {
    document.forms["Form1"].submit();
  });

  $("body").on("change", "#ddlAreas", function () {
    document.forms["Form1"].submit();
  });

    document.addEventListener("DOMContentLoaded", function () {
    // Get a reference to the form and submit button
    var form = document.getElementById("myForm");
    var ddlCategories = document.getElementById("ddlCategories");
    var ddlCities = document.getElementById("ddlCities");
    var ddlAreas = document.getElementById("ddlAreas");
    var spinnerLoading = document.getElementById("spinnerLoading");
    var submitButton = document.getElementById("submitBtn");

    var categoryValue = $('#ddlCategories').find(":selected").val();
    var cityValue = $('#ddlCities').find(":selected").val();
    var areaValue = $('#ddlAreas').find(":selected").val();
    if (areaValue != "0" && areaValue != null && areaValue != undefined) {
      submitButton.disabled = false;
    }

    // Add a submit event listener to the form
    form.addEventListener("submit", function () {

      if ($("#myForm").valid()) {
        ddlCategories.disabled = true;

        $('#categoryId').val(categoryValue);
        ddlCities.disabled = true;

        $('#cityId').val(cityValue);
        ddlAreas.disabled = true;
        $('#areaId').val(areaValue);
        spinnerLoading.hidden = false;
        submitButton.disabled = true;

        alert(" برجاء الأنتظار حتى بتم أنشاء المحل");
      }

    });

  });
*/

    $("body").on("change", "#ddlCities", function (e) {
        e.preventDefault(); 
            var cityValue = $('#ddlCities').find(":selected").val();
                if (cityValue != "0" && cityValue != null && cityValue != undefined) {
       $.get('/shop/getAreasByCityId/'+cityValue,function(result)
       {
      $('#ddlAreas').empty();
       $('#ddlAreas').append(new Option("- أختر المنطقة -","0"));
       $.each(result.areas, function(key,value)
       {
        $('#ddlAreas').append(new Option(value.text,value.value));
       });
                 var ddlAreas = document.getElementById("ddlAreas");
              ddlAreas.disabled = false;
       });
       }
  });

  $("body").on("change", "#ddlAreas", function () {
        var areaValue = $('#ddlAreas').find(":selected").val();
    if (areaValue != "0" && areaValue != null && areaValue != undefined) {
          var submitButton = document.getElementById("submitBtn");
      submitButton.disabled = false;
    }
  });

    document.addEventListener("DOMContentLoaded", function () {
    // Get a reference to the form and submit button
    var form = document.getElementById("myForm");
    var shopName=document.getElementById("shopName");
    var ddlCategories = document.getElementById("ddlCategories");
    var ddlCities = document.getElementById("ddlCities");
    var ddlAreas = document.getElementById("ddlAreas");
    var spinnerLoading = document.getElementById("spinnerLoading");
    var submitButton = document.getElementById("submitBtn");

    // Add a submit event listener to the form
    form.addEventListener("submit", function () {

      if ($("#myForm").valid()) {

shopName.readonly = true;
                var categoryValue = $('#ddlCategories').find(":selected").val();
//to set value in hidden input with id=categoryId before ddlCategories disabled
    $('#categoryId').val(categoryValue); 
ddlCategories.disabled = true;
        

            var cityValue = $('#ddlCities').find(":selected").val();
                    $('#cityId').val(cityValue);
        ddlCities.disabled = true;


    var areaValue = $('#ddlAreas').find(":selected").val();        
        $('#areaId').val(areaValue);
ddlAreas.disabled = true;

        spinnerLoading.hidden = false;

        submitButton.disabled = true;

        alert(" برجاء الأنتظار حتى بتم أنشاء المحل");
      }

    });

  });
