$(function(){
    $('.code').on('click', function(e) {
        $('#liveToast').toast({ autohide: false }).toast('show');
        window.addEventListener('keydown', function (event) {
            if (event.key === 'Escape') {
                $('#liveToast').toast({ autohide: false }).toast('hide');
            }
        })
    });
});