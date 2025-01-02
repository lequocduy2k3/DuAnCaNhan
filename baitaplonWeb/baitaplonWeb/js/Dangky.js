function checkLogup() {
    var user = document.getElementById("username").value.trim();
    var email = document.getElementById("email").value.trim();
    var pass = document.getElementById("password").value.trim();
    var repass = document.getElementById("confirm-password").value.trim();
    var error = document.getElementById('error');

    // Xóa thông báo lỗi cũ
    error.innerHTML = '';

    // Biến kiểm tra lỗi
    let isValid = true;

    // Kiểm tra trường username
    if (user === "") {
        error.innerHTML += "<p>Vui lòng nhập tên người dùng.</p>";
        isValid = false;
    }

    // Kiểm tra trường email
    if (email === "") {
        error.innerHTML += "<p>Vui lòng nhập email.</p>";
        isValid = false;
    } else if (!isValidEmail(email)) {
        error.innerHTML += "<p>Vui lòng nhập đúng định dạng email.</p>";
        isValid = false;
    }

    // Kiểm tra trường mật khẩu
    if (pass === "") {
        error.innerHTML += "<p>Vui lòng nhập mật khẩu.</p>";
        isValid = false;
    }

    // Kiểm tra trường xác nhận mật khẩu
    if (repass === "") {
        error.innerHTML += "<p>Vui lòng nhập xác nhận mật khẩu.</p>";
        isValid = false;
    } else if (pass !== repass) {
        error.innerHTML += "<p>Mật khẩu và xác nhận mật khẩu không giống nhau.</p>";
        isValid = false;
    }

    // Trả về kết quả kiểm tra
    return isValid;
}

// Hàm kiểm tra định dạng email
function isValidEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}
