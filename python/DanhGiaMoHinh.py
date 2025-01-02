import pandas as pd
from sklearn.preprocessing import StandardScaler

# Đọc dữ liệu thực tế từ file CSV
real_data = pd.read_csv('D:\python\VN_housing_dataset_Đã xử lý.csv' , encoding='utf-8')

# Chọn các đặc trưng phù hợp với tập dữ liệu huấn luyện
features = ['Quận/Huyện' , 'Phường/Xã' , 'Loại hình nhà ở' , 'Giấy tờ pháp lý' , 'Số tầng' , 'Số phòng ngủ (phòng)' , 'Dài (m)', 'Rộng (m)']  # Đặt tên các đặc trưng phù hợp với dữ liệu thực tế
X_real = real_data[features]

# Xử lý dữ liệu thực tế
# Mã hóa biến phân loại (nếu có), chuẩn hóa (nếu cần), v.v.
# Giả sử bạn đã chuẩn hóa tập huấn luyện với StandardScaler
scaler = StandardScaler()
X_real = scaler.transform(X_real)  # Chuẩn hóa dữ liệu thực tế

# Dự đoán trên dữ liệu thực tế với mô hình đã được huấn luyện
y_real_pred = model.predict(X_real)

# Lưu kết quả dự đoán
real_data['Predicted_Values'] = y_real_pred

# In kết quả dự đoán
print(real_data[['Quận/Huyện' , 'Phường/Xã' , 'Loại hình nhà ở' , 'Giấy tờ pháp lý' , 'Số tầng' , 'Số phòng ngủ (phòng)' , 'Dài (m)', 'Rộng (m)', 'Predicted_Values']])
