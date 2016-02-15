$(function() {
 
	$("<select />").appendTo("#topnav");
	 
		// Creiamo un'opzione di default "Vai a..."
		$("<option />", {
		 "selected": "selected",
		 "value"   : "",
		 "text"    : "Go to..."
		}).appendTo("#topnav select");
	 
		// Valorizziamo gli elementi della tendina prendendo l'attributo
		// href dei link ed inserendolo nel value delle <option>
		$("#topnav a").each(function() {
		var el = $(this);
		$("<option />", {
		   "value"   : el.attr("href"),
		   "text"    : el.text()
		}).appendTo("#topnav select");
		});
	 
		// Per rendere funzionante la tendina, ogni volta che viene
		// cambiato il valore della select, effetuiamo un redirect
		// alla pagina interessata (value della option)
		$("#topnav select").change(function() {
		window.location = $(this).find("option:selected").val();
		});
	 


	// Twitter bxSlider callback
	$('#slider1').bxSlider({
		auto: true,
		autoControls: false,
		mode: 'vertical',
	});


		//click and show/hide footer panel	
		$(".footerslidingarrow").click(function(){
			// Toggle the bar up 
			$("#pre_footer").slideToggle();
		}); // end sub panel click function
});

// Start Nivoslider
$(window).load(function() {
        $('#slider').nivoSlider();
});