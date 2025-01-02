function checklogin() {
    var user = document.getElementById('username').value.trim();
    var pass = document.getElementById('password').value.trim();
    var verificationCode = document.getElementById('verificationCode').value.trim();
    var error = document.getElementById('error');
    var errorMessages = []; // Mảng để lưu các thông báo lỗi

    // Xóa các thông báo lỗi trước khi kiểm tra
    error.innerHTML = "";

    console.log("User:", user);
    console.log("Pass:", pass);
    console.log("Verification Code:", verificationCode);

    // Kiểm tra trường username
    if (user === "") {
        errorMessages.push("Tên người dùng không được bỏ trống.");
    }

    // Kiểm tra trường password
    if (pass === "") {
        errorMessages.push("Mật khẩu không được bỏ trống.");
    } else if (pass.length < 5) {
        errorMessages.push("Mật khẩu phải có ít nhất 5 ký tự.");
    }

    // Kiểm tra mã xác nhận
    var regex = /^[A-Z]{3}\d{2}$/;
    if (!regex.test(verificationCode)) {
        errorMessages.push("Mã xác nhận không hợp lệ. Vui lòng nhập 3 chữ cái in hoa và 2 chữ số.");
    }

    console.log("Error Messages:", errorMessages);

    // Hiển thị tất cả các thông báo lỗi nếu có
    if (errorMessages.length > 0) {
        error.innerHTML = errorMessages.join("<br>");
        return false; // Ngăn gửi form
    }

    return true; // Đã kiểm tra và không có lỗi
}
