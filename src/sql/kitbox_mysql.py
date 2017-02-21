import csv
import pymysql
from itertools import groupby
import sys

def Mysql(user, pwd, db, port=3306):
     conn = pymysql.connect(host='127.0.0.1', port=int(port), user=user, passwd=pwd, db=db, 
                       charset='utf8')
     cursor = conn.cursor()

     cursor.execute("""
     CREATE TABLE IF NOT EXISTS provider(
          id INT PRIMARY KEY AUTO_INCREMENT UNIQUE NOT NULL,
          name_society VARCHAR(255),
          name_shop VARCHAR(255),
          address VARCHAR(255),
          city VARCHAR(255)
     )
     """)

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

     cursor.execute("""
     CREATE TABLE IF NOT EXISTS customer(
          id_customer INT PRIMARY KEY  AUTO_INCREMENT UNIQUE NOT NULL,
          name VARCHAR(255),
          address VARCHAR(255),
          phone VARCHAR(255),
          email VARCHAR(255),
          password VARCHAR(255)
     )
     """)

     cursor.execute("""
     CREATE TABLE IF NOT EXISTS purchase(
           id INT PRIMARY KEY  AUTO_INCREMENT UNIQUE NOT NULL,
          date_order TIMESTAMP,
          id_customer INT,
          status ENUM('draft', 'deposit', 'paid', 'closed'),
          price FLOAT,
          FOREIGN KEY (id_customer)
          REFERENCES customer(id_customer)
     )
     """)

     cursor.execute("""
     CREATE TABLE IF NOT EXISTS feature_provider(
           id INT PRIMARY KEY  AUTO_INCREMENT UNIQUE NOT NULL,
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

     cursor.execute("""
     CREATE TABLE IF NOT EXISTS orderitem(
           id_order INT PRIMARY KEY AUTO_INCREMENT UNIQUE NOT NULL,
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

     cursor.execute("""
     CREATE TABLE IF NOT EXISTS worker(
          id INT PRIMARY KEY AUTO_INCREMENT UNIQUE NOT NULL,
          name VARCHAR(255),
          address VARCHAR(255),
          phone VARCHAR(255),
          email VARCHAR(255),
          password VARCHAR(255)
     )
     """)
     conn.commit()

     with open('kitbox.csv', 'r', encoding='utf-8') as csvfile:
          spamreader = csv.reader(csvfile, delimiter=';')
          csv_doc = list(spamreader)[1:]
          csvfile.close()

     query = "INSERT INTO product (reference, code, height, depth, width, color, stock, stock_min, price, piece_per_bloc) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s)"

     insert = []
     for row in csv_doc:
          insert.append((row[0], row[1], int(row[2]), int(row[3]), int(row[4]), row[5], int(row[6]), int(row[7]), float(row[8].replace(',', '.')), int(row[9])))

     cursor.executemany(query, tuple(insert))
     conn.commit()

     with open('fournisseurs.txt', 'r', encoding='utf-8') as f:
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

if __name__ == '__main__':

    if len(sys.argv) == 5:
        Mysql(sys.argv[1], sys.argv[2], sys.argv[3], int(sys.argv[4]))
        print("Database ready !")
    elif len(sys.argv) == 4:
        Mysql(sys.argv[1], sys.argv[2], sys.argv[3])
        print("Database ready !")
    else:
        print("Number of arguments invalid")