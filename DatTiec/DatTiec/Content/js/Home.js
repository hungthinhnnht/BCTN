//SLIDE  ĐẦU TRANG
$('.slide_home').owlCarousel({
    loop: true,
    autoplay: true,
    autoplayTimeout: 3000,
    dot: false,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})

//SLIDE  Ý KIẾN KHÁCH HÀNG
$('.slide_ykkh').owlCarousel({
    loop: true,
    autoplay: true,
    autoplayTimeout: 3000,
    dot: false,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 5
        }
    }
})

document.addEventListener('DOMContentLoaded', function () {
    var lis = Array.prototype.slice.call(document.querySelectorAll('div.dv_item'));
    var lis_count = lis.length;
    var active_li_index = 0;

    setInterval(function () {
        var active_li = document.querySelector('div.dv_item.bounce-1');

        if (lis.indexOf(active_li) == lis_count - 1)
            active_li_index = 0;
        else
            active_li_index++;

        active_li.classList.remove('bounce-1');
        document.querySelectorAll('div.dv_item')[active_li_index].classList.add('bounce-1');
    }, 500);
}, false);



//SCROLL ADD CLASS MENU
$(window).scroll(function () {
    var scroll = $(window).scrollTop();

    if (scroll >= 10) {
        $(".ctn_menu").addClass("fix_menu");
    } else {
        $(".ctn_menu").removeClass("fix_menu");
    }
});
$(window).scroll(function () {
    var scroll = $(window).scrollTop();

    if (scroll >= 10) {
        $(".img-menu").addClass("fix_img");
    } else {
        $(".img-menu").removeClass("fix_img");
    }
});