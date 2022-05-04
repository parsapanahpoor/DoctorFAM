/* ------------------------
    Table of Contents

  1. Predefined Variables
  2. Preloader  
  3. Menu  
  4. Side Menu  
  5. FullScreen
  6. Counter
  7. Banner Slider
  8. Owl carousel
  9. Magnific Popup
  10. Scroll to top
  11. Banner Section
  12. Fixed Header
  13. Text Color, Background Color And Image
  14. Contact Form
  15. ProgressBar
  16. Search
  17. Countdown
  18. NiceSelect
  19. ImageGallery
  20. Btn Product
  21. Cart
  22. Parallax
  23. Range Slider
  24. Wow Animation
  25. HT Window load and functions
  

------------------------ */

"use strict";



/*------------------------------------
  HT Predefined Variables
--------------------------------------*/
var $window = $(window),
  $document = $(document),
  $body = $('body'),
  $fullScreen = $('.fullscreen-banner') || $('.section-fullscreen'),
  $halfScreen = $('.halfscreen-banner'),
  searchActive = false;

//Check if function exists
$.fn.exists = function () {
  return this.length > 0;
};


/*------------------------------------
  HT PreLoader
--------------------------------------*/
function preloader() {
  $('#ht-preloader').fadeOut();
};


/*------------------------------------
  HT Menu
--------------------------------------*/
function menu() {
  // Variables
  var $dropdown = $('.dropdown-animate'),
    $dropdownSubmenu = $('.dropdown-submenu [data-toggle="dropdown"]');

  function initSubmenu($this) {
    if (!$this.next().hasClass('show')) {
      $this.parents('.dropdown-menu').first().find('.show').removeClass("show");
    }
    var $submenu = $this.next(".dropdown-menu");
    $submenu.toggleClass('show');
    $submenu.parent().toggleClass('show');
    $this.parents('.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
      $('.dropdown-submenu .show').removeClass("show");
    });
  }
  // Events
  if ($dropdown.length) {
    $dropdown.on({
      'hide.bs.dropdown': function () {
        hideDropdown($dropdown);
      }
    })
  }
  if ($dropdownSubmenu.length) {
    $dropdownSubmenu.on('click', function (e) {
      initSubmenu($(this))
      return false;
    });
  }
};

/*------------------------------------
  HT Side Menu
--------------------------------------*/
function sidenav() {
  $('.ht-nav-toggle').on('click', function (event) {
    event.preventDefault();
    var $this = $(this);
    if ($('body').hasClass('menu-show')) {
      $('body').removeClass('menu-show');
      $('#ht-main-nav > .ht-nav-toggle').removeClass('show');
    } else {
      $('body').addClass('menu-show');
      setTimeout(function () {
        $('#ht-main-nav > .ht-nav-toggle').addClass('show');
      }, 900);
    }
  })
};


/*------------------------------------
  HT FullScreen
--------------------------------------*/
function fullScreen() {
  if ($fullScreen.exists()) {
    $fullScreen.each(function () {
      var $elem = $(this),
        elemHeight = $window.height();
      if ($window.width() < 768) $elem.css('height', elemHeight / 1);
      else $elem.css('height', elemHeight);
    });
  }
  if ($halfScreen.exists()) {
    $halfScreen.each(function () {
      var $elem = $(this),
        elemHeight = $window.height();
      $elem.css('height', elemHeight / 2);
    });
  }
};


/*------------------------------------
  HT Counter
--------------------------------------*/
function counter() {
  $('.count-number').countTo({
    refreshInterval: 2
  });
};


/*------------------------------------
  HT Banner Slider
--------------------------------------*/
function bannerslider() {
  $('.banner-slider').each(function () {
    var $carousel = $(this);
    $carousel.owlCarousel({
      items: 1,
      loop: true,
      rtl: true,
      dots: $carousel.data("dots"),
      nav: $carousel.data("nav"),
      animateIn: 'pulse',
      autoplay: true,
      autoplayTimeout: 6000,
      navText: ['<span class="fas fa-chevron-left"><span>', '<span class="fas fa-chevron-right"></span>'],
    });
  });
};


