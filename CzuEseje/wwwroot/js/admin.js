let $window = $(window)
let windowWidth = $window.width()
// console.log(windowWidth)

$window.resize(function () {
    let newWindowWidth = $window.width()
    if (windowWidth !== newWindowWidth) {
        windowWidth = newWindowWidth;
    }
})

let $sidebar = $('#sidebar');
let $linkText = $('.link-text');
let $linkIcon = $('.link-icon')
let $sidebarLogo = $('.sidebar-logo')
let $sidebarCollapse = $('#sidebarCollapse');
$sidebarLogo.hide()

function offsetAdminNavbar() {
    let $adminHeader = $("#adminHeader");
    let headerHeight = $adminHeader.outerHeight()
    $('#adminNavbar').css("top", headerHeight + "px");
    if ($('#adminNavbar').length > 0) {
        $adminHeader.css("z-index", 103)
        $adminHeader.removeClass("dropshadow-default")
    }
}

function getWindowUrlPaths() {
    let oldLink = document.createElement('a');
    oldLink.href = document.referrer
    oldPath = oldLink.pathname.match(/[^?]+/g)[0] // Match everything up until '?' is found
    console.log(oldPath)

    let newLink = document.createElement('a');
    newLink.href = window.location.href
    newPath = newLink.pathname.match(/[^?]+/g)[0] // Match everything up until '?' is found
    console.log(newPath)

    return [oldPath, newPath]
}

function navigateBack() {
    let paths = getWindowUrlPaths()
    let oldPath = paths[0]
    let newPath = paths[1]
    window.history.go(-1)

    // if (oldPath !== newPath) {
    //     window.history.go(-1)
    // }
    // else {
    //     window.location.href = '/Ucet';
    // }
}

$('.admin-nav-back-arrow').click(function () {
    navigateBack()
})


$(document).ready(function () {
    offsetAdminNavbar()
    $('#sidebarCollapse').on('click', function () {

        $sidebar.toggleClass('active');
        if (windowWidth <= 768) {
            console.log("Hi")
            if ($sidebar.hasClass('active')) {

            }

        }
        else {
            if ($sidebar.hasClass('active')) {
                $linkText.hide()
                $linkIcon.addClass('mx-auto')
                $linkIcon.removeClass('col-2')
                $linkIcon.addClass('col-10')
                $sidebarLogo.show()
                $sidebarCollapse.html("Zobrazit")
            }
            else {
                $linkText.show()
                $linkIcon.removeClass('mx-auto')
                $linkIcon.removeClass('col-10')
                $linkIcon.addClass('col-2')
                $sidebarLogo.hide()
                $sidebarCollapse.html("Skrýt")
            }
        }
    });
});