﻿using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class ServiceKind {
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }
    [AllowNull]
    public List<Tax> Taxes { get; set; }
}