using System;
using System.Collections.Generic;

// Прототип
public abstract class MobilePhonePrototype
{
    public abstract MobilePhonePrototype Clone();
}

// Клас для конфігурації телефону
public class MobilePhone
{
    public string Model { get; set; }
    public string OperatingSystem { get; set; }
    public int CameraResolution { get; set; }
    public int BatteryCapacity { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Phone Model: {Model}");
        Console.WriteLine($"Operating System: {OperatingSystem}");
        Console.WriteLine($"Camera Resolution: {CameraResolution} MP");
        Console.WriteLine($"Battery Capacity: {BatteryCapacity} mAh");
    }
}

// Будівельник для створення телефонів
public interface IPhoneBuilder
{
    void BuildModel();
    void BuildOperatingSystem();
    void BuildCameraResolution();
    void BuildBatteryCapacity();
    MobilePhone GetPhone();
}

// Конкретний будівельник
public class HighEndPhoneBuilder : IPhoneBuilder
{
    private MobilePhone phone = new MobilePhone();

    public void BuildModel()
    {
        phone.Model = "High-End Phone";
    }

    public void BuildOperatingSystem()
    {
        phone.OperatingSystem = "Android";
    }

    public void BuildCameraResolution()
    {
        phone.CameraResolution = 48;
    }

    public void BuildBatteryCapacity()
    {
        phone.BatteryCapacity = 5000;
    }

    public MobilePhone GetPhone()
    {
        return phone;
    }
}

// Директор, який використовує будівельник для створення телефону
public class PhoneManufacturer
{
    private IPhoneBuilder phoneBuilder;

    public PhoneManufacturer(IPhoneBuilder builder)
    {
        phoneBuilder = builder;
    }

    public void ConstructPhone()
    {
        phoneBuilder.BuildModel();
        phoneBuilder.BuildOperatingSystem();
        phoneBuilder.BuildCameraResolution();
        phoneBuilder.BuildBatteryCapacity();
    }

    public MobilePhone GetPhone()
    {
        return phoneBuilder.GetPhone();
    }
}

class Program
{
    static void Main()
    {
        // Використання патерна "Будівник" для створення телефону
        IPhoneBuilder builder = new HighEndPhoneBuilder();
        PhoneManufacturer manufacturer = new PhoneManufacturer(builder);

        manufacturer.ConstructPhone();
        MobilePhone highEndPhone = manufacturer.GetPhone();

        Console.WriteLine("High-End Phone Configuration:");
        highEndPhone.DisplayInfo();
        Console.WriteLine();

        // Використання патерна "Прототип" для клонування телефону
        MobilePhonePrototype clonedPhone = highEndPhone.Clone() as MobilePhonePrototype;

        Console.WriteLine("Cloned Phone Configuration:");
        clonedPhone.DisplayInfo();

        Console.ReadLine();
    }
}
