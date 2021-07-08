$(function () {

  if ($("a.confirmDeletion").length) {
    $("a.confirmDeletion").click(() => {
      if (!confirm("Confirm deletion")) return false;
    });
  }

  if ($("div.alert.notification").length) {
    setTimeout(() => {
      $("div.alert.notification").fadeOut();
    }, 2000);
  }

});

function readURL(input) {
  if (input.files && input.files[0]) {
    let reader = new FileReader();

    reader.onload = function (e) {
      $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
    };

    reader.readAsDataURL(input.files[0]);
  }
}

//// VK S

function confirmDelete(uniqueId, isDeleteClicked) {

  //window.preventDefault();

  var deleteSpan = 'deleteSpan_' + uniqueId;
  var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

  if (isDeleteClicked) {
    $('#' + deleteSpan).hide();
    $('#' + confirmDeleteSpan).show();
  }
  else {
    $('#' + deleteSpan).show();
    $('#' + confirmDeleteSpan).hide();
  }
}

//// VK E

function CKEditor() {

  CKEDITOR.replace('MainContent');
}

window.CKEDITOR =
{
  ckEditor: function () {
    CKEDITOR.replace("Content");
  },

  ckEditor1: function (id) {
    CKEDITOR.replace(document.getElementById(id));
  }

};
