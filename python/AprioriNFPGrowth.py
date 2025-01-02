import pandas as pd
from sklearn.model_selection import train_test_split, GridSearchCV
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score, mean_absolute_percentage_error

# Đọc dữ liệu từ file CSV
data = pd.read_csv('D:\python\VN_housing_dataset_Đã xử lý.csv', encoding='utf-8')

# Chọn các đặc trưng và nhãn
features = ['Quận/Huyện', 'Phường/Xã', 'Loại hình nhà ở', 'Giấy tờ pháp lý', 'Số tầng', 'Số phòng ngủ (phòng)', 'Dài (m)', 'Rộng (m)']
label = 'Giá/m2 (triệu/m²)'
X = data[features]
y = data[label]

# Mã hóa one-hot các biến phân loại trong tập đặc trưng
X_encoded = pd.get_dummies(X)

# Chia dữ liệu thành tập huấn luyện và tập kiểm tra
X_train, X_test, y_train, y_test = train_test_split(X_encoded, y, test_size=0.2, random_state=42)

# Khởi tạo mô hình Random Forest Regressor
rf = RandomForestRegressor(random_state=42)

# Đặt các tham số cần điều chỉnh và các giá trị để thử nghiệm
param_grid = {
    'n_estimators': [100 , 200],
    'max_features': ['sqrt', 'log2' , None],
    'max_depth': [ 5, 10, 15 , 20 , None ]
}

# Sử dụng GridSearchCV để tìm tham số tối ưu
grid_search = GridSearchCV(rf, param_grid, cv=5, scoring='neg_mean_squared_error')
grid_search.fit(X_train, y_train)

# Lấy mô hình tốt nhất
best_model = grid_search.best_estimator_

# Dự đoán trên tập kiểm tra
y_pred = best_model.predict(X_test)

# Tính các chỉ số đánh giá
mse = mean_squared_error(y_test, y_pred)
mae = mean_absolute_error(y_test, y_pred)
mape = mean_absolute_percentage_error(y_test, y_pred)
r2 = r2_score(y_test, y_pred)

# In ra các chỉ số đánh giá
print(f"Mean Squared Error (MSE): {mse:.2f}")
print(f"Mean Absolute Error (MAE): {mae:.2f}")
print(f"Mean Absolute Percentage Error (MAPE): {mape:.2f}")
print(f"R-squared (R^2): {r2:.2f}")

# In ra các tham số tối ưu
print(f'Best parameters: {grid_search.best_params_}')
real_prices = data['Giá/m2 (triệu/m²)']

# Dự đoán giá bất động sản trên dữ liệu thực tế sử dụng best_model
predicted_prices = best_model.predict(X_encoded)

# Tính toán các chỉ số đánh giá
mse = mean_squared_error(real_prices, predicted_prices)
mae = mean_absolute_error(real_prices, predicted_prices)
mape = mean_absolute_percentage_error(real_prices, predicted_prices)
r2 = r2_score(real_prices, predicted_prices)

# In ra các chỉ số đánh giá
print(f"Mean Squared Error (MSE): {mse:.2f}")
print(f"Mean Absolute Error (MAE): {mae:.2f}")
print(f"Mean Absolute Percentage Error (MAPE): {mape:.2f}")
print(f"R-squared (R^2): {r2:.2f}")
