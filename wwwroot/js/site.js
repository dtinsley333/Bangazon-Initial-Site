// Write your Javascript code. < Ok, Steve! :)

$(document).ready(function () {
    var subtypes = []
    $.ajax({
      url: "/Products/GetSubTypesForDropdown",
      method: "GET",
      headers: {
        "Content-Type": "application/json"
      }
    })
    .success(function(subTypes){
        subtypes.push(subTypes);
    });

  $(".ProductSubTypeId").hide();
  $("#ProductTypeId").on("change", function (e) {
    $(".ProductSubTypeId").show();
    $(".ProductSubTypeId").html(`<select></select>`);
    for(var key in subtypes[0]) {
        if(subtypes[0][key].productTypeId == $(this).val()){
            $(".ProductSubTypeId").append(`<option value="${subtypes[0][key].productSubTypeId}">${subtypes[0][key].name}</option>`);
        }
    }
  })
});