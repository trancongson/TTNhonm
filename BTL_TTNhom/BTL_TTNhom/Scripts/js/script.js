$(document).ready(function() {
    $("#owl-carou").owlCarousel({
        navigation : true,
        navigationText: ["<i class='fas fa-chevron-left'></i>","<i class='fas fa-chevron-right'></i>"],
        autoPlay: 1500,
        items : 3,
        itemsDesktop : [1199,3],
        itemsDesktopSmall : [979,3]
    });  
});

$(document).ready(function() {
    $("#owl-carous").owlCarousel({
        navigation : true,
        navigationText: ["<i class='fas fa-chevron-left'></i>","<i class='fas fa-chevron-right'></i>"],
        autoPlay: 1500,
        items : 6,
        itemsDesktop : [1199,6],
        itemsDesktopSmall : [979,4],
        itemsMobile : [479,2],
    });  
});


//Go-top
$(document).ready(function(){ 
    $(window).scroll(function(){ 
        if ($(this).scrollTop() > 100) { 
            $('#gotop').fadeIn(); 
        } else { 
            $('#gotop').fadeOut(); 
        } 
    }); 
    $('#gotop').click(function(){ 
        $("html, body").animate({ scrollTop: 0 }, 500); 
        return false; 
    }); 
});