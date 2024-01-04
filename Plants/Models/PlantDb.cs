using System;
using System.Collections.Generic;

namespace plants.Models;

//DB class EF getters/setters
public partial class PlantDb
{
    public int Id { get; set; }

    public string? ScientificName { get; set; }

    public string? TherapeuticEffects { get; set; }

    public string? References { get; set; }
}