/*------------------------------------
  HT Owl Carousel
--------------------------------------*/
function owlcarousel() {
  $('.owl-carousel').each(function () {
    var $carousel = $(this);
    $carousel.owlCarousel({
      items: $carousel.data("items"),
      slideBy: $carousel.data("slideby"),
      center: $carousel.data("center"),
      loop: true,
      rtl: true,
      margin: $carousel.data("margin"),
      dots: $carousel.data("dots"),
      nav: $carousel.data("nav"),
      autoplay: $carousel.data("autoplay"),
      autoplayTimeout: $carousel.data("autoplay-timeout"),
      navText: ['<span class="fas fa-chevron-left"><span>', '<span class="fas fa-chevron-right"></span>'],
      responsive: {
        0: { items: $carousel.data('xs-items') ? $carousel.data('xs-items') : 1 },
        576: { items: $carousel.data('sm-items') },
        768: { items: $carousel.data('md-items') },
        1024: { items: $carousel.data('lg-items') },
        1200: { items: $carousel.data("items") }
      },
    });
  });
};

/*------------------------------------
  HT Magnific Popup
--------------------------------------*/
function magnificpopup() {
  $('.popup-gallery').magnificPopup({
    delegate: 'a.popup-img',
    type: 'image',
    tLoading: 'Loading image #%curr%...',
    mainClass: 'mfp-img-mobile',
    gallery: {
      enabled: true,
      navigateByImgClick: true,
      preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
    },
    image: {
      tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
      titleSrc: function (item) {
        return item.el.attr('title') + '<small>by Marsel Van Oosten</small>';
      }
    }
  });
  if ($(".popup-youtube, .popup-vimeo, .popup-gmaps").exists()) {
    $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
      disableOn: 700,
      type: 'iframe',
      mainClass: 'mfp-fade',
      removalDelay: 160,
      preloader: false,
      fixedContentPos: false
    });
  }

};


/*------------------------------------
  HT Scroll to top
--------------------------------------*/
function scrolltop() {
  var pxShow = 300,
    goTopButton = $(".scroll-top")
  // Show or hide the button
  if ($(window).scrollTop() >= pxShow) goTopButton.addClass('scroll-visible');
  $(window).on('scroll', function () {
    if ($(window).scrollTop() >= pxShow) {
      if (!goTopButton.hasClass('scroll-visible')) goTopButton.addClass('scroll-visible')
    } else {
      goTopButton.removeClass('scroll-visible')
    }
  });
  $('.smoothscroll').on('click', function (e) {
    $('body,html').animate({
      scrollTop: 0
    }, 1000);
    return false;
  });
};


/*------------------------------------
 HT Banner Section
--------------------------------------*/
function headerheight() {
  $('.fullscreen-banner .align-center').each(function () {
    var headerHeight = $('.header').height();
    // headerHeight+=15; // maybe add an offset too?
    $(this).css('padding-top', headerHeight + 'px');
  });
};


/*------------------------------------
  HT Fixed Header
--------------------------------------*/
function fxheader() {
  $(window).on('scroll', function () {
    if ($(window).scrollTop() >= 300) {
      $('#header-wrap').addClass('fixed-header');
    } else {
      $('#header-wrap').removeClass('fixed-header');
    }
  });
};


/*------------------------------------------
  HT Text Color, Background Color And Image
---------------------------------------------*/
function databgcolor() {
  $('[data-bg-color]').each(function (index, el) {
    $(el).css('background-color', $(el).data('bg-color'));
  });
  $('[data-text-color]').each(function (index, el) {
    $(el).css('color', $(el).data('text-color'));
  });
  $('[data-bg-img]').each(function () {
    $(this).css('background-image', 'url(' + $(this).data("bg-img") + ')');
  });
};


/*------------------------------------
  HT Contact Form
--------------------------------------*/
function contactform() {

  $('#contact-form, #queto-form').validator();

  // when the form is submitted
  $('#contact-form, #queto-form').on('submit', function (e) {

    // if the validator does not prevent form submit
    if (!e.isDefaultPrevented()) {
      var url = "php/contact.php";

      // POST values in the background the the script URL
      $.ajax({
        type: "POST",
        url: url,
        data: $(this).serialize(),
        success: function (response) {
          $("#formmessage").html(response.msg).show().delay(2000).fadeOut('slow');
        }
      });
      return false;
    }
  })
};



