
    function addToCart(element) {
    var id = element.getAttribute('data-id');
    var name = element.getAttribute('data-name');
    var price = element.getAttribute('data-price');
    var image = element.getAttribute('data-image');

    // Gửi yêu cầu POST đến server để thêm món ăn vào giỏ hàng
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'Order.aspx/AddToCart', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
        // Cập nhật giỏ hàng trên trang
        location.reload(); // Tải lại trang để cập nhật giỏ hàng
        }
    };
    xhr.send(JSON.stringify({id: id, name: name, price: price, image: image }));
}

