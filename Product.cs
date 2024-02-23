using System;
using System.IO;

public class Product
{

	private int productID, rating;
	private float volume;
    private string productName,brandName, comment;
	private volumeType vType;

	//default constructor
    public Product(int ID, string name, string brand, int volumeTypeInt, float volume)
	{
		this.productID = ID;
		this.productName = name;
		this.brandName = brand;
		setVolumeType(volumeTypeInt);
		this.volume = volume;
		this.rating = 0;
		this.comment = "";
    }

	//returns data in a string format so it can be saved easily
	public string exportSaveData()
	{
		string saveData = "";
		saveData += Convert.ToString(this.productID) + ",";
		saveData += this.productName + ",";
		saveData += this.brandName + ",";
		saveData += Convert.ToString(getVolumeTypeAsInt()) + ",";
		saveData += Convert.ToString(this.volume) + ",";
		saveData += Convert.ToString(this.rating) + ",";
		saveData += this.comment;

		return saveData;
	}

	//Setters
	public void setProductID(int a) { this.productID = a; }
	public void setName(string a) { this.productName = a;}
	public void setBrandName(string a) { this.brandName = a;}
	//overloaded for ease of use later down the line
	public void setVolumeType(int a)
	{
		switch (a)
		{
			case 1:
				this.vType = volumeType.MASS;
				break;
			case 2:
				this.vType = volumeType.VOLUME;
				break;
			case 3:
				this.vType = volumeType.AMOUNT;
				break;
			default:
				//ig this shouldn't happen but I'll leave this in 'case I need it later
				break;
		}
    }
	public void setVolumeType(string a) 
	{
		if (a.ToUpper() == "MASS") { this.vType = volumeType.MASS; }
        else if (a.ToUpper() == "VOLUME") { this.vType = volumeType.VOLUME; }
        else if (a.ToUpper() == "AMOUNT") { this.vType = volumeType.AMOUNT; }


    }
    public void setVolume(float a) { this.volume = a; }
	public void setRating(int a) { this.rating = a; }
	public void setComment(string a) { this.comment = a; }

	//Getters
	public int getProductID() { return this.productID; }
	public string getName() { return this.productName; }
	public string getBrandName() { return this.brandName; }
	public volumeType getVolumeType() { return this.vType; }
	//converts volume type to string and returns it
	public string getVolumeTypeAsString()
	{
		string a = "";
		if (this.vType == volumeType.MASS) { a = "MASS"; }
        else if (this.vType == volumeType.VOLUME) { a = "VOLUME"; }
		else if (this.vType == volumeType.AMOUNT) { a = "AMOUNT"; }
        return a;
	}
    public int getVolumeTypeAsInt()
    {
        int a = 0;
        if (this.vType == volumeType.MASS) { a = 1; }
        else if (this.vType == volumeType.VOLUME) { a = 2; }
        else if (this.vType == volumeType.AMOUNT) { a = 3; }
        return a;
    }
    public float getVolume() { return this.volume; }
	public int getRating() { return this.rating; }
	public string getComment() { return this.comment; }

	//"Adders" (Gets value, adds user input and then overwrites)
	public void addComments(string a)
	{
		string b = getComment();
		b += " ";
		b += a;
		setComment(b);
	}
}
