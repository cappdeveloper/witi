using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


public enum UserRoles : int
{
    [Description("Admin")]
    Admin = 1,
    [Description("Admin")]
    Users = 2
}

public enum GenericStatuses : int
{
    [Description("Active")]
    Active = 1,
    [Description("Active")]
    InActive = 2,
    [Description("Active")]
    Pending = 3,
    [Description("Active")]
    Approved = 4
}

public enum FuelType : int
{
    [Description("Gas")]
    Gas = 1,
    [Description("Diesel")]
    Diesel = 2,
    [Description("Hybrid")]
    Hybrid = 3
}

public enum Tires : int
{
    [Description("P-Series")]
    PSeries = 1,
    [Description("LT-Series")]
    LTSeries = 2,
    [Description("Winter")]
    Winter = 3,
    [Description("Mud")]
    Mud = 4
}


