/*
 * Mohammad Hossein Abedinpour
 * Hamyar slider version 1.0.1
 * http://mhabedinpour.com
 * http://hamyar.org
 * http://mhabedinpour.com/lab/slider/
 */
(function($) {
	$.fn.hamyar_slider = function(option) {
		//get option
		var def = {
			show : 5,
			btnext : null,
			btnprev : null,
			speed : 300,
			disable_class : 'disable',
			auto : false,
			auto_time : 2000,
			slide : 1
		}
		//set vars
		var opt = $.extend(def, option), div = $(this), ul = $("ul", div), li = $("li", ul), width = (li.outerWidth(true)) * opt.show, height = li.outerHeight(true);
		//set div css
		this.css({
			'height' : height,
			'width' : width,
			'overflow' : 'hidden',
			position : "relative",
			"z-index" : "2",
			left : "0px"
		});
		//set ul css
		ul.css({
			position : "relative",
			"list-style-type" : "none",
			"z-index" : "1",
			margin : "0",
			padding : "0",
			'height' : height,
			'width' : (li.outerWidth(true)) * li.length,
			right : "0px"
		});
		var curr = 0, interval;
		//next slide
		if (opt.btnext) {
			$(opt.btnext).click(function() {
				go(curr + opt.slide);
				if (opt.auto) {
					clearInterval(interval);
					auto();
				}
			});
		}
		//prev slide
		if (opt.btnprev) {
			$(opt.btnprev).addClass(opt.disable_class);
			$(opt.btnprev).click(function() {
				go(curr - opt.slide);
				if (opt.auto) {
					clearInterval(interval);
					auto();
				}
			});
		}
		//auto
		if (opt.auto) {
			auto();
		}
		function auto() {
			var last = li.length - opt.show;
			interval = setInterval(function() {
				if (curr == last) {
					ul.animate({
						right : '0px'
					}, opt.speed);
					curr = 0;
					if (opt.btnext)
						$(opt.btnext).removeClass(opt.disable_class);
					if (opt.btnprev)
						$(opt.btnprev).addClass(opt.disable_class);
				} else {
					go(curr + opt.slide);
				}
			}, opt.auto_time);
		}

		//go to slide
		function go(x) {

			//go prev slide
			if (x < curr) {
				if (curr < opt.slide) {
					var remaind = curr % opt.slide;
					if (remaind == 0)
						remaind = opt.slide;
				} else {
					var remaind = opt.slide;
				}
				if (curr - remaind == 0)
					if (opt.btnprev)
						$(opt.btnprev).addClass(opt.disable_class);
				if (curr != 0) {
					if (opt.btnext)
						$(opt.btnext).removeClass(opt.disable_class);
					var right = li.outerWidth(true);
					right = right * remaind;
					right = parseInt(ul.css('right')) - right + "px";
					ul.animate({
						right : right
					}, opt.speed);
					curr = curr - remaind;
				}
			} else {
				if (li.length - opt.show - curr < opt.slide) {
					var remaind = (li.length - opt.show - curr) % opt.slide;
					if (remaind == 0)
						remaind = opt.slide;
				} else {
					var remaind = opt.slide;
				}
				//go next slide
				var last = li.length - opt.show;
				if (curr + remaind == last)
					if (opt.btnext)
						$(opt.btnext).addClass(opt.disable_class);
				if (curr != last) {
					if (opt.btnprev)
						$(opt.btnprev).removeClass(opt.disable_class);
					var right = li.outerWidth(true);
					right = right * remaind;
					right = parseInt(ul.css('right')) + right + "px";
					ul.animate({
						right : right
					}, opt.speed);
					curr = curr + remaind;
				}

			}
		}

	};

})(jQuery);