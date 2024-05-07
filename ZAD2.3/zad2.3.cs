using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

public class SystemStats
{
    private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    private PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

    public float GetCpuLoad() => cpuCounter.NextValue();
    public float GetRamAvailability() => ramCounter.NextValue();
}

public class EventLogger
{
    private EventLog log;

    public EventLogger(string source)
    {
        if (!EventLog.SourceExists(source))
            EventLog.CreateEventSource(source, "Application");

        log = new EventLog("Application", Environment.MachineName, source);
    }

    public void Log(string message, EventLogEntryType type) => log.WriteEntry(message, type);
}

[DataContract]
public class Settings
{
    [DataMember]
    public string FilePath { get; set; } = "log.txt";
    [DataMember]
    public string SourceName { get; set; } = "SystemMonitorApp";
}

public static class ConfigManager
{
    private static string configPath = "config.json";

    public static Settings LoadConfig()
    {
        if (File.Exists(configPath))
        {
            using (var fs = new FileStream(configPath, FileMode.Open))
                return new DataContractJsonSerializer(typeof(Settings)).ReadObject(fs) as Settings;
        }
        var settings = new Settings();
        SaveConfig(settings);
        return settings;
    }

    public static void SaveConfig(Settings settings)
    {
        using (var fs = new FileStream(configPath, FileMode.Create))
            new DataContractJsonSerializer(typeof(Settings)).WriteObject(fs, settings);
    }
}

class Program
{
    static void Main()
    {
        var settings = ConfigManager.LoadConfig();
        var logger = new EventLogger(settings.SourceName);
        var monitor = new SystemStats();

        while (true)
        {
            var cpuLoad = monitor.GetCpuLoad();
            var ramAvailable = monitor.GetRamAvailability();

            Log($"CPU Load: {cpuLoad}%\tRAM Available: {ramAvailable} MB", settings.FilePath);
            
            if (cpuLoad > 90)
                logger.Log($"High CPU load: {cpuLoad}%", EventLogEntryType.Warning);
            if (ramAvailable < 100)
                logger.Log($"Low RAM available: {ramAvailable} MB", EventLogEntryType.Error);

            System.Threading.Thread.Sleep(5000);
        }
    }

    static void Log(string data, string path)
    {
        using (var writer = new StreamWriter(path, true))
            writer.WriteLine($"{DateTime.Now}: {data}");
    }
}
