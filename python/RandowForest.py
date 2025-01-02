import pandas as pd
from sklearn.model_selection import train_test_split , GridSearchCV
from sklearn.ensemble import RandomForestRegressor
from sklearn.preprocessing import LabelEncoder
from sklearn.preprocessing import OneHotEncoder
from sklearn.datasets import load_iris
from sklearn.metrics import accuracy_score
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score,mean_absolute_percentage_error
import matplotlib.pyplot as plt
import seaborn as sns


# Đọc dữ liệu từ file Excel
data = pd.read_csv('D:\python\VN_housing_dataset_Đã xử lý.csv' , encoding='utf-8')
print(data)

# chọn các đặc trưng và nhãn
features = ['Quận/Huyện' , 'Phường/Xã' , 'Loại hình nhà ở' , 'Giấy tờ pháp lý' , 'Số tầng' , 'Số phòng ngủ (phòng)' , 'Dài (m)', 'Rộng (m)']
laybel = 'Giá/m2 (triệu/m²)'
X = data[features]
y = data[laybel]

#Mã hóa one-hot các biến phân loại trong tập đặc trưng
X_encoded = pd.get_dummies(X)
print(X_encoded.head())
# Chia dữ liệu thành tập huấn luyện và tập kiểm tra
X_train, X_test, y_train, y_test = train_test_split(X_encoded, y, test_size=0.2, random_state=42)

# Tạo mô hình Random Forest Regression
model = RandomForestRegressor(n_estimators=100,random_state=42)
model.fit(X_train, y_train)

# Dự đoán trên tập kiểm tra
y_pred = model.predict(X_test)

# Tính các chỉ số đánh giá
mse = mean_squared_error(y_test, y_pred , squared=False)
mae = mean_absolute_error(y_test, y_pred)
mape = mean_absolute_percentage_error(y_test,y_pred)
r2 = r2_score(y_test, y_pred)

# In ra các chỉ số đánh giá
print(f"Mean Squared Error: {mse:.2f}")
print(f"Mean Absolute Error: {mae:.2f}")
print(f"Mean Absolute Percentage Error:{mape:.2f}")
print(f"R-squared: {r2:.2f}")

# Dự đoán trên dữ liệu thực tế:

# Đọc dữ liệu thực tế từ file CSV
real_data = pd.read_csv('D:\python\VN_housing_dataset_Đã xử lý.csv', encoding='utf-8')

# Chọn các đặc trưng từ dữ liệu thực tế
X_real = real_data[features]

# Mã hóa one-hot các biến phân loại trong tập đặc trưng
X_real_encoded = pd.get_dummies(X_real)

# Đảm bảo các cột trong dữ liệu thực tế đã mã hóa phù hợp với tập huấn luyện
X_real_encoded = X_real_encoded.reindex(columns=X_encoded.columns, fill_value=0)

# Dự đoán trên dữ liệu thực tế
y_real_pred = model.predict(X_real_encoded)

# Lưu kết quả dự đoán vào dữ liệu thực tế
real_data['Predicted_Values'] = y_real_pred

# In kết quả dự đoán
print(real_data[['Quận/Huyện', 'Phường/Xã', 'Loại hình nhà ở', 'Giấy tờ pháp lý','Số tầng' , 'Số phòng ngủ (phòng)' , 'Dài (m)', 'Rộng (m)' , 'Predicted_Values']])

# Giá trị thực tế từ dữ liệu thực tế
y_real = real_data['Giá/m2 (triệu/m²)']

# Giá trị dự đoán từ mô hình
y_real_pred = real_data['Predicted_Values']

# Tính các chỉ số đánh giá
mse = mean_squared_error(y_real, y_real_pred)
mae = mean_absolute_error(y_real, y_real_pred)
mape = mean_absolute_percentage_error(y_real, y_real_pred) 
r2 = r2_score(y_real, y_real_pred)

# In ra các chỉ số đánh giá
print(f"Mean Squared Error (MSE): {mse:.2f}")
print(f"Mean Absolute Error (MAE): {mae:.2f}")
print(f"Mean Absolute Percentage Error (MAPE): {mape:.2f}")
print(f"R-squared (R2): {r2:.2f}")
# Phân tích sai số
# Tính toán các giá trị sai số (residuals)
residuals = y_test - y_pred

# Vẽ biểu đồ phân bố của sai số
plt.figure(figsize=(8, 6))
sns.histplot(residuals, kde=True)
plt.title('Phân bố của sai số (residuals)')
plt.xlabel('Sai số')
plt.ylabel('Tần suất')
plt.show()

# Vẽ biểu đồ phân tán của sai số so với giá trị thực tế
plt.figure(figsize=(8, 6))
plt.scatter(y_test, residuals)
plt.title('Sai số so với giá trị thực tế')
plt.xlabel('Giá trị thực tế')
plt.ylabel('Sai số')
plt.axhline(0, color='red', linestyle='--')  # Đường ngang cho thấy sai số bằng 0
plt.show()