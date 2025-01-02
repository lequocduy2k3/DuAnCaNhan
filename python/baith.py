import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.metrics import accuracy_score, classification_report
from sklearn.preprocessing import LabelEncoder

# Đọc dữ liệu từ file Excel
data = pd.read_excel('D:\python\PlayGolf.xlsx')

# Xác định features và target
X = data.drop(columns=['Windy'])  # Loại bỏ cột target từ dataframe để lấy features
y = data['Windy']  # Lấy cột target

# Chuyển đổi các cột có giá trị chuỗi thành các giá trị số
label_encoder = LabelEncoder()
for col in X.columns:
    if X[col].dtype == 'object':
        X[col] = label_encoder.fit_transform(X[col])

# Chia dữ liệu thành tập huấn luyện và tập kiểm tra
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Khởi tạo mô hình Decision Tree
model = DecisionTreeClassifier()

# Huấn luyện mô hình
model.fit(X_train, y_train)

# Dự đoán trên tập kiểm tra
y_pred = model.predict(X_test)

# Đánh giá mô hình
accuracy = accuracy_score(y_test, y_pred)
print("Accuracy:", accuracy)

# Báo cáo đánh giá
print("Classification Report:")
print(classification_report(y_test, y_pred))