/*
Author       : Dreamguys
Template Name: Doccure - Bootstrap Template
Version      : 1.3
*/

(function($) {
    "use strict";
	
	// Stick Sidebar
	
	if ($(window).width() > 767) {
		if($('.theiaStickySidebar').length > 0) {
			$('.theiaStickySidebar').theiaStickySidebar({
			  // Settings
			  additionalMarginTop: 30
			});
		}
	}
	
	// Sidebar
	
	if($(window).width() <= 991){
	var Sidemenu = function() {
		this.$menuItem = $('.main-nav a');
	};
	
	function init() {
		var $this = Sidemenu;
		$('.main-nav a').on('click', function(e) {
			if($(this).parent().hasClass('has-submenu')) {
				e.preventDefault();
			}
			if(!$(this).hasClass('submenu')) {
				$('ul', $(this).parents('ul:first')).slideUp(350);
				$('a', $(this).parents('ul:first')).removeClass('submenu');
				$(this).next('ul').slideDown(350);
				$(this).addClass('submenu');
			} else if($(this).hasClass('submenu')) {
				$(this).removeClass('submenu');
				$(this).next('ul').slideUp(350);
			}
		});
	}

	// Sidebar Initiate
	init();
	}
	
	// Textarea Text Count
	
	var maxLength = 100;
	$('#review_desc').on('keyup change', function () {
		var length = $(this).val().length;
		 length = maxLength-length;
		$('#chars').text(length);
	});
	
	// Select 2
	
	if($('.select').length > 0) {
		$('.select').select2({
			minimumResultsForSearch: -1,
			width: '100%'
		});
	}
	
	// Date Time Picker
	
	if($('.datetimepicker').length > 0) {
		$('.datetimepicker').datetimepicker({
			format: 'DD/MM/YYYY',
			icons: {
				up: "fas fa-chevron-up",
				down: "fas fa-chevron-down",
				next: 'fas fa-chevron-right',
				previous: 'fas fa-chevron-left'
			}
		});
	}
	
	// Floating Label

	if($('.floating').length > 0 ){
		$('.floating').on('focus blur', function (e) {
		$(this).parents('.form-focus').toggleClass('focused', (e.type === 'focus' || this.value.length > 0));
		}).trigger('blur');
	}
	
	// Mobile menu sidebar overlay
	
	$('body').append('<div class="sidebar-overlay"></div>');
	$(document).on('click', '#mobile_btn', function() {
		$('main-wrapper').toggleClass('slide-nav');
		$('.sidebar-overlay').toggleClass('opened');
		$('html').addClass('menu-opened');
		return false;
	});
	
	$(document).on('click', '.sidebar-overlay', function() {
		$('html').removeClass('menu-opened');
		$(this).removeClass('opened');
		$('main-wrapper').removeClass('slide-nav');
	});
	
	$(document).on('click', '#menu_close', function() {
		$('html').removeClass('menu-opened');
		$('.sidebar-overlay').removeClass('opened');
		$('main-wrapper').removeClass('slide-nav');
	});
	
	// Tooltip
	
	if($('[data-bs-toggle="tooltip"]').length > 0 ){
		var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
		var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
		return new bootstrap.Tooltip(tooltipTriggerEl)
		})
	}
	
	// Add More Hours
	
    $(".hours-info").on('click','.trash', function () {
		$(this).closest('.hours-cont').remove();
		return false;
    });

    $(".add-hours").on('click', function () {
		
		var hourscontent = '<div class="row form-row hours-cont">' +
			'<div class="col-12 col-md-10">' +
				'<div class="row form-row">' +
					'<div class="col-12 col-md-6">' +
						'<div class="form-group">' +
							'<label>Start Time</label>' +
							'<select class="form-control">' +
								'<option>-</option>' +
								'<option>12.00 am</option>' +
								'<option>12.30 am</option>' + 
								'<option>1.00 am</option>' +
								'<option>1.30 am</option>' +
							'</select>' +
						'</div>' +
					'</div>' +
					'<div class="col-12 col-md-6">' +
						'<div class="form-group">' +
							'<label>End Time</label>' +
							'<select class="form-control">' +
								'<option>-</option>' +
								'<option>12.00 am</option>' +
								'<option>12.30 am</option>' +
								'<option>1.00 am</option>' +
								'<option>1.30 am</option>' +
							'</select>' +
						'</div>' +
					'</div>' +
				'</div>' +
			'</div>' +
			'<div class="col-12 col-md-2"><label class="d-md-block d-sm-none d-none">&nbsp;</label><a href="#" class="btn btn-danger trash"><i class="far fa-trash-alt"></i></a></div>' +
		'</div>';
		
        $(".hours-info").append(hourscontent);
        return false;
    });
	
	// Content div min height set
	
	function resizeInnerDiv() {
		var height = $(window).height();	
		var header_height = $(".header").height();
		var footer_height = $(".footer").height();
		var setheight = height - header_height;
		var trueheight = setheight - footer_height;
		$(".content").css("min-height", trueheight);
	}
	
	if($('.content').length > 0 ){
		resizeInnerDiv();
	}

	$(window).resize(function(){
		if($('.content').length > 0 ){
			resizeInnerDiv();
		}
	});
	
	// Slick Slider
	
	if($('.specialities-slider').length > 0) {
		$('.specialities-slider').slick({
			dots: true,
			autoplay:false,
			infinite: true,
			variableWidth: true,
			rtl: true,
			prevArrow: false,
			nextArrow: false
		});
	}
	
	if($('.testimonial-slider').length > 0) {
		$('.testimonial-slider').slick({
			dots: true,
			autoplay:false,
			infinite: true,
			prevArrow: false,
			nextArrow: false,
			rtl: true,
			slidesToShow: 3,
			slidesToScroll: 1,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	if($('.doctor-slider').length > 0) {
		$('.doctor-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			rtl: true,
			variableWidth: true,
		});
	}
	if($('.features-slider').length > 0) {
		$('.features-slider').slick({
			dots: true,
			infinite: true,
			centerMode: true,
			slidesToShow: 3,
			speed: 500,
			variableWidth: true,
			arrows: false,
			autoplay:false,
			rtl: true,
			responsive: [{
				  breakpoint: 992,
				  settings: {
					slidesToShow: 1
				  }

			}]
		});
	}


	// Slick Slider
	if($('.features-slider1').length == 1) {
		$('.features-slider1').slick({
			dots: false,
			infinite: true,
			centerMode: false,
			slidesToShow: 1,
			speed: 500,
			variableWidth: true,
			arrows: true,
			autoplay:false,
			rtl: true,
			responsive: [{
				  breakpoint: 992,
				  settings: {
					slidesToShow: 1
				  }

			}]
		});
	}
	if($('.slider-1').length > 0) {
	    $('.slider-1').slick({
	    	rtl: true,
		});
	}

	if($('.dot-slider').length > 0) {
		$('.dot-slider').slick({
			dots: true,
			autoplay:false,
			infinite: true,
			slidesToShow: 1,
			slidesToScroll: 1,
			arrows: false,
			rtl: true,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 1
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 1
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 1
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	//clinic slider
	if($('.clinic-slider').length > 0) {
		$('.clinic-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			rtl: true,
			rows: 2,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	//browse slider
	if($('.browse-slider').length > 0) {
		$('.browse-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			rtl: true,
			rows: 2,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	//book doctor slider
	if($('.book-slider').length > 0) {
		$('.book-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			rtl: true,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	//avalable features slider
	if($('.aval-slider').length > 0) {
		$('.aval-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			slidesToShow: 3,
			slidesToScroll: 1,
			rtl: true,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}
	//Home pharmacy slider
	if($('.pharmacy-home-slider .swiper-container').length > 0) {
		 	var swiper = new Swiper('.pharmacy-home-slider .swiper-container', {
		 	loop: true,
		 	speed: 1000,
	      	pagination: {
	        	el: '.pharmacy-home-slider .swiper-pagination',
	        	dynamicBullets: true,
	        	clickable: true,
	      	},
	      	navigation: {
        		nextEl: '.pharmacy-home-slider .swiper-button-next',
        		prevEl: '.pharmacy-home-slider .swiper-button-prev',
      		},
	    });
	}

	
	// Date Range Picker
	if ($('.bookingrange').length > 0) {
		var start = moment().subtract(6, 'days');
		var end = moment();

		function booking_range(start, end) {
			var start = moment(start); // pass your date obj here.
            

            var end = moment(end); // pass your date obj here.
			
						
			$('.bookingrange span').html(start.format('jYYYY/jM/jD') + ' - ' + end.format('jYYYY/jM/jD'));
		}

		$('.bookingrange').daterangepicker({
			months: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'],
			startDate: start,
			endDate: end,
			ranges: {
				'امروز': [moment(), moment()],
				'دیروز': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
				'هفته گذشته': [moment().subtract(6, 'days'), moment()],
				'ماه گذشته': [moment().subtract(29, 'days'), moment()],
				'این ماه': [moment().startOf('month'), moment().endOf('month')],
				'ماه بعد': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
			},
			"locale": {
				"format": "YYYY/M/D",
				"separator": " - ",
				"applyLabel": "اعمال",
				"cancelLabel": "انصراف",
				"fromLabel": "از",
				"toLabel": "تا",
				"customRangeLabel": "سفارشی",
				"weekLabel": "هف",
				"daysOfWeek": [
					"ی",
					"د",
					"س",
					"چ",
					"پ",
					"ج",
					"ش"
				],
				"monthNames": [
					"ژانویه",
					"فوریه",
					"مارس",
					"آوریل",
					"می",
					"ژوئن",
					"جولای",
					"آگوست",
					"سپتامبر",
					"اکتبر",
					"نوامبر",
					"دسامبر"
				],
				"firstDay": 6
			}
		}, booking_range);

		booking_range(start, end);
	}

	// Chat

	var chatAppTarget = $('.chat-window');
	(function() {
		if ($(window).width() > 991)
			chatAppTarget.removeClass('chat-slide');
		
		$(document).on("click",".chat-window .chat-users-list a.media",function () {
			if ($(window).width() <= 991) {
				chatAppTarget.addClass('chat-slide');
			}
			return false;
		});
		$(document).on("click","#back_user_list",function () {
			if ($(window).width() <= 991) {
				chatAppTarget.removeClass('chat-slide');
			}	
			return false;
		});
	})();

	//Increment Decrement Numberes
	var quantitiy=0;
   $('.quantity-right-plus').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity').val());        
            $('#quantity').val(quantity + 1);
    });

     $('.quantity-left-minus').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity').val());
            if(quantity>0){
            	$('#quantity').val(quantity - 1);
            }
    });

     //Cart Click
     $("#cart").on("click", function(o) {
     	o.preventDefault();
    	$(".shopping-cart").fadeToggle();
    	$(".shopping-cart").toggleClass('show-cart');
 	 });
	
	// Circle Progress Bar
	
	function animateElements() {
		$('.circle-bar1').each(function () {
			var elementPos = $(this).offset().top;
			var topOfWindow = $(window).scrollTop();
			var percent = $(this).find('.circle-graph1').attr('data-percent');
			var animate = $(this).data('animate');
			if (elementPos < topOfWindow + $(window).height() - 30 && !animate) {
				$(this).data('animate', true);
				$(this).find('.circle-graph1').circleProgress({
					value: percent / 100,
					size : 400,
					thickness: 30,
					fill: {
						color: '#da3f81'
					}
				});
			}
		});
		$('.circle-bar2').each(function () {
			var elementPos = $(this).offset().top;
			var topOfWindow = $(window).scrollTop();
			var percent = $(this).find('.circle-graph2').attr('data-percent');
			var animate = $(this).data('animate');
			if (elementPos < topOfWindow + $(window).height() - 30 && !animate) {
				$(this).data('animate', true);
				$(this).find('.circle-graph2').circleProgress({
					value: percent / 100,
					size : 400,
					thickness: 30,
					fill: {
						color: '#68dda9'
					}
				});
			}
		});
		$('.circle-bar3').each(function () {
			var elementPos = $(this).offset().top;
			var topOfWindow = $(window).scrollTop();
			var percent = $(this).find('.circle-graph3').attr('data-percent');
			var animate = $(this).data('animate');
			if (elementPos < topOfWindow + $(window).height() - 30 && !animate) {
				$(this).data('animate', true);
				$(this).find('.circle-graph3').circleProgress({
					value: percent / 100,
					size : 400,
					thickness: 30,
					fill: {
						color: '#1b5a90'
					}
				});
			}
		});
	}	
	
	if($('.circle-bar').length > 0) {
		animateElements();
	}
	$(window).scroll(animateElements);
	
	// Preloader
	
	$(window).on('load', function () {
		if($('#loader').length > 0) {
			$('#loader').delay(350).fadeOut('slow');
			$('body').delay(350).css({ 'overflow': 'visible' });
		}
	})
	//owl carousel
	
	if($('.owl-carousel.clinics').length > 0) {
		$('.owl-carousel.clinics').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			nav:true,
			navContainer: '.slide-nav-1',
			navText: [ '<i class="fas fa-chevron-right custom-arrow"></i>', '<i class="fas fa-chevron-left custom-arrow"></i>' ], 
			rtl:true,
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:3
				},
				1000:{
					items:4
				},
				1300:{
					items:6
				}
			}
		})	
	}
	if($('.owl-carousel.our-doctors').length > 0) {
		$('.owl-carousel.our-doctors').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			rtl:true,
			nav:true,
			navContainer: '.slide-nav-2',
			navText: [ '<i class="fas fa-chevron-right custom-arrow"></i>', '<i class="fas fa-chevron-left custom-arrow"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:2
				},
				1000:{
					items:3
				},
				1300:{
					items:4
				}
			}
		})	
	}
	if($('.owl-carousel.clinic-feature').length > 0) {
		$('.owl-carousel.clinic-feature').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			rtl:true,
			nav:true,
			navContainer: '.slide-nav-3',
			navText: [ '<i class="fas fa-chevron-right custom-arrow"></i>', '<i class="fas fa-chevron-left custom-arrow"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:3
				},
				1000:{
					items:4
				},
				1300:{
					items:5
				}
			}
		})	
	}
	if($('.owl-carousel.blogs').length > 0) {
		$('.owl-carousel.blogs').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			rtl:true,
			nav:true,
			navContainer: '.slide-nav-4',
			navText: [ '<i class="fas fa-chevron-right custom-arrow"></i>', '<i class="fas fa-chevron-left custom-arrow"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:2
				},
				1000:{
					items:3
				},
				1300:{
					items:4
				}
			}
		})	
	}
	
	//header-fixed
	
	if($('.header-trans').length > 0) {
		$(document).ready(function(){
		  $(window).scroll(function(){
			var scroll = $(window).scrollTop();
			  if (scroll > 95) {
				$(".header-trans").css("background" , "#FFFFFF");
			  }

			  else{
				  $(".header-trans").css("background" , "transparent");  	
			  }
		  })
		})
	}
	if($('.header-trans.custom').length > 0) {
		$(document).ready(function(){
		  $(window).scroll(function(){
			var scroll = $(window).scrollTop();
			  if (scroll > 95) {
				$(".header-trans").css("background" , "#2b6ccb");
			  }

			  else{
				  $(".header-trans").css("background" , "transparent");  	
			  }
		  })
		})
	}

	//BMI Status
	if($('#bmi-status').length > 0) {
		var options = {
          series: [{
            name: "BMI",
            data: [10, 41, 35, 51, 49, 62, 69, 91, 148]
        }],
          chart: {
          height: 350,
          type: 'line',
          zoom: {
            enabled: false
          }
        },
        dataLabels: {
          enabled: false
        },
        stroke: {
          curve: 'straight'
        },
        title: {
          align: 'left'
        },
        grid: {
          row: {
            colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
            opacity: 0.5
          },
        },
        xaxis: {
          categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep'],
        }
        };

        var chart = new ApexCharts(document.querySelector("#bmi-status"), options);
        chart.render();
	}

	//Heart Rate Status
	if($('#heartrate-status').length > 0) {
		var options = {
          series: [{
          name: 'HeartRate',
          data: [4, 3, 10, 9, 29, 19, 22, 9, 12, 7, 19, 5, 13, 9, 17, 2, 7, 5]
        }],
          chart: {
          height: 350,
          type: 'line',
        },
        stroke: {
          width: 7,
          curve: 'smooth'
        },
        xaxis: {
          type: 'datetime',
          categories: ['1/11/2000', '2/11/2000', '3/11/2000', '4/11/2000', '5/11/2000', '6/11/2000', '7/11/2000', '8/11/2000', '9/11/2000', '10/11/2000', '11/11/2000', '12/11/2000', '1/11/2001', '2/11/2001', '3/11/2001','4/11/2001' ,'5/11/2001' ,'6/11/2001'],
          tickAmount: 10,
        },
        title: {
          align: 'left',
        },
        fill: {
          type: 'gradient',
          gradient: {
            shade: 'dark',
            gradientToColors: [ '#0de0fe'],
            shadeIntensity: 1,
            type: 'horizontal',
            opacityFrom: 1,
            opacityTo: 1,
            stops: [0, 100, 100, 100]
          },
        },
        markers: {
          size: 4,
          colors: ["#15558d"],
          strokeColors: "#fff",
          strokeWidth: 2,
          hover: {
            size: 7,
          }
        },
        yaxis: {
          min: -10,
          max: 40,
          title: {
          },
        }
        };

        var chart = new ApexCharts(document.querySelector("#heartrate-status"), options);
        chart.render();
	}

	//FBC Status
	if($('#fbc-status').length > 0) {
	 	var options = {
          series: [{
          name: 'FBC',
          data: [2.3, 3.1, 4.0, 10.1, 4.0, 3.6, 3.2, 2.3, 1.4, 0.8, 0.5, 0.2]
        }],
          chart: {
          height: 350,
          type: 'bar',
        },
        plotOptions: {
          bar: {
            borderRadius: 10,
            dataLabels: {
              position: 'top', // top, center, bottom
            },
          }
        },
        dataLabels: {
          enabled: true,
          formatter: function (val) {
            return val + "%";
          },
          offsetY: -20,
          style: {
            fontSize: '12px',
            colors: ["#304758"]
          }
        },
        
        xaxis: {
          categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
          position: 'top',
          axisBorder: {
            show: false
          },
          axisTicks: {
            show: false
          },
          crosshairs: {
            fill: {
              type: 'gradient',
              gradient: {
                colorFrom: '#0de0fe',
                colorTo: '#0de0fe',
                stops: [0, 100],
                opacityFrom: 0.4,
                opacityTo: 0.5,
              }
            }
          },
          tooltip: {
            enabled: true,
          }
        },
        yaxis: {
          axisBorder: {
            show: false
          },
          axisTicks: {
            show: false,
          },
          labels: {
            show: false,
            formatter: function (val) {
              return val + "%";
            }
          }
        
        },
        title: {
          floating: true,
          offsetY: 330,
          align: 'center',
          style: {
            color: '#444'
          }
        }
        };

        var chart = new ApexCharts(document.querySelector("#fbc-status"), options);
        chart.render();
    }

    //Weight Status
    if($('#weight-status').length > 0) {
    	var options = {
          series: [{
          name: 'Weight',
          data: [34, 44, 54, 21, 12, 43, 33, 23, 66, 66, 58]
        }],
          chart: {
          type: 'line',
          height: 350
        },
        stroke: {
          curve: 'stepline',
        },
        dataLabels: {
          enabled: false
        },
        title: {
          align: 'left'
        },
        markers: {
          hover: {
            sizeOffset: 4
          }
        }
        };

        var chart = new ApexCharts(document.querySelector("#weight-status"), options);
        chart.render();
    }

	// Signup Toggle
	$(function () {
        $("#is_registered").click(function () {
            if ($(this).is(":checked")) {
                $("#preg_div").show();
            } else {
                $("#preg_div").hide();
            }
        });
    });
	
	//Increment Decrement value
	$('.inc.button').click(function(){
	    var $this = $(this),
	        $input = $this.prev('input'),
	        $parent = $input.closest('div'),
	        newValue = parseInt($input.val())+1;
	    $parent.find('.inc').addClass('a'+newValue);
	    $input.val(newValue);
	    newValue += newValue;
	});
	$('.dec.button').click(function(){
	    var $this = $(this),
	        $input = $this.next('input'),
	        $parent = $input.closest('div'),
	        newValue = parseInt($input.val())-1;
	    console.log($parent);
	    $parent.find('.inc').addClass('a'+newValue);
	    $input.val(newValue);
	    newValue += newValue;
	});

	// Signup Profile
	function readURL(input) {
		if (input.files && input.files[0]) {
			var reader = new FileReader();

			reader.onload = function (e) {
				$('#prof-avatar').attr('src', e.target.result);
			};

			reader.readAsDataURL(input.files[0]);
		}
	}
	$("#profile_image").change(function() {
		readURL(this);
	});

	// Datepicker
	  var maxDate = $('#maxDate').val();
	  if($('#dob').length > 0) {
	  $('#dob').datepicker({
		  startView: 2,
		  format: 'dd/mm/yyyy',
		  autoclose: true,
		  todayHighlight: true,
		  endDate: maxDate
	  });
	}
	if($('#editdob').length > 0) {
	  $('#editdob').datepicker({
		startView: 2,
		format: 'dd/mm/yyyy',
		autoclose: true,
		todayHighlight: true,
		endDate: maxDate
	});
	}

	// Doctor Slider

	if($('.doctor-book-slider').length > 0) {
		$('.doctor-book-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			rtl: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	// Features Slider

	if($('.features-section-slider').length > 0) {
		$('.features-section-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			rtl: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			responsive: [{
				breakpoint: 1199,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 860,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	//Banner Three Slider

	var $status = $('.slider-counter-three');
	var $slickElement = $('.home-banner-three-slider');

	$slickElement.on('init reInit afterChange', function (event, slick, currentSlide, nextSlide) {
		if(!slick.$dots){
		return;
	}
	var i = (currentSlide ? currentSlide : 0) + 1;
		$status.text(i + '/' + (slick.$dots[0].children.length));
	});

	if($('.home-banner-three-slider').length > 0) {
		$slickElement.slick({
			autoplay:false,
			infinite: false,
			slidesToShow: 1,
			slidesToScroll: 1,
			autoplay: true,
			rtl: true,
			dots: true
		});
	}

	// AOS Animation

	if($('.main-wrapper .aos').length > 0) {
	    AOS.init({
		  duration: 1200,
		  once: true,
		});
	}

    // Favourite Btn

	$('.doctor-fav-btn .fav-icon').on('click', function () {
      	$(this).toggleClass('favourite');
    });

	// Doctor Slider

	if($('.best-doctor-slider').length > 0) {
		$('.best-doctor-slider').slick({
			dots: false,
			autoplay:false,
			infinite: true,
			rtl: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	// Home Banner Three

	if($('.owl-carousel.home-three-slider').length > 0) {
		$('.owl-carousel.home-three-slider').owlCarousel({
			loop:true,
			dots: true,
			nav:true,
			rtl: true,
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:1
				},
				1000:{
					items:1
				},
				1300:{
					items:1
				}
			}
		})	
	}

	// Best Our Doctors Slider

	if($('.owl-carousel.best-our-doctors').length > 0) {
		$('.owl-carousel.best-our-doctors').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			nav:true,
			rtl: true,
			navContainer: '.slide-nav-5',
			navText: [ '<i class="fas fa-chevron-right"></i>', '<i class="fas fa-chevron-left"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:2
				},
				1000:{
					items:3
				},
				1300:{
					items:4
				}
			}
		})	
	}

	// Features Clinic Slider

	if($('.owl-carousel.features-clinic-slider').length > 0) {
		$('.owl-carousel.features-clinic-slider').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			nav:true,
			rtl: true,
			navContainer: '.slide-nav-6',
			navText: [ '<i class="fas fa-chevron-right"></i>', '<i class="fas fa-chevron-left"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:2
				},
				1000:{
					items:3
				},
				1300:{
					items:4
				}
			}
		})	
	}

	// Latest Blog Slider

	if($('.owl-carousel.latest-blog-slider').length > 0) {
		$('.owl-carousel.latest-blog-slider').owlCarousel({
			loop:true,
			margin:10,
			dots: false,
			nav:true,
			rtl: true,
			navContainer: '.slide-nav-7',
			navText: [ '<i class="fas fa-chevron-right"></i>', '<i class="fas fa-chevron-left"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:2
				},
				1000:{
					items:3
				},
				1300:{
					items:3
				}
			}
		})	
	}

	// Best Doctors Slider

	if($('.best-doctors-slider').length > 0) {
		$('.best-doctors-slider').slick({
			dots: true,
			autoplay:false,
			rtl: true,
			infinite: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			responsive: [{
				breakpoint: 992,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 800,
					settings: {
						slidesToShow: 3
				  	}
			},
			{
				breakpoint: 776,
					settings: {
						slidesToShow: 2
				  	}
			},
			{
				breakpoint: 567,
					settings: {
						slidesToShow: 1
					}
			}]
		});
	}

	// Features Clinic Four

	if($('.owl-carousel.features-clinic-slider-four').length > 0) {
		$('.owl-carousel.features-clinic-slider-four').owlCarousel({
			loop:true,
			margin:15,
			dots: false,
			nav:true,
			rtl: true,
			navContainer: '.slide-nav-8',
			navText: [ '<i class="fas fa-chevron-right"></i>', '<i class="fas fa-chevron-left"></i>' ], 
			responsive:{
				0:{
					items:1
				},
				500:{
					items:1
				},
				768:{
					items:2
				},
				1000:{
					items:3
				},
				1300:{
					items:3
				}
			}
		})	
	}

	// Scroll Down
	
  	$('a.smooth-menu').on('click', function(e) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top});
        e.preventDefault();
    });

    // Home Banner Three Slider Arrow Position 

    var window_width = $(window).outerWidth();
    var container_width = $('.container').outerWidth();
    var full_width = window_width - container_width
    var right_position_value = full_width / 2
    $('.banner-two-slider .slider-counter').css('left', right_position_value);
    $('.banner-two-slider .slick-next').css('left', right_position_value + 10);
    $('.banner-two-slider .slick-prev').css('left', right_position_value + 150);

    // Home Banner Four Slider Arrow Position 

    var window_width = $(window).outerWidth();
    var container_width = $('.container').outerWidth();
    var full_width = window_width - container_width
    var right_position_value = full_width / 2
    $('.home-three-slider .owl-dots').css('right', right_position_value - 10);
    $('.home-three-slider .owl-next').css('left', right_position_value - 10);
    $('.home-three-slider .owl-prev').css('left', right_position_value - 150);

    // Inspect keyCode

	// // $( window ).on( "load", function() {
	// 	document.onkeydown = function(e) {
	// 		if(e.keyCode == 123) {
	// 		 return false;
	// 		}
	// 		if(e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)){
	// 		 return false;
	// 		}
	// 		if(e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)){
	// 		 return false;
	// 		}
	// 		if(e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)){
	// 		 return false;
	// 		}
		
	// 		if(e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)){
	// 		 return false;
	// 		}      
	// 	 };
		 
	// });

	document.oncontextmenu = function() {return false;};
		$(document).mousedown(function(e){ 
		if( e.button == 2 ) { 
			return false; 
		} 
		return true; 
	});
	
})(jQuery);