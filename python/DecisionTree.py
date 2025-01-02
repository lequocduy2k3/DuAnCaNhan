import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeRegressor
from sklearn.preprocessing import LabelEncoder
from sklearn.preprocessing import OneHotEncoder
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score,mean_absolute_percentage_error , precision_score


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

# Tạo mô hình Decision Tree Regression
model = DecisionTreeRegressor(random_state=42)
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