
$(document).ready(function () {
    $('#btnContinue').off('click').on('click', function () {
        window.location.href = "/";       
    });
    $('#btnPayment').off('click').on('click', function () {
        window.location.href = "/thanh-toan";
    });

    $('#btnUpdate').off('click').on('click', function () {
        var list = $('.txtQuantity');
        var cartList = [];
        $.each(list, function (i, item) {
            cartList.push({
                Quantity: $(item).val(),
                SACH: {
                    "MASACH": $(item).data('id')
                }
            });
        });

        $.ajax({
            url: '/CartItem/Update',
            data: { cartModel: JSON.stringify(cartList) },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/CartItem";
                }
            }
        })
    });

    $('#btnDeleteAll').off('click').on('click', function () {

        $.ajax({
            url: '/CartItem/DeleteAll',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/CartItem";
                }
            }
        })
    });
    $('.btn-delete').off('click').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/CartItem/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/CartItem";
                }
            }
        })
    });
});
