using System;
using System.IO;
using FluentResults;
using Newtonsoft.Json;
using NvidiaDisplayController.Objects;
using NvidiaDisplayController.Objects.Entities;

namespace NvidiaDisplayController.Global.Controllers;

public class DataController
{
    private static readonly string _directory = AppContext.BaseDirectory;

    public string DataPath => Path.Combine(_directory, @"Data\Data.json");

    public void Write(Computer data)
    {
        var serializeObject = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });

        File.WriteAllText(DataPath, serializeObject);
    }

    public Result<Computer> Load()
    {
        if (!File.Exists(DataPath))
            return Result.Fail(new Error("Data file not found."));

        var json = File.ReadAllText(DataPath);

        if (string.IsNullOrWhiteSpace(json))
            return Result.Fail(new Error("Data file is empty."));

        var computer = JsonConvert.DeserializeObject<Computer>(json);
        return computer is null ? Result.Fail(new Error("Failed to deserialize data.")) : Result.Ok(computer);
    }
}