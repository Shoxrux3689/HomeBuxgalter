﻿namespace HomeBuxgalterFront.Models.ProfitModels;

public class ProfitCategory
{
    public short Id { get; set; }
    public string Name { get 
        {
            return "Quyidagilardan tanlang";
        }
        set 
        {
            Name = value;
        }
    }
}
