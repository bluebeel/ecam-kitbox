import sqlite3
import psycopg2

conn = sqlite3.connect('kitbox.db')
#conn = psycopg2.connect("dbname='kitbox' user='bluebeel' host='localhost'")

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