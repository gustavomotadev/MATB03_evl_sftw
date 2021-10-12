function pageLoad(sender, args) {
  var prm = Sys.WebForms.PageRequestManager.getInstance();
  prm.add_beginRequest(BeginRequestHandler);
  prm.add_endRequest(EndRequestHandler);
}

function BeginRequestHandler(sender, args) {
  toggleLoader(true);
}

function EndRequestHandler(sender, args) {
  toggleLoader(false);
}

function toggleLoader(visible) {
  $loaderWrapper = $('#loader-wrapper');
  if (visible)
    $loaderWrapper.fadeIn(100);
  else
    $loaderWrapper.fadeOut(100);
}

function initSummernote() {
  $(".summernote").summernote({ height: 300 });
  // When the summernote instance loses focus, update the content of your <textarea>
  $(".summernote").on('summernote.blur', function () {
    $('.summernote').html($('.summernote').summernote('code'));
  });
}

Sys.Application.add_load(BindEvents);

function BindEvents() {
  $(document).ready(function () {
    App.init();
    App.masks();
    try {
      App.wizard();
    }
    catch{ }

    App.formElements();
    initSummernote();

    $(".currency").maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });


  });
}