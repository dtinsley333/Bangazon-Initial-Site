// Write your Javascript code. < Ok, Steve! :)

$(document).ready(function () {
    //^allows us to use jquery
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
        console.log("subTypes", subTypes);
    });
    $(".ProductSubTypeId").hide();
  $("#ProductTypeId").on("change", function (e) {
      $(".ProductSubTypeId").show();
      $(".ProductSubTypeId").html(`<select></select>`);
        console.log("this.val",$(this).val());
        console.log("item.productypeid", subtypes)
    for(var key in subtypes[0]) {
        console.log("key", key)
        if(subtypes[0][key].productTypeId == $(this).val()){
            $(".ProductSubTypeId").append(`<option value="${subtypes[0][key].productSubTypeId}">${subtypes[0][key].name}</option>`);
            console.log("item to append", subtypes[0][key]);
        }
    }
  })
});