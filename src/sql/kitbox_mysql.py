import csv
import pymysql
from itertools import groupby

conn = pymysql.connect(host='127.0.0.1', port=3306, user='root', passwd='bsa190596', db='kitbox')
cursor = conn.cursor()

cursor.execute("""
CREATE TABLE IF NOT EXISTS provider(
     id INT PRIMARY KEY,
     name_society VARCHAR(255),
     name_shop VARCHAR(255),
     address VARCHAR(255),
     city VARCHAR(255)
)
""")
conn.commit()

cursor.execute("""
CREATE TABLE IF NOT EXISTS product(
	 reference VARCHAR(255),
     code VARCHAR(255) PRIMARY KEY UNIQUE,
     height INT,
     depth INT,
     width INT,
     color VARCHAR(255),
     stock INT,
     stock_min INT,
     price FLOAT,
     piece_per_bloc INT
)
""")
conn.commit()

cursor.execute("""
CREATE TABLE IF NOT EXISTS customer(
     id_customer INT PRIMARY KEY UNIQUE,
     name VARCHAR(255),
     address VARCHAR(255),
     phone VARCHAR(255),
     email VARCHAR(255),
     password VARCHAR(255)
)
""")
conn.commit()

cursor.execute("""
CREATE TABLE IF NOT EXISTS purchase(
      id INT PRIMARY KEY UNIQUE,
     date_order TIMESTAMP,
     id_customer INT,
     status ENUM('draft', 'deposit', 'paid', 'closed'),
     price FLOAT,
     FOREIGN KEY (id_customer)
     REFERENCES customer(id_customer)
)
""")
conn.commit()

cursor.execute("""
CREATE TABLE IF NOT EXISTS feature_provider(
	 id INT PRIMARY KEY,
     id_provider INT,
     code VARCHAR(255),
     time_provider INT,
     price_provider FLOAT,
     FOREIGN KEY (code)
     REFERENCES product(code),
     FOREIGN KEY (id_provider)
     REFERENCES provider(id)
)
""")
conn.commit()

cursor.execute("""
CREATE TABLE IF NOT EXISTS orderitem(
      id_order INT,
     nbr_bloc INT,
     code_product VARCHAR(255),
     type ENUM('left', 'right', 'top', 'bottom', 'back', 'front', 'inner'),
     quantity INT,
     unit_cost FLOAT,
     FOREIGN KEY (id_order) 
     REFERENCES purchase(id),
     FOREIGN KEY (code_product) 
     REFERENCES product(code)
)
""")
conn.commit()

cursor.execute("""
CREATE TABLE IF NOT EXISTS worker(
     id INT PRIMARY KEY UNIQUE,
     name VARCHAR(255),
     address VARCHAR(255),
     phone VARCHAR(255),
     email VARCHAR(255),
     password VARCHAR(255)
)
""")
conn.commit()

with open('kitbox.csv') as csvfile:
     spamreader = csv.reader(csvfile, delimiter=';')
     csv_doc = list(spamreader)[1:]
     csvfile.close()

query = "INSERT INTO product (reference, code, height, depth, width, color, stock, stock_min, price, piece_per_bloc) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s)"

insert = []
for row in csv_doc:
     insert.append((row[0], row[1], int(row[2]), int(row[3]), int(row[4]), row[5], int(row[6]), int(row[7]), float(row[8].replace(',', '.')), int(row[9])))

cursor.executemany(query, tuple(insert))
conn.commit()

with open('fournisseurs.txt', 'r') as f:
     doc = [word.strip() for word in f.readlines()]
     doc_filtered = list(filter(None, doc))
     final = [list(g) for k, g in groupby(doc_filtered, lambda x: '------' not in x and 'Fournisseur' not in x) if k]
     f.close()

query = "INSERT INTO provider (name_society, name_shop, address, city) VALUES (%s, %s, %s, %s)"
insert = []

for provider in final:
     insert.append((provider[0], provider[1], provider[2], provider[3]))

cursor.executemany(query, tuple(insert))
conn.commit()

query = "INSERT INTO feature_provider (id_provider, code, time_provider, price_provider) VALUES (%s, %s, %s, %s)"
insert = []

for row in csv_doc:
     insert.append((1, row[1], int(row[11]), float(row[10].replace(',', '.'))))
     insert.append((2, row[1], int(row[13]), float(row[12].replace(',', '.'))))

cursor.executemany(query, tuple(insert))
conn.commit()