/*------------------------------------
  HT ProgressBar
--------------------------------------*/
function progressbar() {
  var progressBar = $('.progress');
  if (progressBar.length) {
    progressBar.each(function () {
      var Self = $(this);
      Self.appear(function () {
        var progressValue = Self.data('value');

        Self.find('.progress-bar').animate({
          width: progressValue + '%'
        }, 1000);
      });
    })
  }
};


/*------------------------------------
  HT Search
--------------------------------------*/
function search() {

  // Search Toggle
  $("#search-input-box").hide();
  $("#search").on("click", function () {
    $("#search-input-box").slideToggle();
    $("#search-input").focus();
  });
  $("#close-search").on("click", function () {
    $('#search-input-box').slideUp(500);
  });
};


/*------------------------------------
  HT Countdown
--------------------------------------*/
function countdown() {
  $('.countdown').each(function () {
    var $this = $(this),
      finalDate = $(this).data('countdown');
    $this.countdown(finalDate, function (event) {
      $(this).html(event.strftime('<li><span>%-D</span><p>روز</p></li>' + '<li><span>%-H</span><p>ساعت</p></li>' + '<li><span>%-M</span><p>دقیقه</p></li>' + '<li><span>%S</span><p>ثانیه</p></li>'));
    });
  });
};

/*------------------------------------
  HT NiceSelect
--------------------------------------*/
function niceSelect() {
  $('select').niceSelect();
}

/*------------------------------------
  HT ImageGallery
--------------------------------------*/
function imagegallery() {
  $('#imageGallery').lightSlider({
    gallery: true,
    item: 1,
    verticalHeight: 450,
    thumbItem: 4,
    slideMargin: 0,
    speed: 600,
    autoplay: true,
    rtl: true
  });
}


/*------------------------------------
  HT Btn Product
--------------------------------------*/
function btnproduct() {
  $('.btn-product-up').on('click', function (e) {
    e.preventDefault();
    var numProduct = Number($(this).next().val());
    if (numProduct > 1) $(this).next().val(numProduct - 1);
  });
  $('.btn-product-down').on('click', function (e) {
    e.preventDefault();
    var numProduct = Number($(this).prev().val());
    $(this).prev().val(numProduct + 1);
  });
};


/*------------------------------------
  HT Cart
--------------------------------------*/
function cart() {
  $('#header-cart-btn').on('click', function () {
    $('body').toggleClass('cart-data-open');
  })
};

/*------------------------------------
  HT Parallax
--------------------------------------*/
function parallax() {
  $(".parallaxie").parallaxie({
    speed: 0.4,
    offset: 0,
  });
};

/*------------------------------------
  HT Range Slider
--------------------------------------*/
function rangeslider() {
    $( "#slider-range" ).slider({
        range: true,
        min: -500,
        max: 0,
        values: [ -400, -150 ],
        isRTL: true,
        slide: function( event, ui ) {
          $( "#amount" ).val(  -ui.values[ 1 ] +"تومان" + " - " + -ui.values[ 0 ]+"تومان" );
        }
      });
      $( "#amount" ).val( $( "#slider-range" ).slider( "values", 1) * (-1)+ "تومان"   +
        " -" + $( "#slider-range" ).slider( "values", 0 )  * (-1)+ "تومان" ) ;
  };


/*------------------------------------
  HT Wow Animation
--------------------------------------*/
function wowanimation() {
  var wow = new WOW({
    boxClass: 'wow',
    animateClass: 'animated',
    offset: 0,
    mobile: false,
    live: true
  });
  wow.init();
}


/*------------------------------------
  HT Window load and functions
--------------------------------------*/
$(document).ready(function () {
  fullScreen(),
    menu(),
    sidenav(),
    bannerslider(),
    owlcarousel(),
    counter(),
    magnificpopup(),
    scrolltop(),
    headerheight(),
    fxheader(),
    databgcolor(),
    contactform(),
    progressbar(),
    search(),
    countdown(),
    imagegallery(),
    niceSelect(),
    btnproduct(),
    cart(),
    parallax(),
    rangeslider();
});


$window.resize(function () {
});


$(window).on('load', function () {
  preloader(),
    wowanimation();
});
