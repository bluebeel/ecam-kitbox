using System;
using UnityEngine;

public class Provider {
		protected int id;
		private string nameSociety;
		private string nameShop;
		private string address;
		private string city;

		public Provider(string nameSociety, string nameShop, string address, string city)
		{
			this.Society = nameSociety;
			this.Shop = nameShop;
			this.Address = address;
			this.City = city;
		}

		public int Id
		{
			get { return this.id; }

			set { this.id = value; }
		}

		public string Society
		{
			get { return this.nameSociety; }

			set { this.nameSociety = value; }
		}

		public string Shop
		{
			get { return this.nameShop; }

			set { this.nameShop = value; }
		}

		public string Address
		{
			get { return this.address; }

			set { this.address = value; }
		}

		public string City
		{
			get { return this.city; }

			set { this.city = value; }
		}
	}

