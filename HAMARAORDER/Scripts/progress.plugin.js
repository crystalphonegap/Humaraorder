
;(function($){

	$.extend({
		stepprogress : function( opt ){

			var def = {
				step : 4,
    			line_w : 300,
			}

			var setting = $.extend({},def,opt);

			function stepprogress(){

				this.index_w = setting.line_w / (setting.step - 1);
				this.index = 0;
				this.init();
			}

			stepprogress.prototype = {
				constructor : stepprogress,
				init : function(){
					this.render();
					this.changeLength();
				},

				render : function(){
					$(`<div class='wrap'>
					        <div class="line"></div>
					        <p class="step"></p>
					    </div> `).appendTo(document.body);

					$(".line").css({
						width : setting.line_w,
					});
					for(var i = 1;i <= setting.step;i++){
						$(`<span class='flag'>${i}</span>`).css({
							left : (i - 1) * this.index_w - 10,
						}).appendTo(".wrap");
					}
				},
			}
			new stepprogress();
		}
	});
})(jQuery)
