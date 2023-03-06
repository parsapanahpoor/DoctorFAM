$("#register-btn").click(function() {
    $("#login").slideUp()
    $("#register").fadeIn()
})
$("#login-btn").click(function() {
    $("#register").slideUp()
    $("#login").slideDown()
})