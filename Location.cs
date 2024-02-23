using System;

public class Location
{
	private string name;
	private retailerName retailer;
	private storeType locationType;
    private Dictionary<int,float> productList = new Dictionary<int,float>();

	public Location(string name, int storetype, int retailer)
	{
		this.name = name;
		setLocationType(storetype);
		setRetailer(retailer);
	}

	public string exportSaveData()
	{
		string saveData = "";
		saveData += this.name + ",";
		saveData += getRetailerNameAsString() + ",";
		saveData += getLocationTypeAsString() + ".";
		foreach (KeyValuePair<int, float> entry in productList)
		{
			saveData += Convert.ToString(entry.Key) + ",";
            saveData += Convert.ToString(entry.Value) + "\n";

        }
        return saveData;
	}

	//Setters
	public void setName(string a) { this.name = a; }
	//set storetype/retailer can be overloaded for flexibility
	public void setLocationType(int a)
	{
		switch (a)
		{
			case 1:
				this.locationType = storeType.CONVENIENCE;
				break;
            case 2:
                this.locationType = storeType.MEDIUM;
                break;
            case 3:
                this.locationType = storeType.SUPERMARKET;
                break;
			default:
				break;
        }
		return;
	}

	public void setLocationType(string a)
	{
		if (a.ToUpper() == "CONVENIENCE") { this.locationType = storeType.CONVENIENCE; }
        else if (a.ToUpper() == "MEDIUM") { this.locationType = storeType.MEDIUM; }
        else if (a.ToUpper() == "SUPERMARKET") { this.locationType = storeType.SUPERMARKET; }
		return;
    }
    public void setRetailer(int a)
	{
		switch (a)
		{
			case 1:
				this.retailer = retailerName.ASDA;
				break;
			case 2:
				this.retailer = retailerName.TESCO;
				break;
			case 3:
				this.retailer = retailerName.SAINSBURY;
				break;
			case 4:
				this.retailer = retailerName.MORRISON;
				break;
			case 5:
				this.retailer = retailerName.LIDL;
				break;
			case 6:
				this.retailer = retailerName.ALDI;
				break;
			case 7:
				this.retailer = retailerName.OTHER;
				break;
			default:
				//this shouldn't happen ideally
				break;
		}
		return;
	}
	public void setRetailer(string a)
	{
		//a.ToUpper converts input (a) to upper so it is case-insensitive
		if (a.ToUpper() == "ASDA") { this.retailer = retailerName.ASDA; }
        else if (a.ToUpper() == "TESCO") { this.retailer = retailerName.TESCO; }
        else if (a.ToUpper() == "SAINSBURY") { this.retailer = retailerName.SAINSBURY; }
        else if (a.ToUpper() == "MORRISON") { this.retailer = retailerName.MORRISON; }
        else if (a.ToUpper() == "LIDL") { this.retailer = retailerName.LIDL; }
        else if (a.ToUpper() == "ALDI") { this.retailer = retailerName.ALDI; }
        else if (a.ToUpper() == "OTHER") { this.retailer = retailerName.OTHER; }
		return;
    }

    //Getters
    public string getName() { return this.name; }

	public storeType getLocationType() { return this.locationType; }
	public string getLocationTypeAsString()
	{
		string a = "";
		if (this.locationType == storeType.CONVENIENCE) { a = "CONVENIENCE"; }
        else if (this.locationType == storeType.MEDIUM) { a = "MEDIUM"; }
        else if (this.locationType == storeType.SUPERMARKET) { a = "SUPERMARKET"; }
		return a;
    }
    public int getLocationTypeAsInt()
    {
        int a = 0;
        if (this.locationType == storeType.CONVENIENCE) { a = 1; }
        else if (this.locationType == storeType.MEDIUM) { a = 2; }
        else if (this.locationType == storeType.SUPERMARKET) { a = 3; }
        return a;
    }

    public retailerName getRetailerName() { return this.retailer; }
	public string getRetailerNameAsString()
	{
		string a = "";
		if (this.retailer == retailerName.ASDA) { a = "ASDA"; }
		else if (this.retailer == retailerName.TESCO) { a = "TESCO"; }
		else if (this.retailer == retailerName.SAINSBURY) { a = "SAINSBURY"; }
		else if (this.retailer == retailerName.MORRISON) { a = "MORRISON"; }
		else if (this.retailer == retailerName.LIDL) { a = "LIDL"; }
		else if (this.retailer == retailerName.ALDI) { a = "ALDI"; }
		else if (this.retailer == retailerName.OTHER) { a = "OTHER"; }
		return a;
	}
	public int getRetailerNameAsInt() 
	{
		int a = 0;
        if (this.retailer == retailerName.ASDA) { a = 1; }
        else if (this.retailer == retailerName.TESCO) { a = 2; }
        else if (this.retailer == retailerName.SAINSBURY) { a = 3; }
        else if (this.retailer == retailerName.MORRISON) { a = 4; }
        else if (this.retailer == retailerName.LIDL) { a = 5; }
        else if (this.retailer == retailerName.ALDI) { a = 6; }
        else if (this.retailer == retailerName.OTHER) { a = 7; }
		return a;
    }
}
