import pandas as pd
import numpy as np

# Đọc file CSV vào DataFrame
df = pd.read_csv('D:\python\VN_housing_dataset (1).csv', encoding='utf-8')

# Xác định giá trị thiếu và thay thế bằng giá trị trung bình của các cột số
numeric_columns = df.select_dtypes(include=[np.number]).columns
df[numeric_columns] = df[numeric_columns].fillna(df[numeric_columns].mean())

# Loại bỏ giá trị NaN
df.dropna(inplace=True)

# Loại bỏ giá trị dư thừa trong từng ô
df = df.applymap(lambda x: x.strip() if isinstance(x, str) else x)

# Danh sách các cột cần xử lý
columns_to_clean = ["Số phòng ngủ", "Diện tích", "Dài", "Rộng", "Giá/m2"]

# Kiểm tra và xử lý từng cột trong danh sách
for column_to_clean in columns_to_clean:
    if column_to_clean in df.columns:
        # Loại bỏ đơn vị trong các ô của cột
        df[column_to_clean] = df[column_to_clean].replace(to_replace=r'[^0-9\.]', value='', regex=True)
    else:
        print(f"Cột '{column_to_clean}' không tồn tại trong DataFrame.")

# Kiểm tra dữ liệu sau khi làm sạch
print(df.head())


#Xóa cột diện tích
df.drop(columns=['Diện tích'], inplace=True)

#Kiểm tra dữ liệu sau khi xóa cột
print(df.head())

# Đường dẫn đến file CSV mới
output_file = 'VN_housing_dataset_cleaned.csv'

# Lưu DataFrame sang file CSV mới
df.to_csv(output_file, index=False, encoding='utf-8-sig')

print(f"Dữ liệu đã được làm sạch đã được lưu vào {output_file}.")