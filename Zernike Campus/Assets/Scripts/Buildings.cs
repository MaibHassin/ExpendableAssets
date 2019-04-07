[System.Serializable]
public class Buildings
{
    public string code;
    public string name;
    public string location;
    public string sections;
    public Departments departments;
    public Facilities facilities;
}

[System.Serializable]
public class Departments
{
    public bool SABE;
    public bool SABK;
    public bool SAGZ;
    public bool SASS;
    public bool SAVK;
    public bool SAVP;
    public bool SCMI;
    public bool SIBK;
    public bool SIBS;
    public bool SIEN;
    public bool SIFE;
    public bool SIFM;
    public bool SILS;
    public bool SIMM;
    public bool SIRE;
    public bool SISP;
    public bool SITE;
    public bool SEPA;
}

[System.Serializable]
public class Facilities
{
    public bool cafetaria;
    public bool ATM;
    public bool parking_meter;
    public bool library;
    public bool sitting_space;
    public bool printers;
    public bool bookable_room;
    public bool coffee_machine;
    public bool vending_machine;
}

[System.Serializable]
public class Timings
{
    public string monday;
    public string tuesday;
    public string wednesday;
    public string thursday;
    public string friday;
    public string saturday;
    public string sunday;
}
