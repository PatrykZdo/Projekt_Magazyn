using Microsoft.AspNetCore.Components.Forms;

namespace CarScrapyardWarehouse.Client.Models;

public class Car
{

    public Car()
    {
		Images = new();
        YearOfProduction = 0;
        HorsePower = 0;
    }

    public string Vin { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Fuel { get; set; }
    public string CarBodyStyle { get; set; }
    public string Transmission { get; set; }
    public string TypeOfPowertrainSystem { get; set; }
    public string EngineCode { get; set; }
    public string EngineCapacity { get; set; }
    public string TransmissionCode { get; set; }
    public string PaintCode { get; set; }
    public string AntiLockSystem { get; set; }
    public string AirCondition { get; set; }
    public string LaneAssist { get; set; }
    public string ParkingSensor { get; set; }
    public string CruiceControl { get; set; }
    public string ElectricMirrors { get; set; }
    public string Warning { get; set; }

    public int YearOfProduction { get; set; }
    public int HorsePower { get; set; }

    public List<IBrowserFile> Images { get; set; }



}
