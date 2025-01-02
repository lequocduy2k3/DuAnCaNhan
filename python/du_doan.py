import tkinter as tk
import joblib
import pandas as pd

# Load mô hình đã được huấn luyện từ tệp pkl
def load_model():
    clf = joblib.load("price_prediction_model.pkl")
    return clf

# Tải lại mô hình đã được huấn luyện
clf = load_model()

# Dự đoán giá nhà khi nhấn nút
def predict():
    # Lấy dữ liệu đầu vào từ các ô nhập liệu
    quan = entries[0].get()
    phuong = entries[1].get()
    loai_nha = entries[2].get()
    giay_to = entries[3].get()
    so_tang = float(entries[4].get())
    so_phong = float(entries[5].get())
    chieu_dai = float(entries[6].get())
    chieu_rong = float(entries[7].get())

    # Tạo một DataFrame từ dữ liệu đầu vào
    data = pd.DataFrame({
        'Quận/Huyện': [quan],
        'Phường/Xã': [phuong],
        'Loại hình nhà ở': [loai_nha],
        'Giấy tờ pháp lý': [giay_to],
        'Số tầng': [so_tang],
        'Số phòng ngủ (phòng)': [so_phong],
        'Dài (m)': [chieu_dai],
        'Rộng (m)': [chieu_rong]
    })

    # Lấy danh sách các feature names trong mô hình
    feature_names = clf.feature_names_in_

    # Chuyển các biến phân loại thành dạng one-hot encoding
    data = pd.get_dummies(data)

    all_features = feature_names.tolist()
    data = data.reindex(columns=all_features, fill_value=False)

    # Dự đoán giá nhà từ dữ liệu đầu vào
    predicted_price = clf.predict(data)[0]

    # Hiển thị kết quả dự đoán
    result_label.config(text=f"Dự đoán giá nhà: {predicted_price:.2f} triệu đồng/m²")

# Tạo giao diện
root = tk.Tk()
root.title("Dự đoán Giá Nhà")

# Tạo Frame chứa các widget
frame = tk.Frame(root)
frame.pack(expand=True, fill='both')

# Tạo các nhãn cho các ô nhập liệu
titles = ['Quận/Huyện', 'Phường/Xã', 'Loại nhà', 'Giấy tờ pháp lý', 'Số tầng', 'Số phòng', 'Chiều dài', 'Chiều rộng']
entries = []

for i, title in enumerate(titles):
    # Tạo nhãn
    label = tk.Label(frame, text=f"{title}:")
    label.grid(row=i, column=0, padx=5, pady=5, sticky='w')

    # Tạo ô nhập liệu
    entry = tk.Entry(frame)
    entry.grid(row=i, column=1, padx=5, pady=5, sticky='w')
    entries.append(entry)

# Tải lại mô hình đã được huấn luyện
clf = load_model()

# Nút "Dự đoán"
predict_button = tk.Button(frame, text="Dự đoán", command=predict)
predict_button.grid(row=len(titles)+1, columnspan=2, padx=5, pady=5)

# Kết quả dự đoán
result_label = tk.Label(frame, text="", justify='left')
result_label.grid(row=len(titles)+2, columnspan=2, padx=5, pady=5, sticky='w')

root.mainloop()
