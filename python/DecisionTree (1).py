import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn import tree
from sklearn.preprocessing import LabelEncoder
from sklearn.metrics import accuracy_score
import matplotlib.pyplot as plt
import joblib
from sklearn.tree import export_text

#Đậu Tiến Đạt --- 21A100100073 
# Đọc dữ liệu từ file Excel
data = pd.read_excel('D:\Khai pha du lieu\KFoldCrossValidation\PlayGolf.xlsx')
#============================================================================
#Bài 2
# Chia dữ liệu thành features và target
# X = data.drop(columns=['Play Golf'])  # bỏ label này còn lại là features
# y = data['Play Golf']  # target/label

# # Chuyển đổi biến phân loại thành dạng số nếu cần
# le = LabelEncoder()
# X['Outlook'] = le.fit_transform(X['Outlook'])
# X['Temp'] = le.fit_transform(X['Temp'])
# X['Humidity'] = le.fit_transform(X['Humidity'])
# X['Windy'] = le.fit_transform(X['Windy'])
# y = le.fit_transform(y)

# X_train, X_test, y_train, y_test= train_test_split(X, y, test_size=0.2, random_state=42)
# clf = DecisionTreeClassifier()
# clf.fit(X_train, y_train)
# y_pred = clf.predict(X_test)

# accuracy = accuracy_score(y_test, y_pred)
# print("Độ chính xác:", accuracy)

# plt.figure(figsize=(10,10))
# tree.plot_tree(clf,filled=True,feature_names=X.columns)
# plt.show()
#===============================================================

#================================================================
#BÀI 2.1
# #Tạo file
model_filename="DecisionTree.jolib"

# Lưu model vào file DecisionTree.jolib
#joblib.dump(clf, model_filename)

# Load lại model từ file
loaded_model = joblib.load(model_filename)
# tree_rules = export_text(loaded_model, feature_names=list(X.columns))
# print(tree_rules)

#Tạo list cho bản ghi mới 
new_record={}
for feature in data.columns:
    if feature != 'Play Golf': #Trừ nhãn
        giaTriMoi = input(f"Nhập giá trị cho '{feature}':") #Nhập các feature
        new_record[feature]=giaTriMoi #Lưu vào list đã tạo trước đó

#In cây quyết định dựa trên bản ghi mới được nhập vào từ bàn phím 
tree_rules = export_text(loaded_model, feature_names=list(new_record))
print(tree_rules)
