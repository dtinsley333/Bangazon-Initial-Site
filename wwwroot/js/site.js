// Write your Javascript code. < Ok, Steve! :)

$(document).ready(function () {
    //^allows us to use jquery
  $("#ProductTypeId").on("change", function (e) {
    $.ajax({
      url: "/Products/GetSubType/",
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      data: {
        "TypeId": $(this).val() 
      }
    });
    // location.reload();
  });
});