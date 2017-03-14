using System;
using UnityEngine;

public class Dimensions{

	private int width;
	private int height;
	private int depth;

	public Dimensions(int width, int height, int depth)
	{
		Width = width;
		Height = height;
		Depth = depth;
	}

	public int Width
	{
		get { return width; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Width", "Width can't be negative");
			}
			width = value;
		}
	}

	public int Height
	{
		get { return height; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Height", "Height can't be negative");
			}
			height = value;
		}
	}

	public int Depth
	{
		get { return depth; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Depth", "Depth can't be negative");
			}
			depth = value;
		}
	}

}


