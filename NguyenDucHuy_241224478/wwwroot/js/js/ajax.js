
$(function () {
    $(document).on('click', '.js-theloai', function (e) {
        e.preventDefault();

        var $a = $(this);

        $.get($a.data('url'))
            .done(function (html) {
                $('#main-content').html(html);

                $('.menu li').removeClass('active');
                $a.closest('li').addClass('active');
            })
            .fail(function () {
                alert('Không tải được dữ liệu');
            });
    });
});
