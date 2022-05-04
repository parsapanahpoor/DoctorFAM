/*! * jQuery Cookie Plugin v1.4.1
 * https://github.com/carhartl/jquery-cookie
 */

!function(a){"function"==typeof define&&define.amd?define(["jquery"],a):"object"==typeof exports?a(require("jquery")):a(jQuery)}(function(a){function c(a){return h.raw?a:encodeURIComponent(a)}function d(a){return h.raw?a:decodeURIComponent(a)}function e(a){return c(h.json?JSON.stringify(a):String(a))}function f(a){0===a.indexOf('"')&&(a=a.slice(1,-1).replace(/\\"/g,'"').replace(/\\\\/g,"\\"));try{return a=decodeURIComponent(a.replace(b," ")),h.json?JSON.parse(a):a}catch(c){}}function g(b,c){var d=h.raw?b:f(b);return a.isFunction(c)?c(d):d}var b=/\+/g,h=a.cookie=function(b,f,i){if(arguments.length>1&&!a.isFunction(f)){if(i=a.extend({},h.defaults,i),"number"==typeof i.expires){var j=i.expires,k=i.expires=new Date;k.setTime(+k+864e5*j)}return document.cookie=[c(b),"=",e(f),i.expires?"; expires="+i.expires.toUTCString():"",i.path?"; path="+i.path:"",i.domain?"; domain="+i.domain:"",i.secure?"; secure":""].join("")}for(var l=b?void 0:{},m=document.cookie?document.cookie.split("; "):[],n=0,o=m.length;o>n;n++){var p=m[n].split("="),q=d(p.shift()),r=p.join("=");if(b&&b===q){l=g(r,f);break}b||void 0===(r=g(r))||(l[q]=r)}return l};h.defaults={},a.removeCookie=function(b,c){return void 0===a.cookie(b)?!1:(a.cookie(b,"",a.extend({},c,{expires:-1})),!a.cookie(b))}});

/* ------------------------------------------------
NOTE: This file Change the styling of color, backgrond color of the actual Template. so you can change as your requirement.
------------------------------------------------ */

jQuery(document).ready(function($) {

/*------------------------------------
  HT Right sidebar
--------------------------------------*/
style_switcher = $('.color-customizer'),
panelWidth = style_switcher.outerWidth(true);
$('.color-customizer .opener').on("click", function(){
	var $this = $(this);
	if ($(".color-customizer.closed").length>0) {
		style_switcher.animate({"left" : "0px"});
		$(".color-customizer.closed").removeClass("closed");
		$(".color-customizer").addClass("opened");
	} else {
		$(".color-customizer.opened").removeClass("opened");
		$(".color-customizer").addClass("closed");
		style_switcher.animate({"left" : '-' + panelWidth});
	}
	return false;
});


/*------------------------------------
  HT Style change
--------------------------------------*/
var link = $('link[data-style="styles"]'),
link_no_cookie = $('link[data-style="styles-no-cookie"]'); 


/*------------------------------------
  HT Color Changer
--------------------------------------*/
$('.color-customizer .colorChange li').on('click',function(){
	if (link.length>0) {
		var $this = $(this),
			tp_stylesheet = $this.data('style');
		$(".color-customizer .colorChange .selected").removeClass("selected");
		$this.addClass("selected");
		link.attr('href', 'css/theme-color/' + tp_stylesheet + '.css');
		if ($(".swicher-title-page-dark").length>0) {
			document.getElementById("logo-img").src="images/logo-customizer/logo_dark_swicher-title_" + tp_stylesheet + ".png";
		} else {
			if ($("#logo-img").length>0) {
				document.getElementById("logo-img").src="images/logo-customizer/logo-" + tp_stylesheet + ".png";
			};
			if ($("#logo-white-img").length>0) {
			 			document.getElementById("logo-white-img").src="images/logo-customizer-white/logo-" + tp_stylesheet + ".png";
			};

			if ($("#footer-logo-img").length>0) {
				document.getElementById("footer-logo-img").src="images/logo-customizer/logo-" + tp_stylesheet + ".png";
			};
		};
		$.cookie('tp_stylesheet', tp_stylesheet, 30);
		updatechart($( $(this) ).index( '.color-customizer .colorChange li' ));
	} 
});


/*------------------------------------
  HT Reset all customize styles
--------------------------------------*/
$('.color-customizer .reset a.reset-btn').on('click',function() { 
	
	//Logo change
	$.cookie('tp_stylesheet', 'theme-default', 30);
	var tp_stylesheet = 'theme-default';
	$('.color-customizer .colorChange li.selected').removeClass("selected");
	$('.color-customizer .colorChange li[data-style="'+tp_stylesheet+'"]').addClass("selected");
	link.attr('href', 'css/theme-color/' + tp_stylesheet + '.css');
	 if ($("#logo-img").length>0) {
	 	document.getElementById("logo-img").src="images/logo-customizer/logo-" + tp_stylesheet + ".png";
	 };

	 $(window).trigger('resize');
	 $('.desktopTopFixed').removeClass('desktopTopFixed');
	});
});
